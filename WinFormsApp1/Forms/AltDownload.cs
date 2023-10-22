using SPTLauncher.Components.ModManagement;

namespace SPTLauncher.Forms
{
    public partial class AltDownload : Form
    {
        public AltDownload()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void StoreImages()
        {
            listView1.SmallImageList = new ImageList();
            listView1.SmallImageList.Images.AddRange(ModManager.GetModDownloads().Where(o => o.image != null).Select(o => o.image).ToArray());
        }

        private void AltDownload_Load(object sender, EventArgs e)
        {
            foreach (ModDownload download in ModManager.GetModDownloads())
            {
                listView1.Items.Add(download.name, $"{download.id}.jpg");
            }
        }
    }
}
