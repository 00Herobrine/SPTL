using SPTLauncher.Components;
using SPTLauncher.Components.Responses;
using SPTLauncher.UIElements;
using WinFormsApp1;
using Newtonsoft.Json;
using SPTLauncher.Components.Presets;
using SPTLauncher.Utils;

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
            LoadToolTips();
            LoadLangs();
            LoadResponses();
            LoadResponseTypes();
        }

        private List<Response> loadedResponses = new List<Response>();
        private readonly string noFilter = "No Filter";
        private void LoadToolTips()
        {
            ToolTip nameTip = new();
            ToolTip sideTip = new();
            ToolTip levelTip = new();
            nameTip.SetToolTip(NameButton, "Appends {{PlayerName}} at caret");
            sideTip.SetToolTip(SideButton, "Appends {{playerSide}} at caret.");
            levelTip.SetToolTip(LevelButton, "Appends {{playerLevel}} at caret");
        }
        private void LoadResponses()
        {
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
            if (LangBox.Items.Contains(LauncherSettings.language.ToString().ToUpper())) LangBox.SelectedItem = LauncherSettings.language.ToString().ToUpper();
        }
        private void LangBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadResponses();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ResponseTypeFilter.SelectedItem == null) return;
            if (ResponseTypeFilter.Text.Equals(noFilter)) { FilterResponses(null); return; }
            FilterResponses((ResponseType)ResponseTypeFilter.SelectedItem);
        }

        public void FilterResponses(ResponseType? type)
        {
            ResponseCheckList.Items.Clear();
            if (type == null) { foreach (Response response in loadedResponses) ResponseCheckList.Items.Add(response, CheckedResponses.Contains(response.RawName)); return; }
            //ResponseCheckList.Items.AddRange(loadedResponses.Where(o => o.type == type).ToArray());
            foreach (Response response in loadedResponses.Where(o => o.type == type)) ResponseCheckList.Items.Add(response, CheckedResponses.Contains(response.RawName));
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            //if (ResponseTypeFilter.SelectedItem == null) return;
            if (ResponseCheckList.SelectedItem == null) return;
            Response response = (Response)ResponseCheckList.SelectedItem;
            UpdateButton.Enabled = response.message != richTextBox1.Text;
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            Response? response = (Response?)ResponseCheckList.SelectedItem;
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
            ResponseCheckList.SelectedIndex = ResponseCheckList.Items.Add(response);
        }

        private void DeleteResponseButton_Click(object sender, EventArgs e)
        {
            Response? response = (Response?)ResponseCheckList.SelectedItem;
            if (response == null) return;
            int updatedIndex = ResponseCheckList.SelectedIndex - 1;
            ResponseManager.RemoveResponse(GetLang(), response);
            ResponseCheckList.Items.Remove(response);
            ResponseCheckList.SelectedIndex = updatedIndex < 0 ? -1 : updatedIndex;
        }
        private void NameButton_Click(object sender, EventArgs e) => AppendText("{{PlayerName}}");
        private void SideButton_Click(object sender, EventArgs e) => AppendText("{{playerSide}}");
        private void LevelButton_Click(object sender, EventArgs e) => AppendText("{{playerLevel}}");
        private void AppendText(string text) => UITools.AppendText(richTextBox1, text);

        private void ExportConfigButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog exportDialog = new()
            {
                Title = "Export Response Preset",
                Filter = "Json Files (*.json)|*.json",
                FileName = "Responses.json",
                AddExtension = true,
            };
            if (exportDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = exportDialog.FileName;
                ResponsesPreset preset = new ResponsesPreset(loadedResponses.Where(o => CheckedResponses.Contains(o.RawName)).ToList());
                File.WriteAllText(exportDialog.FileName, JsonConvert.SerializeObject(preset, Formatting.Indented));
            }
        }

        private List<string> CheckedResponses = new();
        private void ResponseCheckList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ResponseCheckList.SelectedItem == null) { richTextBox1.Text = ""; return; };
            Response response = (Response)ResponseCheckList.SelectedItem;
            richTextBox1.Text = response.message;
            ExportConfigButton.Enabled = CheckedResponses.Count > 0;
        }

        private void ResponseCheckList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            Response response = (Response)ResponseCheckList.Items[e.Index];
            if (e.NewValue == CheckState.Checked && !CheckedResponses.Contains(response.RawName)) CheckedResponses.Add(response.RawName);
            else if (e.NewValue == CheckState.Unchecked) CheckedResponses.Remove(response.RawName);
            ExportConfigButton.Enabled = CheckedResponses.Count > 0;
        }

        private void SelectAllResponses_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < ResponseCheckList.Items.Count; i++) ResponseCheckList.SetItemCheckState(i, SelectAllResponses.CheckState);
        }

        private void ImportPresetButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog presetDialog = new OpenFileDialog
            {
                Title = "Import Response Preset",
                FileName = "Responses.json",
                Filter = "Json Files (.*json)|*.json|Text Files (*.txt)|*.txt",
                AddExtension = true,
            };
            if (presetDialog.ShowDialog() == DialogResult.OK)
            {
                if (!File.Exists(presetDialog.FileName)) return;
                PresetHandler.InstallPreset(GetLang(), JsonConvert.DeserializeObject<ResponsesPreset>(File.ReadAllText(presetDialog.FileName)));
                LoadResponses();
            }
        }
    }
}
