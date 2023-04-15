using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Windows.Forms.VisualStyles;
using WinFormsApp1;

namespace SPTLauncher.Constructors
{
    public enum CacheType { ARMOR, BACKPACKS, CLOTHING, HEADPHONES, HELMETS, RIGS, FIREARMS, AMMO, MAGAZINES, GRENADES,
        FOOD, CONTAINERS, ITEMS, KNIVES, KEYS, MAPS, MEDICALS, MODS, MONEY }
    public enum CacheTab { ARMOR, WEARABLES, WEAPONS, KEYS, CONSUMABLES, MISC }

    internal class TarkovCache
    {
        public static Dictionary<CacheType, CacheTab> tabs = new Dictionary<CacheType, CacheTab>();
        public static Dictionary<CacheType, string> caches = new Dictionary<CacheType, string>();
        public static Dictionary<string, CachedItem> itemCache = new Dictionary<string, CachedItem>(); // itemID, cached item
        private string mainPath;
        private string nameCachePath = Form1.itemCache + "/idnames.json";
        private static JObject nameCache = new JObject();
        private static JObject names = new JObject();
        private static string[] blacklist = { "item", "weapon box", "stash", "equipment", "throwable weapon", "food and drink", "bear", "usec",
            "ammo", "functional mod", "pistolet", "pockets", "default inventory", "inventory", "secure folder", "bsample" };
        private static string[] whitelist =
        {
            "5e9db13186f7742f845ee9d3", // LBT-1961A Load Bearing Chest Rig
            "628baf0b967de16aab5a4f36", // LCBR Goons Edition
            "5ea03f7400685063ec28bfa8", // PPSh-41
            "5c1a1e3f2e221602b66cc4c2", // Beard
            "5bc9b9ecd4351e3bac122519", // Beard Oil
            "5bffdc370db834001d23eca8", // Bayonet
            "59fb042886f7746c5005a7b2", // Items Case
            "62a08f4c4f842e1bd12d9d62", // BEAR Buddy
            "5d08d21286f774736e7c94c3", // Shturman's Key
            "61a64492ba05ef10d62adcc1", // Rogue USEC Stash Key
            "5da743f586f7744014504f72", // USEC Stash Key
            "5aafbde786f774389d0cbc0f", // Ammo Case
        };

        public TarkovCache(string mainPath) {
            this.mainPath = mainPath;
            if (!Directory.Exists(Form1.itemCache)) Directory.CreateDirectory(Form1.itemCache);
            if (!Directory.Exists(mainPath)) Directory.CreateDirectory(mainPath);
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
                //Debug.Write("Iterating " + cacheType);
                string cachePath = mainPath + "/" + cacheType.ToString().ToLower() + ".json";
                if (!File.Exists(cachePath))
                {
                    if (!missing) missing = true;
                    GenerateCacheFile(cacheType);
                } else caches[cacheType] = cachePath;
            }
            if (!missing) Form1.form.log("All files cached.");
            UpdateNameCache();
            ItemCheck();
        }

        public void ItemCheck()
        {
            foreach (JToken obj in nameCache.Values())
            {
                var parentProperty = ((JProperty)obj.Parent);
                string name = parentProperty.Name;
                string id = name.Split(" ")[0];
                string shortName = obj.ToString();
                //if (blacklist.Contains(shortName.ToLowerInvariant())) continue;
                if (name.Contains("ShortName"))
                {
                    string description = nameCache[id + " Description"].ToString();
                    string[] _d = description.Split();
                    //string d = _d[0];
                    string d2 = $"{_d[0]}{((_d.Length > 2) ? $" {_d[1]} {_d[2]}" : "")}";
                    string longName = nameCache[id + " Name"].ToString();
                    string[] _l = longName.Split(" ");
                    string l2 = $"{_l[0]}{((_l.Length > 1) ? $" {_l[1]}" : "")}";
                    
                    //Debug.WriteLine($"Comparison name({longName}) short({shortName}) d({description})");
                    bool blacklisted = false;
                    //Debug.WriteLine($"l2({l2}) d2({d2}) id({id}) shortName({shortName})");
                    if (!whitelist.Contains(id)) { 
                        foreach (string word in blacklist)
                        {
                            if (l2.ToLower().Contains(word) || shortName.ToLower().Contains(word) || d2.ToLower().Contains(word))
                            {
                                Debug.WriteLine($"Blacklisted {obj}({id}) containing {word}");
                                blacklisted = true;
                                break;
                            }
                            else if (l2.Equals(d2) && l2.Equals(shortName))
                            {
                                blacklisted = true;
                                Debug.WriteLine($"Blacklisted {obj}({id}) containing {(l2.Equals(d2) ? l2 : shortName)}");
                                break;
                            }
                        }
                    } else {
                        Debug.WriteLine($"Whitelisted item {obj}({id})");
                    }
                    /*                    if (blacklist.Contains(d.ToLowerInvariant()) || blacklist.Contains(longName.ToLower()) || blacklist.Contains(r.ToLower()))
                                        {
                                            Debug.WriteLine($"Blacklisted {obj}({id})");
                                            continue;
                                        } else if(r.Equals(description) && r.Equals(longName))
                                        {
                                            Debug.WriteLine($"Blacklisted {obj}({id})");
                                            continue;
                                        }*/
                    if (!blacklisted)
                    {
                        SetName(id, obj.ToString(), true);
                        SetName(id, longName);
                    }
                } 
            }
            //foreach(JProperty prop in nameCache.Values()) if(prop.Name.Contains("ShortName")) Debug.WriteLine($"Valid item {prop.Name}");
        }

        public void SetName(string id, string name, bool Short = false)
        {
            if (!itemCache.ContainsKey(id)) itemCache.Add(id, new CachedItem(id));
            CachedItem cacheItem = itemCache[id];
            if(Short) cacheItem.ShortName = name;
            else cacheItem.Name = name;
        }

        public void UpdateNameCache()
        {
            nameCache = JObject.Parse(File.ReadAllText(Form1.localesFile));
        }

        public static string GetReadableName(string id, bool Short = false)
        {
            string name = id;
            string lookup = id + (Short ? " ShortName" : " Name");
            if (nameCache[lookup] != null) name = nameCache[lookup].ToString();
            return name;
        }

        public void CacheNames(CacheType cacheType)
        {
            nameCache ??= JObject.Parse(File.ReadAllText(nameCachePath));
            string typePath = Form1.itemCache + "/" + cacheType.ToString().ToLower() + ".json";
            JObject cacheObject = JObject.Parse(File.ReadAllText(typePath));
            foreach (JToken jToken in cacheObject[""])
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

    public class CachedItem {
        public string Name, ShortName, ID;
        public CachedItem(string id) {
            ID = id;
        }

        override
        public string ToString()
        {
            return Name;
        }
    }
}
