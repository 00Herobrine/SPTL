using Aki.Launcher;
using SPTLauncher.Components.Profiles;
using System.Diagnostics;
using WinFormsApp1;
using Timer = System.Windows.Forms.Timer;

namespace SPTLauncher.Components.BackupManagement
{
    public class BackupManager
    {
        private static Timer timer = new Timer();
        public readonly static string backupRawPath = $"[BACKUPS]/[ID]/[YYYY]/[MMMM]/[D]-[TIME].json";

        public static void Initialize()
        {
            timer.Interval = 60000;
            timer.Tick += TimerInterval;
            timer.Start();
        }

        private static void TimerInterval(object sender, EventArgs e)
        {
            BackupCheck();
        }
        public static List<string> BackupDeletionCheck()
        {
            DateTime now = DateTime.Now;
            List<string> deleted = new();
            foreach (string backupFile in GetAllBackups())
            {
                DateTime? deletionTime = GetBackupDeletionTime(File.GetCreationTime(backupFile));
                if (deletionTime == null) return new();
                if (now >= deletionTime)
                {
                    File.Delete(backupFile);
                    deleted.Add(backupFile);
                }
            }
            return deleted;
        }
        public static void BackupCheck()
        {
            Profile? selectedProfile = Form1.ActiveProfile;
            AccountInfo? accountInfo = selectedProfile?.accountInfo;
            if (selectedProfile == null || accountInfo == null || !Config.file.Backups) return;
            string id = accountInfo.id;
            DateTime now = DateTime.Now;
            TimeSpan interval = TimeSpan.FromMinutes(Config.GetBackupInterval());
            TimeSpan difference = now - Config.GetLastBackupTime();
            if (difference >= interval) CreateProfileBackup(id, now, "Auto-Backup Created");
        }
        public static void RestoreBackup(string id, DateTime date)
        {
            int year = date.Year;
            int month = date.Month;
            int day = date.Day;
            string backupPath = $"{Paths.backupsPath}/id/{year}/{month}/{day}/{FormatTimeString(date)}.json";
            File.Copy($"{backupPath}", $"{Paths.profilesFolder}/{id}.json", true);
            Form1.log("Restored Backup " + Path.GetFileName(backupPath));
        }
        private static string FormatTimeString(DateTime time) => time.ToString("t").Replace(":", ".");
        public static void CreateProfileBackup(string id) => CreateProfileBackup(id, DateTime.Now);
        public static void CreateProfileBackup(string id, DateTime now, string? logMessage = null)
        {
            string path = $"{Paths.profilesFolder}/{id}.json";
            string backupPath = TodaysPath(id);
            string filePath = $"{backupPath}/{now.ToString("t").Replace(":", ".")}.json";
            if (!Directory.Exists(backupPath)) Directory.CreateDirectory(backupPath);
            File.WriteAllText(filePath, File.ReadAllText(path));
            Config.SetLastBackUpTime(now);
            logMessage ??= "Backup Created " + Path.GetFileName(filePath);
            Form1.log(logMessage);
        }
        public static DateTime? GetBackupDeletionTime(DateTime fileDate) => Config.file.BackupDeleteInterval > 0 ? fileDate.AddDays(Config.file.BackupDeleteInterval) : null;
        public static string TodaysPath(string id) => $"{Paths.backupsPath}/{id}/{DateTime.Now:yyyy}/{DateTime.Now:MM}/{DateTime.Now:dd}/";
        public static List<string> GetAllBackups() => Directory.GetDirectories(Paths.backupsPath).SelectMany(id => GetAllBackups(Path.GetFileName(id))).ToList();
        public static List<string> GetAllBackups(string id) => GetYearFolders(id)
                .SelectMany(year => GetMonthFolders(id, int.Parse(year))
                    .SelectMany(month => GetDayFolders(id, int.Parse(year), int.Parse(month))
                        .SelectMany(day => GetProfileBackups(id, int.Parse(year), int.Parse(month), int.Parse(day))))).ToList();
        public static List<string> GetTodaysBackups(string id) => GetProfileBackups(id, DateTime.Now);
        public static List<string> GetYearFolders(string id) => Directory.GetDirectories($"{Paths.backupsPath}/{id}/").Select(Path.GetFileName).ToList();
        public static List<string> GetMonthFolders(string id, int Year) => Directory.GetDirectories($"{Paths.backupsPath}/{id}/{Year}/").Select(Path.GetFileName).ToList();
        public static List<string> GetDayFolders(string id, int Year, int Month) => Directory.GetDirectories($"{Paths.backupsPath}/{id}/{Year}/{Month}/").Select(Path.GetFileName).ToList();
        public static List<string> GetProfileBackups() => Directory.GetDirectories($"{Paths.backupsPath}").Select(Path.GetFileName).ToList();
        public static List<string> GetProfileBackups(string id, int year, int month, int day) => GetProfileBackups(id, new(year, month, day));
        public static List<string> GetProfileBackups(string id, DateTime date) => Directory.GetFiles($"{Paths.backupsPath}/{id}/{date:yyyy}/{date:MM}/{date:dd}/").ToList();
    }
}
