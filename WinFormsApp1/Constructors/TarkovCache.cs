

using Microsoft.VisualBasic.Logging;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using WinFormsApp1;

namespace SPTLauncher.Constructors
{
    public enum CacheType { ARMOR, BACKPACKS, CLOTHING, HEADPHONES, HELMETS, RIGS, FIREARMS, AMMO, MAGAZINES, GRENADES,
        FOOD, CONTAINERS, ITEMS, KNIVES, KEYS, MAPS, MEDICALS, MODS, MONEY}
    public enum CacheTabs { CLOTHING, WEAPONS, KEYS, MISC }
    internal class TarkovCache
    {
        Dictionary<CacheType, string> caches = new Dictionary<CacheType, string>();
        private string mainPath;
        
        public TarkovCache(string mainPath) {
            this.mainPath = mainPath;
            if(!Directory.Exists(mainPath)) Directory.CreateDirectory(mainPath);
            GenerateCache();
        }

        public void GenerateCache()
        {
            Form1.form.log("Launcher-Cache File Check.");
            bool missing = false;
            foreach (CacheType cacheType in Enum.GetValues<CacheType>())
            {
                Debug.Write("Iterating " + cacheType);
                string cachePath = mainPath + "/" + cacheType.ToString().ToLower() + ".json";
                if (!File.Exists(cachePath))
                {
                    if (!missing) missing = true;
                    GenerateCacheFile(cacheType);
                } else caches[cacheType] = cachePath;
            }
            if (!missing) Form1.form.log("All files cached.");
            else Form1.form.log("Caching missing files.");
        }

        public async void GenerateCacheFile(CacheType cacheType)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.tarkov-changes.com/");

            var request = new HttpRequestMessage(HttpMethod.Get, "v1/" + cacheType.ToString().ToLower());
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.Add("AUTH-Token", Form1.form.GetConfig().getApiKey());

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                JToken jToken = JObject.Parse(responseBody);
                string cachePath = mainPath + "/" + cacheType.ToString().ToLower() + ".json";
                File.WriteAllText(cachePath, jToken["results"].ToString());
                Form1.form.log("Generated cache for " + cacheType + ".");
                caches[cacheType] = cachePath;
            }
            else
            {
                Form1.form.log("Failed to get cache for " + cacheType + " Status code: " + response.StatusCode);
            }
        }

        public JObject getCache(CacheType cacheType)
        {
            string cachePath = mainPath + "/" + cacheType.ToString().ToLower() + ".json";
            return JObject.Parse(File.ReadAllText(cachePath));
        }

    }
}
