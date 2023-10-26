using System.Diagnostics;

namespace SPTLauncher.Utils
{
    public static class FileManagement
    {
        public static string CreateJunction(string sourcePath, string targetPath) // symlink without the admin privileges
        {
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
    }
}
