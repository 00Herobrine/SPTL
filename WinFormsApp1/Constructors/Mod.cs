using SPTLauncher.Components;
using WinFormsApp1;

namespace SPTLauncher.Constructors
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
            enabled = !path.Contains("DisabledMods");
            if (!enabled) originalPath = Form1.form.GetConfig().GetDisabledModPath(name);
            else originalPath = path;
            if (originalPath.Contains("bepinex/plugins")) { modType = ModType.SERVER; plugin = true; }
            if (originalPath.Contains("user")) { client = true; }
        }

        public override string ToString()
        {
            string type = IsPlugin() ? "[P]" : "[C]";
            string enabled = isEnabled() ? "" : " [DISABLED]";
            return $"{name} {type}{enabled}";
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
            return (modType == ModType.SERVER || plugin);
        }

        public bool IsClient()
        {
            return (modType == ModType.CLIENT || client);
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

        public void Enable()
        {
            Form1.form.GetConfig().EnableMod(this);
            enabled = true;
        }

        public void Disable()
        {
            Form1.form.GetConfig().DisableMod(this);
            enabled = false;
        }

        public string? GetConfigPath()
        {
            return configPath;
        }
    }
}
