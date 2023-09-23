using SharpCompress.Archives;
using SharpCompress.Common;
using SPTLauncher.Constructors;
using System.Diagnostics;
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
                    success = ExtractArchive(toInstall);
                    break;
                case "rar":
                    success = ExtractArchive(toInstall);
                    break;
                case "7z":
                    success = ExtractArchive(toInstall);
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

        private static bool HasClientFolder(Entry entry)
        {
            return false;
        }
        private static bool HasBepinex(Entry entry)
        {
            return false;
        }
        private static bool DirectoryIsBepinex(string dir)
        {
            return dir.Contains("/bepinex");
        }
        private static string GetDestination(string path)
        {
            if (path.Contains("patchers")) return Paths.akiData + "/patchers";
            else if (path.Contains("bepinex")) return Paths.pluginsFolder;
            else if (path.Contains("user")) return Paths.modsFolder;
            else return Paths.pluginsFolder;
        }
        private static readonly string[] modFiles = [ "mod.ts", "package.json", "mod.js" ];
        private static bool ExtractArchive(DownloadedMod toInstall)
        {
            IArchive archive = ArchiveFactory.Open(toInstall.path);
            if (archive == null) return false;

            try
            {
                List<string> rootFolders = GetRootFolders(archive);
                //foreach (string e in rootFolders) Form1.log(e);
                foreach (IArchiveEntry entry in archive.Entries)
                {
                    if (IsDllFile(entry.Key))
                    {
                        entry.WriteToDirectory(GetDestination(entry.Key));
                        return true;
                    }
                    HandleModEntry(entry.Key, toInstall);
                }

                if (toInstall.subrooted)
                    return ExtractSubrootedArchive(archive, rootFolders);
                else if (rootFolders.Count == 1 && toInstall.client)
                    return ExtractSingleRootArchive(archive, rootFolders, toInstall);
                else if (toInstall.plugin || toInstall.client)
                {
                    archive.ExtractToDirectory(Paths.gameFolder);
                    return true;
                }
                else HandleMissingFolders(toInstall);
            }
            catch (Exception ex)
            {
                Form1.log($"An error occurred: {ex.Message}");
            }

            return false;
        }

        private static List<string> GetRootFolders(IArchive archive)
        {
            return archive.Entries
                .Where(entry => entry.IsDirectory)
                .Select(entry => entry.Key.Replace(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar).Split(Path.AltDirectorySeparatorChar)[0])
                .Distinct()
                .ToList();
        }

        private static bool IsDllFile(string entryKey)
        {
            return entryKey.EndsWith(".dll", StringComparison.OrdinalIgnoreCase);
        }

        private static void HandleModEntry(string entryKey, DownloadedMod toInstall)
        {
            entryKey = FormatPathChars(entryKey);
            string file = entryKey.Split("/").Last();
            //Form1.log("Checking " + entryKey + " F: " + modFiles.Contains(file));
            if (entryKey.StartsWith($"bepinex{Path.DirectorySeparatorChar}", StringComparison.OrdinalIgnoreCase))
            {
                toInstall.plugin = true;
                if (entryKey.Contains($"/bepinex/", StringComparison.OrdinalIgnoreCase))
                {
                    toInstall.subrooted = true;
                }
            }
            else if (entryKey.StartsWith("user/", StringComparison.OrdinalIgnoreCase))
            {
                toInstall.client = true;
                if (modFiles.Contains(entryKey.Split('/').Last()))
                {
                    toInstall.subrooted = true;
                }
            }
            else if (modFiles.Contains(file))
            {
                toInstall.client = true;
            }
        }
        private static string FormatPathChars(string input)
        {
            return input.Replace(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
        }

        private static bool ExtractSubrootedArchive(IArchive archive, List<string> rootFolders)
        {
            try
            {
                foreach (var entry in archive.Entries.Where(entry => entry.IsDirectory))
                {
                    string path = DirectoryIsBepinex(entry.Key) ? Paths.pluginsFolder : Paths.modsFolder;
                    entry.WriteToDirectory(path);
                    return true;
                }
            } catch (Exception e) { Form1.log(e.Message); return false; }
            return false;
        }

        private static bool ExtractSingleRootArchive(IArchive archive, List<string> rootFolders, DownloadedMod toInstall)
        {
            try
            {
                string folderName = archive.Entries.First(entry => entry.IsDirectory).Key;
                bool custom = !folderName.Equals("user");
                archive.ExtractToDirectory(custom ? Paths.modsFolder : Paths.gameFolder);
                return true;
            } catch(Exception e) { Form1.log(e.Message); return false; }
        }

        private static void HandleMissingFolders(DownloadedMod toInstall)
        {
            Form1.log(toInstall.path.Replace("\\", "/"));
            Process.Start("explorer.exe", Paths.downloadingPath);
            Form1.log($"The {toInstall.extension} file does not contain the required 'Bepinex' or 'user' folders.");
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
                    return Paths.pluginsFolder;
                default:
                    break;
            }
            return null;
        }
    }

}
