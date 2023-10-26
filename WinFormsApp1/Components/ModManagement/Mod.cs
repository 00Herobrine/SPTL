using WinFormsApp1;

namespace SPTLauncher.Components.ModManagement
{
    public class Mod
    {
        private string path;
        private string name;
        private string? configPath;
        private string originalPath;
        private bool enabled, plugin = false, client = false;
        private ModType modType = ModType.CLIENT;

        public Mod(string path)
        {
            this.path = path;
            name = Path.GetFileName(path);
            string configPath = path + "/config/config.json";
            if (File.Exists(configPath)) this.configPath = configPath;
            enabled = !path.Contains(Paths.disabledModsPath);
            if (!enabled) originalPath = Config.GetDisabledModPath(name);
            else originalPath = path;
            if (originalPath.ToLower().Contains("bepinex/plugins")) { modType = ModType.PLUGIN; plugin = true; }
            if (originalPath.ToLower().Contains("user")) { client = true; }
        }

        public override string ToString()
        {
            string type = IsPlugin ? "[P]" : "[C]";
            string enabled = IsEnabled ? "" : " [DISABLED]";
            return $"{type} {name}{enabled}";
        }

        public string FilePath => path;
        public string OriginalPath => originalPath;
        public string Name => name;
        public bool IsPlugin => modType == ModType.PLUGIN || plugin;
        public bool IsClient => modType == ModType.CLIENT || client;
        public bool IsBoth => IsPlugin && IsClient;
        public ModType Type => modType;
        public bool IsEnabled => enabled;
        public bool HasConfig => configPath != null;
        public string? ConfigPath => configPath;

        public void Toggle()
        {
            if (enabled) Disable();
            else Enable();
        }
        public void Enable()
        {
            Config.EnableMod(this);
            enabled = true;
        }

        public void Disable()
        {
            Config.DisableMod(this);
            enabled = false;
        }

        public void SetPath(string path)
        {
            this.path = path;
        }

    }
}
