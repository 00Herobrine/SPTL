﻿using Newtonsoft.Json;
using SPTLauncher.Constructors.Enums;

namespace SPTLauncher.Components
{
    public struct ConfigStruct
    {
        [JsonProperty("apiKey")]
        public string apiKey { get; set; }

        [JsonProperty("LastBackup")]
        public DateTime LastBackup { get; set; }

        [JsonProperty("BackupInterval")]
        public int BackupInterval { get; set; }

        [JsonProperty("BackupsEnabled")]
        public bool Backups { get; set; }
        [JsonProperty("MinimizeOnLaunch")]
        public bool MinimizeOnLaunch { get; set; }
        [JsonProperty("ImageCaching")]
        public bool ImageCaching { get; set; }
        [JsonProperty("AutoUpdate")]
        public bool AutoUpdate { get; set; }
        [JsonProperty("AutoScrollConsole")]
        public bool AutoScroll { get; set; }
        [JsonProperty("Lang")]
        public LANG Lang { get; set; }
        [JsonProperty("DisabledMods")]
        public Dictionary<string, string> DisabledMods { get; set; }


        public ConfigStruct()
        {
            // Initialize properties with default values.
            apiKey = "";
            LastBackup = DateTime.MinValue;
            DisabledMods = new Dictionary<string, string>();
            BackupInterval = 60;
            AutoScroll = true;
            Backups = false;
            Lang = LANG.EN;
            MinimizeOnLaunch = false;
            ImageCaching = true;
        }
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
