using SharpCompress.Archives;
using SharpCompress.Archives.Rar;
using SharpCompress.Archives.SevenZip;
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
            if (toInstall == null) { Form1.log("Invalid mod to install."); return; }
            string modFilePath = toInstall.path.Replace("\\", "/");

            // Check if the downloaded mod file exists
            if (!File.Exists(modFilePath))
            {
                Form1.log($"Mod file '{modFilePath}' not found.");
                return;
            } // add a check to see if the mod is installed (outdated, or just replacing it) add a confirmation
            //Debug.WriteLine("Downloaded Path to install: " + modFilePath);
            bool success = false;
            switch(toInstall.extension)
            {
                case "zip":
                    success = ExtractZip(toInstall);
                    break;
                case "rar":
                    success = ExtractRar(toInstall);
                    break;
                case "7z":
                    success = Extract7z(toInstall);
                    break;
                case "dll":
                    success = MoveFile(toInstall);
                    break;
            }
            Form1.log(success ? $"Installed {toInstall.name} Successfully!" : $"Error Installing {toInstall.name}.");
        }

        private static bool AlreadyInstalled(DownloadedMod downloaded)
        {
            return false;
        }

        private static bool HasClientFolder(SharpCompress.Common.Entry entry)
        {
            return false;
        }
        private static bool HasBepinex(SharpCompress.Common.Entry entry)
        {
            return false;
        }

        private static bool Extract7z(DownloadedMod toInstall)
        {
            SevenZipArchive archive = SevenZipArchive.Open(toInstall.path);
            foreach(var entry in archive.Entries.Where(entry => entry.IsDirectory))
            {
                if (entry.Key.StartsWith("user/", StringComparison.OrdinalIgnoreCase)) toInstall.client = true;
                else if (entry.Key.StartsWith("bepinex/", StringComparison.OrdinalIgnoreCase)) toInstall.plugin = true;
                else if (entry.Key.EndsWith(".dll")) MoveFile(toInstall);
            }
            if (toInstall.client || toInstall.plugin) { archive.ExtractToDirectory(Paths.gameFolder); return true; }
            else { Process.Start("explorer.exe", $"/select,\"{toInstall.path}\""); Form1.log($"The 7z file does not contain the required 'Bepinex' or 'user' folders."); }
            return false;
        }

        private static bool ExtractRar(DownloadedMod toInstall)
        {
            RarArchive rar = RarArchive.Open(toInstall.path);
            foreach (var entry in rar.Entries.Where(entry => entry.IsDirectory))
            {
                if (entry.Key.StartsWith("user/", StringComparison.OrdinalIgnoreCase)) toInstall.client = true;
                else if (entry.Key.StartsWith("bepinex/", StringComparison.OrdinalIgnoreCase)) toInstall.plugin = true;
            }
            if (toInstall.client || toInstall.plugin) { rar.ExtractToDirectory(Paths.gameFolder); return true; }
            else { Process.Start("explorer.exe", $"/select,\"{toInstall.path}\""); Form1.log($"The rar file does not contain the required 'Bepinex' or 'user' folders."); }
            return false;
        }

        private static bool ExtractZip(DownloadedMod toInstall)
        {
            string modFilePath = @toInstall.path.Replace("\\", "/");
            try
            {
                ZipArchive archive = ZipFile.OpenRead(modFilePath);
                int folderCount = archive.Entries.Where(entry => Directory.Exists(entry.FullName)).Count();
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.StartsWith("bepinex/", StringComparison.OrdinalIgnoreCase))
                        toInstall.plugin = true;
                    else if (entry.FullName.StartsWith("user/", StringComparison.OrdinalIgnoreCase)) 
                        toInstall.client = true;
                }
                if (toInstall.plugin || toInstall.client)
                {
                    archive.ExtractToDirectory(Paths.gameFolder, true);
                    return true;
                }
                else if (folderCount == 1)
                {
                    archive.ExtractToDirectory($"{Paths.modsFolder}");
                    return true;
                }
                else
                {
                    Form1.log(modFilePath);
                    Process.Start("explorer.exe", modFilePath);
                    Form1.log($"The ZIP file does not contain the required 'Bepinex' or 'user' folders.");
                }
            }
            catch (Exception ex)
            {
                Form1.log($"An error occurred: {ex.Message}");
            }
            return false;
        }

        private static bool MoveFile(DownloadedMod toInstall)
        {
            string? dest = GetModDestination(toInstall);
            if (dest == null) { Form1.log("dest == null"); return false; }
            File.Move(toInstall.path, $"{dest}/{toInstall.name}.{toInstall.extension}");
            return true;
        }

        private static string? GetModDestination(DownloadedMod mod)
        {
            switch (mod.extension.ToLower())
            {
                case "dll":
                    return Paths.modsFolder;
                default:
                    break;
            }
            return null;
        }
    }

}
