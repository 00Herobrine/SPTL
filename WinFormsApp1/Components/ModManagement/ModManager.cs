using HtmlAgilityPack;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SPTLauncher.Constructors;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using WinFormsApp1;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using System.Web;
using System.IO;
using System;
using System.Net.Http;
using System.Xml.Linq;

namespace SPTLauncher.Components.ModManagement
{
    public enum ModType { CLIENT, SERVER }
    public enum ORIGIN
    {
        [Description("github.com")]
        GITHUB,
        [Description("drive.google.com")]
        GOOGLE,
        [Description("dropbox.com")]
        DROPBOX,
        [Description("sp-tarkov.com")]
        SPT,
        DIRECT,
        INVALID
    }
    public class ModManager
    {
        public ModDownload curDownload = null;
        public static List<ModDownload> downloadableMods = new();
        public static List<Mod> mods = new();
        const string baseURL = "https://hub.sp-tarkov.com/files/";
        private static string xsrfToken = "";
        public static int disabledAmount = 0;

        public static void Initialize()
        {
            //LoadMods();
            WebRequestMods();
            WebRequestMods(2);
            //ModDownloader.Check();

        }

        private static string[] ignoredFiles = { "order.json", "spt" };
        public static void LoadMods()
        {
            disabledAmount = 0;
            mods = new();
            List<string> files = new();
            if (Directory.Exists(Paths.disabledModsPath))
            {
                files.AddRange(Directory.GetFiles(Paths.disabledModsPath));
                files.AddRange(Directory.GetDirectories(Paths.disabledModsPath));
            }
            if (Directory.Exists(Paths.modsFolder))
            {
                files.AddRange(Directory.GetFiles(Paths.modsFolder));
                files.AddRange(Directory.GetFiles(Paths.pluginsFolder));
            }
            if (Directory.Exists(Paths.pluginsFolder))
            {
                files.AddRange(Directory.GetDirectories(Paths.modsFolder));
                files.AddRange(Directory.GetDirectories(Paths.pluginsFolder));
            }
            int amount = files.Count;
            foreach (string file in files)
            {
                string fileName = file.Split('\\')[1];
                if (file.Contains(Paths.pluginsFolder + "\\aki-") || ignoredFiles.Contains(fileName.ToLower())) amount--;
                else
                {
                    Mod mod = new(file);
                    if (!mod.isEnabled()) disabledAmount++;
                    mods.Add(mod);
                }
            }
        }

