using HtmlAgilityPack;
using SPTLauncher.Constructors;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using WinFormsApp1;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace SPTLauncher.Components
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
        INVALID
    }
    public class ModManager
    {
        public ModDownload curDownload = null;
        public static List<ModDownload> downloadableMods = new();
        public static List<Mod> mods = new();
        const string baseURL = "https://hub.sp-tarkov.com/files/";
        private static string xsrfToken = "";

        public ModManager()
        {
            WebRequestMods();
        }

        public static void Initialize()
        {
            WebRequestMods();
            LoadMods();
        }

        public static void LoadMods()
        {
            List<string> files = new List<string>();
            if (Directory.Exists(Paths.disabledModsPath))
            {
                files.AddRange(Directory.GetFiles(Paths.disabledModsPath));
                files.AddRange(Directory.GetDirectories(Paths.disabledModsPath));
            }
            if (Directory.Exists(Paths.modsFolder))
            {
                files.AddRange(Directory.GetFiles(Paths.modsFolder));
                files.AddRange(Directory.GetFiles(Paths.pluginsFolder));
                if (Directory.Exists(Paths.pluginsFolder))
                {
                    files.AddRange(Directory.GetDirectories(Paths.modsFolder));
                    files.AddRange(Directory.GetDirectories(Paths.pluginsFolder));
                }
                int amount = files.Count;
                int disabledAmount = 0;
                foreach (string file in files)
                {
                    string fileName = file.Split('\\')[1];
                    //log(fileName);
                    if (file.Contains(Paths.pluginsFolder + "\\aki-") || fileName.Equals("order.json") || fileName.Equals("spt")) amount--;
                    else
                    {
                        Mod mod = new(file);
                        string d = "";
                        if (!mod.isEnabled())
                        {
                            d = " DISABLED";
                            disabledAmount++;
                        }
                        //int index = modsListBox.Items.Add(mod.GetName() + (mod.IsPlugin() ? " [P]" : " [C]") + d);
                        mods.Add(mod);
                    }
                    //modsIndex = mods;
                    //ModsButton.Text = "Mods" + ((amount > 0) ? $": {amount - disabledAmount}/{amount}" : "");
                }
            }
        }

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
            string downloadURL = $"{baseURL}license/{split[^2]}";
            HttpClient downloadClient = new();
            response = await downloadClient.GetAsync(downloadURL);
            html = await response.Content.ReadAsStringAsync();
            string pattern = @"var SECURITY_TOKEN = '(.+?)';";
            Match match = Regex.Match(html, pattern);
            string t = match.Success ? match.Groups[1].Value : "";
            HttpRequestMessage request = new(HttpMethod.Post, downloadURL);
            /*var payloadData = new
            {
                confirm = 1,
                purchase = 0,
                versionID = $"{versionID}",
                t = $"{t}"
            };
            string jsonPayload = Newtonsoft.Json.JsonConvert.SerializeObject(payloadData);
            StringContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");*/
            string requestBody = $"confirm=1&purchase=0versionID={versionID}&t={t}";
            request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
            StringContent content = new StringContent(requestBody);
            response = await downloadClient.PostAsync(downloadURL, content);
            html = await response.Content.ReadAsStringAsync();
            doc.LoadHtml(html);
            Debug.WriteLine($"versionID:{versionID} t:{t} Redirect:{IsRedirect(response.StatusCode)} B:{requestBody}");
            Debug.WriteLine(html);
        }

        static bool IsRedirect(System.Net.HttpStatusCode statusCode)
        {
            return statusCode == System.Net.HttpStatusCode.Moved ||
                   statusCode == System.Net.HttpStatusCode.Redirect ||
                   statusCode == System.Net.HttpStatusCode.RedirectMethod;
        }

        public static async Task Download(ModDownload mod)
        {
            HttpClient client = new HttpClient();
            string[] split = mod.URL.Split("/");
            string downloadURL = $"{baseURL}license/{split[^2]}";
            string versionID = downloadURL.Split("/").Last();
            // Send a GET request to the specified URL
            client.DefaultRequestHeaders.Add("confirm", "1");
            client.DefaultRequestHeaders.Add("purchase", "0");
            client.DefaultRequestHeaders.Add("versionID", versionID);
            client.DefaultRequestHeaders.Add("t", xsrfToken);
            //client.DefaultRequestHeaders.Add("Cookie", $"welovesenko_user_session={xsrfToken}");
            HttpRequestMessage request = new(HttpMethod.Post, downloadURL);
            string requestBody = "{\"key\": \"value\"}";
            request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.SendAsync(request);
            HtmlDocument doc = new();
            string html = await response.Content.ReadAsStringAsync();
            doc.LoadHtml(html);
            Debug.WriteLine($"DL: {downloadURL} VID: {versionID} ML: {mod.URL} TKN: {xsrfToken} RES:{response}");
            Debug.WriteLine(response.Headers);
            //HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//a[@itemprop='downloadUrl']");
            /*if (nodes != null)
            {
                foreach (HtmlNode node in nodes)
                {
                    downloadURL = node.GetAttributeValue("href", "");
                }
                string _URL = URL.Replace("https://hub.sp-tarkov.com/files/file/", "");
                string modLink = $"{_URL}";
                string newURL = $"{baseURL}license/{modLink}";
                string versionID = downloadURL.Split("/").Last();
                var client2 = new HttpClient();
                client2.DefaultRequestHeaders.Add("confirm", "1");
                client2.DefaultRequestHeaders.Add("purchase", "0");
                client2.DefaultRequestHeaders.Add("versionID", versionID);
                client2.DefaultRequestHeaders.Add("welovesenko_user_session", xsrfToken);
                string basedURL = newURL + $"?confirm=1&purchase=0&versionID={versionID}&t={xsrfToken}";
                response = await client2.GetAsync(newURL, HttpCompletionOption.ResponseContentRead);
                Debug.WriteLine($"UL: {newURL} BL: {basedURL} _U:{_URL} U: {URL} D: {downloadURL}");
                if (response.StatusCode == HttpStatusCode.Redirect)
                {
                    var redirectUrl = response.Headers.Location.AbsoluteUri;
                    Console.WriteLine($"Redirect URL: {redirectUrl}");
                }
                else
                {
                    Console.WriteLine("Request was not redirected");
                }
            }
            string r = await response.Content.ReadAsStringAsync();
            Debug.WriteLine($"Response:\n{r}");
            // string downloadURL = doc.DocumentNode.SelectSingleNode("//a[class='button buttonPrimary externalURL']").Attributes["href"].Value;
            //HtmlNode downloadNode = doc.DocumentNode.SelectSingleNode("//a[class='button buttonPrimary externalURL'");
            //string downloadURL = downloadNode.Attributes["href"].Value;
            //Debug.WriteLine($"Download URL: {downloadURL}");
            //Form1.form.log(html);*/
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
            if (response.Headers.TryGetValues("Set-Cookie", out IEnumerable<string> cookieValues))
            {
                // Iterate through the cookie values and look for the XSRF-TOKEN cookie
                foreach (string cookieValue in cookieValues)
                {
                    if (cookieValue.Contains("XSRF-TOKEN"))
                    {
                        // Extract the value of the XSRF-TOKEN cookie
                        xsrfToken = cookieValue.Split(';').FirstOrDefault(c => c.Contains("XSRF-TOKEN")).Split('=')[1];
                        Debug.WriteLine("XSRF-TOKEN: " + xsrfToken);
                        break;
                    }
                }
            }
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

        public ModDownload(HtmlNode element)
        {
            name = element.SelectSingleNode(".//h3[@class='filebaseFileSubject']").InnerText.Trim();
            description = element.SelectSingleNode(".//div[@class='containerContent filebaseFileTeaser']").InnerText.Trim();
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
            ModManager.Download(this, true);
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
    }
}
