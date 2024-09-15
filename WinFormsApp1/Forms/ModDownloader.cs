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

        private static int page = 1;
        public Timer Timer;

        public ModDownloadStruct? GetSelectedModDownload() => modList.SelectedItem == null ? null : (ModDownloadStruct)modList.SelectedItem;
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
            //ModDownload mod = (ModDownload)modList.SelectedItem;
            //if (mod.totalBytes == 0) return;
           // updateVars(mod);
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
            SetDataSource();
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
        public static void SetDataSource()
        {
            if (form == null) return;
            form.modList.Items.Clear();
            foreach (var mod in ModManager.QueryMods().mods) form.modList.Items.Add(mod);
        }

        static bool loadingMods = false;
        private void modList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GetSelectedModDownload() == null) return;
            ModDownloadStruct mod = (ModDownloadStruct)modList.SelectedItem;
            ModImage.Image = Paths.Roller;
            if ((SearchBox.Text == "" || SearchBox.Text == null) && !loadingMods && modList.SelectedIndex >= modList.Items.Count - 20) RequestMods();
            //updateVars(mod);
            LoadMod(mod);
        }
        public static void RequestMods()
        {
            page++;
            loadingMods = true;
            ModManager.WebRequestMods(page);
            loadingMods = false;
        }

        public void modList_Scrolled(object sender, MouseEventArgs e) => ScrollCheck(e.Delta > 0);
        private readonly int threshold = 15;
        public void ScrollCheck(bool upwards)
        {
            int visibleItems = modList.ClientSize.Height / modList.ItemHeight;
            int totalItems = modList.Items.Count;
            int lastIndexVisible = modList.TopIndex + visibleItems - 1;
            if (lastIndexVisible >= 0 && lastIndexVisible < modList.Items.Count && !upwards)
                if (lastIndexVisible >= totalItems - threshold) RequestMods();
        }

        public void LoadMod(ModDownloadStruct mod)
        {
            ModName.Text = mod.name;
            Author.Text = $"Author: {mod.author}";
            AkiVersion.Text = $"Version: {mod.AkiVersion}";
            ModImage.Image = mod.GetImage();
            Favorite.Image = GetFavoriteImageState();
            Description.Text = mod.description;
            lastUpdated.Text = $"Updated: {mod.lastUpdated}";
            Downloads.Text = $"Downloads: {mod.downloads.Split(" ")[0]}";
            Ratings.Text = $"Ratings: {mod.reactions}";
            Comments.Text = $"Comments: {mod.comments}";
        }

        
/*        private void LoadImage(ModDownload mod)
        {
            bool allowed = mod.imageURL != null && allowedImageTypes.Contains(mod.imageURL.Split(".")[^1].ToString());
            if (!allowed) { ModImage.Image = Paths.NotFound; return; }
            string imagePath = $"{Paths.iconsCachePath}/{mod.imageName}";
            if (File.Exists(imagePath)) ModImage.ImageLocation = imagePath;
            else if (string.IsNullOrWhiteSpace(mod.imageURL)) ModImage.Image = Paths.NotFound;
            else ModImage.ImageLocation = mod.imageURL;
        }*/

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (GetSelectedModDownload() == null) return;
            Process.Start("explorer", ((ModDownloadStruct)GetSelectedModDownload()!).URL);
        }

        private void DownloadModButton_Click(object sender, EventArgs e)
        {
            if (GetSelectedModDownload() == null) return;
            ModDownloadStruct mod = (ModDownloadStruct)GetSelectedModDownload()!;
            if (Config.file.VersionWarnings) {
                CompatibilityResult results = mod.GetVersion().CompatibilityCheck();
                VersionCompatibility compatibility = results.Compatibility;
                var icon = compatibility switch
                {
                    VersionCompatibility.Improbable => MessageBoxIcon.Error,
                    VersionCompatibility.Unlikely => MessageBoxIcon.Warning,
                    _ => MessageBoxIcon.Information,
                };
                if (compatibility != VersionCompatibility.Certain)
                    if (MessageBox.Show($"Mod Compatability is '{compatibility}' functionality is not guaranteed, are you sure you'd like to continue with Download?",
                        "Compatability Check", MessageBoxButtons.YesNo, icon) == DialogResult.No) return;
            }
            Form1.log($"Downloading mod {mod.name} URL: {mod.URL}");
            //_ = mod.Download();
        }

        public void UpdateProgressBar(int currentDownloadAmount, long downloadSize)
        {
            if (downloadSize == 0) downloadProgress.Value = 0;
            else
            {
                int progressPercentage = (int)((double)currentDownloadAmount / downloadSize * 100);
                downloadProgress.Value = progressPercentage;
            }
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
            if (string.IsNullOrWhiteSpace(input) && (!FilterDescriptionCheck.Checked && !FilterNameCheck.Checked && !FilterAuthorCheck.Checked)) return filtered;
            else return filtered.FindAll(o =>
            (o.name.Contains(input, StringComparison.OrdinalIgnoreCase) && FilterNameCheck.Checked)
            || (o.author.Contains(input, StringComparison.OrdinalIgnoreCase) && FilterAuthorCheck.Checked)
            || (o.description.Contains(input, StringComparison.OrdinalIgnoreCase) && FilterDescriptionCheck.Checked));
        }
        private void FilterDescriptionCheck_CheckedChanged(object sender, EventArgs e) => UpdateWithFilters();
        private void FilterVersionCheck_CheckedChanged(object sender, EventArgs e) => UpdateWithFilters();
        private void FilterAuthorCheck_CheckedChanged(object sender, EventArgs e) => UpdateWithFilters();
        private void FilterNameCheck_CheckedChanged(object sender, EventArgs e) => UpdateWithFilters();
        private void AkiVersionsBox_SelectedIndexChanged(object sender, EventArgs e) => UpdateWithFilters();
        private void Favorite_Click(object sender, EventArgs e) => Favorite.Image = /*GetSelectedModDownload().ToggleFavorite() ? Paths.starFilled :*/ Paths.starEmpty;
        private Image GetFavoriteImageState() => /*GetSelectedModDownload().IsFavorited*/ false ? Paths.starFilled : Paths.starEmpty;

        private void Favorite_MouseEnter(object sender, EventArgs e)
        {
            Favorite.Image = Paths.starFilled;
        }

        private void Favorite_MouseLeave(object sender, EventArgs e)
        {
            if (modList.SelectedItem == null) return;
            if (!/*GetSelectedModDownload().IsFavorited*/ false) Favorite.Image = Paths.starEmpty;
        }
    }
}
