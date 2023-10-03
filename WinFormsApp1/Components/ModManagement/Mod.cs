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
            name = path.Split("\\")[1];
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
            string type = IsPlugin() ? "[P]" : "[C]";
            string enabled = isEnabled() ? "" : " [DISABLED]";
            return $"{type} {name}{enabled}";
        }

        public string GetPath()
        {
            return path;
        }

        public string GetOriginalPath()
        {
            return originalPath;
        }

        public string GetName()
        {
            return name;
        }

        public bool IsPlugin()
        {
            return modType == ModType.PLUGIN || plugin;
        }

        public bool IsClient()
        {
            return modType == ModType.CLIENT || client;
        }
        public bool IsBoth()
        {
            return IsPlugin() && IsClient();
        }

        public ModType GetModType()
        {
            return modType;
        }

        public bool isEnabled()
        {
            return enabled;
        }

        public bool HasConfig()
        {
            return configPath != null;
        }

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

        public string? GetConfigPath()
        {
            return configPath;
        }
    }
}
