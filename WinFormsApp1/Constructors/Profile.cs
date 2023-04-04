using Aki.Launcher;
using Aki.Launcher.Models.Launcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTLauncher.Constructors
{
    internal class Profile // probably better to call it an OfflineProfile mainly for offline usage
    {
        private string id;
        private ProfileInfo profileInfo;
        private AccountInfo accountInfo;
        public Profile(string id, ProfileInfo profileInfo, AccountInfo accountInfo)
        {
            this.id = id;
            this.profileInfo = profileInfo;
            this.accountInfo = accountInfo;
        }
    }
}
