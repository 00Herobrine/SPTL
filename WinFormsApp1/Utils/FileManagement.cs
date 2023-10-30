using SPTLauncher.Components.ModManagement;
using System.Diagnostics;

namespace SPTLauncher.Utils
{
    public static class FileManagement
    {
        public static bool IsDllFile(string entryKey) => entryKey.EndsWith(".dll", StringComparison.OrdinalIgnoreCase);
        public static string[] GetContents(string[] paths)
        {
            List<string> filePaths = new();
            foreach(string path in paths)
            {
                foreach(string dir in Directory.GetDirectories(path)) filePaths.Add(dir);
                foreach (string file in Directory.GetFiles(path)) filePaths.Add(file);
            }
            return filePaths.ToArray();
        }

        public static string CreateJunction(string sourcePath, string targetPath) // symlink without the admin privileges
        {
            Debug.WriteLine("Creating Junction for " + sourcePath);
            if (File.Exists(sourcePath))
            {
                Debug.WriteLine($"Existing File for path");
                string fileName = Path.GetFileName(sourcePath);
                string shortName = fileName.Split(".")[0];
                DirectoryInfo di = Directory.GetParent(sourcePath)!.CreateSubdirectory(shortName); // change it to mod name possibly, fileName works similarly
                Debug.WriteLine("Writing file to " + di);
                File.Move(sourcePath, Path.Combine(di.ToString(), fileName));
                sourcePath = di.ToString();
            }
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.Start();

                StreamWriter sw = process.StandardInput;
                if (sw.BaseStream.CanWrite)
                {
                    sw.WriteLine($"mklink /J \"{Path.Combine(targetPath, Path.GetFileName(sourcePath))}\" \"{sourcePath}\"");
                    sw.WriteLine("exit");
                }

                process.WaitForExit();
                process.Close();

                return "Junction created successfully!";
            }
            catch (Exception ex)
            {
                return $"Failed to create junction. Error: {ex.Message}";
            }
        }
        public static VersionStatus VersionComparison(string newVersion, string oldVersion) => VersionComparison(Version.Parse(newVersion), Version.Parse(oldVersion));
        public static VersionStatus VersionComparison(Version version1, Version version2)
        {
            int state = version1.CompareTo(version2);
            return state switch
            {
                0 => VersionStatus.Match,
                1 => VersionStatus.Newer,
                -1 => VersionStatus.Outdated,
                _ => VersionStatus.None,
            };
        }
    }
}
