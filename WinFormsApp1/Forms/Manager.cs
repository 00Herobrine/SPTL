using SPTLauncher.Components.ModManagement;

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

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

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
