using System.ComponentModel;

namespace SPTLauncher.Components.ModManagement.Downloader
{
    public enum ORIGIN
    {
        [Description("github.com")]
        GITHUB,
        [Description("drive.google.com")]
        GOOGLE,
        [Description("dropbox.com")]
        DROPBOX,
        [Description("sp-tarkov.com")]
        SPT,
        DIRECT,
        INVALID
    }
}
