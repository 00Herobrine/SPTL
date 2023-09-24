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
            return dir.Contains("/bepinex", StringComparison.OrdinalIgnoreCase);
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
                List<string> rootFiles = GetRootFiles(archive);
                bool hasDlls = false;
                foreach (var file in rootFiles) if (!hasDlls && IsDllFile(file)) { hasDlls = true; break; }
                foreach (IArchiveEntry entry in archive.Entries) HandleModEntry(entry.Key, toInstall);
                Form1.log("Is Subrooted? " + toInstall.subrooted);
                foreach (var folder in rootFolders) Form1.log("Folder: " + folder);
                if (toInstall.subrooted)
                    return ExtractSubrootedArchive(archive);
                else if (rootFolders.Count == 1 && !rootFolders[0].Equals("user") && toInstall.client)
                    return ExtractSingleRootArchive(archive);
                else if (toInstall.plugin || toInstall.client)
                {
                    archive.ExtractToDirectory(Paths.gameFolder);
                    return true;
                } else if(hasDlls)
                {
                    List<string> updatedList = rootFiles.Concat(rootFolders).Distinct().ToList();
                    return ExtractFilesFromArchive(archive, updatedList, true);
                }
                else HandleMissingFolders(toInstall);
            }
            catch (Exception ex)
            {
                Form1.log($"An error occurred: {ex.Message}");
            }

            return false;
        }

        private static List<string> GetRootFiles(IArchive archive)
        {
            return archive.Entries
                .Where(entry => !entry.IsDirectory && entry.Key.Contains('.'))
                .Select(entry => entry.Key.Replace(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
                .Split(Path.AltDirectorySeparatorChar)[0])
                .Distinct()
                .ToList();
        }

        private static List<string> GetRootFolders(IArchive archive)
        {
                return archive.Entries
                .Select(entry => entry.Key.Replace(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
                .Split(Path.AltDirectorySeparatorChar)[0])
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
            //Form1.log("Checking " + entryKey + " Subbed? " + entryKey.Contains("/user/"));
            if (entryKey.StartsWith($"bepinex/", StringComparison.OrdinalIgnoreCase))
                toInstall.plugin = true;
            else if (entryKey.Contains($"/bepinex/", StringComparison.OrdinalIgnoreCase))
                toInstall.subrooted = true;
            else if (entryKey.StartsWith("user/", StringComparison.OrdinalIgnoreCase))
                toInstall.client = true;
            else if (entryKey.Contains("/user/", StringComparison.OrdinalIgnoreCase))
                toInstall.subrooted = true;
            else if (modFiles.Contains(file))
            {
                toInstall.client = true;
            }
        }
        private static string FormatPathChars(string input)
        {
            return input.Replace(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
        }

        private readonly static string[] dirTypes = ["/bepinex/", "/user/"];
        private static bool HasFileExtension(string path)
        {
            // Check if the path contains a file extension.
            return !string.IsNullOrEmpty(Path.GetExtension(path));
        }
        private static bool ExtractSubrootedArchive(IArchive archive)
        {
            try
            {
                Form1.log("SubrootedArchive");
                foreach (var entry in archive.Entries)
                {
                    string entryName = FormatPathChars(entry.Key);
                    string[] parts = entryName.Split("/");
                    string subfolderToExtract = parts[0]; // Stupid subfolder name
                    if (entryName.StartsWith($"{subfolderToExtract}/"))
                    {
                        string relativePath = entryName[(subfolderToExtract.Length + 1)..]; // path after sub shit
                        var fullPath = Path.Combine(Paths.gameFolder, relativePath);
                        bool IsDir = Directory.Exists(fullPath);
                        var subPath = Path.GetDirectoryName(fullPath);
                        try
                        {
                            if (HasFileExtension(relativePath)) continue;
                            if (!Directory.Exists(subPath)) { Form1.log("Attempting to create"); Directory.CreateDirectory(subPath); }
                            entry.WriteToFile(FormatPathChars(fullPath), new ExtractionOptions
                            {
                                ExtractFullPath = false,
                                Overwrite = true
                            });
                        }
                        catch (Exception ex)
                        {
                            Form1.log("Extraction error: " + ex.Message + " With path " + fullPath);
                        }
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Form1.log("Error: " + e.Message);
                return false;
            }
        }
        private static bool HasFolderInBepinex(string name)
        {
            return false;
        }
        private static bool HasFolderInMods(string name)
        {
            return false;
        }

        private static bool ExtractSingleRootArchive(IArchive archive)
        {
            try
            {
                Form1.log("SingleRoot");
                string folderName = archive.Entries.First().Key;
                bool custom = !folderName.Equals("user", StringComparison.OrdinalIgnoreCase);
                string path = custom ? Paths.modsFolder : Paths.gameFolder;
                archive.ExtractToDirectory(path);
                return true; // need a way to check if files were created but it works even if installed to wrong dir
            } catch(Exception e) { Form1.log(e.Message); return false; }
        }

        private static bool ExtractFilesFromArchive(IArchive archive, List<string> rootFiles, bool plugin)
        {
            try
            {
                Form1.log("FromArchive");
                foreach (var entry in archive.Entries.Where(_entry => rootFiles.Contains(_entry.Key.TrimEnd('/')))) {
                    entry.WriteToDirectory(plugin ? Paths.pluginsFolder : Paths.modsFolder, new ExtractionOptions
                    {
                        ExtractFullPath = true,
                        Overwrite = true 
                    });
                }
                return true;
            } catch(Exception e) { Form1.log(e.Message); return false; }
        }
        private static bool MoveFile(DownloadedMod toInstall)
        {
            Form1.log("MoveFile");
            string? dest = GetModDestination(toInstall);
            if (dest == null) { Form1.log("dest == null"); return false; }
            File.Move(toInstall.path, $"{dest}/{toInstall.name}.{toInstall.extension}");
            return true;
        }

        private static void HandleMissingFolders(DownloadedMod toInstall)
        {
            // Start the Explorer process to open the folder
            Form1.log($"The {toInstall.extension} file does not contain the required 'Bepinex' or 'user' folders.");
            if(MessageBox.Show("No BepInEx or User folder found. Manually Install?", "Not Valid!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Process.Start("explorer.exe", $"/select,\"{Path.GetFullPath(toInstall.path)}\"");
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
