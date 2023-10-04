using Aki.Launcher;
using Aki.Launcher.Models.Aki;
using Aki.Launcher.Models.Launcher;
using SPTLauncher.Components.BackupManagement;
using WinFormsApp1;

namespace SPTLauncher.Constructors
{
    public class Profile(ServerProfileInfo serverProfileInfo)
    {
        public string? id { get; set; }
        private ServerProfileInfo serverProfileInfo = serverProfileInfo;
        public ProfileInfo? profileInfo { get; set; }
        public AccountInfo? accountInfo { get; set; }
        private Encyclopedia? encyclopedia;

        public AccountStatus Login()
        {
            // Server Ping
            AccountStatus status = AccountManager.Login(serverProfileInfo.username, "");
            switch (status)
            {
                case AccountStatus.OK:
                    profileInfo = AccountManager.SelectedProfileInfo;
                    accountInfo = AccountManager.SelectedAccount;
                    id = accountInfo.id;
                    break;
                case AccountStatus.NoConnection:
                    Form1.log("Error viewing account, Aki down?");
                    break;
                case AccountStatus.LoginFailed:
                    Form1.log("Login Failed username/password possibly changed?");
                    break;
            }
            return status;
        }
        public bool IsStored => profileInfo == null || accountInfo == null;
        public void Store() // resigns into active profile
        {
            Login();
            Form1.ActiveProfile?.Login();
        }

        public Encyclopedia? GetEncyclopedia()
        {
            if (!IsStored) Store();
            encyclopedia ??= GenerateEncyclopedia();
            return encyclopedia;
        }

        public Encyclopedia? GenerateEncyclopedia()
        {
            Form1.log("Generating Encyclopedia for " + id);
            if (id == null) return null;
            return new Encyclopedia(id);
        }

        public void CreateBackup()
        {
            if(id == null) return;
            BackupManager.CreateProfileBackup(id);
        }
        public List<string> GetBackups(DateTime date) => BackupManager.GetProfileBackups(id, date);
        public List<string> GetTodaysBackups() => BackupManager.GetTodaysBackups(id);
        public override string ToString() => serverProfileInfo.username;
    }
}
