using Newtonsoft.Json.Linq;
using SPTLauncher.Components.Presets;

namespace SPTLauncher.Components.Responses
{
    public class ResponseManager
    {
        private static Dictionary<ResponseType, List<int>> responseInts = new();
        public static List<Response> GetResponses(string lang, ResponseType? type = null)
        {
            List<Response> responses = new List<Response>();
            responseInts = new();
            string text = ReadLocaleFile(lang);
            JObject jObject = JObject.Parse(text);
            foreach (var entry in jObject)
            {
                if (!entry.Key.StartsWith("pmcresponse-") || entry.Key.EndsWith("unable_to_find_key") || (type != null && entry.Key.Contains(((ResponseType)type).ToString(), StringComparison.OrdinalIgnoreCase))) continue;
                Response response = new(entry);
                responses.Add(response);
                AddID(response);
            }
            return responses;
        }
        private static void AddID(Response response) => (responseInts.TryGetValue(response.type, out var list) ? list : (responseInts[response.type] = new List<int>())).Add(response.id);
        private static void RemoveID(Response response) => responseInts[response.type].Remove(response.id);
        private static int GenerateReponseID(ResponseType type)
        {
            List<int> usedIDs = responseInts[type];
            int id = 1;
            while (usedIDs.Contains(id)) id++; // hopefully people don't make a bajillion of em
            return id;
        }
        public static Response CreateResponse(string lang, ResponseType type)
        {
            Response response = new(GenerateReponseID(type), type);
            AddID(response);
            TryUpdateResponse(lang, response);
            return response;
        }
        public static void RemoveResponse(string lang, Response response)
        {
            JObject jsonObject = JObject.Parse(ReadLocaleFile(lang));
            if (jsonObject.ContainsKey(response.RawName)) jsonObject.Remove(response.RawName);
            RemoveID(response);
            WriteToLocaleFile(lang, jsonObject.ToString());
        }
        public static void TryUpdateResponse(string lang, Response response)
        {
            JObject jsonObject = JObject.Parse(ReadLocaleFile(lang));
            if (jsonObject.ContainsKey(response.RawName)) jsonObject[response.RawName] = response.message;
            else jsonObject.Add(response.RawName, response.message);
            WriteToLocaleFile(lang, jsonObject.ToString());
        }
        public static void ImportResponse(string lang, Response response, bool replace = false)
        {
            JObject jsonObject = JObject.Parse(ReadLocaleFile(lang));
            if (jsonObject.ContainsKey(response.RawName))
                if (!replace)
                {
                    response.SetID(GenerateReponseID(response.type));
                    jsonObject.Add(response.RawName, response.message);
                }
                else jsonObject[response.RawName] = response.message;
            else jsonObject.Add(response.RawName, response.message);
            WriteToLocaleFile(lang, jsonObject.ToString());
        }
        private static void WriteToLocaleFile(string lang, string updatedFile) => File.WriteAllText($"{Paths.databasePath}/locales/server/{lang}.json", updatedFile);
        private static string ReadLocaleFile(string lang) => File.ReadAllText($"{Paths.databasePath}/locales/server/{lang}.json");
        internal static void ImportPreset(string lang, Preset preset) => ImportPreset(lang, (ResponsesPreset)preset);
        internal static void ImportPreset(string lang, ResponsesPreset preset)
        {
            foreach(Response response in preset.Responses) ImportResponse(lang, response, preset.replace); //
        }
    }
}
