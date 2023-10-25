using SPTLauncher.Components.Caching;
using System.Text;
using WinFormsApp1;

namespace SPTLauncher.Forms
{
    public partial class NodeViewer : Form
    {
        public NodeViewer()
        {
            InitializeComponent();
        }

        private void NodeViewer_Load(object sender, EventArgs e)
        {
            LoadListboxes(TarkovCache.ReferenceNodes.Values.ToArray());
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;
            CacheEntry entry = (CacheEntry)listBox1.SelectedItem;
            StringBuilder sb = new();
            foreach (var ent in entry.Props) sb.Append($"{ent.Key}: {ent.Value}\n");
            richTextBox1.Text = sb.ToString();
            Check();
            Form1.log(entry.ShortName);
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem == null) return;
            CacheEntry entry = (CacheEntry)listBox2.SelectedItem;
            StringBuilder sb = new();
            foreach (var ent in entry.Props) sb.Append($"{ent.Key}: {ent.Value}\n");
            richTextBox2.Text = sb.ToString();
            Check();
        }

        public void Check(bool alt = true)
        {
            if (!alt)
            {
                if (listBox1.SelectedItem == null || listBox2.SelectedItem == null) return;
                string text1 = richTextBox1.Text;
                string text2 = richTextBox2.Text;

                // Perform text comparison (You can use a diff library for more advanced comparisons)
                string[] lines1 = text1.Split('\n');
                string[] lines2 = text2.Split('\n');

                var differences = lines1.Zip(lines2, (line1, line2) =>
                {
                    string[] line1kv = line1.Split(":");
                    string[] line2kv = line2.Split(":");
                    if (line1kv[0].Equals(line2kv[0], StringComparison.OrdinalIgnoreCase))
                    {
                        if (line1kv[1].Equals(line2kv[1], StringComparison.OrdinalIgnoreCase)) return line1;
                        else return line1;
                    }
                    else
                    {
                        return $"[D] {line1}";
                    }
                });

                // Display differences in the third RichTextBox
                richTextBox3.Text = string.Join("\n", differences);
            } else
            {
                string text1 = richTextBox1.Text;
                string text2 = richTextBox2.Text;

                string[] lines1 = text1.Split('\n');
                string[] lines2 = text2.Split('\n');

                StringBuilder diffBuilder = new StringBuilder();

                for (int i = 0; i < Math.Min(lines1.Length, lines2.Length); i++)
                {
                    string line1 = lines1[i].Trim(); // Remove leading and trailing whitespace
                    string line2 = lines2[i].Trim();

                    if (!string.IsNullOrEmpty(line1) && !string.IsNullOrEmpty(line2) && !line1.StartsWith(line2) && !line2.StartsWith(line1))
                    {
                        // Lines are different at the beginning
                        diffBuilder.AppendLine($"Line {i + 1}:");
                        diffBuilder.AppendLine($"Text 1: {line1}");
                        diffBuilder.AppendLine($"Text 2: {line2}");
                        diffBuilder.AppendLine();
                    }
                }

                richTextBox3.Text = diffBuilder.ToString();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (checkBox1.Checked) listBox1.Items.AddRange(TarkovCache.ItemDictionary.Values.ToArray());
            else listBox1.Items.AddRange(TarkovCache.ReferenceNodes.Values.ToArray());
        }

        private void LoadListboxes(CacheEntry[] entries)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox1.Items.AddRange(entries);
            listBox2.Items.AddRange(entries);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            if (checkBox2.Checked) listBox2.Items.AddRange(TarkovCache.ItemDictionary.Values.ToArray());
            else listBox2.Items.AddRange(TarkovCache.ReferenceNodes.Values.ToArray());
        }
    }

}
