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
            ArmorList = new ListBox();
            WearablesTab = new TabPage();
            WeaponsTab = new TabPage();
            MiscTab = new TabPage();
            ConsumablesTab = new TabPage();
            KeysTab = new TabPage();
            label2 = new Label();
            WearableDescription = new RichTextBox();
            WearablesList = new ListBox();
            label3 = new Label();
            WeaponDescription = new RichTextBox();
            WeaponsList = new ListBox();
            label4 = new Label();
            MiscDescription = new RichTextBox();
            MiscList = new ListBox();
            label5 = new Label();
            ConsumableDescription = new RichTextBox();
            ConsumablesList = new ListBox();
            label6 = new Label();
            KeyDescription = new RichTextBox();
            KeysList = new ListBox();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            label17 = new Label();
            label18 = new Label();
            label19 = new Label();
            label20 = new Label();
            label21 = new Label();
            label22 = new Label();
            label23 = new Label();
            label24 = new Label();
            label25 = new Label();
            label26 = new Label();
            label27 = new Label();
            label28 = new Label();
            label29 = new Label();
            label30 = new Label();
            label31 = new Label();
            label32 = new Label();
            label33 = new Label();
            label34 = new Label();
            label35 = new Label();
            label36 = new Label();
            label37 = new Label();
            label38 = new Label();
            label39 = new Label();
            label40 = new Label();
            label41 = new Label();
            label42 = new Label();
            dictionaryTabs.SuspendLayout();
            ArmorTab.SuspendLayout();
            WearablesTab.SuspendLayout();
            WeaponsTab.SuspendLayout();
            MiscTab.SuspendLayout();
            ConsumablesTab.SuspendLayout();
            KeysTab.SuspendLayout();
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
            ArmorTab.Controls.Add(ArmorList);
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
            label1.Location = new Point(241, 224);
            label1.Name = "label1";
            label1.Size = new Size(70, 15);
            label1.TabIndex = 9;
            label1.Text = "Description:";
            // 
            // DescriptionBox
            // 
            DescriptionBox.Location = new Point(241, 242);
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
            // ArmorList
            // 
            ArmorList.FormattingEnabled = true;
            ArmorList.ItemHeight = 15;
            ArmorList.Location = new Point(0, 0);
            ArmorList.Name = "ArmorList";
            ArmorList.Size = new Size(241, 424);
            ArmorList.TabIndex = 0;
            ArmorList.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // WearablesTab
            // 
            WearablesTab.Controls.Add(label21);
            WearablesTab.Controls.Add(label8);
            WearablesTab.Controls.Add(label9);
            WearablesTab.Controls.Add(label10);
            WearablesTab.Controls.Add(label11);
            WearablesTab.Controls.Add(label12);
            WearablesTab.Controls.Add(label13);
            WearablesTab.Controls.Add(label2);
            WearablesTab.Controls.Add(WearableDescription);
            WearablesTab.Controls.Add(WearablesList);
            WearablesTab.Location = new Point(4, 24);
            WearablesTab.Name = "WearablesTab";
            WearablesTab.Size = new Size(798, 427);
            WearablesTab.TabIndex = 5;
            WearablesTab.Text = "Wearables";
            WearablesTab.UseVisualStyleBackColor = true;
            // 
            // WeaponsTab
            // 
            WeaponsTab.Controls.Add(label14);
            WeaponsTab.Controls.Add(label15);
            WeaponsTab.Controls.Add(label16);
            WeaponsTab.Controls.Add(label17);
            WeaponsTab.Controls.Add(label18);
            WeaponsTab.Controls.Add(label19);
            WeaponsTab.Controls.Add(label20);
            WeaponsTab.Controls.Add(label3);
            WeaponsTab.Controls.Add(WeaponDescription);
            WeaponsTab.Controls.Add(WeaponsList);
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
            MiscTab.Controls.Add(label22);
            MiscTab.Controls.Add(label23);
            MiscTab.Controls.Add(label24);
            MiscTab.Controls.Add(label25);
            MiscTab.Controls.Add(label26);
            MiscTab.Controls.Add(label27);
            MiscTab.Controls.Add(label28);
            MiscTab.Controls.Add(label4);
            MiscTab.Controls.Add(MiscDescription);
            MiscTab.Controls.Add(MiscList);
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
            ConsumablesTab.Controls.Add(label29);
            ConsumablesTab.Controls.Add(label30);
            ConsumablesTab.Controls.Add(label31);
            ConsumablesTab.Controls.Add(label32);
            ConsumablesTab.Controls.Add(label33);
            ConsumablesTab.Controls.Add(label34);
            ConsumablesTab.Controls.Add(label35);
            ConsumablesTab.Controls.Add(label5);
            ConsumablesTab.Controls.Add(ConsumableDescription);
            ConsumablesTab.Controls.Add(ConsumablesList);
            ConsumablesTab.Location = new Point(4, 24);
            ConsumablesTab.Name = "ConsumablesTab";
            ConsumablesTab.Size = new Size(798, 427);
            ConsumablesTab.TabIndex = 3;
            ConsumablesTab.Text = "Consumables";
            ConsumablesTab.UseVisualStyleBackColor = true;
            // 
            // KeysTab
            // 
            KeysTab.Controls.Add(label36);
            KeysTab.Controls.Add(label37);
            KeysTab.Controls.Add(label38);
            KeysTab.Controls.Add(label39);
            KeysTab.Controls.Add(label40);
            KeysTab.Controls.Add(label41);
            KeysTab.Controls.Add(label42);
            KeysTab.Controls.Add(label6);
            KeysTab.Controls.Add(KeyDescription);
            KeysTab.Controls.Add(KeysList);
            KeysTab.Location = new Point(4, 24);
            KeysTab.Name = "KeysTab";
            KeysTab.Size = new Size(798, 427);
            KeysTab.TabIndex = 4;
            KeysTab.Text = "Keys";
            KeysTab.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(241, 224);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 12;
            label2.Text = "Description:";
            // 
            // WearableDescription
            // 
            WearableDescription.Location = new Point(241, 242);
            WearableDescription.Name = "WearableDescription";
            WearableDescription.Size = new Size(554, 183);
            WearableDescription.TabIndex = 11;
            WearableDescription.Text = "";
            // 
            // WearablesList
            // 
            WearablesList.FormattingEnabled = true;
            WearablesList.ItemHeight = 15;
            WearablesList.Location = new Point(0, 0);
            WearablesList.Name = "WearablesList";
            WearablesList.Size = new Size(241, 424);
            WearablesList.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(241, 224);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 12;
            label3.Text = "Description:";
            // 
            // WeaponDescription
            // 
            WeaponDescription.Location = new Point(241, 242);
            WeaponDescription.Name = "WeaponDescription";
            WeaponDescription.Size = new Size(554, 183);
            WeaponDescription.TabIndex = 11;
            WeaponDescription.Text = "";
            // 
            // WeaponsList
            // 
            WeaponsList.FormattingEnabled = true;
            WeaponsList.ItemHeight = 15;
            WeaponsList.Location = new Point(0, 0);
            WeaponsList.Name = "WeaponsList";
            WeaponsList.Size = new Size(241, 424);
            WeaponsList.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(241, 224);
            label4.Name = "label4";
            label4.Size = new Size(70, 15);
            label4.TabIndex = 12;
            label4.Text = "Description:";
            // 
            // MiscDescription
            // 
            MiscDescription.Location = new Point(241, 242);
            MiscDescription.Name = "MiscDescription";
            MiscDescription.Size = new Size(554, 183);
            MiscDescription.TabIndex = 11;
            MiscDescription.Text = "";
            // 
            // MiscList
            // 
            MiscList.FormattingEnabled = true;
            MiscList.ItemHeight = 15;
            MiscList.Location = new Point(0, 0);
            MiscList.Name = "MiscList";
            MiscList.Size = new Size(241, 424);
            MiscList.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(241, 224);
            label5.Name = "label5";
            label5.Size = new Size(70, 15);
            label5.TabIndex = 12;
            label5.Text = "Description:";
            // 
            // ConsumableDescription
            // 
            ConsumableDescription.Location = new Point(241, 242);
            ConsumableDescription.Name = "ConsumableDescription";
            ConsumableDescription.Size = new Size(554, 183);
            ConsumableDescription.TabIndex = 11;
            ConsumableDescription.Text = "";
            // 
            // ConsumablesList
            // 
            ConsumablesList.FormattingEnabled = true;
            ConsumablesList.ItemHeight = 15;
            ConsumablesList.Location = new Point(0, 0);
            ConsumablesList.Name = "ConsumablesList";
            ConsumablesList.Size = new Size(241, 424);
            ConsumablesList.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(241, 224);
            label6.Name = "label6";
            label6.Size = new Size(70, 15);
            label6.TabIndex = 12;
            label6.Text = "Description:";
            // 
            // KeyDescription
            // 
            KeyDescription.Location = new Point(241, 242);
            KeyDescription.Name = "KeyDescription";
            KeyDescription.Size = new Size(554, 183);
            KeyDescription.TabIndex = 11;
            KeyDescription.Text = "";
            // 
            // KeysList
            // 
            KeysList.FormattingEnabled = true;
            KeysList.ItemHeight = 15;
            KeysList.Location = new Point(0, 0);
            KeysList.Name = "KeysList";
            KeysList.Size = new Size(241, 424);
            KeysList.TabIndex = 10;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(241, 78);
            label8.Name = "label8";
            label8.Size = new Size(79, 15);
            label8.TabIndex = 18;
            label8.Text = "Discard Limit:";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(241, 63);
            label9.Name = "label9";
            label9.Size = new Size(75, 15);
            label9.TabIndex = 17;
            label9.Text = "Item Weight:";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(241, 48);
            label10.Name = "label10";
            label10.Size = new Size(68, 15);
            label10.TabIndex = 16;
            label10.Text = "Cell Width: ";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(241, 33);
            label11.Name = "label11";
            label11.Size = new Size(69, 15);
            label11.TabIndex = 15;
            label11.Text = "Cell Height:";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(241, 18);
            label12.Name = "label12";
            label12.Size = new Size(48, 15);
            label12.TabIndex = 14;
            label12.Text = "Item ID:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(241, 3);
            label13.Name = "label13";
            label13.Size = new Size(42, 15);
            label13.TabIndex = 13;
            label13.Text = "Name:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label14.ForeColor = Color.Red;
            label14.Location = new Point(444, 18);
            label14.Name = "label14";
            label14.Size = new Size(81, 15);
            label14.TabIndex = 22;
            label14.Text = "BLACKLISTED";
            label14.Visible = false;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(241, 78);
            label15.Name = "label15";
            label15.Size = new Size(79, 15);
            label15.TabIndex = 21;
            label15.Text = "Discard Limit:";
            label15.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(241, 63);
            label16.Name = "label16";
            label16.Size = new Size(75, 15);
            label16.TabIndex = 20;
            label16.Text = "Item Weight:";
            label16.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(241, 48);
            label17.Name = "label17";
            label17.Size = new Size(68, 15);
            label17.TabIndex = 19;
            label17.Text = "Cell Width: ";
            label17.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(241, 33);
            label18.Name = "label18";
            label18.Size = new Size(69, 15);
            label18.TabIndex = 18;
            label18.Text = "Cell Height:";
            label18.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(241, 18);
            label19.Name = "label19";
            label19.Size = new Size(48, 15);
            label19.TabIndex = 17;
            label19.Text = "Item ID:";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(241, 3);
            label20.Name = "label20";
            label20.Size = new Size(42, 15);
            label20.TabIndex = 16;
            label20.Text = "Name:";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label21.ForeColor = Color.Red;
            label21.Location = new Point(444, 18);
            label21.Name = "label21";
            label21.Size = new Size(81, 15);
            label21.TabIndex = 23;
            label21.Text = "BLACKLISTED";
            label21.Visible = false;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label22.ForeColor = Color.Red;
            label22.Location = new Point(444, 18);
            label22.Name = "label22";
            label22.Size = new Size(81, 15);
            label22.TabIndex = 29;
            label22.Text = "BLACKLISTED";
            label22.Visible = false;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(241, 78);
            label23.Name = "label23";
            label23.Size = new Size(79, 15);
            label23.TabIndex = 28;
            label23.Text = "Discard Limit:";
            label23.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(241, 63);
            label24.Name = "label24";
            label24.Size = new Size(75, 15);
            label24.TabIndex = 27;
            label24.Text = "Item Weight:";
            label24.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(241, 48);
            label25.Name = "label25";
            label25.Size = new Size(68, 15);
            label25.TabIndex = 26;
            label25.Text = "Cell Width: ";
            label25.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new Point(241, 33);
            label26.Name = "label26";
            label26.Size = new Size(69, 15);
            label26.TabIndex = 25;
            label26.Text = "Cell Height:";
            label26.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new Point(241, 18);
            label27.Name = "label27";
            label27.Size = new Size(48, 15);
            label27.TabIndex = 24;
            label27.Text = "Item ID:";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new Point(241, 3);
            label28.Name = "label28";
            label28.Size = new Size(42, 15);
            label28.TabIndex = 23;
            label28.Text = "Name:";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label29.ForeColor = Color.Red;
            label29.Location = new Point(444, 18);
            label29.Name = "label29";
            label29.Size = new Size(81, 15);
            label29.TabIndex = 29;
            label29.Text = "BLACKLISTED";
            label29.Visible = false;
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Location = new Point(241, 78);
            label30.Name = "label30";
            label30.Size = new Size(79, 15);
            label30.TabIndex = 28;
            label30.Text = "Discard Limit:";
            label30.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Location = new Point(241, 63);
            label31.Name = "label31";
            label31.Size = new Size(75, 15);
            label31.TabIndex = 27;
            label31.Text = "Item Weight:";
            label31.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Location = new Point(241, 48);
            label32.Name = "label32";
            label32.Size = new Size(68, 15);
            label32.TabIndex = 26;
            label32.Text = "Cell Width: ";
            label32.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Location = new Point(241, 33);
            label33.Name = "label33";
            label33.Size = new Size(69, 15);
            label33.TabIndex = 25;
            label33.Text = "Cell Height:";
            label33.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.Location = new Point(241, 18);
            label34.Name = "label34";
            label34.Size = new Size(48, 15);
            label34.TabIndex = 24;
            label34.Text = "Item ID:";
            // 
            // label35
            // 
            label35.AutoSize = true;
            label35.Location = new Point(241, 3);
            label35.Name = "label35";
            label35.Size = new Size(42, 15);
            label35.TabIndex = 23;
            label35.Text = "Name:";
            // 
            // label36
            // 
            label36.AutoSize = true;
            label36.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label36.ForeColor = Color.Red;
            label36.Location = new Point(444, 18);
            label36.Name = "label36";
            label36.Size = new Size(81, 15);
            label36.TabIndex = 29;
            label36.Text = "BLACKLISTED";
            label36.Visible = false;
            // 
            // label37
            // 
            label37.AutoSize = true;
            label37.Location = new Point(241, 78);
            label37.Name = "label37";
            label37.Size = new Size(79, 15);
            label37.TabIndex = 28;
            label37.Text = "Discard Limit:";
            label37.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label38
            // 
            label38.AutoSize = true;
            label38.Location = new Point(241, 63);
            label38.Name = "label38";
            label38.Size = new Size(75, 15);
            label38.TabIndex = 27;
            label38.Text = "Item Weight:";
            label38.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label39
            // 
            label39.AutoSize = true;
            label39.Location = new Point(241, 48);
            label39.Name = "label39";
            label39.Size = new Size(68, 15);
            label39.TabIndex = 26;
            label39.Text = "Cell Width: ";
            label39.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label40
            // 
            label40.AutoSize = true;
            label40.Location = new Point(241, 33);
            label40.Name = "label40";
            label40.Size = new Size(69, 15);
            label40.TabIndex = 25;
            label40.Text = "Cell Height:";
            label40.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label41
            // 
            label41.AutoSize = true;
            label41.Location = new Point(241, 18);
            label41.Name = "label41";
            label41.Size = new Size(48, 15);
            label41.TabIndex = 24;
            label41.Text = "Item ID:";
            // 
            // label42
            // 
            label42.AutoSize = true;
            label42.Location = new Point(241, 3);
            label42.Name = "label42";
            label42.Size = new Size(42, 15);
            label42.TabIndex = 23;
            label42.Text = "Name:";
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
            WearablesTab.ResumeLayout(false);
            WearablesTab.PerformLayout();
            WeaponsTab.ResumeLayout(false);
            WeaponsTab.PerformLayout();
            MiscTab.ResumeLayout(false);
            MiscTab.PerformLayout();
            ConsumablesTab.ResumeLayout(false);
            ConsumablesTab.PerformLayout();
            KeysTab.ResumeLayout(false);
            KeysTab.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl dictionaryTabs;
        private TabPage ArmorTab;
        private TabPage WeaponsTab;
        private TabPage MiscTab;
        private ListBox ArmorList;
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
        private Label label2;
        private RichTextBox WearableDescription;
        private ListBox WearablesList;
        private Label label3;
        private RichTextBox WeaponDescription;
        private ListBox WeaponsList;
        private Label label4;
        private RichTextBox MiscDescription;
        private ListBox MiscList;
        private Label label5;
        private RichTextBox ConsumableDescription;
        private ListBox ConsumablesList;
        private Label label6;
        private RichTextBox KeyDescription;
        private ListBox KeysList;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label20;
        private Label label21;
        private Label label22;
        private Label label23;
        private Label label24;
        private Label label25;
        private Label label26;
        private Label label27;
        private Label label28;
        private Label label29;
        private Label label30;
        private Label label31;
        private Label label32;
        private Label label33;
        private Label label34;
        private Label label35;
        private Label label36;
        private Label label37;
        private Label label38;
        private Label label39;
        private Label label40;
        private Label label41;
        private Label label42;
    }
}