using SPTLauncher.Components;

namespace SPTLauncher.Constructors.Presets
{
    internal struct PresetInfo
    {
        public string? Author { get; set; }
        public string? Description { get; set; }
        public string? AkiVersion { get; set; }
        public bool Replace { get; set; }

        public PresetInfo()
        {
            AkiVersion = LauncherSettings.akiData.akiVersion;
            Replace = false;
        }
    }
}
