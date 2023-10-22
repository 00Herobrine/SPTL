using SPTLauncher.Components;
using SPTLauncher.Components.Responses;
using SPTLauncher.Constructors.Enums;
using WinFormsApp1;

namespace SPTLauncher.Forms
{
    public partial class ResponseEditor : Form
    {
        public ResponseEditor()
        {
            InitializeComponent();
        }

        private void ResponseEditor_Load(object sender, EventArgs e)
        {
            ToolTip toolTip = new();
            toolTip.SetToolTip(richTextBox1, "Use {{PlayerName}} and {{PlayerSide}} as placeholder variables");
            LoadLangs();
            LoadResponses();
            LoadResponseTypes();
        }

        List<Response> loadedResponses = new List<Response>();
        private readonly string noFilter = "No Filter";
        private void LoadResponses()
        {
            listBox1.Items.Clear();
            ResponseTypeFilter.Items.Clear();
            ResponseTypeFilter.Items.Add(noFilter);
            loadedResponses.Clear();
            string lang = GetLang();
            foreach (Response response in ResponseManager.GetResponses(lang))
            {
                if (!ResponseTypeFilter.Items.Contains(response.type)) ResponseTypeFilter.Items.Add(response.type);
                loadedResponses.Add(response);
            }
            if (ResponseTypeFilter.Items.Count > 0) ResponseTypeFilter.SelectedIndex = 0;
        }
        private string GetLang()
        {
            if (string.IsNullOrWhiteSpace(LangBox.Text)) return "en";
            else return LangBox.Text;
        }
        private void LoadResponseTypes()
        {
            ResponseToAdd.Items.Clear();
            ResponseType[] types = (ResponseType[])Enum.GetValues(typeof(ResponseType));
            Dictionary<ResponseType, string> interactionTypeDisplay = types
            .ToDictionary(
                value => value,
                value => value.GetDescription()
            );

            ResponseToAdd.DataSource = new BindingSource(interactionTypeDisplay, null);
            ResponseToAdd.DisplayMember = "Value";
            ResponseToAdd.ValueMember = "Key";
            //foreach (ResponseType response in Enum.GetValues(typeof(ResponseType))) ResponseToAdd.Items.Add(response);
            if (ResponseToAdd.Items.Count > 0) ResponseToAdd.SelectedIndex = 0;
        }

        private void LoadLangs()
        {
            LangBox.Items.Clear();
            foreach (string file in Directory.GetFiles($"{Paths.databasePath}/locales/server")) LangBox.Items.Add(Path.GetFileName(file).Replace(".json", "").ToUpper());
        }
        private void LangBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadResponses();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;
            Response response = (Response)listBox1.SelectedItem;
            richTextBox1.Text = response.message;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ResponseTypeFilter.SelectedItem == null) return;
            if (ResponseTypeFilter.Text.Equals(noFilter)) { FilterResponses(null); return; }
            FilterResponses((ResponseType)ResponseTypeFilter.SelectedItem);
        }

        public void FilterResponses(ResponseType? type)
        {
            listBox1.Items.Clear();
            if (type == null) { listBox1.Items.AddRange(loadedResponses.ToArray()); return; }
            listBox1.Items.AddRange(loadedResponses.Where(o => o.type == type).ToArray());
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            //if (ResponseTypeFilter.SelectedItem == null) return;
            if (listBox1.SelectedItem == null) return;
            Response response = (Response)listBox1.SelectedItem;
            UpdateButton.Enabled = response.message != richTextBox1.Text;
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            Response? response = (Response?)listBox1.SelectedItem;
            if (response == null) return;
            response.message = richTextBox1.Text;
            ResponseManager.TryUpdateResponse(GetLang(), response);
            UpdateButton.Enabled = false;
        }

        private void AddResponseButton_Click(object sender, EventArgs e)
        {
            ResponseType? type = (ResponseType?)ResponseToAdd.SelectedValue;
            Form1.log("type: " + type);
            if (type == null) return;
            Response response = ResponseManager.CreateResponse(GetLang(), (ResponseType)type);
            listBox1.SelectedIndex = listBox1.Items.Add(response);
        }

        private void DeleteResponseButton_Click(object sender, EventArgs e)
        {
            Response? response = (Response?)listBox1.SelectedItem;
            if (response == null) return;
            int updatedIndex = listBox1.SelectedIndex - 1;
            ResponseManager.RemoveResponse(GetLang(), response);
            listBox1.Items.Remove(response);
            listBox1.SelectedIndex = updatedIndex < 0 ? -1 : updatedIndex;
        }
    }
}
