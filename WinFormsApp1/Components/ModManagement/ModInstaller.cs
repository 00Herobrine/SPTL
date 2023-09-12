using SPTLauncher.Constructors;
using System.IO.Compression;
using WinFormsApp1;

namespace SPTLauncher.Components.ModManagement
{
    internal class ModInstaller
    {
        public static void Install(DownloadedMod toInstall)
        {
            if (toInstall == null)
            {
                Form1.form.log("Invalid mod to install.");
                return;
            }

            string modFilePath = toInstall.path;

            // Check if the mod file exists
            if (!File.Exists(modFilePath))
            {
                Form1.form.log($"Mod file '{modFilePath}' not found.");
                return;
            }

            // Check if it's a ZIP file
            //string extension = modFilePath.Split(".")[^0];
            //Form1.form.log("Got extension " + extension);
            //if(ModManager.allowedFileTypes.Contains(modFilePath) ) { }
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
                    // Check for the presence of Bepinex folder
                    if (entry.FullName.StartsWith("Bepinex/", StringComparison.OrdinalIgnoreCase))
                    {
                        foundBepinex = true;
                    }

                    // Check for the presence of User folder
                    if (entry.FullName.StartsWith("user/", StringComparison.OrdinalIgnoreCase))
                    {
                        foundUser = true;
                    }
                }

                if (foundBepinex || foundUser)
                {
                    string bepinexPath = $@"{Paths.gameFolder}";
                    string userPath = $@"{Paths.gameFolder}";

                    // Extract the Bepinex and User folders to their respective paths
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        if (entry.FullName.StartsWith("Bepinex/", StringComparison.OrdinalIgnoreCase))
                        {
                            string destinationPath = Path.Combine(bepinexPath, entry.FullName[..8]);
                            entry.ExtractToFile(bepinexPath, true);
                        }
                        else if (entry.FullName.StartsWith("user/", StringComparison.OrdinalIgnoreCase))
                        {
                            string destinationPath = Path.Combine(userPath, entry.FullName[..5]);
                            entry.ExtractToFile(userPath, true);
                        }
                    }

                    Form1.form.log("Mod installation successful.");
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
