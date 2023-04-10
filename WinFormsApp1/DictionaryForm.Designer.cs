namespace SPTLauncher
{
    partial class DictionaryForm
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
            dictionaryTabs = new TabControl();
            ArmorTab = new TabPage();
            DescriptionBox = new RichTextBox();
            DropLimit = new Label();
            Weight = new Label();
            CellWidth = new Label();
            CellHeight = new Label();
            ItemID = new Label();
            NameLabel = new Label();
            listBox1 = new ListBox();
            WearablesTab = new TabPage();
            WeaponsTab = new TabPage();
            MiscTab = new TabPage();
            ConsumablesTab = new TabPage();
            KeysTab = new TabPage();
            dictionaryTabs.SuspendLayout();
            ArmorTab.SuspendLayout();
            SuspendLayout();
            // 
            // dictionaryTabs
            // 
            dictionaryTabs.Controls.Add(ArmorTab);
            dictionaryTabs.Controls.Add(WearablesTab);
            dictionaryTabs.Controls.Add(WeaponsTab);
            dictionaryTabs.Controls.Add(MiscTab);
            dictionaryTabs.Controls.Add(ConsumablesTab);
            dictionaryTabs.Controls.Add(KeysTab);
            dictionaryTabs.Location = new Point(-2, -2);
            dictionaryTabs.Name = "dictionaryTabs";
            dictionaryTabs.SelectedIndex = 0;
            dictionaryTabs.Size = new Size(806, 455);
            dictionaryTabs.TabIndex = 0;
            // 
            // ArmorTab
            // 
            ArmorTab.Controls.Add(DescriptionBox);
            ArmorTab.Controls.Add(DropLimit);
            ArmorTab.Controls.Add(Weight);
            ArmorTab.Controls.Add(CellWidth);
            ArmorTab.Controls.Add(CellHeight);
            ArmorTab.Controls.Add(ItemID);
            ArmorTab.Controls.Add(NameLabel);
            ArmorTab.Controls.Add(listBox1);
            ArmorTab.Location = new Point(4, 24);
            ArmorTab.Name = "ArmorTab";
            ArmorTab.Padding = new Padding(3);
            ArmorTab.Size = new Size(798, 427);
            ArmorTab.TabIndex = 0;
            ArmorTab.Text = "Armor";
            ArmorTab.UseVisualStyleBackColor = true;
            // 
            // DescriptionBox
            // 
            DescriptionBox.Location = new Point(241, 241);
            DescriptionBox.Name = "DescriptionBox";
            DescriptionBox.Size = new Size(554, 183);
            DescriptionBox.TabIndex = 8;
            DescriptionBox.Text = "";
            // 
            // DropLimit
            // 
            DropLimit.AutoSize = true;
            DropLimit.Location = new Point(241, 78);
            DropLimit.Name = "DropLimit";
            DropLimit.Size = new Size(79, 15);
            DropLimit.TabIndex = 6;
            DropLimit.Text = "Discard Limit:";
            DropLimit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Weight
            // 
            Weight.AutoSize = true;
            Weight.Location = new Point(241, 63);
            Weight.Name = "Weight";
            Weight.Size = new Size(75, 15);
            Weight.TabIndex = 5;
            Weight.Text = "Item Weight:";
            Weight.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CellWidth
            // 
            CellWidth.AutoSize = true;
            CellWidth.Location = new Point(241, 48);
            CellWidth.Name = "CellWidth";
            CellWidth.Size = new Size(68, 15);
            CellWidth.TabIndex = 4;
            CellWidth.Text = "Cell Width: ";
            CellWidth.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CellHeight
            // 
            CellHeight.AutoSize = true;
            CellHeight.Location = new Point(241, 33);
            CellHeight.Name = "CellHeight";
            CellHeight.Size = new Size(69, 15);
            CellHeight.TabIndex = 3;
            CellHeight.Text = "Cell Height:";
            CellHeight.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ItemID
            // 
            ItemID.AutoSize = true;
            ItemID.Location = new Point(241, 18);
            ItemID.Name = "ItemID";
            ItemID.Size = new Size(48, 15);
            ItemID.TabIndex = 2;
            ItemID.Text = "Item ID:";
            // 
            // Name
            // 
            NameLabel.AutoSize = true;
            NameLabel.Location = new Point(241, 3);
            NameLabel.Name = "Name";
            NameLabel.Size = new Size(42, 15);
            NameLabel.TabIndex = 1;
            NameLabel.Text = "Name:";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(0, 0);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(241, 424);
            listBox1.TabIndex = 0;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // WearablesTab
            // 
            WearablesTab.Location = new Point(4, 24);
            WearablesTab.Name = "WearablesTab";
            WearablesTab.Size = new Size(798, 427);
            WearablesTab.TabIndex = 5;
            WearablesTab.Text = "Wearables";
            WearablesTab.UseVisualStyleBackColor = true;
            // 
            // WeaponsTab
            // 
            WeaponsTab.Location = new Point(4, 24);
            WeaponsTab.Name = "WeaponsTab";
            WeaponsTab.Padding = new Padding(3);
            WeaponsTab.Size = new Size(798, 427);
            WeaponsTab.TabIndex = 1;
            WeaponsTab.Text = "Weapons";
            WeaponsTab.UseVisualStyleBackColor = true;
            // 
            // MiscTab
            // 
            MiscTab.Location = new Point(4, 24);
            MiscTab.Name = "MiscTab";
            MiscTab.Padding = new Padding(3);
            MiscTab.Size = new Size(798, 427);
            MiscTab.TabIndex = 2;
            MiscTab.Text = "Misc";
            MiscTab.UseVisualStyleBackColor = true;
            // 
            // ConsumablesTab
            // 
            ConsumablesTab.Location = new Point(4, 24);
            ConsumablesTab.Name = "ConsumablesTab";
            ConsumablesTab.Size = new Size(798, 427);
            ConsumablesTab.TabIndex = 3;
            ConsumablesTab.Text = "Consumables";
            ConsumablesTab.UseVisualStyleBackColor = true;
            // 
            // KeysTab
            // 
            KeysTab.Location = new Point(4, 24);
            KeysTab.Name = "KeysTab";
            KeysTab.Size = new Size(798, 427);
            KeysTab.TabIndex = 4;
            KeysTab.Text = "Keys";
            KeysTab.UseVisualStyleBackColor = true;
            // 
            // DictionaryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 446);
            Controls.Add(dictionaryTabs);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "DictionaryForm";
            Text = "Dictionary";
            Load += DictionaryForm_Load;
            dictionaryTabs.ResumeLayout(false);
            ArmorTab.ResumeLayout(false);
            ArmorTab.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl dictionaryTabs;
        private TabPage ArmorTab;
        private TabPage WeaponsTab;
        private TabPage MiscTab;
        private ListBox listBox1;
        private RichTextBox DescriptionBox;
        private Label DropLimit;
        private Label Weight;
        private Label CellWidth;
        private Label CellHeight;
        private Label ItemID;
        private Label NameLabel;
        private TabPage WearablesTab;
        private TabPage ConsumablesTab;
        private TabPage KeysTab;
    }
}