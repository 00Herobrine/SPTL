using HtmlAgilityPack;
using SPTLauncher.Components.RecipeManagement;
using System.Diagnostics;
using System.Web;

namespace SPTLauncher.Components.ModManagement
{
    public class ModDownload
    {
        public ORIGIN Origin;
        public string? imageURL, imageName;
        public string URL, name, author, description, AkiVersion, lastUpdated, downloads;
        public Image? image;
        public int comments, reviews, ratings, id;
        public float stars;
        public long bytes = 0, totalBytes = 0;
        public double downloadSpeed = 0;

        public ModDownload(HtmlNode element)
        {
            //element = element.SelectSingleNode("//div[starts-with(@class, 'filebaseFileCard')]");
            name = DecodeString(element.SelectSingleNode(".//h3[@class='filebaseFileSubject']").InnerText.Trim());
            description = DecodeString(element.SelectSingleNode(".//div[@class='containerContent filebaseFileTeaser']").InnerText.Trim());
            URL = element.SelectSingleNode(".//a[@class='box128']").Attributes["href"].Value;
            id = int.Parse(URL.Split("file/")[1].Split("-")[0]);
            HtmlNode spanNode = element.SelectSingleNode(".//span[@class='filebaseFileIcon']");
            HtmlNode imageNode = element.SelectSingleNode(".//img");
            imageURL = imageNode?.GetAttributeValue("src", "");
            imageName = imageURL?.Split("/")[^1];
            HtmlNode ratingNode = element.SelectSingleNode(".//li[@class='jsTooltip filebaseFileRating']");
            HtmlNode att = element.SelectSingleNode(".//ul[@class='inlineList dotSeparated filebaseFileMetaData']");
            author = att.SelectSingleNode(".//li").InnerText;
            AkiVersion = element.SelectSingleNode(".//span [starts-with(@class, 'badge label')]").InnerText;
            //Debug.WriteLine(element.SelectSingleNode(".//ul[@class='inlineList filebaseFileStats']").SelectSingleNode(".//li").InnerText);
            downloads = element.SelectSingleNode(".//ul[@class='inlineList filebaseFileStats']").SelectSingleNode(".//li").InnerText.Trim();
            ratings = 0;
            HtmlNode ratingsNode = element.SelectSingleNode(".//span[@class='filebaseFileNumberOfRatings']");
            if (ratingsNode != null) ratings = int.Parse(ratingsNode.InnerText.Trim().Replace("(", "").Replace(")", ""));
            if (ratingNode != null)
            {
                string[] v = ratingNode.Attributes["title"].Value.Split("; ");
                stars = float.Parse(v[0].Split(" ")[0]);
                reviews = int.Parse(v[1].Split(" ")[0]);
            }
            lastUpdated = att.SelectSingleNode(".//time [@class='datetime']").InnerText;
            Origin = GetOrigin(URL);
            if (!File.Exists($"{Paths.iconsCachePath}/{imageName}") && Config.GetImageCaching()) CacheImage();
            ModDownloader.DisplayModDownload(this);
        }

        public static string DecodeString(string input)
        {
            return HttpUtility.HtmlDecode(input);
        }

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

        public VersionStatus VersionComparison => ModManager.VersionComparsion(this);

        public async Task Download()
        {
            await Task.Run(async () =>
            {
                await ModManager.Download(this);
            });
        }
        public int CalculatePercentageInt()
        {
            return (int)(Math.Round(CalculatePercentage()));
        }
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
