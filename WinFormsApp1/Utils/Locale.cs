using SPTLauncher.Components;
using SPTLauncher.Constructors.Enums;

namespace SPTLauncher.Utils
{
    public static class Locale
    {
        public static LANG language => LauncherSettings.language;
        public static string ReadLocaleFromFile(LANG language) => ReadLocaleFromFile(language.ToString());
        public static string ReadLocaleFromFile(string localeString) => File.ReadAllText($"{Paths.localesFile}/{localeString}.json");
    }
}
