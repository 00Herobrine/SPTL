using SPTLauncher.Components.Responses;

namespace SPTLauncher.Components.Presets
{
    [Serializable]
    internal struct LauncherPreset : Preset
    {
        public PresetInfo Info { get; set; }
        public readonly string type => "Launcher";
        public bool replace { get; set; }
        public List<Preset> Presets { get; set; }
/*        public ModPreset? modPreset { get; set; }
        public ProfilePreset? profilePreset { get; set; }
        public ResponsesPreset? responsePreset { get; set; }
        public ConfigStruct? launcherPreset { get; set; }
        public List<TraderPreset>? traderPresets { get; set; }*/

        public LauncherPreset(string lang)
        {
            Info = new PresetInfo();
            Presets = new List<Preset>
            {
                new ResponsesPreset(ResponseManager.GetResponses(lang))
            };
        }
    }
}
