using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SPTLauncher.Components.Caching;
using SPTLauncher.Constructors;
using System.Diagnostics;
using System.Net.Http.Headers;
using WinFormsApp1;

namespace SPTLauncher.Components
{
    public enum CacheType
    {
        ARMOR, BACKPACKS, CLOTHING, HEADPHONES, HELMETS, RIGS, FIREARMS, AMMO, MAGAZINES, GRENADES,
        FOOD, CONTAINERS, ITEMS, KNIVES, KEYS, MAPS, MEDICALS, MODS, MONEY
    }
    public enum CacheTab { ARMOR, WEARABLES, WEAPONS, KEYS, CONSUMABLES, MISC }

    internal class TarkovCache
    {
        public static Dictionary<CacheType, CacheTab> tabs = new Dictionary<CacheType, CacheTab>
        {
        { CacheType.ARMOR, CacheTab.ARMOR },
        { CacheType.BACKPACKS, CacheTab.WEARABLES },
        { CacheType.CLOTHING, CacheTab.WEARABLES },
        { CacheType.HEADPHONES, CacheTab.WEARABLES },
        { CacheType.HELMETS, CacheTab.WEARABLES },
        { CacheType.RIGS, CacheTab.WEARABLES },
        { CacheType.FIREARMS, CacheTab.WEAPONS },
        { CacheType.AMMO, CacheTab.WEAPONS },
        { CacheType.MAGAZINES, CacheTab.WEAPONS },
        { CacheType.GRENADES, CacheTab.WEAPONS },
        { CacheType.FOOD, CacheTab.CONSUMABLES },
        { CacheType.CONTAINERS, CacheTab.MISC },
        { CacheType.ITEMS, CacheTab.MISC },
        { CacheType.KNIVES, CacheTab.WEAPONS },
        { CacheType.KEYS, CacheTab.KEYS },
        { CacheType.MAPS, CacheTab.MISC },
        { CacheType.MEDICALS, CacheTab.CONSUMABLES },
        { CacheType.MODS, CacheTab.MISC },
        { CacheType.MONEY, CacheTab.MISC }
        };
        public static Dictionary<CacheType, string> caches = new Dictionary<CacheType, string>();
        public static Dictionary<string, CachedItem> itemCache = new Dictionary<string, CachedItem>(); // itemID, cached item
        public static Dictionary<string, CachedQuest> questCache = new();
        private static JObject nameCache = new JObject();
        #region Filtering
        private static string[] blacklist = { "item", "weapon box", "stash", "equipment", "throwable weapon", "food and drink", "bear", "usec",
            "ammo", "functional mod", "pistolet", "pockets", "default inventory", "inventory", "secure folder", "bsample" };
        private static string[] whitelist =
        {
            "5e9db13186f7742f845ee9d3", // LBT-1961A Load Bearing Chest Rig
            "628baf0b967de16aab5a4f36", // LBCR Goons Edition
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
        #endregion

        public static void Initialize()
        {
            if (!Directory.Exists(Paths.itemCache)) Directory.CreateDirectory(Paths.itemCache);
            //if (!Directory.Exists(Paths.tarkovCachePath)) Directory.CreateDirectory(mainPath);
            GenerateCache();
        }


        public static void GenerateCache()
        {
            Form1.log("Launcher-Cache File Check.");
            bool missing = false;
            UpdateNameCache();
            ItemCheck();
            InitalizeQuestCache();
            if (string.IsNullOrWhiteSpace(Config.file.apiKey)) return;
            foreach (CacheType cacheType in Enum.GetValues<CacheType>())
            {
                //Debug.Write("Iterating " + cacheType);
                string cachePath = $"{Paths.itemCache}/{cacheType.ToString().ToLower()}.json";
                if (!File.Exists(cachePath))
                {
                    if (!missing) missing = true;
                    GenerateCacheFile(cacheType);
                }
                else caches[cacheType] = cachePath;
            }
            if (!missing) Form1.log("All files cached.");
        }

        private static string ReadQuestsFile()
        {
            return File.ReadAllText($"{Paths.databasePath}/templates/quests.json");
        }
        private static void InitalizeQuestCache()
        {
            try
            {
                string jsonData = ReadQuestsFile();
                questCache = JsonConvert.DeserializeObject<Dictionary<string, CachedQuest>>(jsonData) ?? new();
                Form1.log($"Loaded {questCache.Count} quests");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception while deserializing JSON: " + ex.Message);
            }
        }

        public static CachedQuest GetQuestByID(string id)
        {
            return questCache[id];
        }

        public static void ItemCheck()
        {
            foreach (JToken obj in nameCache.Values())
            {
                var parentProperty = (JProperty)obj.Parent;
                string name = parentProperty.Name;
                string id = name.Split(" ")[0];
                string shortName = obj.ToString();
                if (name.Contains("ShortName"))
                {
                    string description = nameCache[id + " Description"].ToString();
                    string[] _d = description.Split();
                    string d2 = $"{_d[0]}{(_d.Length > 2 ? $" {_d[1]} {_d[2]}" : "")}";
                    string longName = nameCache[id + " Name"].ToString();
                    string[] _l = longName.Split(" ");
                    string l2 = $"{_l[0]}{(_l.Length > 1 ? $" {_l[1]}" : "")}";
                    //Debug.WriteLine($"Comparison name({longName}) short({shortName}) d({description})");
                    bool blacklisted = false;
                    //Debug.WriteLine($"l2({l2}) d2({d2}) id({id}) shortName({shortName})");
                    if (!whitelist.Contains(id))
                    {
                        foreach (string word in blacklist)
                        {
                            if (l2.ToLower().Contains(word) || shortName.ToLower().Contains(word) || d2.ToLower().Contains(word))
                            {
                                //Debug.WriteLine($"Blacklisted {obj}({id}) containing {word}");
                                blacklisted = true;
                                break;
                            }
                            else if (l2.Equals(d2) && l2.Equals(shortName))
                            {
                                blacklisted = true;
                                //Debug.WriteLine($"Blacklisted {obj}({id}) containing {(l2.Equals(d2) ? l2 : shortName)}");
                                break;
                            }
                        }
                    }
                    else
                    {
                        //Debug.WriteLine($"Whitelisted item {obj}({id})");
                    }
                    if (!blacklisted)
                    {
                        SetName(id, obj.ToString(), true);
                        SetName(id, longName);
                    }
                }
            }
        }

        public static void SetName(string id, string name, bool Short = false)
        {
            if (!itemCache.ContainsKey(id)) itemCache.Add(id, new CachedItem(id));
            CachedItem cacheItem = itemCache[id];
            if (Short) cacheItem.ShortName = name;
            else cacheItem.Name = name;
        }

        public static void UpdateNameCache()
        {
            nameCache = JObject.Parse(File.ReadAllText(Paths.localesFile));
        }

        public static string GetReadableName(string id, bool Short = false)
        {
            return Cache.GetReadableNameFromID(id, Short);
            string name = id;
            string lookup = id + (Short ? " ShortName" : " Name");
            if (nameCache[lookup] != null) name = nameCache[lookup].ToString();
            return name;
        }

        public async static void GenerateCacheFile(CacheType cacheType)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.tarkov-changes.com/");

            var request = new HttpRequestMessage(HttpMethod.Get, "v1/" + cacheType.ToString().ToLower());
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.Add("AUTH-Token", Config.GetApiKey());

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                JToken jToken = JObject.Parse(responseBody);
                string typePath = $"{Paths.itemCache}/{cacheType.ToString().ToLower()}.json";
                File.WriteAllText(typePath, jToken["results"].ToString());
                Form1.log($"Generated cache for {cacheType}.");
                caches[cacheType] = typePath;
                //CacheNames(cacheType);
            }
            else
            {
                Form1.log("Failed to get cache for " + cacheType + " Status code: " + response.StatusCode);
            }
        }

        public JObject getCache(CacheType cacheType)
        {
            string cachePath = Paths.cachePath + "/" + cacheType.ToString().ToLower() + ".json";
            return JObject.Parse(File.ReadAllText(cachePath));
        }

    }

    public class CachedItem
    {
        public string Name, ShortName, ID;
        public CachedItem(string id)
        {
            ID = id;
        }

        override
        public string ToString()
        {
            return Name;
        }
    }
}
