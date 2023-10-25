namespace SPTLauncher.Components.Presets
{
    internal struct PresetInfo
    {
        public string? Author { get; set; } // Author of Preset
        public string? Name { get; set; } // Name of Preset
        public string? Description { get; set; } // Description of what it does
        public string? AkiVersion { get; set; } // AkiVersion Config was Created on

        public PresetInfo()
        {
            AkiVersion = LauncherSettings.akiData.akiVersion;
        }
    }
}
