using Newtonsoft.Json;
using SPTLauncher.Constructors.Enums;

namespace SPTLauncher.Utils
{
    internal class LocaleFile
    {
        public LANG lang { get; }
        public string path { get; }
        public LocaleFile(string path)
        {
            string typeName = Path.GetFileName(path);
            lang = Enum.Parse<LANG>(typeName.Split(".")[0]);
            this.path = path;
        }

        public override string ToString() => lang.ToString();
        public string Read() => File.ReadAllText(path);
        public Dictionary<string, string> ReadFileAsDictionary() => JsonConvert.DeserializeObject<Dictionary<string, string>>(Read()) ?? new();
        public Dictionary<string, string> GetValuesFromKey(string key) => ReadFileAsDictionary().Where(o => o.Key.StartsWith(key)).ToDictionary(o => o.Key, o => o.Value);
        public string GetValueFromKey(string key) => ReadFileAsDictionary()[key];
        public string GetItemDescription(string id) => GetValueFromKey($"{id} Description");
        public string GetItemName(string id) => GetValueFromKey($"{id} Name");
        public string GetShortName(string id) => GetValueFromKey($"{id} ShortName");
        public QuestLocale GetQuestLocale(string id) => new(id, GetValuesFromKey(id));
        public string GetQuestDescription(string id) => GetValueFromKey($"{id} description");
    }

    internal struct QuestLocale
    {
        string id { get; }
        public string name { get; set; }
        public string acceptPlayerMessage { get; set; }
        public string completePlayerMessage { get; set; }
        public string declinePlayerMessage { get; set; }
        public string description { get; set; }
        public string failMessageText { get; set; }
        public string successMessageText { get; set; }
        public QuestLocale(string id, Dictionary<string, string> entry)
        {
            this.id = id;
            name = entry[$"{id} name"];
            acceptPlayerMessage = entry[$"{id} acceptPlayerMessage"];
            completePlayerMessage = entry[$"{id} completePlayerMessage"];
            declinePlayerMessage = entry[$"{id} declinePlayerMessage"];
            description = entry[$"{id} description"];
            failMessageText = entry[$"{id} failMessageText"];
            successMessageText = entry[$"{id} successMessageText"];
        }
    }

    internal struct ItemLocale
    {
        public string id { get; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
    }
}
