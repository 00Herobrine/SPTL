namespace SPTLauncher.Components.Profiles
{
    public struct LocalProfileInfo // Eventually will replace the AkiLauncher ProfileInfo I hope
    {
        public string id { get; }
        public string username { get; set; }
        public string password { get; set; }
        public bool wipe { get; set; }
        public string edition { get; set; }
    }
}
