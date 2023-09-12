using OpenQA.Selenium.DevTools.V114.Memory;
using SPTLauncher.Components.ModManagement;
using SPTLauncher.Constructors;
using System.Diagnostics;
using System.Timers;
using WinFormsApp1;
using Timer = System.Windows.Forms.Timer;

namespace SPTLauncher
{
    public partial class ModDownloader : Form
    {
        public static ModDownloader? form;
        private int page = 1;
        public Timer Timer;
        public ModDownloader()
        {
            InitializeComponent();
            ModManager.Initialize();
            Timer = new Timer();
            Timer.Tick += TimerTick;
            Timer.Interval = 1000;
            Timer.Start();
            page = 2;
            form = this;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            if (modList.SelectedItem == null) return;
            ModDownload mod = (ModDownload)modList.SelectedItem;
            if (mod.totalBytes == 0) return;
            updateVars(mod);
            // This method will be called every second
            //Console.WriteLine("Timer ticked at: " + DateTime.Now);
        }

        public void updateVars(ModDownload mod)
        {
            string totalBytes = ModManager.FormatByteCount(mod.totalBytes);
            string downloadedBytes = ModManager.FormatByteCount(mod.bytes);
            string downloadSpeed = mod.downloadSpeed == 0 ? "" : $" ({ModManager.FormatByteCount((long)mod.downloadSpeed)})";
            DownloadLabel.Text = mod.totalBytes == 0 ? "" : $"Downloaded {downloadedBytes}/{totalBytes}{downloadSpeed}";
            downloadProgress.Value = mod.CalculatePercentageInt();
        }

        private void ModDownloader_Load(object sender, EventArgs e)
        {
            Check();
        }

        public static void Check()
        {
            if (form == null) return;
            if (form.modList.Items.Count > 0) form.modList.SelectedIndex = 0;
        }

        public void AddMod(ModDownload mod)
        {
            modList.Items.Add(mod);
        }

        bool loadingMods = false;
        private void modList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModDownload mod = (ModDownload)modList.SelectedItem;
            if (!loadingMods && modList.SelectedIndex >= modList.Items.Count - 20)
            {
                page++;
                loadingMods = true;
                ModManager.WebRequestMods(page);
                loadingMods = false;
            }
            updateVars(mod);
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
