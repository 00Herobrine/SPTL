using Aki.Launcher;
using Aki.Launcher.Models.Aki;
using Aki.Launcher.Models.Launcher;
using Newtonsoft.Json;
using SPTLauncher.Components;
using SPTLauncher.Components.BackupManagement;
using WinFormsApp1;

namespace SPTLauncher.Constructors.Profiles
{
    public class Profile(ServerProfileInfo serverProfileInfo)
    {
        public string? id { get; set; }
        private ServerProfileInfo serverProfileInfo = serverProfileInfo;
        public ProfileInfo? profileInfo { get; set; }
        public AccountInfo? accountInfo { get; set; }
        private Encyclopedia? encyclopedia;
        public ProfileStruct? file { get; set; }
        public bool IsStored => profileInfo == null || accountInfo == null;
        public List<string> GetBackups(DateTime date) => BackupManager.GetProfileBackups(id, date);
        public List<string> TodaysBackups => BackupManager.GetTodaysBackups(id);
        public override string ToString() => serverProfileInfo.username;
        public ProfileStruct GetFile(bool store = false)
        {
            if (file == null || store) file = JsonConvert.DeserializeObject<ProfileStruct>(ReadProfileFile);
            return (ProfileStruct) file;
        }
        public string ReadProfileFile => id != null ? File.ReadAllText($"{Paths.profilesFolder}/{id}.json") : "";
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
            if (id == null) return;
            BackupManager.CreateProfileBackup(id);
        }

        #region Ease of Use
        public Dictionary<string, Skill> GetSkills => GetFile().characters.pmc.SkillsNode.Skills.ToDictionary(o => o.name, o => o);
        //public void SetSkill(string name, Skill skill) 
        public Skill? GetSkillByID(string ID) => GetSkills?[ID];
        #endregion
    }
}
