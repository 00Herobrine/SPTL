namespace SPTLauncher.Forms
{
    partial class ResponseEditor
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
            AddResponseButton = new Button();
            DeleteResponseButton = new Button();
            ResponseToAdd = new ComboBox();
            richTextBox1 = new RichTextBox();
            label2 = new Label();
            ResponseTypeFilter = new ComboBox();
            label1 = new Label();
            LangBox = new ComboBox();
            UpdateButton = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(1, 23);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(207, 424);
            listBox1.TabIndex = 1;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // AddResponseButton
            // 
            AddResponseButton.Location = new Point(540, 1);
            AddResponseButton.Name = "AddResponseButton";
            AddResponseButton.Size = new Size(75, 23);
            AddResponseButton.TabIndex = 4;
            AddResponseButton.Text = "Add";
            AddResponseButton.UseVisualStyleBackColor = true;
            AddResponseButton.Click += AddResponseButton_Click;
            // 
            // DeleteResponseButton
            // 
            DeleteResponseButton.Location = new Point(323, 0);
            DeleteResponseButton.Name = "DeleteResponseButton";
            DeleteResponseButton.Size = new Size(59, 23);
            DeleteResponseButton.TabIndex = 5;
            DeleteResponseButton.Text = "Remove";
            DeleteResponseButton.UseVisualStyleBackColor = true;
            DeleteResponseButton.Click += DeleteResponseButton_Click;
            // 
            // ResponseToAdd
            // 
            ResponseToAdd.FormattingEnabled = true;
            ResponseToAdd.Location = new Point(388, 1);
            ResponseToAdd.Name = "ResponseToAdd";
            ResponseToAdd.Size = new Size(148, 23);
            ResponseToAdd.TabIndex = 6;
            ResponseToAdd.Text = "TypeToAdd";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(214, 51);
            richTextBox1.MaxLength = 500;
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(401, 202);
            richTextBox1.TabIndex = 7;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(214, 28);
            label2.Name = "label2";
            label2.Size = new Size(322, 17);
            label2.TabIndex = 8;
            label2.Text = "Use {{PlayerName}} and {{PlayerSide}} as placeholders";
            // 
            // ResponseTypeFilter
            // 
            ResponseTypeFilter.FormattingEnabled = true;
            ResponseTypeFilter.Location = new Point(44, 0);
            ResponseTypeFilter.Name = "ResponseTypeFilter";
            ResponseTypeFilter.Size = new Size(148, 23);
            ResponseTypeFilter.TabIndex = 9;
            ResponseTypeFilter.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(503, 421);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 11;
            label1.Text = "Language:";
            // 
            // LangBox
            // 
            LangBox.FormattingEnabled = true;
            LangBox.Location = new Point(566, 418);
            LangBox.Name = "LangBox";
            LangBox.Size = new Size(46, 23);
            LangBox.TabIndex = 10;
            LangBox.SelectedIndexChanged += LangBox_SelectedIndexChanged;
            // 
            // UpdateButton
            // 
            UpdateButton.Enabled = false;
            UpdateButton.Location = new Point(540, 26);
            UpdateButton.Name = "UpdateButton";
            UpdateButton.Size = new Size(75, 23);
            UpdateButton.TabIndex = 12;
            UpdateButton.Text = "Update";
            UpdateButton.UseVisualStyleBackColor = true;
            UpdateButton.Click += UpdateButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 4);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 13;
            label3.Text = "Filter:";
            // 
            // ResponseEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(617, 447);
            Controls.Add(label3);
            Controls.Add(UpdateButton);
            Controls.Add(label1);
            Controls.Add(LangBox);
            Controls.Add(ResponseTypeFilter);
            Controls.Add(label2);
            Controls.Add(richTextBox1);
            Controls.Add(ResponseToAdd);
            Controls.Add(DeleteResponseButton);
            Controls.Add(AddResponseButton);
            Controls.Add(listBox1);
            Name = "ResponseEditor";
            Text = "ResponseEditor";
            Load += ResponseEditor_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private Button AddResponseButton;
        private Button DeleteResponseButton;
        private ComboBox ResponseToAdd;
        private RichTextBox richTextBox1;
        private Label label2;
        private ComboBox ResponseTypeFilter;
        private Label label1;
        private ComboBox LangBox;
        private Button UpdateButton;
        private Label label3;
    }
}