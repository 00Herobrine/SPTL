namespace SPTLauncher.Constructors.Profiles
{
    public struct ProfileStruct
    {
        public LocalProfileInfo info { get; set; }
        public Dictionary<string, string> inraid { get; }
        public ProfileCharacters characters { get; set; }

        public readonly bool IsInRaid => !inraid["location"].Equals("none");
        public readonly string LastCharacter => inraid["character"];
    }
}
