using Aki.Launcher;
using Aki.Launcher.Models.Launcher;
using WinFormsApp1;

namespace SPTLauncher.Constructors
{
    public class Profile
    {
        private string id;
        private ProfileInfo profileInfo;
        private AccountInfo accountInfo;
        private Encyclopedia? encyclopedia;
        //private bool backup;
        public Profile(string id, ProfileInfo profileInfo, AccountInfo accountInfo)
        {
            this.id = id;
            this.profileInfo = profileInfo;
            this.accountInfo = accountInfo;
            //backup = Form1.form.GetConfig().BackupState();
           // Debug.WriteLine($"profile {profileInfo.Username} backups-enabled {backup}");
        }

        public string getID()
        {
            return id;
        }

        public ProfileInfo getProfileInfo()
        {
            return profileInfo;
        }

        public AccountInfo getAccountInfo()
        {
            return accountInfo;
        }

        public Encyclopedia GetEncyclopedia()
        {
            encyclopedia ??= GenerateEncyclopedia();
            return encyclopedia;
        }

        public Encyclopedia GenerateEncyclopedia()
        {
            Form1.log("Generated Encyclopedia for " + id);
            return new Encyclopedia(id);
        }

        public bool BackupsEnabled()
        {
            return false;
            //return backup;
        }
    }
}
