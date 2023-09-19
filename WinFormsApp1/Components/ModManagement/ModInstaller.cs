using SPTLauncher.Constructors;
using System.Diagnostics;
using System.IO.Compression;
using WinFormsApp1;

namespace SPTLauncher.Components.ModManagement
{
    internal class ModInstaller
    {
        public static void Install(DownloadedMod toInstall)
        {
            if (toInstall == null) { Form1.form.log("Invalid mod to install."); return; }
            string modFilePath = toInstall.path.Replace("\\", "/");

            // Check if the downloaded mod file exists
            if (!File.Exists(modFilePath))
            {
                Form1.form.log($"Mod file '{modFilePath}' not found.");
                return;
            } // add a check to see if the mod is installed (outdated, or just replacing it) add a confirmation
            Debug.WriteLine("Downloaded Path to install: " + modFilePath);

            if (!modFilePath.EndsWith(".zip", StringComparison.OrdinalIgnoreCase))
            {
                Form1.form.log("The provided mod file is not a ZIP file.");
                return;
            }

            try
            {
                ZipArchive archive = ZipFile.OpenRead(modFilePath);
                bool foundBepinex = false;
                bool foundUser = false;
                List<string> files = new();

                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.StartsWith("bepinex/", StringComparison.OrdinalIgnoreCase))
                        foundBepinex = true;
                    else if (entry.FullName.StartsWith("user/", StringComparison.OrdinalIgnoreCase))
                        foundUser = true;
                }

                if (foundBepinex || foundUser)
                {
                    archive.ExtractToDirectory(Paths.gameFolder, true);
                    Form1.form.log($"Installation for {toInstall.name} successful.");
                }
                else
                {
                    Form1.form.log($"The ZIP file does not contain the required 'Bepinex' or 'user' folders.");
                    Form1.form.log($"Contains: {files.ToArray()}");
                }
            }
            catch (Exception ex)
            {
                Form1.form.log($"An error occurred: {ex.Message}");
            }
        }
    }   
}
