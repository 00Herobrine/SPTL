using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net.Http.Headers;
using WinFormsApp1;

namespace SPTLauncher.Constructors
{
    public enum CacheType { ARMOR, BACKPACKS, CLOTHING, HEADPHONES, HELMETS, RIGS, FIREARMS, AMMO, MAGAZINES, GRENADES,
        FOOD, CONTAINERS, ITEMS, KNIVES, KEYS, MAPS, MEDICALS, MODS, MONEY}
    public enum CacheTab { ARMOR, WEARABLES, WEAPONS, KEYS, CONSUMABLES, MISC }

    internal class TarkovCache
    {
        public static Dictionary<CacheType, CacheTab> tabs = new Dictionary<CacheType, CacheTab>();
        public static Dictionary<CacheType, string> caches = new Dictionary<CacheType, string>();
        private string mainPath;
        private string nameCachePath = Form1.itemCache + "/idnames.json";
        private JObject nameCache;

        public TarkovCache(string mainPath) {
            this.mainPath = mainPath;
            if(!Directory.Exists(Form1.itemCache)) Directory.CreateDirectory(Form1.itemCache);
            if(!Directory.Exists(mainPath)) Directory.CreateDirectory(mainPath);
            LoadTabs();
            GenerateCache();
        }

        public void LoadTabs()
        {
            tabs.Add(CacheType.ARMOR, CacheTab.ARMOR);
            tabs.Add(CacheType.BACKPACKS, CacheTab.WEARABLES);
            tabs.Add(CacheType.CLOTHING, CacheTab.WEARABLES);
            tabs.Add(CacheType.HEADPHONES, CacheTab.WEARABLES);
            tabs.Add(CacheType.HELMETS, CacheTab.WEARABLES);
            tabs.Add(CacheType.RIGS, CacheTab.WEARABLES);
            tabs.Add(CacheType.FIREARMS, CacheTab.WEAPONS);
            tabs.Add(CacheType.AMMO, CacheTab.WEAPONS);
            tabs.Add(CacheType.MAGAZINES, CacheTab.WEAPONS);
            tabs.Add(CacheType.GRENADES, CacheTab.WEAPONS);
            tabs.Add(CacheType.FOOD, CacheTab.CONSUMABLES);
            tabs.Add(CacheType.CONTAINERS, CacheTab.MISC);
            tabs.Add(CacheType.ITEMS, CacheTab.MISC);
            tabs.Add(CacheType.KNIVES, CacheTab.WEAPONS);
            tabs.Add(CacheType.KEYS, CacheTab.KEYS);
            tabs.Add(CacheType.MAPS, CacheTab.MISC);
            tabs.Add(CacheType.MEDICALS, CacheTab.CONSUMABLES);
            tabs.Add(CacheType.MODS, CacheTab.MISC);
            tabs.Add(CacheType.MONEY, CacheTab.MISC);
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
            else
            {
                Form1.form.log("Caching missing files.");
                if(nameCache != null) File.WriteAllText(nameCachePath, nameCache.ToString());
            }
        }

 /*       public string getNameCache()
        {
            nameCache ??= JObject.Parse(File.ReadAllText(nameCachePath));
            
        }*/

        public void CacheNames(CacheType cacheType)
        {
            nameCache ??= JObject.Parse(File.ReadAllText(nameCachePath));
            string typePath = Form1.itemCache + "/" + cacheType.ToString().ToLower() + ".json";
            JObject cacheObject = JObject.Parse(File.ReadAllText(typePath));
            foreach(JToken jToken in cacheObject[""])
            {
                string id = jToken["Item ID"].ToString();
                nameCache[id] = cacheType.ToString();
            }
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
                string typePath = Form1.cachePath + "/" + cacheType.ToString().ToLower() + ".json";
                File.WriteAllText(typePath, jToken["results"].ToString());
                Form1.form.log("Generated cache for " + cacheType + ".");
                caches[cacheType] = typePath;
                //CacheNames(cacheType);
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
