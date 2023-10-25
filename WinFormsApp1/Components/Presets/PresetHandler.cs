using SPTLauncher.Components.Responses;

namespace SPTLauncher.Components.Presets
{
    internal class PresetHandler
    {
        public static LauncherPreset GetLauncherPreset() => GetLauncherPreset(LauncherSettings.language.ToString());
        public static LauncherPreset GetLauncherPreset(string lang) => new LauncherPreset(lang);

        public static void InstallPreset(string lang, Preset preset)
        {
            switch (preset.type)
            {
                case "Responses": ResponseManager.ImportPreset(lang, preset); break;
                //case "Recipes": RecipeManager.InstallPreset(lang, preset); break;
                //case "Launcher": 
            }
        }

        private static void InstallLauncherPreset(Preset preset)
        {
            LauncherPreset launcherPreset = (LauncherPreset)preset;
        }

        public static string? ExportPreset(Preset preset)
        {
            SaveFileDialog exportDialog = new()
            {
                Title = "Export Response Preset",
                Filter = "Json Files (*.json)|*.json",
                FileName = $"{preset.type}.json",
                AddExtension = true,
            };
            if (exportDialog.ShowDialog() == DialogResult.OK)
            {
                preset.export(exportDialog.FileName);
                return exportDialog.FileName;
            }
            return null;
        }
    }
}
