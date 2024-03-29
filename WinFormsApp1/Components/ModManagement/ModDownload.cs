﻿using HtmlAgilityPack;
using SPTLauncher.Components.ModManagement.Downloader;
using System.Diagnostics;
using System.Text;
using System.Web;

namespace SPTLauncher.Components.ModManagement
{
    public class ModDownload
    {
        public ORIGIN Origin;
        public string? imageURL, imageName;
        public string URL, name, author, description, AkiVersion, lastUpdated, downloads, comments, reactions;
        public Image? image;
        public int id;
        public long bytes = 0, totalBytes = 0;
        public double downloadSpeed = 0;

        private readonly static string[] NonVersions = ["Featured", "Outdated"];
        internal string formattedVersion => NonVersions.Any(nonVersion => nonVersion.Equals(AkiVersion, StringComparison.OrdinalIgnoreCase))
            ? AkiVersion.Equals("Outdated", StringComparison.OrdinalIgnoreCase) ? "0.0.0" : LauncherSettings.AkiVersion : AkiVersion.Replace("SPT-AKI", "", StringComparison.OrdinalIgnoreCase).Split("-")[0];

        public ModDownload(HtmlNode element)
        {
            name = DecodeString(element.SelectSingleNode(".//h3[@class='filebaseFileSubject']").InnerText.Trim());
            description = DecodeString(element.SelectSingleNode(".//div[@class='containerContent filebaseFileTeaser']").InnerText.Trim());
            URL = element.SelectSingleNode(".//a[@class='box128']").Attributes["href"].Value;
            id = int.Parse(URL.Split("file/")[1].Split("-")[0]);
            HtmlNode imageNode = element.SelectSingleNode(".//img");
            imageURL = imageNode?.GetAttributeValue("src", "");
            imageName = imageURL?.Split("/")[^1];
            HtmlNode att = element.SelectSingleNode(".//ul[@class='inlineList dotSeparated filebaseFileMetaData']");
            author = att.SelectSingleNode(".//li").InnerText;
            AkiVersion = element.SelectSingleNode(".//span [starts-with(@class, 'badge label')]").InnerText;
            HtmlNodeCollection fileStatNodes = element.SelectSingleNode(".//ul[@class='inlineList filebaseFileStats']").SelectNodes(".//li");
            downloads = fileStatNodes[0].InnerText.Trim();
            StringBuilder sb = new();
            for (int i = 0; i < fileStatNodes.Count; i++) sb.Append(fileStatNodes[i].InnerText.TrimStart().TrimEnd().Split(" ")[0] + " | ");
            Debug.WriteLine("Nodes: " + sb);
            comments = fileStatNodes.Count >= 2 ? fileStatNodes[1].InnerText.TrimStart().TrimEnd().Split(" ")[0] : "0";
            HtmlNode? reactionsNode = element.SelectSingleNode(".//span [@class='reactionCount']");
            reactions = reactionsNode == null ? "0" : reactionsNode.InnerText.Trim();
            lastUpdated = att.SelectSingleNode(".//time [@class='datetime']").InnerText;
            Origin = ModManager.GetOrigin(URL);
            if (!File.Exists($"{Paths.iconsCachePath}/{imageName}") && Config.GetImageCaching()) CacheImage();
            ModDownloader.DisplayModDownload(this);
        }
        public static string DecodeString(string input) => HttpUtility.HtmlDecode(input);
        private async void CacheImage()
        {
            HttpClient client = new();
            try
            {
                HttpResponseMessage response = await client.GetAsync(imageURL);

                if (response.IsSuccessStatusCode)
                {
                    byte[] imageBytes = await response.Content.ReadAsByteArrayAsync();
                    string filePath = $"{Paths.iconsCachePath}/{imageName}";
                    File.WriteAllBytes(filePath, imageBytes);
                    Debug.WriteLine("Image downloaded successfully.");
                    image = Image.FromFile(filePath);
                }
                else
                {
                    Debug.WriteLine($"Failed to download image. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public bool IsFavorited => ModManager.Favorites.ContainsKey(URL);
        public bool ToggleFavorite() {
            if (!IsFavorited) { Favorite(); return true; }
            else { UnFavorite(); return false; }
        }
        public void Favorite() => ModManager.AddToFavorites(this);
        public void UnFavorite() => ModManager.RemoveFavorite(this);
        public override string ToString() => name;

        public VersionStatus VersionComparison => this.CompareVersions();

        public async Task Download()
        {
            await Task.Run(async () =>
            {
                await ModManager.Download(this);
            });
        }
        public int CalculatePercentageInt() => (int)Math.Round(CalculatePercentage());
        public double CalculatePercentage()
        {
            if (totalBytes == 0)
                return 0;

            double percentage = (double)bytes / totalBytes * 100;
            if (percentage > 100) percentage = 100;
            return percentage;
        }
    }
}
