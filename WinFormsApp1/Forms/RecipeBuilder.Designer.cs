namespace SPTLauncher
{
    partial class RecipeBuilder
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
            NewRecipeButton = new Button();
            groupBox1 = new GroupBox();
            productBox = new ComboBox();
            DeleteRecipeButton = new Button();
            LockedBox = new CheckBox();
            SaveRecipeButton = new Button();
            label9 = new Label();
            productionTime = new NumericUpDown();
            label5 = new Label();
            CraftAmount = new NumericUpDown();
            PowerRequirement = new CheckBox();
            label4 = new Label();
            endProductBox = new TextBox();
            nameTextBox = new TextBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            ItemCheckBox = new CheckBox();
            ResourceCheckBox = new CheckBox();
            ToolCheckBox = new CheckBox();
            linkLabel1 = new LinkLabel();
            requiredModuleLvl = new NumericUpDown();
            label8 = new Label();
            RequiredAmount = new NumericUpDown();
            label7 = new Label();
            label6 = new Label();
            requiredModuleBox = new ComboBox();
            button3 = new Button();
            label3 = new Label();
            requirementID = new ComboBox();
            requirementList = new ListBox();
            button2 = new Button();
            ModuleComboBox = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)productionTime).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CraftAmount).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)requiredModuleLvl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RequiredAmount).BeginInit();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(0, 0);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(207, 454);
            listBox1.TabIndex = 0;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // NewRecipeButton
            // 
            NewRecipeButton.Location = new Point(546, 0);
            NewRecipeButton.Name = "NewRecipeButton";
            NewRecipeButton.Size = new Size(43, 23);
            NewRecipeButton.TabIndex = 1;
            NewRecipeButton.Text = "New";
            NewRecipeButton.UseVisualStyleBackColor = true;
            NewRecipeButton.Click += NewRecipeButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(productBox);
            groupBox1.Controls.Add(DeleteRecipeButton);
            groupBox1.Controls.Add(LockedBox);
            groupBox1.Controls.Add(SaveRecipeButton);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(productionTime);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(CraftAmount);
            groupBox1.Controls.Add(PowerRequirement);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(endProductBox);
            groupBox1.Controls.Add(nameTextBox);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(NewRecipeButton);
            groupBox1.Controls.Add(ModuleComboBox);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(209, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(589, 448);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Selected Recipe";
            // 
            // productBox
            // 
            productBox.FormattingEnabled = true;
            productBox.Location = new Point(272, 82);
            productBox.Name = "productBox";
            productBox.RightToLeft = RightToLeft.No;
            productBox.Size = new Size(179, 23);
            productBox.TabIndex = 18;
            productBox.SelectedIndexChanged += productBox_SelectedIndexChanged;
            productBox.KeyDown += productBox_KeyDown;
            // 
            // DeleteRecipeButton
            // 
            DeleteRecipeButton.Location = new Point(451, 0);
            DeleteRecipeButton.Name = "DeleteRecipeButton";
            DeleteRecipeButton.Size = new Size(54, 23);
            DeleteRecipeButton.TabIndex = 17;
            DeleteRecipeButton.Text = "Delete";
            DeleteRecipeButton.UseVisualStyleBackColor = true;
            DeleteRecipeButton.Click += DeleteRecipeButton_Click;
            // 
            // LockedBox
            // 
            LockedBox.AutoSize = true;
            LockedBox.Location = new Point(476, 49);
            LockedBox.Name = "LockedBox";
            LockedBox.Size = new Size(64, 19);
            LockedBox.TabIndex = 16;
            LockedBox.Text = "Locked";
            LockedBox.UseVisualStyleBackColor = true;
            // 
            // SaveRecipeButton
            // 
            SaveRecipeButton.Location = new Point(504, 0);
            SaveRecipeButton.Name = "SaveRecipeButton";
            SaveRecipeButton.Size = new Size(43, 23);
            SaveRecipeButton.TabIndex = 15;
            SaveRecipeButton.Text = "Save";
            SaveRecipeButton.UseVisualStyleBackColor = true;
            SaveRecipeButton.Click += SaveRecipeButton_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 82);
            label9.Name = "label9";
            label9.Size = new Size(98, 15);
            label9.TabIndex = 14;
            label9.Text = "Production Time:";
            // 
            // productionTime
            // 
            productionTime.Location = new Point(110, 80);
            productionTime.Maximum = new decimal(new int[] { 604800, 0, 0, 0 });
            productionTime.Name = "productionTime";
            productionTime.Size = new Size(88, 23);
            productionTime.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(204, 54);
            label5.Name = "label5";
            label5.Size = new Size(83, 15);
            label5.TabIndex = 12;
            label5.Text = "Craft Amount:";
            // 
            // CraftAmount
            // 
            CraftAmount.Location = new Point(293, 51);
            CraftAmount.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            CraftAmount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            CraftAmount.Name = "CraftAmount";
            CraftAmount.Size = new Size(51, 23);
            CraftAmount.TabIndex = 11;
            CraftAmount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // PowerRequirement
            // 
            PowerRequirement.AutoSize = true;
            PowerRequirement.Location = new Point(476, 24);
            PowerRequirement.Name = "PowerRequirement";
            PowerRequirement.Size = new Size(103, 19);
            PowerRequirement.TabIndex = 10;
            PowerRequirement.Text = "Power Needed";
            PowerRequirement.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(204, 25);
            label4.Name = "label4";
            label4.Size = new Size(75, 15);
            label4.TabIndex = 9;
            label4.Text = "End Product:";
            // 
            // endProductBox
            // 
            endProductBox.Location = new Point(293, 22);
            endProductBox.Name = "endProductBox";
            endProductBox.Size = new Size(158, 23);
            endProductBox.TabIndex = 8;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(63, 22);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(135, 23);
            nameTextBox.TabIndex = 7;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(groupBox3);
            groupBox2.Controls.Add(linkLabel1);
            groupBox2.Controls.Add(requiredModuleLvl);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(RequiredAmount);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(requiredModuleBox);
            groupBox2.Controls.Add(button3);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(requirementID);
            groupBox2.Controls.Add(requirementList);
            groupBox2.Controls.Add(button2);
            groupBox2.Location = new Point(6, 262);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(577, 180);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Requirements:";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(ItemCheckBox);
            groupBox3.Controls.Add(ResourceCheckBox);
            groupBox3.Controls.Add(ToolCheckBox);
            groupBox3.Location = new Point(178, 131);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(222, 45);
            groupBox3.TabIndex = 17;
            groupBox3.TabStop = false;
            groupBox3.Text = "Requirement Type";
            // 
            // ItemCheckBox
            // 
            ItemCheckBox.AutoSize = true;
            ItemCheckBox.Location = new Point(20, 20);
            ItemCheckBox.Name = "ItemCheckBox";
            ItemCheckBox.Size = new Size(50, 19);
            ItemCheckBox.TabIndex = 8;
            ItemCheckBox.Text = "Item";
            ItemCheckBox.UseVisualStyleBackColor = true;
            ItemCheckBox.CheckedChanged += ItemCheckBox_CheckedChanged;
            // 
            // ResourceCheckBox
            // 
            ResourceCheckBox.AutoSize = true;
            ResourceCheckBox.Location = new Point(76, 20);
            ResourceCheckBox.Name = "ResourceCheckBox";
            ResourceCheckBox.Size = new Size(74, 19);
            ResourceCheckBox.TabIndex = 7;
            ResourceCheckBox.Text = "Resource";
            ResourceCheckBox.UseVisualStyleBackColor = true;
            ResourceCheckBox.CheckedChanged += ResourceCheckBox_CheckedChanged;
            // 
            // ToolCheckBox
            // 
            ToolCheckBox.AutoSize = true;
            ToolCheckBox.Location = new Point(156, 20);
            ToolCheckBox.Name = "ToolCheckBox";
            ToolCheckBox.Size = new Size(48, 19);
            ToolCheckBox.TabIndex = 6;
            ToolCheckBox.Text = "Tool";
            ToolCheckBox.UseVisualStyleBackColor = true;
            ToolCheckBox.CheckedChanged += ToolCheckBox_CheckedChanged;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(303, 19);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(25, 15);
            linkLabel1.TabIndex = 16;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "List";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // requiredModuleLvl
            // 
            requiredModuleLvl.Location = new Point(519, 38);
            requiredModuleLvl.Name = "requiredModuleLvl";
            requiredModuleLvl.Size = new Size(41, 23);
            requiredModuleLvl.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(193, 69);
            label8.Name = "label8";
            label8.Size = new Size(104, 15);
            label8.TabIndex = 14;
            label8.Text = "Required Amount:";
            // 
            // RequiredAmount
            // 
            RequiredAmount.Location = new Point(303, 67);
            RequiredAmount.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            RequiredAmount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            RequiredAmount.Name = "RequiredAmount";
            RequiredAmount.Size = new Size(51, 23);
            RequiredAmount.TabIndex = 13;
            RequiredAmount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(526, 19);
            label7.Name = "label7";
            label7.Size = new Size(28, 15);
            label7.TabIndex = 13;
            label7.Text = "LVL:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(423, 19);
            label6.Name = "label6";
            label6.Size = new Size(51, 15);
            label6.TabIndex = 12;
            label6.Text = "Module:";
            // 
            // requiredModuleBox
            // 
            requiredModuleBox.FormattingEnabled = true;
            requiredModuleBox.Location = new Point(384, 37);
            requiredModuleBox.Name = "requiredModuleBox";
            requiredModuleBox.Size = new Size(129, 23);
            requiredModuleBox.TabIndex = 10;
            // 
            // button3
            // 
            button3.Location = new Point(130, -1);
            button3.Name = "button3";
            button3.Size = new Size(42, 23);
            button3.TabIndex = 9;
            button3.Text = "-";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(249, 19);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 8;
            label3.Text = "Item ID:";
            // 
            // requirementID
            // 
            requirementID.FormattingEnabled = true;
            requirementID.Location = new Point(187, 37);
            requirementID.Name = "requirementID";
            requirementID.Size = new Size(178, 23);
            requirementID.TabIndex = 7;
            requirementID.SelectedIndexChanged += requirementID_SelectedIndexChanged;
            requirementID.KeyPress += requirementID_KeyPress;
            // 
            // requirementList
            // 
            requirementList.FormattingEnabled = true;
            requirementList.ItemHeight = 15;
            requirementList.Location = new Point(6, 22);
            requirementList.Name = "requirementList";
            requirementList.Size = new Size(166, 154);
            requirementList.TabIndex = 0;
            requirementList.SelectedIndexChanged += requirementList_SelectedIndexChanged;
            // 
            // button2
            // 
            button2.Location = new Point(85, -1);
            button2.Name = "button2";
            button2.Size = new Size(42, 23);
            button2.TabIndex = 5;
            button2.Text = "+";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // ModuleComboBox
            // 
            ModuleComboBox.FormattingEnabled = true;
            ModuleComboBox.Location = new Point(63, 51);
            ModuleComboBox.Name = "ModuleComboBox";
            ModuleComboBox.Size = new Size(135, 23);
            ModuleComboBox.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 54);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 2;
            label2.Text = "Module:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 25);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 1;
            label1.Text = "Name:";
            // 
            // RecipeBuilder
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Controls.Add(listBox1);
            Name = "RecipeBuilder";
            Text = "RecipeBuilder";
            FormClosing += RecipeBuilder_FormClosing;
            Load += RecipeBuilder_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)productionTime).EndInit();
            ((System.ComponentModel.ISupportInitialize)CraftAmount).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)requiredModuleLvl).EndInit();
            ((System.ComponentModel.ISupportInitialize)RequiredAmount).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBox1;
        private Button NewRecipeButton;
        private GroupBox groupBox1;
        private Label label1;
        private ListBox requirementList;
        private Label label2;
        private ComboBox ModuleComboBox;
        private GroupBox groupBox2;
        private Button button2;
        private CheckBox ToolCheckBox;
        private Label label3;
        private ComboBox requirementID;
        private Button button3;
        private TextBox nameTextBox;
        private Label label4;
        private TextBox endProductBox;
        private CheckBox PowerRequirement;
        private NumericUpDown CraftAmount;
        private Label label5;
        private ComboBox requiredModuleBox;
        private Label label7;
        private Label label6;
        private Label label8;
        private NumericUpDown RequiredAmount;
        private Label label9;
        private NumericUpDown productionTime;
        private NumericUpDown requiredModuleLvl;
        private Button SaveRecipeButton;
        private CheckBox LockedBox;
        private LinkLabel linkLabel1;
        private GroupBox groupBox3;
        private CheckBox ItemCheckBox;
        private CheckBox ResourceCheckBox;
        private Button DeleteRecipeButton;
        private ComboBox productBox;
    }
}