using Aki.Launcher;
using SPTLauncher.Constructors.Profiles;
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
        public static string TodaysPath(string id) => $"{Paths.backupsPath}/{id}/{DateTime.Now:yyyy}/{DateTime.Now:MM}/{DateTime.Now:dd}/";
        public static List<string> GetTodaysBackups(string id) => GetProfileBackups(id, DateTime.Now);
        public static List<string> GetYearFolders(string id) => Directory.GetDirectories($"{Paths.backupsPath}/{id}/").Select(Path.GetFileName).ToList();
        public static List<string> GetMonthFolders(string id, int Year) => Directory.GetDirectories($"{Paths.backupsPath}/{id}/{Year}/").Select(Path.GetFileName).ToList();
        public static List<string> GetDayFolders(string id, int Year, int Month) => Directory.GetDirectories($"{Paths.backupsPath}/{id}/{Year}/{Month}/").Select(Path.GetFileName).ToList();
        public static List<string> GetProfileBackups() => Directory.GetDirectories($"{Paths.backupsPath}").Select(Path.GetFileName).ToList();
        public static List<string> GetProfileBackups(string id, int year, int month, int day) => GetProfileBackups(id, new(year, month, day));
        public static List<string> GetProfileBackups(string id, DateTime date) => Directory.GetFiles($"{Paths.backupsPath}/{id}/{date:yyyy}/{date:MM}/{date:dd}/").Select(Path.GetFileName).ToList();
    }
}
