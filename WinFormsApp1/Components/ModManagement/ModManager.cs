﻿using HtmlAgilityPack;
using System.Diagnostics;
using System.Text.RegularExpressions;
using WinFormsApp1;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using Newtonsoft.Json;
using SPTLauncher.Forms;
using SPTLauncher.Components.ModManagement.Downloader;
using SPTLauncher.Utils;
using SPTLauncher.Components.ModManagement.Types;

namespace SPTLauncher.Components.ModManagement
{
    public enum ModType { CLIENT, PLUGIN, BOTH }

    internal class ModManager
    {
        public ModDownload? curDownload = null;
        public static List<ModDownload> downloadableMods = new();
        public static List<Mod> mods = new();
        const string baseURL = "https://hub.sp-tarkov.com/files/";
        private static string modsURL = "http://spt.minekov.net/mods";
        public static int disabledAmount = 0;
        public static ModManagerConfigStruct config;
        public static readonly string[] allowedImageTypes = ["png", "jpg", "jpeg", "gif"];

        public static void Initialize()
        {
            LoadConfig();
            ModQuery query = QueryMods();
            Form1.log($"{query.mods.Count} mods queried.");
            //Manager.AddDownloadedMod(downloadedMod); 
/*            WebRequestMods();
            WebRequestMods(2);*/
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
                string fileName = Path.GetFileName(file);
                if (fileName.StartsWith("aki-", true) && fileName.EndsWith(".dll", true) || ignoredFiles.Contains(fileName.ToLower())) amount--;
                else
                {
                    Mod mod = new(file);
                    if (!mod.IsEnabled) disabledAmount++;
                    mods.Add(mod);
                }
            }
            foreach(string file in Directory.GetDirectories($"{Paths.modManagerFolder}/extracted"))
            {
                ExtractedMod em = new(file);
                em.CreateJunction();
                Debug.WriteLine(em); 
            }
        }

