namespace SPTLauncher.Constructors
{
    public struct AkiData
    {
        public string akiVersion { get; set; }
        public string projectName { get; set; }
        public string compatibleTarkovVersion { get; set; }
        public string serverName { get; set; }
        public int profileSaveIntervalSeconds { get; set; }
        public string commit { get; set; }
    }
}
