using System.ComponentModel;
using System.Runtime.Serialization;

namespace SPTLauncher.Components
{
    public struct ConfigStruct
    {
        [DataMember(Name = "apiKey")]
        public string apiKey { get; set; }

        [DataMember(Name = "LastBackup")]
        public DateTime LastBackup { get; set; }

        [DataMember(Name = "BackupInterval"), DefaultValue(-1)]
        public int BackupInterval { get; set; }

        [DataMember(Name = "DisabledMods")]
        public Dictionary<string, string> DisabledMods { get; set; }

        [DataMember(Name = "Backups")]
        public bool Backups { get; set; }
        [DataMember(Name = "MinimizeOnLaunch"), DefaultValue(false)]
        public bool MinimizeOnLaunch { get; set; }
    }

    internal struct DisabledMod
    {
        public string originalPath { get; set; }
    }

    internal struct BackupSetting
    {
        public bool enabled { get; set; }
    }
}
