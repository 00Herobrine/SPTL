using System.Diagnostics;
using System.IO.Compression;
using System.Text.Json;

namespace SPTL_Updater
{
    internal partial class Updater : Form
    {
        private static string repositoryOwner = "00Herobrine";
        private static string repositoryName = "SPTL";
        public string path = Directory.GetCurrentDirectory() + "/Launcher-Cache/temp";
        public static Updater? form;

        public Updater()
        {
            form = this;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _ = DownloadUpdate();
        }
        internal void Log(string message, bool scroll = true)
        {
            if (form == null) return;
            int index = listBox1.Items.Add(message);
            if (scroll) listBox1.SelectedIndex = index;
        }

        internal void UpdateBar(int moved, int totalItems)
        {
            bool installed = moved >= totalItems && totalItems > 0;
            label1.Text = installed ? "Installed Successfully" : $"Installing {moved}/{totalItems}";
            int progress = 0;
            if (totalItems > 0) progress = (int)((double)moved / totalItems * 100);
            progressBar1.Value = progress;
        }

        internal async Task DownloadUpdate()
        {
            Log("Attempting Download");
            using (var httpClient = new HttpClient())
            {
                Log("Adding headers");
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/98.0.4758.102 Safari/537.36");
                Log("getting tag");
                string? latestReleaseTag = await GetLatestReleaseTagAsync(httpClient);
                if (latestReleaseTag == null) { Log("Tag == null"); return; }
                string? downloadUrl = await GetReleaseDownloadUrlAsync(httpClient, latestReleaseTag);
                if (downloadUrl == null) { Log("downloadUrl == null"); return; }
                string downloadFileName = Path.GetFileName(downloadUrl);
                string downloadPath = $"{path}/{downloadFileName}";
                Log("Set downloadPath to " + downloadPath);
                bool exists = Directory.Exists(path);
                Log($"Path exists? {exists}");
                if (!exists) { Directory.CreateDirectory(path); Log("Directory Created"); }

                Log("Writing Bytes");
                byte[] fileContent = await httpClient.GetByteArrayAsync(downloadUrl);
                File.WriteAllBytes(downloadPath, fileContent);
                Log("File Downloaded");
                ExtractZipFile(downloadPath, Directory.GetCurrentDirectory());
            }
        }

        private static int totalItems = 0;
        private static int moved = 0;

        internal void ExtractZipFile(string zipFilePath, string destinationDirectory)
        {
            Log($"Extracting {zipFilePath} to {destinationDirectory}");
            FileStream zipToOpen = new(zipFilePath, FileMode.Open);
            ZipArchive archive = new(zipToOpen, ZipArchiveMode.Read);
            totalItems = archive.Entries.Count;
            moved = 0;
            foreach (ZipArchiveEntry entry in archive.Entries)
            {
                if (entry.FullName.EndsWith("/"))
                {
                    Log($"Creating Directory {destinationDirectory + "/" + entry.FullName}");
                    Directory.CreateDirectory(Path.Combine(destinationDirectory, entry.FullName));
                }
                else
                {
                    Log($"Extracted {entry.FullName}");
                    entry.ExtractToFile(Path.Combine(destinationDirectory, entry.FullName), true);
                }
                moved++;
                UpdateBar(moved, totalItems);
            }
            Log("Extraction Completed!");
        }

        internal async Task<string?> GetReleaseDownloadUrlAsync(HttpClient httpClient, string tag)
        {
            Log("Getting Download URL");
            string apiUrl = $"https://api.github.com/repos/{repositoryOwner}/{repositoryName}/releases/tags/{tag}";
            try
            {
                string json = await httpClient.GetStringAsync(apiUrl);
                var release = JsonSerializer.Deserialize<GitHubRelease>(json);
                var asset = release.assets.Count() > 0 ? release.assets[0] : new(); // Assuming there's at least one asset
                Log("Got URL: " + asset.browser_download_url);
                return asset.browser_download_url;
            }
            catch 
            {
                return null;
            }
        }

        internal async Task<string?> GetLatestReleaseTagAsync(HttpClient httpClient)
        {
            Debug.WriteLine("getting Release tag");
            string apiUrl = $"https://api.github.com/repos/{repositoryOwner}/{repositoryName}/releases/latest";
            try
            {
                string json = await httpClient.GetStringAsync(apiUrl);
                var release = JsonSerializer.Deserialize<GitHubRelease>(json);
                Log("Got tag: " + release.tag_name);
                return release.tag_name;
            }
            catch
            {
                return null;
            }
        }
    }
}