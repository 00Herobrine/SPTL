using System.Diagnostics;
using Aki.Launcher;
using Aki.Launcher.Models.Launcher;
using Aki.Launcher.Helpers;
using System.Text;
using Aki.Launcher.Models.Aki;
using Newtonsoft.Json.Linq;
using SPTLauncher;
using System.Text.RegularExpressions;
using SPTLauncher.Components;
using SPTLauncher.Constructors.Enums;
using SPTLauncher.Components.ModManagement;
using SPTLauncher.Forms.Reporting;
using SPTLauncher.Components.BackupManagement;
using SPTLauncher.Components.Caching;
using SPTLauncher.Forms;
using SPTLauncher.Components.RecipeManagement;
using SPTLauncher.Components.Presets;
using SPTLauncher.Components.Profiles;
using SPTLauncher.Components.Updater;
using SPTLauncher.Utils;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private bool console = true, modsTab = true, backupsTab = true; // scaling shit
        private bool logging = true;
        private bool inUse = false;
        private int port = 6969;
        public static string serverURL;
        private static string Prefix = "[Hero's Launcher] ";
        public static Form1? form;
        public bool startup = true;
        public enum STATE { OFFLINE, BINDING, STARTING, ONLINE }

        public delegate void PingServer(out bool returnValue);

        #region Launcher Stuff
        //private Encyclopedia encyclopedia;
        private RecipeBuilder recipeBuilder;
        private GroupBox activeGroupBox;
        private int creatingAccount = -1;
        public static Profile ActiveProfile { get; set; }
        #endregion

        private delegate void TextCallBack(string text);
        private delegate void ProfileCallBack();
        private Process? server;
        private Process? game;
        private STATE serverState = STATE.OFFLINE;
        private static ServerInfo si;

        public Form1()
        {
            InitializeComponent();
            serverURL = "127.0.0.1:" + port;
            form = this;
        }


        public void StartUp()
        {
            //_ = BindToAkiAsync(); // call this to another thread
            _ = AutoUpdater.UpdateCheck();
            Paths.PathCheck();
            md = new ModDownloader();
            Config.Load();
            LauncherSettings.Load();
            ModManager.LoadMods();
            TarkovCache.Initialize();
            Traders.Initialize();
            BackupManager.Initialize();
            RecipeManager.Initialize();
            RenderMods();
            UpdateModsButton();
            UpdateSettingsValues();
            LoadToolTips();
            log(BackupManager.BackupDeletionCheck().Count + " backups deleted."); // Auto-Delete backups after specified interval =< 0 means off
        }


        public void UpdateSettingsValues()
        {
            textBox1.Text = Config.GetApiKey();
            profileBackupCheckBox.Checked = Config.BackupState();
            BackUpInterval.Value = Config.GetBackupInterval();
            backupDeleteInterval.Value = Config.file.BackupDeleteInterval;
            minimizeCheck.Checked = Config.file.MinimizeOnLaunch;
            ImageCachingCheck.Checked = Config.file.ImageCaching;
            versionWarningCheck.Checked = Config.file.VersionWarnings;
            LangBox.Items.Clear();
            foreach (LANG lang in Enum.GetValues(typeof(LANG))) LangBox.Items.Add(lang);
            LangBox.SelectedItem = Config.file.Lang;
        }

        public static Process[] GetServerProcesses()
        {
            return Process.GetProcessesByName("Aki.Server");
        }

        public void OpenGameFolderCommand()
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = Paths.gameFolder,
                UseShellExecute = true,
                Verb = "open"
            });
        }

        public void AddMod(ModDownload mod)
        {
            modsListBox.Items.Add(mod);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenGameFolderCommand();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartUp();
            activeGroupBox = groupBox3;
            Text += $" - {LauncherSettings.akiData.akiVersion}";
        }

        #region ToolTips
        ToolTip donationTip = new();
        ToolTip bugTip = new();
        ToolTip settingsTip = new();
        ToolTip folderTip = new();
        ToolTip imageCachingTip = new();
        ToolTip serverButtonTip = new();
        ToolTip versionWarningTip = new();
        ToolTip languageTip = new();
        public void LoadToolTips()
        {
            donationTip.SetToolTip(donatePicture, "Donation!");
            bugTip.SetToolTip(BugsFeedbackBox, "Bug Reports & Feedback");
            settingsTip.SetToolTip(SettingsButton, "Settings");
            folderTip.SetToolTip(OpenFolderButton, "Open Game Folder");
            imageCachingTip.SetToolTip(ImageCachingCheck, "Toggles Mod Manager Image Caching");
            serverButtonTip.SetToolTip(startServerButton, "Start Server");
            versionWarningTip.SetToolTip(versionWarningCheck, "Toggles the Version Compatibility check for Mod Downloads");
            languageTip.SetToolTip(LangBox, "Loads the selected Tarkov localization");
        }
        #endregion
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serverState == STATE.ONLINE || serverState == STATE.STARTING)
            {
                if (MessageBox.Show("Are you sure you want to close?", "Kill Server", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    logging = false;
                    KillServers();
                }
                else e.Cancel = true;
            }
        }

        private void StartServerButton_Click(object sender, EventArgs e)
        {
            LaunchServer();
        }

        public void LaunchServer()
        {
            inUse = false;
            CreateServer();
        }

        public void CreateServer()
        {
            string serverExe = Directory.GetFiles(Paths.gameFolder, "*Server.exe")[0];
            server = new Process();
            server.StartInfo.WorkingDirectory = Paths.gameFolder;
            if (File.Exists(serverExe))
            {
                server.StartInfo.FileName = serverExe;
                server.StartInfo.CreateNoWindow = true;
                server.StartInfo.UseShellExecute = false;
                server.StartInfo.RedirectStandardError = true;
                server.StartInfo.RedirectStandardInput = true;
                server.StartInfo.RedirectStandardOutput = true;
                server.StartInfo.StandardOutputEncoding = Encoding.UTF8;
                server.EnableRaisingEvents = true;
                server.Exited += Terminated;
                server.Start();
                log($"Starting Aki... [ProcessID: {server.Id}]");
                SetState(STATE.STARTING);
                startServerButton.Enabled = false;
                killServerButton.Enabled = true;
                server.BeginOutputReadLine();
                server.OutputDataReceived += ProcessData;
            }
        }

        private void KillServers()
        {
            foreach (Process process in GetServerProcesses()) { process.Kill(); log($"Killed {process.ProcessName}."); }
            startServerButton.Enabled = true;
            killServerButton.Enabled = false;
            SetState(STATE.OFFLINE);
            startup = true;
            Debug.Write("Killing Servers");
        }

        public void Terminated(object sender, EventArgs e)
        {
            server = null;
        }

        async void ProcessData(object sender, DataReceivedEventArgs e)
        {
            string r = e.Data;
            if (r == null) return;
            r = Regex.Replace(r, @"\[[0-1];[0-9][a-z]|\[[0-9][0-9][a-z]|\[[0-9][a-z]|\[[0-9][A-Z]", string.Empty);
            await ConsoleOutputAsync(r + "\n");
        }

        private async Task ConsoleOutputAsync(string text)
        {
            if (serverConsole.InvokeRequired)
            {
                if (!logging) return;
                TextCallBack d = new TextCallBack(async text => await ConsoleOutputAsync(text));
                await InvokeAsync(d, new object[] { text });
            }
            else
            {
                serverConsole.Text += text;
                if (autoScrollBox.Checked)
                {
                    scrollToBottom();
                }
                if (text.Contains("Port " + port + " is already in use"))
                {
                    inUse = true;
                    SetState(STATE.OFFLINE);
                }
                else if (text.Contains(serverURL) && !inUse && serverState != STATE.ONLINE)
                {
                    SetState(STATE.ONLINE);
                    StoreEditions();
                    LoadProfiles();
                }
            }
        }

        private Task InvokeAsync(Delegate method, params object[] args)
        {
            var taskCompletionSource = new TaskCompletionSource<object>();
            try
            {
                this.Invoke(method, args);
                taskCompletionSource.SetResult(null);
            }
            catch (Exception ex)
            {
                taskCompletionSource.SetException(ex);
            }
            return taskCompletionSource.Task;
        }

        public void SetState(STATE state)
        {
            switch (state)
            {
                case STATE.OFFLINE:
                    startServerButton.Enabled = true;
                    killServerButton.Enabled = false;
                    groupBox1.Enabled = false;
                    break;
                case STATE.ONLINE:
                    startServerButton.Enabled = false;
                    killServerButton.Enabled = true;
                    groupBox1.Enabled = true;
                    break;
                case STATE.STARTING:
                    startServerButton.Enabled = false;
                    killServerButton.Enabled = true;
                    groupBox1.Enabled = false;
                    break;
            }
            stateLabel.Text = "Status: " + state.ToString();
            serverState = state;
        }

        public void StoreEditions()
        {
            if (ServerManager.SelectedServer == null)
                ServerManager.LoadServer(LauncherSettingsProvider.Instance.Server.Url);
            if (!ServerManager.PingServer()) return;
            if (ServerManager.SelectedServer == null) return;
            editionsBox.Items.Clear();
            editionsBox.Items.AddRange(ServerManager.SelectedServer.editions);
        }

        public static bool Ping()
        {
            return ServerManager.PingServer();
        }

        public static async void log(string text)
        {
            if (form == null) return;
            await Task.Run(() =>
            {
                form.Invoke(new Action(() =>
                {
                    form.serverConsole.Text += Prefix + text + "\n";
                    if (form.checkBox1.Checked) form.scrollToBottom();
                }));
            });
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ToggleConsole();
            linkLabel1.Text = console ? "Hide Console" : "Show Console";
        }

        private void killServerButton_Click(object sender, EventArgs e)
        {
            KillServers();
        }

        public static ServerProfileInfo[] GetServerProfileInfos() => AccountManager.GetExistingProfiles();

        public void LoadProfiles()
        {
            profilesList.Items.Clear();
            ServerProfileInfo[] profiles = GetServerProfileInfos();
            if (profilesList.InvokeRequired)
            {
                ProfileCallBack d = new ProfileCallBack(LoadProfiles);
                Invoke(d, new object[] { d });
            }
            else foreach (var profile in profiles) profilesList.Items.Add(new Profile(profile));
            if (profilesList.Items.Count > 0) profilesList.SelectedIndex = 0;
            profilesList.Items.Add("New Profile...");
        }

        public void StartClient(string uid)
        {
            string dll = Paths.gameFolder + "/EscapeFromTarkov_Data/Managed/Assembly-CSharp.dll";
            string bpf = Paths.gameFolder + "/Aki_Data/Launcher/Patches/aki-core/EscapeFromTarkov_Data/Managed/Assembly-CSharp.dll.bpf";
            FilePatcher.Patch(dll, bpf, false);
            ProcessStartInfo startGame = new ProcessStartInfo(Path.Combine(Paths.gameFolder, "EscapeFromTarkov.exe"))
            {
                //$"-force-gfx-jobs native -token={account.id} -config={Json.Serialize(new ClientConfig(server.backendUrl))}";
                Arguments = "-token=" + uid + " -config={'BackendUrl':'" + serverURL + "','Version':'live'}",
                UseShellExecute = false,
                WorkingDirectory = Paths.gameFolder
            };

            if (game != null)
            {
                if (MessageBox.Show("Active game process detected, would you like to continue?", "Alert", MessageBoxButtons.YesNo) == DialogResult.No) return;
            }
            Process p = new Process();
            p.Exited += GameQuit;
            Process.Start(startGame);
            game = p;
            //PlayButton.Enabled = false;
        }

        public void GameQuit(object sender, EventArgs e)
        {
            game = null;
            //PlayButton.Enabled = true;
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (AccountManager.SelectedAccount.wipe)
            {
                if (MessageBox.Show("Launching will wipe your account. Continue?", "WIPE ACCOUNT", MessageBoxButtons.YesNo) == DialogResult.No) return;
            }
            if (minimizeCheck.Checked) { WindowState = FormWindowState.Minimized; }
            StartClient(AccountManager.SelectedAccount.id);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadProfiles();
        }

        public void NewAccountCreation()
        {
            profilesList.SelectedIndex = profilesList.Items.Add("Temp Name");
            creatingAccount = profilesList.SelectedIndex;
            log("Creating new profile @ " + creatingAccount);
        }

        public void CreateProfile(string username, string password = "", string edition = "Standard")
        {
            string[] editions = ServerManager.SelectedServer.editions;
            if (!editions.Contains(edition)) { log($"Cannot find '{edition}' as a valid edition."); return; }
            AccountManager.Register(username, password, edition);
            creatingAccount = -1;
            log($"Created new Profile '{username}' with '{edition}' Edition");
        }

        private void profilesList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && creatingAccount != -1)
            {
                CreateProfile(profilesList.Text, "", editionsBox.Text);
                LoadProfiles();
                e.Handled = true;
            }
        }

        private void profilesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (profilesList.SelectedItem == null) return;
            if (creatingAccount != -1) // -1 means no selectedProfile Index
            {
                // remove the account in creation from the profilesList
                profilesList.Items.RemoveAt(creatingAccount);
                log($"Account creation cancelled");
                creatingAccount = -1;
                return;
            }
            if (profilesList.SelectedItem.Equals("New Profile..."))
            {
                NewAccountCreation();
                return;
            }
            if (profilesList.SelectedItem is not Profile) return;
            ActiveProfile = (Profile)profilesList.SelectedItem;
            if (ActiveProfile == null) return;
            if (ActiveProfile.Login() == AccountStatus.OK) LoadProfileInfo();
        }

        private void LoadProfileInfo(Profile? profile = null)
        {
            profile ??= ActiveProfile;
            ProfileInfo info = profile.profileInfo;
            AccountInfo account = profile.accountInfo;
            nameLabel.Text = "Name: " + info.Nickname + " (" + info.Side.ToUpper() + ")";
            IDLabel.Text = "ID: " + account.id;
            editionLabel.Text = "Edition:                                         " + (account.wipe ? " (WIPED)" : "");
            expLabel.Text = "Level: " + info.Level + " (" + info.CurrentExp + "/" + info.NextLvlExp + ")\nNeeded: " + info.RemainingExp;
            factionImage.ImageLocation = info.SideImage;
            editionsBox.SelectedItem = account.edition;
            LoadProfileSkills();
        }
        private void LoadProfileSkills()
        {
            comboBox1.Items.Clear();
            List<Skill> profileSkills = ActiveProfile.GetSkills != null ? ActiveProfile.GetSkills.Values.ToList() : new();
            foreach (Skill skill in profileSkills) comboBox1.Items.Add(skill);
            if (comboBox1.Items.Count > 0) comboBox1.SelectedIndex = 0;
        }

        public void scrollToBottom()
        {
            serverConsole.SelectionStart = serverConsole.Text.Length;
            serverConsole.ScrollToCaret();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ToggleWipe(AccountManager.SelectedAccount.id);
            //AccountManager.Wipe(AccountManager.SelectedAccount.edition); // stuck with the first selected edition for now
            LoadProfiles();
        }

        public void ToggleWipe(string id)
        {
            string infoPath = Paths.profilesFolder + "/" + id + ".json";
            JObject newStats = getParsedJson(infoPath);
            JToken info = newStats["info"]["wipe"];
            bool wipe = bool.Parse(info.ToString());
            AccountManager.SelectedAccount.wipe = !wipe;
            newStats["info"]["wipe"] = !wipe;
            File.WriteAllText(infoPath, newStats.ToString());
        }

        public JObject getParsedJson(string file) => JObject.Parse(File.ReadAllText(file));

        private void button12_Click(object sender, EventArgs e)
        {
            toggleActiveTab(groupBox3);
        }

        #region Tab Stuff
        public void toggleActiveTab(GroupBox groupBox)
        {
            activeGroupBox ??= groupBox;
            if (activeGroupBox == groupBox) activeGroupBox.Visible = !activeGroupBox.Visible;
            else
            {
                activeGroupBox.Visible = false;
                activeGroupBox = groupBox;
                activeGroupBox.Visible = true;
            }
        }

        Dictionary<string, Skill> updatedSkills = new();
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null) return;
            Skill selectedSkill = (Skill)comboBox1.SelectedItem;
            skillProgressBox.Value = (decimal)selectedSkill.progress;
        }
        private void skillProgressBox_ValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null) return;
            Skill selectedSkill = (Skill)comboBox1.SelectedItem;
            updatedSkills[selectedSkill.name] = selectedSkill;
        }

        private void saveSkillsButton_Click(object sender, EventArgs e)
        {
            foreach (Skill skill in updatedSkills.Values) { log("Updated " + skill); ActiveProfile.GetSkills[skill.name] = skill; };
            updatedSkills = new();
        }
        #endregion

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process process = Process.Start("explorer", "https://tarkov-changes.com/developer");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Config.SetApiKey(textBox1.Text);
            Config.SetLang((LANG)LangBox.SelectedIndex);
            Config.SetBackupInterval((int)BackUpInterval.Value);
            Config.file.Backups = profileBackupCheckBox.Checked;
            Config.file.BackupDeleteInterval = (int)backupDeleteInterval.Value;
            Config.file.MinimizeOnLaunch = minimizeCheck.Checked;
            Config.file.VersionWarnings = versionWarningCheck.Checked;
            Config.save();
        }

        private void dictionaryButton_Click(object sender, EventArgs e)
        {
            Form df = new DictionaryForm();
            df.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Profile? profile = GetSelectedProfile();
            if (profile == null) return;
            profile.GetEncyclopedia().Show();
        }

        public Profile? GetSelectedProfile() => profilesList.SelectedItem is Profile ? (Profile)profilesList.SelectedItem : null;

        private void button14_Click(object sender, EventArgs e)
        {
            if (recipeBuilder == null) recipeBuilder = new RecipeBuilder();
            recipeBuilder.Show();
        }

        #region gato
        private void serverConsole_KeyPress(object sender, KeyPressEventArgs e)
        {
            cat(e.KeyChar);
            e.Handled = true; // Shut annoying ass windows up
        }
        private string input = "";
        public void cat(char keyChar)
        {
            input += keyChar;
            if (input.Length < 3) return;
            if (input.Length > 50) input = "";
            string last3 = input.ToLower().Substring(input.Length - 3);
            string last4 = (input.Length >= 4) ? input.ToLower().Substring(input.Length - 4) : "";
            if (last3.Contains("cat") || last4.Contains("gato")) catToggle();
        }
        private bool gato = false;
        public void catToggle()
        {
            input = "";
            gato = !gato;
            if (gato) factionImage.Image = Image.FromFile(chooseGato());
            else factionImage.Image = null;
        }
        private string chooseGato()
        {
            string[] gatos = Directory.GetFiles(Paths.gatoPath);
            Random random = new();
            int randomReturn = random.Next(gatos.Length);
            return gatos[randomReturn];
        }
        #endregion

        public bool ToggleConsole()
        {
            console = !console;
            ScaleCheck();
            return console;
        }
        public void ScaleCheck()
        {
            bool sidebar = (modsTab == false || backupsTab == false);
            int width = !sidebar ? 1043 : 812;
            int height = console ? 692 : 340;
            Size = new Size(width, height);
        }
        #region Mod Manager
        ModDownloader? md = null;
        private void ModsButton_Click(object sender, EventArgs e)
        {
            md ??= new ModDownloader();
            md.Show();
            //if (ToggleMods()) LoadMods();
            /*listBox2.Items.Clear();
            listBox2.Items.AddRange(mods.ToArray());*/
        }

        public bool ToggleMods()
        {
            modsTab = !modsTab;
            ScaleCheck();
            return modsTab;
        }

        public Mod GetSelectedMod()
        {
            return (Mod)modsListBox.SelectedItem;
        }
        private void modsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mod mod = GetSelectedMod();
            if (mod == null) return;
            if (mod.HasConfig) ModConfig.Enabled = true;
            else ModConfig.Enabled = false;
            if (mod.IsEnabled) button16.Text = "Disable";
            else button16.Text = "Enable";
            UpdateModsButton();
        }

        public void UpdateModsButton()
        {
            ModsButton.Text = $"Mods {ModManager.mods.Count - ModManager.disabledAmount}/{ModManager.mods.Count}";
        }

        internal Mod? selectedMod = null;
        private void button16_Click(object sender, EventArgs e)
        {
            if (serverState == STATE.ONLINE || serverState == STATE.STARTING)
            {
                MessageBox.Show("Cannot disable mods while server is running.", "SERVER RUNNING", MessageBoxButtons.OK);
                return;
            }
            selectedMod = GetSelectedMod();
            GetSelectedMod().Toggle();
            RenderMods();
            if (selectedMod != null) modsListBox.SelectedItem = selectedMod;
        }

        private void RenderMods(bool reorganize = true)
        {
            if (reorganize) ModManager.LoadMods();
            ModsListCheckBox.Items.Clear();
            foreach (Mod mod in ModManager.mods) ModsListCheckBox.Items.Add(mod, mod.IsEnabled);
        }

        #endregion

        #region Backup Manager
        private void button5_Click(object sender, EventArgs e)
        {
            BackupGroup.Enabled = !BackupGroup.Enabled;
            if (BackupGroup.Enabled)
            {
                LoadProfileValues();
            }
        }

        private void BackupsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool enabled = true;
            if (BackupProfiles.SelectedIndex == -1 || YearBox.SelectedIndex == -1 || BackupsList.SelectedIndex == -1) enabled = false;
            RestoreBackupButton.Enabled = enabled;
            SaveRestoreButton.Enabled = enabled;
        }

        private void BackupProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BackupProfiles.SelectedIndex != -1) LoadYearValues();
            YearBox.Enabled = BackupProfiles.SelectedIndex != -1;
            BackupsList.Enabled = BackupProfiles.SelectedIndex != -1 || YearBox.SelectedIndex != -1;
        }
        public void LoadYearValues()
        {
            YearBox.Items.Clear();
            YearBox.Items.AddRange(BackupManager.GetYearFolders(BackupProfiles.Text).ToArray());
            if (YearBox.Items.Count > 0) YearBox.SelectedIndex = 0;
        }
        public void LoadMonthValues()
        {
            MonthBox.Items.Clear();
            MonthBox.Items.AddRange(BackupManager.GetMonthFolders(BackupProfiles.Text, int.Parse(YearBox.Text)).ToArray());
            if (MonthBox.Items.Count > 0) MonthBox.SelectedIndex = 0;
        }
        public void LoadDayValues()
        {
            DayBox.Items.Clear();
            DayBox.Items.AddRange(BackupManager.GetDayFolders(BackupProfiles.Text, int.Parse(YearBox.Text), int.Parse(MonthBox.Text)).ToArray());
            if (DayBox.Items.Count > 0) DayBox.SelectedIndex = 0;
        }
        public void LoadProfileValues()
        {
            BackupProfiles.Items.Clear();
            BackupProfiles.Items.AddRange(BackupManager.GetProfileBackups().ToArray());
            if (BackupProfiles.Items.Count > 0) BackupProfiles.SelectedIndex = 0;
        }
        public void LoadBackupsValues()
        {
            BackupsList.Items.Clear();
            BackupsList.Items.AddRange(BackupManager.GetProfileBackups(BackupProfiles.Text, int.Parse(YearBox.Text), int.Parse(MonthBox.Text), int.Parse(DayBox.Text)).ToArray());
            if (BackupsList.Items.Count > 0) BackupsList.SelectedIndex = 0;
        }

        private void RestoreBackupButton_Click(object sender, EventArgs e)
        {
            int year = int.Parse(YearBox.SelectedText);
            int month = int.Parse(MonthBox.SelectedText);
            int day = int.Parse(DayBox.SelectedText);
            string[] split = BackupsList.Text.Split(".");
            int hour = int.Parse(split[0]);
            int minute = int.Parse(split[1]);
            int second = int.Parse(split[2]);
            DateTime backupTime = new(year, month, day, hour, minute, second);
            BackupManager.RestoreBackup(BackupProfiles.Text, backupTime);
        }

        private void SaveRestoreButton_Click(object sender, EventArgs e)
        {
            string id = BackupProfiles.Text;
            int year = int.Parse(YearBox.Text);
            int month = int.Parse(MonthBox.Text);
            int day = int.Parse(DayBox.Text);
            string[] split = BackupsList.Text.Split(".");
            int hour = int.Parse(split[0]);
            int minute = int.Parse(split[1]);
            int second = int.Parse(split[2]);
            DateTime backupTime = new(year, month, day, hour, minute, second);
            BackupManager.CreateProfileBackup(id);
            BackupManager.RestoreBackup(id, backupTime);
            ReloadBackupIndexes();
        }

        public void ReloadBackupIndexes()
        {
            string id = BackupProfiles.Text;
            int year = int.Parse(YearBox.Text);
            int month = int.Parse(MonthBox.Text);
            int day = int.Parse(DayBox.Text);
            DateTime backupTime = new(year, month, day);
            BackupsList.Items.Clear();
            BackupsList.Items.AddRange(BackupManager.GetProfileBackups(id, backupTime).Select(Path.GetFileName).ToArray());
        }

        #endregion
        private void editionsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Profile? profile = GetSelectedProfile();
            AccountInfo? accountInfo = profile?.accountInfo;
            if (startup) { startup = false; return; }
            if (profile == null || accountInfo == null || editionsBox.SelectedIndex == -1) return;
            if (!accountInfo.wipe) if (MessageBox.Show("Changing Editions will WIPE your profile data! DO NOT change editions if you want to keep your profile data!", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel) return;
            string edition = editionsBox.SelectedText;
            AccountManager.SelectedAccount.edition = edition;
            AccountManager.WipeAsync(edition);
            AccountManager.UpdateProfileInfo();
            log($"Changed {accountInfo.nickname} to {edition}");
            LoadProfiles();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form traders = new TradersEditor();
            traders.Show();
        }

        private void ModConfig_Click(object sender, EventArgs e)
        {
            Mod mod = GetSelectedMod();
            string? path = mod.ConfigPath;
            if (mod == null || path == null) return;
            Process.Start("explorer.exe", path.Replace("/", "\\"));
        }

        private void DeleteProfileButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete Selected Profile", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return;
            AccountManager.Remove();
            LoadProfiles();
        }

        private void SavePresetButton_Click(object sender, EventArgs e)
        {
            Preset preset = PresetHandler.GetLauncherPreset();
            string? fileName = PresetHandler.ExportPreset(preset);
            if (fileName == null) return;
            preset.export(fileName);
        }

        private void donatePicture_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "https://www.google.com");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            scrollToBottom();
        }

        private void QuestButton_Click(object sender, EventArgs e)
        {

        }

        Form? fb;
        private void BugsFeedbackBox_Click(object sender, EventArgs e)
        {
            fb ??= new Feedback();
            fb.Show();
        }

        NodeViewer nv;
        private void OpenFolderButton_Click(object sender, EventArgs e)
        {
            /*nv ??= new NodeViewer();
            nv.Show();*/
            //log(FileManagement.CreateJunction(@$"{Paths.downloadedPath}/AmandsGraphics", @$"{Paths.pluginsFolder}/"));
            //OpenGameFolderCommand();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            toggleActiveTab(settingsGroup);
        }

        private void ImageCachingCheck_CheckedChanged(object sender, EventArgs e)
        {
            Config.SetImageCache(ImageCachingCheck.Checked);
        }

        private void BackupDatesBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BackupValidityCheck();
            if (YearBox.SelectedIndex != 1) LoadMonthValues();
        }

        private void MonthBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BackupValidityCheck();
            if (MonthBox.SelectedIndex != 1) LoadDayValues();
        }

        private void DayBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BackupValidityCheck();
            if (DayBox.SelectedIndex != -1) ReloadBackupIndexes();
        }

        public void BackupValidityCheck()
        {
            BackupsList.Enabled = DayBox.SelectedIndex != -1;
            DayBox.Enabled = MonthBox.SelectedIndex != -1;
            MonthBox.Enabled = YearBox.SelectedIndex != -1;
            YearBox.Enabled = BackupProfiles.SelectedIndex != -1;
        }

        private void ResponsesButton_Click(object sender, EventArgs e)
        {
            ResponseEditor re = new ResponseEditor();
            re.Show();
        }


        private void LoadPresetButton_Click(object sender, EventArgs e)
        {

        }
    }
}