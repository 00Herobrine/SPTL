using SPTLauncher.Components;
using SPTLauncher.Forms.Feedback;
using System.Diagnostics;

namespace SPTLauncher.Forms.Reporting
{
    public partial class Feedback : Form
    {
        public RadioButton? activeCheckBox;
        private Severity bugSeverity = Severity.Low;
        public Feedback()
        {
            InitializeComponent();
        }

        private void Feedback_Load(object sender, EventArgs e)
        {
            BugReportBox.Checked = true;
            LoadSeverityLevels();
            if (comboBox1.Items.Count > 0) comboBox1.SelectedItem = bugSeverity;
        }

        public void LoadSeverityLevels()
        {
            comboBox1.Items.Clear();
            foreach (Severity level in Enum.GetValues(typeof(Severity)))
                comboBox1.Items.Add(level);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string? check = ValidityCheck();
            if (check == null)
                Thing.SendFeedBack(richTextBox1.Text, (Severity)comboBox1.SelectedItem, BugReportBox.Checked, textBox1.Text);
            else Debug.WriteLine(check);
        }

        private string? ValidityCheck()
        {
            if (richTextBox1.Text == "" || richTextBox1.Text == null) return "No Text Input";
            if (activeCheckBox == null) return "No Report Type";
            if (comboBox1.SelectedItem == null) return "No Severity Type";
            if (richTextBox1.Text.Length > 1200) return "Too Many Characters";
            return null;
        }

        public void Toggle(RadioButton button)
        {
            if (activeCheckBox != null) activeCheckBox.Checked = false;
            activeCheckBox = button;
            if (FeedbackBox.Checked && groupBox2.Enabled) { bugSeverity = (Severity)comboBox1.SelectedItem; comboBox1.SelectedItem = Severity.None; groupBox2.Enabled = false; }
            else if (!FeedbackBox.Checked && !groupBox2.Enabled) { groupBox2.Enabled = true; comboBox1.SelectedItem = bugSeverity; }
        }
        private void BugReportBox_CheckedChanged_1(object sender, EventArgs e)
        {
            Toggle((RadioButton)sender);
        }
        private void FeedbackBox_CheckedChanged(object sender, EventArgs e)
        {
            Toggle((RadioButton)sender);
        }

        private void Feedback_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
