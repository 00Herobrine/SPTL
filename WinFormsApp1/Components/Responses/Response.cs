using Newtonsoft.Json.Linq;
using System.Runtime.CompilerServices;

namespace SPTLauncher.Components.Responses
{
    public class Response
    {
        // {{PlayerName}} {{PlayerSide}}
        //pmcresponse-type_{#}
        public int id;
        public ResponseType type;
        public string message;

        public Response(int id, ResponseType type, string message = "")
        {
            this.id = id;
            this.type = type;
            this.message = message;
        }
        public Response(KeyValuePair<string, object> ResponseKV)
        {
            type = GetResponseType(ResponseKV.Key);
            message = ResponseKV.Value.ToString() ?? "";
        }

        public Response(KeyValuePair<string, JToken?> entry)
        {
            type = GetResponseType(entry.Key);
            message = entry.Value?.ToString() ?? "";
        }

        public Response(ResponseType type, string message)
        {
            this.type = type;
            this.message = message;
        }

        public ResponseType GetResponseType(string key)
        {
            string[] split = key.Replace("pmcresponse-", "", StringComparison.OrdinalIgnoreCase).Split("_");
            string suffix = IsInteger(split[1]) ? "" : $"_{split[1]}";
            if (IsInteger(split[1])) SetID(split[1]); 
            else SetID(split[2]);
            return (ResponseType)Enum.Parse(typeof(ResponseType), $"{split[0]}{suffix}", true);
        }
        public override string ToString() => $"{type}_{id}";
        public void SetID(string id) => SetID(int.Parse(id));
        public void SetID(int id) => this.id = id;
        public static bool IsInteger(string input) => int.TryParse(input, out _);
        public static readonly ResponseType[] positiveResponses = [ResponseType.Killer_Positive, ResponseType.Victim_Positive];
        public static readonly ResponseType[] negativeResponses = [ResponseType.Killer_Negative, ResponseType.Victim_Negative];
        public static readonly ResponseType[] pleadingResponses = [ResponseType.Killer_Plead, ResponseType.Victim_Plead];
        public bool IsPositive => positiveResponses.Contains(type);
        public bool IsNegative => negativeResponses.Contains(type);
        public bool IsPlead => pleadingResponses.Contains(type);
        public bool IsSuffix => type == ResponseType.Suffix;
        public string RawName => $"pmcresponse-{ToString().ToLower()}";
    }
}
