using SPTLauncher.Components.Responses;

namespace SPTLauncher.Constructors.Presets
{
    [Serializable]
    internal struct ResponsesPreset
    {
        public PresetInfo Info { get; set; }
        public List<Response> Responses { get; set; }

        public ResponsesPreset(List<Response> responses)
        {
            Info = new PresetInfo();
            Responses = responses;
        }
    }
}
