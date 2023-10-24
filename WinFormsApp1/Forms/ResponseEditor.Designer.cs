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
            NameButton = new Button();
            SideButton = new Button();
            LevelButton = new Button();
            label4 = new Label();
            ImportPresetButton = new Button();
            ExportConfigButton = new Button();
            ResponseCheckList = new CheckedListBox();
            SelectAllResponses = new CheckBox();
            SuspendLayout();
            // 
            // AddResponseButton
            // 
            AddResponseButton.Location = new Point(459, 0);
            AddResponseButton.Name = "AddResponseButton";
            AddResponseButton.Size = new Size(75, 23);
            AddResponseButton.TabIndex = 4;
            AddResponseButton.Text = "Add";
            AddResponseButton.UseVisualStyleBackColor = true;
            AddResponseButton.Click += AddResponseButton_Click;
            // 
            // DeleteResponseButton
            // 
            DeleteResponseButton.Location = new Point(215, 418);
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
            ResponseToAdd.Location = new Point(277, 0);
            ResponseToAdd.Name = "ResponseToAdd";
            ResponseToAdd.Size = new Size(176, 23);
            ResponseToAdd.TabIndex = 6;
            ResponseToAdd.Text = "TypeToAdd";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(214, 23);
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
            label2.Location = new Point(226, 257);
            label2.Name = "label2";
            label2.Size = new Size(380, 17);
            label2.TabIndex = 8;
            label2.Text = "Placeholders will be replaced with the appropriate vars in game";
            // 
            // ResponseTypeFilter
            // 
            ResponseTypeFilter.FormattingEnabled = true;
            ResponseTypeFilter.Location = new Point(60, 0);
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
            UpdateButton.Location = new Point(540, 0);
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
            label3.Location = new Point(24, 4);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 13;
            label3.Text = "Filter:";
            // 
            // NameButton
            // 
            NameButton.Location = new Point(298, 231);
            NameButton.Name = "NameButton";
            NameButton.Size = new Size(85, 23);
            NameButton.TabIndex = 14;
            NameButton.Text = "Player Name";
            NameButton.UseVisualStyleBackColor = true;
            NameButton.Click += NameButton_Click;
            // 
            // SideButton
            // 
            SideButton.Location = new Point(389, 231);
            SideButton.Name = "SideButton";
            SideButton.Size = new Size(85, 23);
            SideButton.TabIndex = 15;
            SideButton.Text = "Player Side";
            SideButton.UseVisualStyleBackColor = true;
            SideButton.Click += SideButton_Click;
            // 
            // LevelButton
            // 
            LevelButton.Location = new Point(480, 231);
            LevelButton.Name = "LevelButton";
            LevelButton.Size = new Size(85, 23);
            LevelButton.TabIndex = 16;
            LevelButton.Text = "Player Level";
            LevelButton.UseVisualStyleBackColor = true;
            LevelButton.Click += LevelButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(215, 235);
            label4.Name = "label4";
            label4.Size = new Size(77, 15);
            label4.TabIndex = 17;
            label4.Text = "Placeholders:";
            // 
            // ImportPresetButton
            // 
            ImportPresetButton.Location = new Point(422, 418);
            ImportPresetButton.Name = "ImportPresetButton";
            ImportPresetButton.Size = new Size(75, 23);
            ImportPresetButton.TabIndex = 18;
            ImportPresetButton.Text = "Import";
            ImportPresetButton.UseVisualStyleBackColor = true;
            ImportPresetButton.Click += ImportPresetButton_Click;
            // 
            // ExportConfigButton
            // 
            ExportConfigButton.Location = new Point(341, 418);
            ExportConfigButton.Name = "ExportConfigButton";
            ExportConfigButton.Size = new Size(75, 23);
            ExportConfigButton.TabIndex = 19;
            ExportConfigButton.Text = "Export";
            ExportConfigButton.UseVisualStyleBackColor = true;
            ExportConfigButton.Click += ExportConfigButton_Click;
            // 
            // ResponseCheckList
            // 
            ResponseCheckList.FormattingEnabled = true;
            ResponseCheckList.Location = new Point(1, 23);
            ResponseCheckList.Name = "ResponseCheckList";
            ResponseCheckList.Size = new Size(207, 436);
            ResponseCheckList.TabIndex = 20;
            ResponseCheckList.ItemCheck += ResponseCheckList_ItemCheck;
            ResponseCheckList.SelectedIndexChanged += ResponseCheckList_SelectedIndexChanged;
            // 
            // SelectAllResponses
            // 
            SelectAllResponses.AutoSize = true;
            SelectAllResponses.Location = new Point(4, 5);
            SelectAllResponses.Name = "SelectAllResponses";
            SelectAllResponses.Size = new Size(15, 14);
            SelectAllResponses.TabIndex = 21;
            SelectAllResponses.UseVisualStyleBackColor = true;
            SelectAllResponses.CheckedChanged += SelectAllResponses_CheckedChanged;
            // 
            // ResponseEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(617, 459);
            Controls.Add(SelectAllResponses);
            Controls.Add(ResponseCheckList);
            Controls.Add(ExportConfigButton);
            Controls.Add(ImportPresetButton);
            Controls.Add(label4);
            Controls.Add(LevelButton);
            Controls.Add(SideButton);
            Controls.Add(NameButton);
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
            MaximizeBox = false;
            Name = "ResponseEditor";
            Text = "ResponseEditor";
            Load += ResponseEditor_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
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
        private Button NameButton;
        private Button SideButton;
        private Button LevelButton;
        private Label label4;
        private Button ImportConfigButton;
        private Button ExportConfigButton;
        private CheckedListBox ResponseCheckList;
        private CheckBox SelectAllResponses;
        private Button ImportPresetButton;
    }
}