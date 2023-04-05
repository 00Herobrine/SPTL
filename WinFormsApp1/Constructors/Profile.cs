using Aki.Launcher;
using Aki.Launcher.Models.Launcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1;

namespace SPTLauncher.Constructors
{
    public class Profile // probably better to call it an OfflineProfile mainly for offline usage
    {
        private string id;
        private ProfileInfo profileInfo;
        private AccountInfo accountInfo;
        private Encyclopedia encyclopedia;
        public Profile(string id, ProfileInfo profileInfo, AccountInfo accountInfo)
        {
            this.id = id;
            this.profileInfo = profileInfo;
            this.accountInfo = accountInfo;
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
            return encyclopedia;
        }

        public void generateEncyclopedia()
        {
            Form1.form.log("Generated Encyclopedia for " + id);
            encyclopedia = new Encyclopedia(id);
        }
    }
}
