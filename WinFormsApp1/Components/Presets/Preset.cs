using Newtonsoft.Json;

namespace SPTLauncher.Components.Presets
{
    internal interface Preset
    {
        public string type { get; }
        public bool replace { get; }

        public void export(string fileName)
        {
            File.WriteAllText(fileName, JsonConvert.SerializeObject(this, Formatting.Indented));
        }
    }
}
