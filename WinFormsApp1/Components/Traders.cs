using Newtonsoft.Json.Linq;
using SPTLauncher.Constructors;

namespace SPTLauncher.Components
{
    internal class Traders
    {
        public static Dictionary<string, Trader> traders = new();
        public static string? tradersFilePath;
        public int updateTimeDefault = 3600;
        public bool purchasesAreFoundInRaid = false;
        public int traderPriceMultiplier = 1;

        public static void Initialize()
        {
            tradersFilePath = $"{Paths.serverConfigsPath}/trader.json";
            string file = ReadTradersFile();
            JObject jobject = JObject.Parse(file);
            foreach (string folder in Directory.GetDirectories($"{Paths.databasePath}/traders"))
            { // need to pass the base.json
                string[] path = folder.Split(Path.DirectorySeparatorChar);
                string traderID = path[^1];
                traders.Add(traderID, new(folder));
            }
        }

        public static List<Trader> GetTraders()
        {
            return traders.Values.ToList();
        }
/*        public static Dictionary<string, Trader> GetTraders()
        {
            return traders;
        }*/

        public static Trader GetTrader(string id)
        {
            return traders[id];
        }
        public static string GetTraderName(string id)
        {
            return traders[id].nickname;
        }

        public static string ReadTradersFile()
        {
            return File.ReadAllText(tradersFilePath);
        }
    }
}
