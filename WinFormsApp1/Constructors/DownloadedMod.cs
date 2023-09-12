using SPTLauncher.Components;

namespace SPTLauncher.Constructors
{
    internal class DownloadedMod
    {
        public string name, extension, path, akiVersion = "";
        public bool client = false, plugin = false;

        public DownloadedMod(string path, string name, string extension)
        {
            this.name = name;
            this.path = path;
            this.extension = extension;
        }
    }
}
