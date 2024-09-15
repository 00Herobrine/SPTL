using Newtonsoft.Json;
using System.Diagnostics;

namespace SPTLauncher.Components.ModManagement
{
    public struct ModQuery
    {
        [JsonProperty("lastUpdated")]
        public long lastUpdated { get; set; }
        [JsonProperty("mods")]
        public List<ModDownloadStruct> mods { get; set; }
    }
    public struct ModDownloadStruct
    {
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("image")]
        public string? imageURL { get; set; }
        [JsonProperty("version")]
        public string version { get; set; }
        [JsonProperty("versionID")]
        public string downloadVersionID { get; set; }
        [JsonProperty("sptakiVersion")]
        public string AkiVersion { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
        [JsonProperty("author")]
        public string author { get; set; }
        [JsonProperty("lastUpdated")]
        public long lastUpdated { get; set; }
        [JsonProperty("downloads")]
        public string downloads { get; set; }
        [JsonProperty("comments")]
        public string comments { get; set; }
        [JsonProperty("reactions")]
        public List<Reaction>? reactions { get; set; }
        [JsonProperty("downloadUrl")]
        public string downloadURL { get; set; }
        [JsonProperty("modUrl")]
        public string URL { get; set; }
        public override string ToString() => name;
        [JsonIgnore]
        private string imageName => imageURL?.Split("/")[^1] ?? "";
        public Version GetVersion() => Version.Parse(version);
        public Image GetImage() => ModManager.allowedImageTypes.Contains(imageName.Split(".")[^1]) 
            ? File.Exists($"{Paths.iconsCachePath}/{imageName}") 
            ? Image.FromFile($"{Paths.iconsCachePath}/{imageName}") : Config.GetImageCaching() 
            ? CacheImage() : Paths.NotFound : Paths.NotFound;
        private Image CacheImage()
        {
            HttpClient client = new();
            try
            {
                HttpResponseMessage response = client.GetAsync(imageURL).Result;

                if (response.IsSuccessStatusCode)
                {
                    byte[] imageBytes = response.Content.ReadAsByteArrayAsync().Result;
                    string filePath = $"{Paths.iconsCachePath}/{imageName}";
                    File.WriteAllBytes(filePath, imageBytes);
                    Debug.WriteLine("Image downloaded successfully.");
                    return Image.FromFile(filePath);
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
            return Paths.NotFound;
        }

    }
    public struct Reaction
    {
        public string Name { get; set; }
        public string Count { get; set; }
    }
}
