using Aki.Launcher;
using Newtonsoft.Json.Linq;
using SPTLauncher.Components;

namespace WinFormsApp1
{
    public partial class Encyclopedia : Form
    {
        public Encyclopedia()
        {
            InitializeComponent();
            StartUp(AccountManager.SelectedAccount.id);
        }

        public Encyclopedia(string accountID)
        {
            InitializeComponent();
            StartUp(accountID);
        }

        public void StartUp(string accountID)
        {
            string path = Paths.profilesFolder + "/" + accountID + ".json";
            JObject jObject = JObject.Parse(File.ReadAllText(path));
            foreach (JProperty jToken in jObject["characters"]["pmc"]["Encyclopedia"] ?? "")
            {
                //string name = getDisplayName(id)
                EncyclopediaEntry entry = new(jToken);
                checkedListBox1.Items.Add(entry, entry.inspected);
            }
        }

        private void Connection_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void Encyclopedia_Load(object sender, EventArgs e)
        {

        }
    }
    public class EncyclopediaEntry
    {
        public string id { get; set; }
        public bool inspected { get; set; }
        public string Name { get; set; }
        public EncyclopediaEntry(JProperty token)
        {
            id = token.Name;
            inspected = (bool)token.Value;
            Name = TarkovCache.GetReadableName(id);
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
