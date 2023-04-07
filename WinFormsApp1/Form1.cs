using System.Diagnostics;
using Aki.Launcher;
using Aki.Launcher.Models.Launcher;
using Aki.Launcher.Helpers;
using System.Text;
using Timer = System.Windows.Forms.Timer;
using Aki.Launcher.Models.Aki;
using WinFormsApp1.Constructors;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using SPTLauncher.Constructors;
using SPTLauncher;
using System.Net.NetworkInformation;
using System.Windows.Forms.VisualStyles;
using System.Text.RegularExpressions;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private bool autoLogin = false;
        private bool debug = true;
        private bool console = true, modsTab = true; // scaling shit
        private bool logging = true;
        private bool enabled = false;
        private bool inUse = false;
        private Timer _timer = new Timer();
        private int port = 6969;
        private int processID;
        #region paths
        public static string gameFolder, profilesFolder, serverURL, configPath, cachePath, itemCache, akiData, productionPath, gatoPath, backupsPath, modsFolder, pluginsFolder, disabledModsPath;
        #endregion
        private string Prefix = "[Hero's Launcher] ";
        public static Form1 form;
        // do automatic profile backups, let the user set how often they should occur.

        public enum STATE { OFFLINE, STARTING, ONLINE }

        public delegate void PingServer(out bool returnValue);

        #region Launcher Stuff
        private Config config;
        private Character selectedCharacter;
        private TarkovCache cache;
        //private Encyclopedia encyclopedia;
        private RecipeBuilder recipeBuilder;
        private GroupBox activeGroupBox;
        private int creatingAccount;
        private Dictionary<int, Profile> cachedProfiles = new Dictionary<int, Profile>();
        private Dictionary<int, Mod> modsIndex = new Dictionary<int, Mod>();
        #endregion

        private delegate void TextCallBack(string text);
        private delegate void ProfileCallBack(bool refresh);
        private Process server;
        private STATE serverState = STATE.OFFLINE;

        public static string getProfilesFolder()
        {
            return profilesFolder;
        }

        public Form1()
        {
            InitializeComponent();
            gameFolder = debug ? "F:/TestPT" : Environment.CurrentDirectory;
            profilesFolder = gameFolder + "/user/profiles";
            serverURL = "127.0.0.1:" + port;
            cachePath = gameFolder + "/Launcher-Cache";
            configPath = cachePath + "/config.json";
            itemCache = cachePath + "/items";
            akiData = gameFolder + "/Aki_Data";
            gatoPath = cachePath + "/gato";
            backupsPath = cachePath + "/backups";
            modsFolder = gameFolder + "/user/mods";
            pluginsFolder = gameFolder + "/bepinex/plugins";
            productionPath = akiData + "/Server/database/hideout/production.json"; // - aki json file, should exist already nor should I make it
            disabledModsPath = cachePath + "/DisabledMods";
            _timer.Interval = 60 * 1000;
            _timer.Tick += TimerInterval;
            _timer.Start();
            form = this;
        }

        public void PathCheck()
        {
            List<string> paths = new List<string>();
            paths.Add(cachePath);
            paths.Add(itemCache);
            paths.Add(akiData);
            paths.Add(gatoPath);
            paths.Add(backupsPath);
            paths.Add(modsFolder);
            paths.Add(pluginsFolder);
            foreach (string path in paths)
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        }

        public void StartUp()
        {
            bindToAkiAsync();
            PathCheck();
            LoadConfig();
            LoadCache();
            LoadMods();
            //ServerManager.LoadServer(LauncherSettingsProvider.Instance.Server.Url);
            /*if(aliveCheck()) bindToAki();
            else */
            // server check
            //ConnectServer();
            // login check
        }

        public void LoadMods()
        {
            List<string> files = new List<string>();
            Dictionary<int, Mod> mods = new Dictionary<int, Mod>();
            modsListBox.Items.Clear();
            if (Directory.Exists(disabledModsPath))
            {
                files.AddRange(Directory.GetFiles(disabledModsPath));
                files.AddRange(Directory.GetDirectories(disabledModsPath));
            }
            if (Directory.Exists(modsFolder))
            {
                files.AddRange(Directory.GetFiles(modsFolder));
                files.AddRange(Directory.GetFiles(pluginsFolder));
                if (Directory.Exists(pluginsFolder))
                {
                    files.AddRange(Directory.GetDirectories(modsFolder));
                    files.AddRange(Directory.GetDirectories(pluginsFolder));
                }
                int amount = files.Count;
                foreach (string file in files)
                    if (file.Contains(pluginsFolder + "\\aki-") || file.Contains(modsFolder + "\\order.json")) amount--;
                    else
                    {
                        Mod mod = new(file);
                        int index = modsListBox.Items.Add(mod.GetName() + (mod.isPlugin() ? " [P]" : " [C]") + (!mod.isEnabled() ? " DISABLED" : ""));
                        mods.Add(index, mod);
                    }
                modsIndex = mods;
                ModsButton.Text = "Mods" + ((amount > 0) ? ": " + amount : "");
            }
        }

        public void LoadConfig()
        {
            config = new Config(configPath);
            textBox1.Text = config.getApiKey();
            BackUpInterval.Value = config.GetBackupInterval();
        }

        public void LoadCache()
        {
            cache = new TarkovCache(cachePath);
        }

        public async Task bindToAkiAsync()
        {
            await ServerManager.LoadDefaultServerAsync(LauncherSettingsProvider.Instance.Server.Url);
            //var delInstance = new PingServer(Ping);
            //var asyncResult = delInstance.BeginInvoke(out response, null, null);
            //delInstance.EndInvoke(out response, asyncResult);
            //var valueWhenDone = response;
            //bool online = ServerManager.PingServer();
            log("Attemping to bind to Aki.");
            if (Process.GetProcessesByName("Aki.Server").Length > 0)
            {
                SetState(STATE.ONLINE);
                log("Detected active Aki.");
            }
            else
            {
                log("Active Aki not detected.");
                if (autoStartCheckBox.Checked) LaunchServer();
                //server = new Process();
            }
        }

        public bool aliveCheck()
        {
            if (ServerManager.PingServer())
            {
                SetState(STATE.ONLINE);
            }
            return serverState == STATE.ONLINE;
        }

        public void OpenGameFolderCommand()
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = gameFolder,
                UseShellExecute = true,
                Verb = "open"
            });
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenGameFolderCommand();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartUp();
            activeGroupBox = groupBox3;
        }

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

        private void button2_Click(object sender, EventArgs e)
        {
            LaunchServer();
        }

        public void LaunchServer()
        {
            inUse = false;
            log("Starting Aki...");
            createServer();
        }

        public void createServer()
        {
            string serverExe = Directory.GetFiles(gameFolder, "*Server.exe")[0];
            server = new Process();
            server.StartInfo.WorkingDirectory = gameFolder;
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
                SetState(STATE.STARTING);
                startServerButton.Enabled = false;
                killServerButton.Enabled = true;
                server.BeginOutputReadLine();
                server.OutputDataReceived += ProcessData;
            }
        }

        private void KillServers()
        {
            if (server != null)
            {
                server.Kill(true);
            }
            else
            {
                Process.GetProcesses().FirstOrDefault(x => x.ProcessName == "Aki.Server")?.Kill();
                Process.GetProcesses().Where(x => x.ProcessName == "conhost").ToList().ForEach(x => x.Kill());
            }
            startServerButton.Enabled = true;
            killServerButton.Enabled = false;
            SetState(STATE.OFFLINE);
            log("Killed Aki.Server.exe");
            Debug.Write("Killing Servers");
        }

        public void Terminated(object sender, EventArgs e)
        {
            server = null;
        }

        void ProcessData(object sender, DataReceivedEventArgs e)
        {
            string r = e.Data;
            if (r == null) return;
            r = Regex.Replace(r, @"\[[0-1];[0-9][a-z]|\[[0-9][0-9][a-z]|\[[0-9][a-z]|\[[0-9][A-Z]", string.Empty);
            ConsoleOutput(r + "\n");
        }

        private void ConsoleOutput(string text)
        {
            if (serverConsole.InvokeRequired)
            {
                if (!logging) return;
                TextCallBack d = new TextCallBack(ConsoleOutput);
                Invoke(d, new object[] { text });
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
                    LoadProfiles();
                }
            }
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

        public void TimerInterval(object sender, EventArgs e)
        {
            BackupCheck();
        }

        public static bool Ping()
        {
            return ServerManager.PingServer();
        }

        public void log(string text)
        {
            serverConsole.Text += Prefix + text + "\n";
        }

        public void ToggleConsole()
        {
            int size = !console ? 688 : 340;
            console = !console;
            Size = new Size(Size.Width, size);
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

        public static ServerProfileInfo[] GetServerProfileInfos()
        {
            return AccountManager.GetExistingProfiles();
        }

        public void LoadProfiles(bool refresh = false)
        {
            if (refresh) profilesList.Items.Clear();
            ServerProfileInfo[] profiles = GetServerProfileInfos();
            if (profilesList.InvokeRequired)
            {
                ProfileCallBack d = new ProfileCallBack(LoadProfiles);
                Invoke(d, new object[] { d });
            }
            else
            {
                for (int i = 0; i < profiles.Length; i++)
                {
                    ServerProfileInfo profile = profiles[i];
                    //Debug.Write("logging " + profile.username + " [" + i + "]");
                    int index = profilesList.Items.Add(profile.username);
                    if (checkBox1.Checked) cacheProfile(profile.username, index);
                }
            }
            profilesList.Items.Add("New Profile...");
            profilesList.SelectedIndex = 1;
        }

        public void cacheProfile(string username, int index)
        {
            AccountManager.Login(username, "");
            cachedProfiles.Add(index, new Profile(AccountManager.SelectedAccount.id, AccountManager.SelectedProfileInfo, AccountManager.SelectedAccount));
            AccountManager.Logout();
            log("Offline cached profile " + username);
        }

        public void StartClient(string uid)
        {
            string dll = gameFolder + "/EscapeFromTarkov_Data/Managed/Assembly-CSharp.dll";
            string bpf = gameFolder + "/Aki_Data/Launcher/Patches/aki-core/EscapeFromTarkov_Data/Managed/Assembly-CSharp.dll.bpf";
            Aki.Launcher.Helpers.FilePatcher.Patch(dll, bpf, false);
            ProcessStartInfo startGame = new ProcessStartInfo(Path.Combine(gameFolder, "EscapeFromTarkov.exe"))
            {
                //$"-force-gfx-jobs native -token={account.id} -config={Json.Serialize(new ClientConfig(server.backendUrl))}";
                Arguments = "-token=" + uid + " -config={'BackendUrl':'" + serverURL + "','Version':'live'}",
                UseShellExecute = false,
                WorkingDirectory = gameFolder
            };

            Process p = new Process();
            p.Exited += GameQuit;
            Process.Start(startGame);
            //PlayButton.Enabled = false;
        }

        public void GameQuit(object sender, EventArgs e)
        {
            //PlayButton.Enabled = true;
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (AccountManager.SelectedAccount.wipe)
            {
                if (MessageBox.Show("Launching will wipe your account. Continue?", "WIPE ACCOUNT", MessageBoxButtons.YesNo) == DialogResult.No) return;
            }
            StartClient(AccountManager.SelectedAccount.id);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            OpenGameFolderCommand();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadProfiles(true);
        }

        public void NewAccount()
        {
            profilesList.SelectedIndex = profilesList.Items.Add("Temp Name");
            creatingAccount = profilesList.SelectedIndex;
            log("Creating new profile...");
        }

        private void profilesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (profilesList.SelectedItem.Equals("New Profile..."))
            {
                NewAccount();
                return;
            }
            AccountStatus status = AccountManager.Login(profilesList.SelectedItem.ToString(), "");
            if (status == AccountStatus.OK)
            {
                ProfileInfo info = AccountManager.SelectedProfileInfo;
                AccountInfo account = AccountManager.SelectedAccount;
                selectedCharacter = new Character(account.id);
                comboBox1.Items.Clear();
                foreach (Skill skill in selectedCharacter.getSkills().Values)
                {
                    comboBox1.Items.Add(skill.getName());
                }
                if (comboBox1.Items.Count > 0) comboBox1.SelectedIndex = 0;
                nameLabel.Text = "Name: " + info.Nickname + " (" + info.Side.ToUpper() + ")";
                IDLabel.Text = "ID: " + account.id;
                editionLabel.Text = "Edition: " + account.edition + (account.wipe ? " (WIPED)" : "");
                expLabel.Text = "Level: " + info.Level + " (" + info.CurrentExp + "/" + info.NextLvlExp + ")\nNeeded: " + info.RemainingExp;
                factionImage.ImageLocation = info.SideImage;
            }
            else
            {
                log("Error viewing account, Aki down?");
            }
        }

        private void bottomButton_Click(object sender, EventArgs e)
        {
            scrollToBottom();
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
            LoadProfiles(true);
        }

        public void ToggleWipe(string id)
        {
            string infoPath = profilesFolder + "/" + id + ".json";
            JObject newStats = getParsedJson(infoPath);
            JToken info = newStats["info"]["wipe"];
            bool wipe = bool.Parse(info.ToString());
            AccountManager.SelectedAccount.wipe = !wipe;
            newStats["info"]["wipe"] = !wipe;
            File.WriteAllText(infoPath, newStats.ToString());
        }

        public JToken getInfo(string id)
        {
            return getParsedJson(profilesFolder + "/" + id + ".json")["info"];
        }
        public JObject getParsedJson(string file)
        {
            return JObject.Parse(File.ReadAllText(file));
        }

        private void profilesList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                log("Created new Profile '" + profilesList.Text + "'");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            toggleActiveTab(groupBox3);
        }

        //region Tab Stuff
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

        private void settingsButton_Click(object sender, EventArgs e)
        {
            toggleActiveTab(settingsGroup);
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Skill selectedSkill = selectedCharacter.getSkillByID(comboBox1.SelectedItem.ToString());
            skillDescriptionLabel.Text = selectedSkill.getDescription();
            skillProgressTextBox.Text = selectedSkill.getProgress();
        }

        private void saveSkillsButton_Click(object sender, EventArgs e)
        {
            Skill selectedSkill = selectedCharacter.getSkillByID(comboBox1.SelectedItem.ToString());
            selectedSkill.setProgress(skillProgressTextBox.Text);
            selectedCharacter.update(selectedSkill);
        }
        //endregion

        private void ToolsButton_Click(object sender, EventArgs e)
        {
            BackupCheck();
        }


        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process process = Process.Start("explorer", "https://tarkov-changes.com/developer");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            config.setApiKey(textBox1.Text);
            config.SetBackupInterval((int)BackUpInterval.Value);
        }

        public Config GetConfig()
        {
            return config;
        }

        private void dictionaryButton_Click(object sender, EventArgs e)
        {
            Form df = new DictionaryForm();
            df.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (GetSelectedProfile().GetEncyclopedia() == null) GetSelectedProfile().generateEncyclopedia();
            GetSelectedProfile().GetEncyclopedia().Show();
        }

        public Profile GetSelectedProfile()
        {
            int index = profilesList.SelectedIndex;
            if (index == -1 || index > profilesList.Items.Count) return null;
            return cachedProfiles[profilesList.SelectedIndex];
        }

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
        public List<string> last3 = new List<string>();
        public void cat(char keyChar)
        {
            last3.Add(keyChar.ToString());
            string word = "";
            if (!last3[0].ToLower().Equals("c") && !last3[0].ToLower().Equals("g"))
            {
                //log("clearing " + last3[0]);
                last3.Clear();
            }
            if (last3.Count >= 3)
            {
                foreach (string s in last3.ToArray()) word += s;
                if (word.ToLower().Contains("cat") || word.ToLower().Contains("gato")) catToggle();
                else if (last3.Count >= 5) last3.Clear();
                //log("spelled " + word);
            }
        }
        private bool gato = false;
        public void catToggle()
        {
            last3.Clear();
            gato = !gato;
            if (gato)
            {
                factionImage.Image = Image.FromFile(chooseGato());
            }
            else factionImage.ImageLocation = "";
        }
        private string chooseGato()
        {
            string[] gatos = Directory.GetFiles(gatoPath);
            Random random = new Random();
            int randomReturn = random.Next(gatos.Length);
            //log(randomReturn + " returned path " + gatos[randomReturn]);
            return gatos[randomReturn];
        }
        #endregion
        public void BackupCheck()
        {
            Profile selectedProfile = GetSelectedProfile();
            if (selectedProfile == null || !profileBackupCheckBox.Checked) return;
            DateTime startTime = config.GetLastBackupTime();
            DateTime now = DateTime.Now;
            TimeSpan interval = TimeSpan.FromMinutes((double)BackUpInterval.Value);
            TimeSpan difference = now - startTime;
            string path = profilesFolder + "/" + selectedProfile.getAccountInfo().id + ".json";
            if (difference >= interval)
            {
                if (!Directory.Exists(backupsPath + "/" + now.ToLongDateString())) Directory.CreateDirectory(backupsPath + "/" + now.ToLongDateString());
                File.WriteAllText(backupsPath + "/" + now.ToLongDateString() + "/" + selectedProfile.getAccountInfo().id + "-" + now.ToLongTimeString().Replace(":", "-") + ".json", File.ReadAllText(path));
            }
        }

        #region Mod Manager
        private void ModsButton_Click(object sender, EventArgs e)
        {
            if (ToggleMods()) LoadMods();
            /*listBox2.Items.Clear();
            listBox2.Items.AddRange(mods.ToArray());*/
        }

        public bool ToggleMods()
        {
            modsTab = !modsTab;
            if (modsTab) Size = new Size(1043, Size.Height);
            else Size = new Size(812, Size.Height);
            return modsTab;
            //Debug.WriteLine("bool " + console + " new size " + size + " new bool " + !console);
        }

        public Mod GetSelectedMod()
        {
            int index = modsListBox.SelectedIndex;
            if (index < 0) return null;
            else return modsIndex[index];
        }
        private void modsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mod mod = GetSelectedMod();
            if (mod == null) return;
            if (mod.HasConfig()) ModManager.Enabled = true;
            else ModManager.Enabled = false;
            if (mod.isEnabled()) button16.Text = "Disable";
            else button16.Text = "Enable";
        }

        public string GetCachePath()
        {
            return cachePath;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            config.DisableMod(GetSelectedMod());
            LoadMods();
        }

        public string GetDisabledModsPath()
        {
            return disabledModsPath;
        }

        public string GetModsPath()
        {
            return modsFolder;
        }
        #endregion

    }
}