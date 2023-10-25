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
                // Set a common User-Agent for all requests
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/98.0.4758.102 Safari/537.36");

                string latestReleaseTag = await GetLatestReleaseTagAsync(httpClient);
                if (latestReleaseTag != null && latestReleaseTag != currentVersion)
                {
                    //Form1.log("A new version is available.");

                    // Close the current application
                    if (MessageBox.Show("A new version is availabe, Download & Install now?", "New Version!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Process.Start(Paths.gameFolder + "\\SPTL-Updater.exe");
                        Environment.Exit(0);
                        // Start the updated application
                    }
                }
                else
                {
                    Form1.log($"Your application is up-to-date. {currentVersion}");
                }
            }
        }

        static async Task<string?> GetLatestReleaseTagAsync(HttpClient httpClient)
        {
            string apiUrl = $"https://api.github.com/repos/{repositoryOwner}/{repositoryName}/releases/latest";

            try
            {
                string json = await httpClient.GetStringAsync(apiUrl);
                var release = JObject.Parse(json);
                return release["tag_name"]?.ToString();
            }
            catch (Exception ex)
            {
                Form1.log("Error getting the latest release: " + ex.Message);
                return null;
            }
        }

        
    }
}
