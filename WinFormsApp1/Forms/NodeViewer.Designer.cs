namespace SPTLauncher.Forms
{
    partial class NodeViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBox1 = new ListBox();
            richTextBox1 = new RichTextBox();
            listBox2 = new ListBox();
            richTextBox2 = new RichTextBox();
            richTextBox3 = new RichTextBox();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(0, 0);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(180, 454);
            listBox1.TabIndex = 0;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // richTextBox1
            // 
            richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            richTextBox1.Location = new Point(179, 0);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(270, 453);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            // 
            // listBox2
            // 
            listBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 15;
            listBox2.Location = new Point(719, 0);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(178, 454);
            listBox2.TabIndex = 2;
            listBox2.SelectedIndexChanged += listBox2_SelectedIndexChanged;
            // 
            // richTextBox2
            // 
            richTextBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            richTextBox2.Location = new Point(449, 0);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(270, 453);
            richTextBox2.TabIndex = 3;
            richTextBox2.Text = "";
            // 
            // richTextBox3
            // 
            richTextBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            richTextBox3.Location = new Point(925, 0);
            richTextBox3.Name = "richTextBox3";
            richTextBox3.Size = new Size(270, 453);
            richTextBox3.TabIndex = 4;
            richTextBox3.Text = "";
            // 
            // checkBox1
            // 
            checkBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(903, 3);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(15, 14);
            checkBox1.TabIndex = 5;
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // checkBox2
            // 
            checkBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(903, 23);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(15, 14);
            checkBox2.TabIndex = 6;
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // NodeViewer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1195, 453);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(richTextBox3);
            Controls.Add(listBox2);
            Controls.Add(richTextBox2);
            Controls.Add(richTextBox1);
            Controls.Add(listBox1);
            Name = "NodeViewer";
            Text = "NodeViewer";
            Load += NodeViewer_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private RichTextBox richTextBox1;
        private ListBox listBox2;
        private RichTextBox richTextBox2;
        private RichTextBox richTextBox3;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
    }
}