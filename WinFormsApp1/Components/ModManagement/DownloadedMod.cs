namespace SPTLauncher.Components.ModManagement
{
    internal class DownloadedMod
    {
        public string name, extension, path, akiVersion = "";
        public bool client = false, plugin = false, subrooted = false;
        public ModDownload toInstall;

        public DownloadedMod(string path, string name, string extension, ModDownload toInstall)
        {
            this.name = name;
            this.path = path;
            this.extension = extension;
            this.toInstall = toInstall;
        }
    }
}
