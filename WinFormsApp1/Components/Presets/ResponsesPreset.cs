using SPTLauncher.Components.Responses;

namespace SPTLauncher.Components.Presets
{
    [Serializable]
    internal struct ResponsesPreset : Preset
    {
        public readonly string type => "Response";
        public bool replace { get; set; }
        public List<Response> Responses { get; set; }

        public ResponsesPreset(List<Response> responses)
        {
            Responses = responses;
        }

    }
}
