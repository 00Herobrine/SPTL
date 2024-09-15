using SPTLauncher.Components.ModManagement;
using SPTLauncher.Components.ModManagement.Types;
using System.ComponentModel;

namespace SPTLauncher.Forms
{
    public partial class Manager : Form
    {
        public static Manager? manager;
        public Manager()
        {
            InitializeComponent();
            manager = this;
        }

        private void Manager_Load(object sender, EventArgs e)
        {

        }

        public static void AddDownloadedMod(DownloadedMod downloaded)
        {
            if (manager == null) return;
            manager.DownloadedModsList.Items.Add(downloaded);
        }


    }
}