        private readonly static string[] sizeSuffixes = { "B", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
        public static string FormatByteCount(long bytes)
        {
            if (bytes == 0) return "0" + sizeSuffixes[0];
            int magnitude = (int)Math.Floor(Math.Log(bytes, 1024));
            double adjustedSize = bytes / Math.Pow(1024, magnitude);

            return string.Format("{0:0.##} {1}", adjustedSize, sizeSuffixes[magnitude]);
        }

        public static bool IsValidFileType(string input)
        {
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

        public static Dictionary<string, string> Favorites => config.favorites.ToDictionary(o => o.URL, o => o.name);
        public static void AddToFavorites(ModDownload download)
        {
            config.favorites.Add(new(download.URL, download.name));
            SaveConfig();
        }
        internal static void RemoveFavorite(ModDownload download)
        {
            config.favorites.Remove(config.favorites.Where(o => o.URL == download.URL).FirstOrDefault());
            SaveConfig();
        }
        #region Config Shit
        public static void CheckConfig(ModDownload download)
        {
            Form1.log("Checking config for " + download.id + " Exist? " + HasConfig(download));
            if (HasConfig(download))
            {
                
            }
            else GenerateConfig(download);
        }
        private readonly static string[] NonVersions = ["Featured", "Outdated"];
        public static ModConfig GenerateConfig(ModDownload download)
        {
            ModConfig modConfig = new()
            {
                AkiVersion = download.formattedVersion,
                ID = download.id,
                Name = download.name,
                URL = download.URL
            };
            config.ModConfigs.Add(modConfig);
            SaveConfig();
            return modConfig;
        }
        public static Dictionary<int, ModConfig> GetModConfigs() => config.ModConfigs.ToDictionary(entry => entry.ID);
        public static bool HasConfig(ModDownload download) => GetModConfigs().ContainsKey(download.id);
        public static ModConfig? GetConfig(ModDownload download) => GetModConfigs().TryGetValue(download.id, out ModConfig modConfig) ? modConfig : null;
        private static void SaveConfig() => File.WriteAllText(Paths.modManagerConfigPath, JsonConvert.SerializeObject(config, Formatting.Indented));
        public static void LoadConfig()
        {
            if (!File.Exists(Paths.modManagerConfigPath)) File.WriteAllText(Paths.modManagerConfigPath, JsonConvert.SerializeObject(new ModManagerConfigStruct(), Formatting.Indented));
            config = JsonConvert.DeserializeObject<ModManagerConfigStruct>(File.ReadAllText(Paths.modManagerConfigPath));
        }
        #endregion

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
                    // some people don't format their links correctly sigh
                    updated = updated.ToLower().Replace("dl=0", "dl=1").Replace("amp;", "");
                    break;
                case ORIGIN.GOOGLE:
                    if (url.Contains("export=download") && url.Contains("id=")) return url; // some people already have direct links
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
                if (url.Contains(origins.GetDescription(), StringComparison.OrdinalIgnoreCase)) origin = origins;
            return origin;
        }

        public static string[] allowedFileTypes =
        {
            "rar",
            "7z",
            "zip",
            "dll"
        };
        public static async Task Download(ModDownload mod)
        {
            if (!mod.URL.StartsWith(baseURL)) { Form1.log($"Not an SPT Mod! URL:\n{mod.URL}"); return; }
            HttpClient client = new HttpClient();
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
            // some mfers don't like you without a user-agent, fake asf fr
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
            string savePath = Paths.downloadedPath;
            response = await downloadClient.PostAsync(licenseURL, content);
            if (response.IsSuccessStatusCode)
            {
                string? filename = GetFilenameFromResponse(response);
                if (filename != null)
                {
                    filename = filename.Replace("\"", "");
                    //Form1.log($"File Included FN: {filename}");
                    string extension = filename.Replace("\"", "").Split(".")[^1];
                    if (!IsValidFileType(extension.TrimEnd())) { Form1.log("No File Found."); return; }
                    Form1.log($"Downloading file.");
                    long byteSize = response.Content.Headers.ContentLength ?? 0;
                    mod.totalBytes = byteSize;
                    Form1.log($"Download Size: {FormatByteCount(byteSize)}");
                    mod.bytes = 0;
                    Stream contentStream = await response.Content.ReadAsStreamAsync();
                    byte[] buffer = new byte[8192];
                    mod.bytes = 0;
                    DateTime startTime = DateTime.Now;
                    string fullSavePath = Path.Combine(savePath, filename.Replace("\"", ""));
                    try
                    {
                        FileStream fileStream = new FileStream(fullSavePath, FileMode.Create, FileAccess.Write, FileShare.None);
                        int bytesRead;
                        while ((bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                        {
                            await fileStream.WriteAsync(buffer, 0, bytesRead);

                            mod.bytes += bytesRead;
                            TimeSpan elapsedTime = DateTime.Now - startTime;
                            mod.downloadSpeed = mod.bytes / (elapsedTime.TotalMilliseconds / 1000);
                        }
                        mod.downloadSpeed = 0;
                        Form1.log("File downloaded successfully!");
                        ModInstaller.Install(new(fullSavePath, mod.name, extension, mod));
                    }
                    catch (Exception ex)
                    {
                        // Log any exceptions that occur during the download process
                        Form1.log($"Error during download: {ex.Message}");
                    }
                    return;
                }
            }
            html = await response.Content.ReadAsStringAsync();
            doc.LoadHtml(html);
            string downloadURL = doc.DocumentNode.SelectSingleNode(".//a[@class='button buttonPrimary noDereferer']").Attributes["href"].Value;
            HttpClient httpClient = new();
            try
            {
                httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(useragent);
                string formattedURL = FormatURL(downloadURL);
                Form1.log("Formatted: " + formattedURL);
                HttpResponseMessage response2 = await httpClient.GetAsync(formattedURL, HttpCompletionOption.ResponseHeadersRead);
                if (response2.IsSuccessStatusCode)
                {
                    string filename = (GetFilenameFromResponse(response2) ?? GetFilenameFromUrl(downloadURL)).Replace("\"", "");
                    bool downloaded = FileAlreadyDownloaded(filename);
                    string fullSavePath = Path.Combine(savePath, filename);
                    string extension = filename.Replace("\"", "").Split(".")[^1];
                    if (downloaded) { Form1.log("already downloaded"); ModInstaller.Install(new(fullSavePath, mod.name, extension, mod)); return; }
                    if (!IsValidFileType(extension.TrimEnd())) {
                        Form1.log("No File Found.");
                        if(MessageBox.Show("No file downloaded on attached page. Open in browser?", "No File Found", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = formattedURL,
                            UseShellExecute = true
                        }); return; }
                    Form1.log($"Downloading file.");
                    long byteSize = response2.Content.Headers.ContentLength ?? 0;
                    mod.totalBytes = byteSize;
                    Form1.log($"Download Size: {FormatByteCount(byteSize)}");
                    Stream contentStream = response2.Content.ReadAsStream();
                    byte[] buffer = new byte[8192];
                    int bytesRead = 0;
                    mod.bytes = 0;
                    DateTime startTime = DateTime.Now;

                    using (FileStream fileStream = new FileStream(fullSavePath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        while ((bytesRead = await contentStream.ReadAsync(buffer)) > 0)
                        {
                            mod.bytes += bytesRead;
                            await fileStream.WriteAsync(buffer.AsMemory(0, bytesRead));

                            TimeSpan elapsedTime = DateTime.Now - startTime;
                            mod.downloadSpeed = mod.bytes / (elapsedTime.TotalMilliseconds / 1000);
                        }
                    }

                    mod.downloadSpeed = 0;
                    Form1.log("File downloaded successfully!");
                    DownloadedMod downloadedMod = new(fullSavePath, mod.name, extension, mod);
                    Manager.AddDownloadedMod(downloadedMod); 
                    ModInstaller.Install(downloadedMod);
                }
                else
                {
                    Form1.log($"HTTP request failed with status code: {response2.StatusCode}");
                }
            }
            catch (HttpRequestException e)
            {
                Form1.log($"HTTP request error: {e.Message}");
            }
        }

/*        public static List<Image> GetImageCache()
        {
            //Directory.GetFiles(Paths.iconsCachePath).Where(fileName => ModDownloader.allowedImageTypes.Contains(fileName.Split(".")[1])).Select(Image.FromFile).ToList();
            List<Image> images = new List<Image>();
            foreach(string fileName in Directory.GetFiles(Paths.iconsCachePath))
            {
                Debug.WriteLine(fileName);
                if (!ModDownloader.allowedImageTypes.Contains(fileName.Split(".")[1])) continue;
                Debug.WriteLine($"adding {fileName.Split("\\")[1]}");
                images.Add(Image.FromFile(fileName));
            }
            return images;
        }*/
        private static bool FileAlreadyDownloaded(string name)
        {
            return File.Exists($"{Paths.downloadedPath}/{name}");
        }

        public static ModQuery QueryMods()
        {
            HttpClient client = new();
            HttpResponseMessage response = client.GetAsync(modsURL).Result;
            string json = response.Content.ReadAsStringAsync().Result;
            File.WriteAllText(Paths.gameFolder + "/mods.json", json);
            return JsonConvert.DeserializeObject<ModQuery>(json);
        }
        public async static void WebRequestMods(int page = 1)
        {
            string url = $"https://hub.sp-tarkov.com/files/?pageNo={page}&sortField=time&sortOrder=DESC";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            string html = await response.Content.ReadAsStringAsync();
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            HtmlNodeCollection elements = doc.DocumentNode.SelectNodes("//div[starts-with(@class, 'filebaseFileCard')]");
/*            var listItems = doc.DocumentNode
                .Descendants("ol")
                .FirstOrDefault(ol => ol.GetAttributeValue("class", "") == "filebaseFileList")?
                .Descendants("li")
                .ToList();*/
            //if (listItems == null) return;
            foreach (HtmlNode listItem in elements)
                downloadableMods.Add(new ModDownload(listItem));
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
}
