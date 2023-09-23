﻿using SharpCompress.Archives;
using SharpCompress.Archives.Rar;
using SharpCompress.Archives.SevenZip;
using SharpCompress.Archives.Zip;
using SharpCompress.Common;
using SharpCompress.Common.Tar;
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
        private static bool ExtractArchive(DownloadedMod toInstall)
        {
            IArchive? archive = null;
            switch(toInstall.extension)
            {
                case "rar":
                    archive = ArchiveFactory.Open(toInstall.path);
                    break;
                case "zip":
                    archive = ArchiveFactory.Open(toInstall.path);
                    break;
                case "7z":
                    archive = ArchiveFactory.Open(toInstall.path);
                    break;
            }
            if (archive == null) return false;
            string modFilePath = @toInstall.path.Replace("\\", "/");
            try
            {
                int rootFolderCount = archive.Entries.Where(_entry => _entry.IsDirectory && !_entry.Key.Any(c => c == '\\')).Count();
                foreach (IArchiveEntry entry in archive.Entries)
                {
                    if (entry.Key.StartsWith("bepinex/", StringComparison.OrdinalIgnoreCase))
                        toInstall.plugin = true;
                    else if (entry.Key.StartsWith("user/", StringComparison.OrdinalIgnoreCase) ||
                        entry.Key.Contains("mod.ts", StringComparison.OrdinalIgnoreCase) ||
                        entry.Key.Contains("config.js", StringComparison.OrdinalIgnoreCase))
                        toInstall.client = true;
                    else if (entry.Key.Contains("/bepinex/", StringComparison.OrdinalIgnoreCase))
                    {
                        toInstall.plugin = true;
                        toInstall.subrooted = true;
                    }
                    else if (entry.Key.Contains("/user/", StringComparison.OrdinalIgnoreCase))
                    {
                        toInstall.client = true;
                        toInstall.subrooted = true;
                    }
                }
                if (toInstall.subrooted)
                {
                    foreach (var entry in archive.Entries.Where(_entry => _entry.IsDirectory))
                    {
                        string path = DirectoryIsBepinex(entry.Key) ? Paths.pluginsFolder : Paths.modsFolder;
                        entry.WriteToDirectory(path);
                    }
                    return true;
                }
                else if (rootFolderCount == 1 && toInstall.client)
                {
                    string folderName = archive.Entries.Where(entry => entry.IsDirectory).First().Key;
                    bool custom = !folderName.Equals("user");
                    archive.ExtractToDirectory(custom ? $"{Paths.modsFolder}" : Paths.gameFolder);
                    return true;
                }
                else if (toInstall.plugin || toInstall.client)
                {
                    archive.ExtractToDirectory(Paths.gameFolder);
                    return true;
                }
                else
                {
                    Form1.log(modFilePath);
                    Process.Start("explorer.exe", Paths.downloadingPath);
                    Form1.log($"The {toInstall.extension} file does not contain the required 'Bepinex' or 'user' folders.");
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
                    return Paths.pluginsFolder;
                default:
                    break;
            }
            return null;
        }
    }

}
