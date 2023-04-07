using WinFormsApp1;

namespace SPTLauncher.Constructors
{
    public class Mod
    {
        private string path;
        private string name;
        private string configPath;
        private string originalPath;
        private bool enabled, plugin = false;

        public Mod(string path)
        {
            this.path = path;
            name = path.Split("\\")[1];
            string configPath = path + "/config/config.json";
            if (File.Exists(configPath)) this.configPath = configPath;
            enabled = !path.Contains("DisabledMods");
            if (!enabled) originalPath = Form1.form.GetConfig().GetDisabledModPath(name);
            else originalPath = path;
            if (originalPath.Contains("bepinex/plugins")) plugin = true;
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

        public bool isPlugin()
        {
            return plugin;
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

    }
}
