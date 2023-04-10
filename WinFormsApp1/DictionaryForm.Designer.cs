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
            Class = new Label();
            ProtectionZones = new Label();
            Penalties = new Label();
            label7 = new Label();
            RepairCost = new Label();
            EffectiveDurability = new Label();
            Durability = new Label();
            BluntThroughput = new Label();
            Materials = new Label();
            label1 = new Label();
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
            ArmorTab.Controls.Add(Class);
            ArmorTab.Controls.Add(ProtectionZones);
            ArmorTab.Controls.Add(Penalties);
            ArmorTab.Controls.Add(label7);
            ArmorTab.Controls.Add(RepairCost);
            ArmorTab.Controls.Add(EffectiveDurability);
            ArmorTab.Controls.Add(Durability);
            ArmorTab.Controls.Add(BluntThroughput);
            ArmorTab.Controls.Add(Materials);
            ArmorTab.Controls.Add(label1);
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
            // Class
            // 
            Class.AutoSize = true;
            Class.Location = new Point(241, 108);
            Class.Name = "Class";
            Class.Size = new Size(37, 15);
            Class.TabIndex = 18;
            Class.Text = "Class:";
            // 
            // ProtectionZones
            // 
            ProtectionZones.AutoSize = true;
            ProtectionZones.Location = new Point(416, 78);
            ProtectionZones.Name = "ProtectionZones";
            ProtectionZones.Size = new Size(100, 15);
            ProtectionZones.TabIndex = 17;
            ProtectionZones.Text = "Protection Zones:";
            ProtectionZones.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Penalties
            // 
            Penalties.AutoSize = true;
            Penalties.Location = new Point(241, 138);
            Penalties.Name = "Penalties";
            Penalties.Size = new Size(57, 60);
            Penalties.TabIndex = 16;
            Penalties.Text = "Penalties:\r\nTurn 0\r\nMove 0\r\nErgo 0";
            Penalties.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label7.ForeColor = Color.Red;
            label7.Location = new Point(444, 18);
            label7.Name = "label7";
            label7.Size = new Size(81, 15);
            label7.TabIndex = 15;
            label7.Text = "BLACKLISTED";
            label7.Visible = false;
            // 
            // RepairCost
            // 
            RepairCost.AutoSize = true;
            RepairCost.Location = new Point(416, 63);
            RepairCost.Name = "RepairCost";
            RepairCost.Size = new Size(70, 15);
            RepairCost.TabIndex = 14;
            RepairCost.Text = "Repair Cost:";
            // 
            // EffectiveDurability
            // 
            EffectiveDurability.AutoSize = true;
            EffectiveDurability.Location = new Point(416, 48);
            EffectiveDurability.Name = "EffectiveDurability";
            EffectiveDurability.Size = new Size(109, 15);
            EffectiveDurability.TabIndex = 13;
            EffectiveDurability.Text = "Effective Durability:";
            // 
            // Durability
            // 
            Durability.AutoSize = true;
            Durability.Location = new Point(416, 33);
            Durability.Name = "Durability";
            Durability.Size = new Size(61, 15);
            Durability.TabIndex = 12;
            Durability.Text = "Durability:";
            // 
            // BluntThroughput
            // 
            BluntThroughput.AutoSize = true;
            BluntThroughput.Location = new Point(241, 123);
            BluntThroughput.Name = "BluntThroughput";
            BluntThroughput.Size = new Size(104, 15);
            BluntThroughput.TabIndex = 11;
            BluntThroughput.Text = "Blunt Throughput:";
            // 
            // Materials
            // 
            Materials.AutoSize = true;
            Materials.Location = new Point(241, 93);
            Materials.Name = "Materials";
            Materials.Size = new Size(58, 15);
            Materials.TabIndex = 10;
            Materials.Text = "Materials:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(241, 223);
            label1.Name = "label1";
            label1.Size = new Size(70, 15);
            label1.TabIndex = 9;
            label1.Text = "Description:";
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
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Location = new Point(241, 3);
            NameLabel.Name = "NameLabel";
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
        private Label RepairCost;
        private Label EffectiveDurability;
        private Label Durability;
        private Label BluntThroughput;
        private Label Materials;
        private Label label1;
        private Label label7;
        private Label Penalties;
        private Label ProtectionZones;
        private Label Class;
    }
}