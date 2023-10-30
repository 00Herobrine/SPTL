using SPTLauncher.Utils;

namespace SPTLauncher.Components.ModManagement
{
    public static class Extensions
    {
        public static VersionStatus CompareVersions(this ModDownload download) => 
            FileManagement.VersionComparison(Version.Parse(download.formattedVersion), download.GetConfig == null ? Version.Parse("0.0.0") : download.GetVersion());
        public static ModConfig? GetConfig(this ModDownload download) => ModManager.GetConfig(download);
        public static ModConfig GetCreateConfig(this ModDownload download) => ModManager.HasConfig(download) ? (ModConfig)ModManager.GetConfig(download)! : ModManager.GenerateConfig(download);
        public static Version GetVersion(this ModDownload download) => Version.Parse(download.formattedVersion);

        //public static ModConfig GetConfig(this DownloadedMod downloaded) => ModManager.GetConfig(downloaded);
    }
}
