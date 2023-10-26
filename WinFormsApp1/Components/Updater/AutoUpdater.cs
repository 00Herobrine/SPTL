using Newtonsoft.Json.Linq;
using System.Diagnostics;
using WinFormsApp1;

namespace SPTLauncher.Components.Updater
{
    internal class AutoUpdater
    {
        static string repositoryOwner = "00Herobrine";
        static string repositoryName = "SPTL";
        static string currentVersion = LauncherSettings.Version.ToString(); // Current version of your app

        public static async Task UpdateCheck()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/98.0.4758.102 Safari/537.36");

                string[]? responses = await GetLatestReleaseTagAsync(httpClient);
                if (responses == null) { Form1.log("No Versions Uploaded"); return; }
                string latestReleaseTag = responses[0];
                if (latestReleaseTag != null && latestReleaseTag != currentVersion)
                {
                    if (MessageBox.Show($"A new version is availabe, open the download link?\n{responses[1]}\n",
                        //$"                       Yours:                 Latest:\n                       {LauncherSettings.Version}     =>     {latestReleaseTag}",
                        "New Version!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        Process.Start(new ProcessStartInfo(responses[1]) { UseShellExecute = true });
                }
                else
                {
                    Form1.log($"Your application is up-to-date. {currentVersion}");
                }
            }
        }

        static async Task<string[]?> GetLatestReleaseTagAsync(HttpClient httpClient)
        {
            string apiUrl = $"https://api.github.com/repos/{repositoryOwner}/{repositoryName}/releases/latest";

            try
            {
                string json = await httpClient.GetStringAsync(apiUrl);
                var release = JObject.Parse(json);
                return [release["tag_name"]?.ToString(), release["html_url"]?.ToString()];
            }
            catch (Exception ex)
            {
                Form1.log("Error getting the latest release: " + ex.Message);
                return null;
            }
        }

        
    }
}