        public static string FormatByteCount(long bytes)
        {
            string[] sizeSuffixes = { "B", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
            if (bytes == 0)
            {
                return "0" + sizeSuffixes[0];
            }

            int magnitude = (int)Math.Floor(Math.Log(bytes, 1024));
            double adjustedSize = bytes / Math.Pow(1024, magnitude);

            return string.Format("{0:0.##} {1}", adjustedSize, sizeSuffixes[magnitude]);
        }

        public static bool IsValidFileType(string input)
        {
            //foreach (string fileType in allowedFileTypes) Form1.form.log($"[type:{fileType} compared:{input}]");
            return allowedFileTypes.Contains(input);
        }

        private static string? GetFilenameFromResponse(HttpResponseMessage response)
        {
            if (response.Content.Headers.ContentDisposition != null)
            {
                return response.Content.Headers.ContentDisposition.FileName;
            }
            return null;
        }

        private static string GetFilenameFromUrl(string url)
        {
            Uri uri = new Uri(url);
            return Path.GetFileName(uri.LocalPath);
        }

        private readonly static string baseGoogleLink = "https://drive.google.com/uc?export=download&id=";
        public static string FormatURL(string url)
        {
            ORIGIN origin = GetOrigin(url);
            string updated = url;
            switch (origin)
            {
                case ORIGIN.DROPBOX:
                    updated = updated.ToLower().Replace("dl=0", "dl=1");
                    break;
                case ORIGIN.GOOGLE:
                    string googleID = url.Split("d/")[1].Split("/")[0];
                    updated = baseGoogleLink + googleID;
                    break;
            }
            return updated;
        }

        public static ORIGIN GetOrigin(string url)
        {
            ORIGIN origin = ORIGIN.INVALID;
            foreach (ORIGIN origins in Enum.GetValues(typeof(ORIGIN)))
                if (url.Contains(Recipe.GetEnumDescription(origins).ToLower())) origin = origins;
            return origin;
        }

        static bool IsRedirect(System.Net.HttpStatusCode statusCode)
        {
            return statusCode == System.Net.HttpStatusCode.Moved ||
                   statusCode == System.Net.HttpStatusCode.Redirect ||
                   statusCode == System.Net.HttpStatusCode.RedirectMethod;
        }

        public static string[] allowedFileTypes =
{
            "rar",
            "7z",
            "zip",
            "dll"
        };
        public static async Task Download(ModDownload mod, bool thing)
        {
            HttpClient client = new HttpClient();
            //HttpRequestMessage request = new(HttpMethod.Get, mod.URL);
            HttpResponseMessage response = await client.GetAsync(mod.URL);
            string html = await response.Content.ReadAsStringAsync();
            HtmlDocument doc = new();
            doc.LoadHtml(html);
            HtmlNode node = doc.DocumentNode.SelectSingleNode("//a[@class='button buttonPrimary externalURL']");
            string versionURL = node.Attributes["href"].Value.TrimEnd('/');
            string versionID = versionURL.Split("/")[^1];
            Debug.WriteLine($"VURL: {versionURL} VID: {versionID}");

            // download request
            string[] split = mod.URL.Split("/");
            string licenseURL = $"{baseURL}license/{split[^2]}";
            HttpClient downloadClient = new();
            response = await downloadClient.GetAsync(licenseURL);
            html = await response.Content.ReadAsStringAsync();
            string pattern = @"var SECURITY_TOKEN = '(.+?)';";
            Match match = Regex.Match(html, pattern);
            string t = match.Success ? match.Groups[1].Value : "";
            HttpRequestMessage request = new(HttpMethod.Post, licenseURL);
            string useragent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36";
            downloadClient.DefaultRequestHeaders.UserAgent.ParseAdd(useragent);
            var content = new FormUrlEncodedContent(new[] // Thanks alrick. for saying that it can't be in json
            {
                new KeyValuePair<string, string>("confirm", "1"),
                new KeyValuePair<string, string>("purchase", "0"),
                new KeyValuePair<string, string>("versionID", versionID),
                new KeyValuePair<string, string>("t", t)
            });
            //string jsonPayload = Newtonsoft.Json.JsonConvert.SerializeObject(payloadData);
            response = await downloadClient.PostAsync(licenseURL, content);
            html = await response.Content.ReadAsStringAsync();
            doc.LoadHtml(html);
            string downloadURL = doc.DocumentNode.SelectSingleNode(".//a[@class='button buttonPrimary noDereferer']").Attributes["href"].Value;
            string savePath = Paths.downloadingPath;
            HttpClient httpClient = new();
            try
            {
                // some mfers don't like you without a user-agent, fake asf fr
                httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(useragent);
                string formattedURL = FormatURL(downloadURL);
                Form1.form.log("Formatted: " + formattedURL);
                HttpResponseMessage response2 = await httpClient.GetAsync(formattedURL, HttpCompletionOption.ResponseHeadersRead);
                if (response2.IsSuccessStatusCode)
                {
                    string filename = (GetFilenameFromResponse(response2) ?? GetFilenameFromUrl(downloadURL)).Replace("\"", "");
                    string extension = filename.Replace("\"", "").Split(".")[^1];
                    Form1.form.log($"FN:{filename} Ex: {extension}");
                    if (!IsValidFileType(extension.TrimEnd())) { Form1.form.log("No File Found."); return; }
                    Form1.form.log($"Downloading file.");
                    long byteSize = response2.Content.Headers.ContentLength ?? 0;
                    mod.totalBytes = byteSize;
                    Form1.form.log($"Download Size: {FormatByteCount(byteSize)}");
                    Stream contentStream = response2.Content.ReadAsStream();
                    byte[] buffer = new byte[8192];
                    int bytesRead = 0;
                    mod.bytes = 0;
                    DateTime startTime = DateTime.Now;
                    string fullSavePath = Path.Combine(savePath, filename);
                    FileStream fileStream = new(fullSavePath, FileMode.Create, FileAccess.Write, FileShare.None);
                    while ((bytesRead = await contentStream.ReadAsync(buffer)) > 0)
                    {
                        mod.bytes += bytesRead;
                        await fileStream.WriteAsync(buffer, 0, bytesRead);

                        TimeSpan elapsedTime = DateTime.Now - startTime;
                        mod.downloadSpeed = mod.bytes / (elapsedTime.TotalMilliseconds / 1000);
                    }
                    mod.downloadSpeed = 0;
                    ModInstaller.Install(new(fullSavePath, mod.name, extension));
                    Form1.form.log("File downloaded successfully!");
                }
                else
                {
                    Form1.form.log($"HTTP request failed with status code: {response2.StatusCode}");
                }
            }
            catch (HttpRequestException e)
            {
                Form1.form.log($"HTTP request error: {e.Message}");
            }
        }

        public async static void WebRequestMods(int page = 1)
        {
            string url = $"https://hub.sp-tarkov.com/files/?pageNo={page}&sortField=time&sortOrder=DESC";
            string className = "box128";
            HttpClient client = new HttpClient();
            // Send a GET request to the specified URL
            HttpResponseMessage response = await client.GetAsync(url);
            Debug.WriteLine($"Querying for {className} on {url}");
            // Read the response content as a string
            string html = await response.Content.ReadAsStringAsync();
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            HtmlNodeCollection elements = doc.DocumentNode.SelectNodes("//div[starts-with(@class, 'filebaseFileCard')]");
            // Loop through the elements and print their inner text
            foreach (HtmlNode element in elements)
            {
                downloadableMods.Add(new ModDownload(element));
            }
        }

        public static List<ModDownload> GetModDownloads()
        {
            return downloadableMods;
        }
        public void DownloadMod(ModDownload mod)
        {
            if (curDownload != null)
                if (MessageBox.Show($"Downloading {curDownload.name}, are you sure you want to replace?", "Active Download!", MessageBoxButtons.YesNo) == DialogResult.No) return;
            curDownload = mod;
        }
    }

