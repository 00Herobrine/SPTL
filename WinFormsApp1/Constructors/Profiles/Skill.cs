using Newtonsoft.Json;

namespace SPTLauncher.Constructors.Profiles
{
    public struct Skill
    {
        [JsonProperty("Id")]
        public string name { get; set; }
        [JsonProperty("Progress")]
        public float progress { get; set; }
        [JsonProperty("PointsEarnedDuringSession")]
        public float PointsEarnedDuringSession { get; set; }
        [JsonProperty("LastAccess")]
        public int LastAccessedInMillis { get; set; }
        public override string ToString() => name;
    }
}
