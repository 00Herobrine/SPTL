using SPTLauncher.Utils;

namespace SPTLauncher.Components.ModManagement.Types
{
    internal class ExtractedMod
    {
        public string path;
        public ExtractedMod(string path)
        {
            this.path = path;
        }
        public override string ToString() => $"[{Type}] {path}";
        public string pluginsPath => $"{path}/bepinex/plugins";
        public string modsPath => $"{path}/user/mods";
        public string FolderName => Path.GetDirectoryName(path)!;
        public string[] Files => Directory.GetDirectories($"{path}");
        public ModType Type => Files.Any(o => o.Contains("bepinex", true)) ? Files.Any(o => o.Contains("user", true)) ? ModType.BOTH : ModType.PLUGIN : ModType.CLIENT;
        public string[] GetPluginFiles() => Directory.Exists(pluginsPath) ? Directory.GetFiles(pluginsPath) : [];
        public string[] GetPluginFolders() => Directory.Exists(pluginsPath) ? Directory.GetDirectories(pluginsPath) : [];
        public string[] GetModFiles() => Directory.Exists(modsPath) ? Directory.GetFiles(modsPath) : [];
        public string[] GetModFolders() => Directory.Exists(modsPath) ? Directory.GetDirectories(modsPath) : [];
        public string GetJunctionFile() => GetPluginFolders().Length > 0 ? GetPluginFolders()[0] : GetPluginFiles()[0];
        public string CreatePluginJunction() => FileManagement.CreateJunction(GetJunctionFile(), Paths.pluginsFolder);
        public string CreateModJunction() => FileManagement.CreateJunction(GetModFiles().First(), Paths.modsFolder);
        public void CreateJunction()
        {
            if (GetPluginFolders().Length > 0) CreatePluginJunction();
            if (GetModFiles().Length > 0) CreateModJunction();
        }
    }
}
