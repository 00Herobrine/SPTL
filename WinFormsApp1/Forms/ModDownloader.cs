using Aki.Launch.Models.Aki;
using SPTLauncher.Components;
using SPTLauncher.Components.ModManagement;
using System.Diagnostics;
using WinFormsApp1;
using Timer = System.Windows.Forms.Timer;

namespace SPTLauncher
{
    public partial class ModDownloader : Form
    {
        public static ModDownloader? form;
        private ModDownload? selected;

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
            if (mod == null) return;
            string totalBytes = ModManager.FormatByteCount(mod.totalBytes);
            string downloadedBytes = ModManager.FormatByteCount(mod.bytes);
            string downloadSpeed = mod.downloadSpeed == 0 ? "" : $" ({ModManager.FormatByteCount((long)mod.downloadSpeed)}/s)";
            DownloadLabel.Text = mod.totalBytes == 0 ? "" : $"Downloaded: {downloadedBytes}/{totalBytes}{downloadSpeed}";
            downloadProgress.Visible = mod.totalBytes != 0;
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

        public static void DisplayModDownload(ModDownload mod)
        {
            if (form == null) return;
            if (form.SearchBox.Text != "" && form.SearchBox.Text != null) return;
            form.modList.Items.Add(mod);
            if (!form.AkiVersionsBox.Items.Contains(mod.AkiVersion))
            {
                form.AkiVersionsBox.Items.Add(mod.AkiVersion);
                if (form.AkiVersionsBox.SelectedItem == null) form.AkiVersionsBox.SelectedIndex = 0;
            }
        }

        bool loadingMods = false;
        private void modList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModDownload mod = (ModDownload)modList.SelectedItem;
            ModImage.Image = Image.FromFile($"{Paths.iconsPath}/roller144.gif");
            if ((SearchBox.Text == "" || SearchBox.Text == null) && !loadingMods && modList.SelectedIndex >= modList.Items.Count - 20)
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
            if (mod == null) return;
            ModName.Text = mod.name;
            Author.Text = $"Author: {mod.author}";
            AkiVersion.Text = $"Version: {mod.AkiVersion}";
            LoadImage(mod);
            Description.Text = mod.description;
            lastUpdated.Text = $"Updated: {mod.lastUpdated}";
            Downloads.Text = $"Downloads: {mod.downloads.Split(" ")[0]}";
            Rating.Text = $"Rating: {mod.stars}/5";
            Ratings.Text = $"Ratings: {mod.ratings}";
            Reviews.Text = $"Reviews: {mod.reviews}";
        }

        private readonly string[] allowedImageTypes = ["png", "jpg", "gif"];
        private void LoadImage(ModDownload mod)
        {
            bool allowed = mod.imageURL != null && allowedImageTypes.Contains(mod.imageURL.Split(".")[^1].ToString());
            if (!allowed) { ModImage.ImageLocation = $"{Paths.cachePath}/icons/NotFound.png"; return; }
            string imagePath = $"{Paths.iconsCachePath}/{mod.imageName}";
            if (File.Exists(imagePath)) ModImage.ImageLocation = imagePath;
            else ModImage.ImageLocation = mod.imageURL;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (GetSelectedModDownload() == null) return;
            Process.Start("explorer", GetSelectedModDownload().URL);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            page++;
            ModManager.WebRequestMods(page);
        }

        private void DownloadModButton_Click(object sender, EventArgs e)
        {
            ModDownload mod = GetSelectedModDownload();
            if (mod == null) return;
            Form1.log($"Downloading mod {mod.name} URL: {mod.URL}");
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
                int progressPercentage = (int)((double)currentDownloadAmount / downloadSize * 100);
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

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            if (modList.SelectedItem != null) selected = (ModDownload)modList.SelectedItem;
            UpdateWithFilters();
            if (selected != null) modList.SelectedItem = selected;
        }

        private void UpdateWithFilters()
        {
            modList.Items.Clear();
            modList.Items.AddRange(FilterDownloads(SearchBox.Text).ToArray());
        }

        private List<ModDownload> FilterDownloads(string? input = null)
        {
            List<ModDownload> filtered = ModManager.downloadableMods;
            if (FilterVersionCheck.Checked) filtered = filtered.FindAll(o => o.AkiVersion.Equals(AkiVersionsBox.Text, StringComparison.OrdinalIgnoreCase));
            if (string.IsNullOrWhiteSpace(input) || (!FilterDescriptionCheck.Checked && !FilterNameCheck.Checked && !FilterAuthorCheck.Checked)) return filtered;
            else return filtered.FindAll(o =>
            (o.name.Contains(input, StringComparison.OrdinalIgnoreCase) && FilterNameCheck.Checked)
            || (o.author.Contains(input, StringComparison.OrdinalIgnoreCase) && FilterAuthorCheck.Checked)
            || (o.description.Contains(input, StringComparison.OrdinalIgnoreCase) && FilterDescriptionCheck.Checked));
        }

        private void FilterDescriptionCheck_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWithFilters();
        }

        private void FilterVersionCheck_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWithFilters();
        }

        private void FilterAuthorCheck_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWithFilters();
        }

        private void FilterNameCheck_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWithFilters();
        }

        private void AkiVersionsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateWithFilters();
        }
    }
}