    public class ModDownload
    {
        public ORIGIN Origin;
        public string URL, name, author, description, imageURL, AkiVersion, lastUpdated, downloads;
        public int comments, reviews, ratings;
        public float stars;
        public long bytes = 0, totalBytes = 0;
        public double downloadSpeed = 0;

        public ModDownload(HtmlNode element)
        {
            name = DecodeString(element.SelectSingleNode(".//h3[@class='filebaseFileSubject']").InnerText.Trim());
            description = DecodeString(element.SelectSingleNode(".//div[@class='containerContent filebaseFileTeaser']").InnerText.Trim());
            URL = element.SelectSingleNode(".//a[@class='box128']").Attributes["href"].Value;
            HtmlNode spanNode = element.SelectSingleNode(".//span[@class='filebaseFileIcon']");
            HtmlNode imageNode = element.SelectSingleNode(".//img");
            imageURL = imageNode != null ? imageNode.GetAttributeValue("src", "") : "";
            HtmlNode ratingNode = element.SelectSingleNode(".//li[@class='jsTooltip filebaseFileRating']");
            HtmlNode att = element.SelectSingleNode(".//ul[@class='inlineList dotSeparated filebaseFileMetaData']");
            author = att.SelectSingleNode(".//li").InnerText;
            AkiVersion = element.SelectSingleNode(".//span [starts-with(@class, 'badge label')]").InnerText;
            //Debug.WriteLine(element.SelectSingleNode(".//ul[@class='inlineList filebaseFileStats']").SelectSingleNode(".//li").InnerText);
            downloads = element.SelectSingleNode(".//ul[@class='inlineList filebaseFileStats']").SelectSingleNode(".//li").InnerText.Trim();
            ratings = 0;
            HtmlNode ratingsNode = element.SelectSingleNode(".//span[@class='filebaseFileNumberOfRatings']");
            if (ratingsNode != null) ratings = int.Parse(ratingsNode.InnerText.Trim().Replace("(", "").Replace(")", ""));
            //downloads = int.Parse();
            if (ratingNode != null)
            {
                string[] v = ratingNode.Attributes["title"].Value.Split("; ");
                stars = float.Parse(v[0].Split(" ")[0]);
                reviews = int.Parse(v[1].Split(" ")[0]);
            }
            lastUpdated = att.SelectSingleNode(".//time [@class='datetime']").InnerText;
            //Form1.form.log($"N:{name} A:{author} V:{AkiVersion} UP:{lastUpdated} S:{s} R:{r} IU:{imageURL} U:{URL} Description:\n{description}");
            Origin = GetOrigin(URL);
            ModDownloader.form.AddMod(this);
        }

        public static string DecodeString(string input)
        {
            return HttpUtility.HtmlDecode(input);
        }

        override
        public string ToString()
        {
            return name;
        }

        public static ORIGIN GetOrigin(string url)
        {
            ORIGIN origin = ORIGIN.INVALID;
            foreach (ORIGIN origins in Enum.GetValues(typeof(ORIGIN)))
                if (url.Contains(Recipe.GetEnumDescription(origins).ToLower())) origin = origins;
            return origin;
        }

        public async Task Download()
        {
            await Task.Run(async () =>
            {
                ModManager.Download(this, true);
            });
        }

        public async Task DownloadCall(string url)
        {
            HttpClient client = new HttpClient();
            // Send a GET request to the specified URL
            HttpResponseMessage response = await client.GetAsync(URL);
            // Read the response content as a string
            string html = await response.Content.ReadAsStringAsync();
            //Debug.WriteLine($"Loading html\n{html}");
            //File.WriteAllText(Form1.form.GetCachePath() + "/last.html", html);
            // Get all elements with class 'filebaseFileCard new'
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            string downloadURL = "";
        }
        public int CalculatePercentageInt()
        {
            return (int)(Math.Round(CalculatePercentage()));
        }
        public double CalculatePercentage()
        {
            if (totalBytes == 0)
            {
                // Avoid division by zero error; you can choose to handle this case differently if needed.
                return 0;
            }

            double percentage = (double)bytes / totalBytes * 100;
            if (percentage > 100) percentage = 100;
            return percentage;
        }
    }
}
