using Aki.Launcher;
using Newtonsoft.Json.Linq;

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
            string path = Form1.profilesFolder + "/" + accountID + ".json";
            JObject jObject = JObject.Parse(File.ReadAllText(path));
            foreach (JProperty jToken in jObject["characters"]["pmc"]["Encyclopedia"])
            {
                //string name = getDisplayName(id)
                var id = jToken.Name;
                var value = (bool)jToken.Value;
                int listID = checkedListBox1.Items.Add($"ID: {id}", value);
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

        public string getDisplayName(string id)
        {

            return "";
        }
    }
}
