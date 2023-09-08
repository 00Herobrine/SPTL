using SPTLauncher.Components;
using System.Diagnostics;
using WinFormsApp1;

namespace SPTLauncher
{
    public partial class ModDownloader : Form
    {
        public static ModDownloader form;
        private int page = 1;
        public ModDownloader()
        {
            InitializeComponent();
            ModManager.WebRequestMods(2);
            page = 2;
            form = this;
        }

        private void ModDownloader_Load(object sender, EventArgs e)
        {

        }

        public void AddMod(ModDownload mod)
        {
            modList.Items.Add(mod);
        }

        bool loadingMods = false;
        private void modList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loadingMods && modList.SelectedIndex >= modList.Items.Count - 20)
            {
                page++;
                loadingMods = true;
                ModManager.WebRequestMods(page);
                loadingMods = false;
            }
            LoadMod(GetSelectedModDownload());
        }

        public ModDownload GetSelectedModDownload()
        {
            return (ModDownload)modList.SelectedItem;
        }

        public void LoadMod(ModDownload mod)
        {
            ModName.Text = mod.name;
            Author.Text = $"Author: {mod.author}";
            AkiVersion.Text = $"Version: {mod.AkiVersion}";
            ModImage.ImageLocation = mod.imageURL;
            Description.Text = mod.description;
            lastUpdated.Text = $"Updated: {mod.lastUpdated}";
            Downloads.Text = $"Downloads: {mod.downloads.Split(" ")[0]}";
            Rating.Text = $"Rating: {mod.stars}/5";
            Ratings.Text = $"Ratings: {mod.ratings}";
            Reviews.Text = $"Reviews: {mod.reviews}";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (GetSelectedModDownload() == null) return;
            Process.Start("explorer", GetSelectedModDownload().URL);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            page++;
            ModManager.WebRequestMods(page);
            //modManager.WebRequestMods(page++);
        }

        private void DownloadModButton_Click(object sender, EventArgs e)
        {
            ModDownload mod = GetSelectedModDownload();
            if (mod == null) return;
            Form1.form.log($"Downloading mod {mod.name} URL: {mod.URL}");
            _ = mod.Download();
        }

        public void UpdateProgressBar(int currentDownloadAmount, long downloadSize)
        {
            if (downloadSize == 0)
            {
                // Avoid division by zero error
                downloadProgress.Value = 0;
            }
            else
            {
                int progressPercentage = (int)(((double)currentDownloadAmount / downloadSize) * 100);
                downloadProgress.Value = progressPercentage;
            }
        }

        private void modList_DrawItem(object sender, DrawItemEventArgs e)
        {
            Debug.WriteLine("drawing mod");
        }

        private void ModDownloader_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
