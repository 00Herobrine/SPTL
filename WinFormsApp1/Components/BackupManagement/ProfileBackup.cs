
namespace SPTLauncher.Components.BackupManagement
{
    internal class ProfileBackup
    {
        private string id;
        private string name;
        private List<Backup> backupList = new();
        public string profileFolder; 
        public ProfileBackup(string id)
        {
            this.id = id;
            profileFolder = Path.Combine(Paths.backupsPath, id);
        }

        public void StoreBackups()
        {
            backupList.Clear();
            foreach(string dir in Directory.GetFiles(Paths.backupsPath))
            {

            }
        }
    }
}
