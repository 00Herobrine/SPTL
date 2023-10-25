namespace SPTLauncher.Components.Profiles
{
    internal struct ProfileAkiInfo
    {
        public string version { get; }
        public List<ProfileModInfo> mods { get; }
        public ProfileAkiInfo()
        {
            // version = set this to current aki version
            mods = new List<ProfileModInfo>();
        }
    }

    internal struct ProfileModInfo
    {
        public string author { get; }
        public int dateAdded { get; }
        public string name { get; }
        public string version { get; }
    }
}
