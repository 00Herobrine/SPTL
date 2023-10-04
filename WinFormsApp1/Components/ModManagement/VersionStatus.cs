namespace SPTLauncher.Components.ModManagement
{
    public enum VersionStatus
    {
        Outdated, // local file is outdated
        Newer, // local file is newer than online somehow
        Match, // local file is a match
        None // uh doesn't exist
    }
}
