using SPTLauncher.Utils;

namespace SPTLauncher.Components.ModManagement
{
    public static class Extensions
    {
        public static CompatibilityResult CompatibilityCheck(this Version version)
        {
            Version downloadVersion = version;
            Version AkiVersion = Version.Parse(LauncherSettings.AkiVersion);
            int difference = Math.Abs(downloadVersion.Minor - AkiVersion.Minor);
            difference += Math.Abs(downloadVersion.Major - AkiVersion.Major) * 10;
            return new CompatibilityResult(downloadVersion, AkiVersion, difference);
        }
        public static VersionCompatibility VersionCompatibilityCheck(this Version version) => VersionCompatibilityCheck(version, Version.Parse(LauncherSettings.AkiVersion));
        public static VersionCompatibility VersionCompatibilityCheck(this Version version, Version comparisonVersion)
        {
            int difference = Math.Abs(version.Minor - comparisonVersion.Minor);
            difference += Math.Abs(version.Major - comparisonVersion.Major) * 10;
            switch (difference)
            {
                case 0: return VersionCompatibility.Certain;
                case <= 1: return VersionCompatibility.Likely;
                case <= 3: return VersionCompatibility.Unlikely;
                case >= 4: return VersionCompatibility.Improbable;
            }
        }
        public static VersionStatus CompareVersions(this ModDownload download) => 
            FileManagement.VersionComparison(Version.Parse(download.formattedVersion), download.GetConfig == null ? Version.Parse("0.0.0") : download.GetVersion());
        public static ModConfig? GetConfig(this ModDownload download) => ModManager.GetConfig(download);
        public static ModConfig GetCreateConfig(this ModDownload download) => ModManager.HasConfig(download) ? (ModConfig)ModManager.GetConfig(download)! : ModManager.GenerateConfig(download);
        public static Version GetVersion(this ModDownload download) => Version.Parse(download.formattedVersion);
    }

    public class CompatibilityResult(Version version, Version version2, int difference)
    {
        public readonly Version initialVersion = version, versionComparedTo = version2;
        public readonly int difference = difference;
        public readonly VersionCompatibility Compatibility = version.VersionCompatibilityCheck(version2);
    }
}
