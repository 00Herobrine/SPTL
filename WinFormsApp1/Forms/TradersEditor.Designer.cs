namespace SPTLauncher
{
    partial class TradersEditor
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
            groupBox1 = new GroupBox();
            unlocked = new CheckBox();
            traderID = new Label();
            medicCheckBox = new CheckBox();
            label15 = new Label();
            gridHeight = new NumericUpDown();
            insuranceCheckBox = new CheckBox();
            InsuranceGroup = new GroupBox();
            label16 = new Label();
            numericUpDown1 = new NumericUpDown();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            maxReturnTime = new NumericUpDown();
            minReturnTime = new NumericUpDown();
            label10 = new Label();
            label9 = new Label();
            refreshTime = new NumericUpDown();
            clothingCheckBox = new CheckBox();
            currencyBox = new ComboBox();
            newLoyaltyLevel = new Button();
            loyaltyBox = new ComboBox();
            groupBox2 = new GroupBox();
            label17 = new Label();
            insuranceCoef = new NumericUpDown();
            button5 = new Button();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            saleSum = new NumericUpDown();
            minLevel = new NumericUpDown();
            minStanding = new NumericUpDown();
            label1 = new Label();
            label5 = new Label();
            healCoef = new NumericUpDown();
            label4 = new Label();
            repairCoef = new NumericUpDown();
            label3 = new Label();
            exchangeCoef = new NumericUpDown();
            label2 = new Label();
            buyCoef = new NumericUpDown();
            tradersBox = new ComboBox();
            SaveButton = new Button();
            LoadButton = new Button();
            button3 = new Button();
            button4 = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridHeight).BeginInit();
            InsuranceGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)maxReturnTime).BeginInit();
            ((System.ComponentModel.ISupportInitialize)minReturnTime).BeginInit();
            ((System.ComponentModel.ISupportInitialize)refreshTime).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)insuranceCoef).BeginInit();
            ((System.ComponentModel.ISupportInitialize)saleSum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)minLevel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)minStanding).BeginInit();
            ((System.ComponentModel.ISupportInitialize)healCoef).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repairCoef).BeginInit();
            ((System.ComponentModel.ISupportInitialize)exchangeCoef).BeginInit();
            ((System.ComponentModel.ISupportInitialize)buyCoef).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(unlocked);
            groupBox1.Controls.Add(traderID);
            groupBox1.Controls.Add(medicCheckBox);
            groupBox1.Controls.Add(label15);
            groupBox1.Controls.Add(gridHeight);
            groupBox1.Controls.Add(insuranceCheckBox);
            groupBox1.Controls.Add(InsuranceGroup);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(refreshTime);
            groupBox1.Controls.Add(clothingCheckBox);
            groupBox1.Controls.Add(currencyBox);
            groupBox1.Controls.Add(newLoyaltyLevel);
            groupBox1.Controls.Add(loyaltyBox);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Location = new Point(130, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(669, 452);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Trader Controls";
            // 
            // unlocked
            // 
            unlocked.AutoSize = true;
            unlocked.Location = new Point(414, 14);
            unlocked.Name = "unlocked";
            unlocked.Size = new Size(76, 19);
            unlocked.TabIndex = 39;
            unlocked.Text = "Unlocked";
            unlocked.UseVisualStyleBackColor = true;
            // 
            // traderID
            // 
            traderID.AutoSize = true;
            traderID.Location = new Point(247, 0);
            traderID.Name = "traderID";
            traderID.RightToLeft = RightToLeft.No;
            traderID.Size = new Size(161, 15);
            traderID.TabIndex = 38;
            traderID.Text = "ID GOES HERE IN THIS PLACE";
            traderID.TextAlign = ContentAlignment.MiddleRight;
            // 
            // medicCheckBox
            // 
            medicCheckBox.AutoSize = true;
            medicCheckBox.Location = new Point(500, 14);
            medicCheckBox.Name = "medicCheckBox";
            medicCheckBox.Size = new Size(59, 19);
            medicCheckBox.TabIndex = 32;
            medicCheckBox.Text = "Medic";
            medicCheckBox.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(14, 53);
            label15.Name = "label15";
            label15.Size = new Size(71, 15);
            label15.TabIndex = 31;
            label15.Text = "Grid Height:";
            // 
            // gridHeight
            // 
            gridHeight.Location = new Point(91, 51);
            gridHeight.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            gridHeight.Name = "gridHeight";
            gridHeight.Size = new Size(61, 23);
            gridHeight.TabIndex = 30;
            // 
            // insuranceCheckBox
            // 
            insuranceCheckBox.AutoSize = true;
            insuranceCheckBox.Location = new Point(167, 15);
            insuranceCheckBox.Name = "insuranceCheckBox";
            insuranceCheckBox.Size = new Size(15, 14);
            insuranceCheckBox.TabIndex = 24;
            insuranceCheckBox.UseVisualStyleBackColor = true;
            insuranceCheckBox.CheckedChanged += insuranceCheckBox_CheckedChanged;
            // 
            // InsuranceGroup
            // 
            InsuranceGroup.Controls.Add(label16);
            InsuranceGroup.Controls.Add(numericUpDown1);
            InsuranceGroup.Controls.Add(label14);
            InsuranceGroup.Controls.Add(label13);
            InsuranceGroup.Controls.Add(label12);
            InsuranceGroup.Controls.Add(label11);
            InsuranceGroup.Controls.Add(maxReturnTime);
            InsuranceGroup.Controls.Add(minReturnTime);
            InsuranceGroup.Enabled = false;
            InsuranceGroup.Location = new Point(158, 14);
            InsuranceGroup.Name = "InsuranceGroup";
            InsuranceGroup.Size = new Size(174, 104);
            InsuranceGroup.TabIndex = 29;
            InsuranceGroup.TabStop = false;
            InsuranceGroup.Text = "     Insurance";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(114, 0);
            label16.Name = "label16";
            label16.Size = new Size(60, 15);
            label16.TabIndex = 37;
            label16.Text = "In Hour(s)";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(105, 70);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(45, 23);
            numericUpDown1.TabIndex = 36;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(20, 72);
            label14.Name = "label14";
            label14.Size = new Size(79, 15);
            label14.TabIndex = 35;
            label14.Text = "Storage Time:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(89, 43);
            label13.Name = "label13";
            label13.Size = new Size(33, 15);
            label13.TabIndex = 34;
            label13.Text = "Max:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(1, 43);
            label12.Name = "label12";
            label12.Size = new Size(31, 15);
            label12.TabIndex = 33;
            label12.Text = "Min:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(48, 19);
            label11.Name = "label11";
            label11.Size = new Size(74, 15);
            label11.TabIndex = 32;
            label11.Text = "Return Time:";
            // 
            // maxReturnTime
            // 
            maxReturnTime.Location = new Point(127, 41);
            maxReturnTime.Name = "maxReturnTime";
            maxReturnTime.Size = new Size(45, 23);
            maxReturnTime.TabIndex = 31;
            // 
            // minReturnTime
            // 
            minReturnTime.Location = new Point(37, 41);
            minReturnTime.Name = "minReturnTime";
            minReturnTime.Size = new Size(45, 23);
            minReturnTime.TabIndex = 30;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(27, 83);
            label10.Name = "label10";
            label10.Size = new Size(58, 15);
            label10.TabIndex = 28;
            label10.Text = "Currency:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(7, 24);
            label9.Name = "label9";
            label9.Size = new Size(78, 15);
            label9.TabIndex = 27;
            label9.Text = "Refresh Time:";
            // 
            // refreshTime
            // 
            refreshTime.Location = new Point(91, 22);
            refreshTime.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            refreshTime.Name = "refreshTime";
            refreshTime.Size = new Size(61, 23);
            refreshTime.TabIndex = 26;
            refreshTime.Value = new decimal(new int[] { 3600, 0, 0, 0 });
            // 
            // clothingCheckBox
            // 
            clothingCheckBox.AutoSize = true;
            clothingCheckBox.Location = new Point(565, 14);
            clothingCheckBox.Name = "clothingCheckBox";
            clothingCheckBox.Size = new Size(98, 19);
            clothingCheckBox.TabIndex = 25;
            clothingCheckBox.Text = "Sells Clothing";
            clothingCheckBox.UseVisualStyleBackColor = true;
            // 
            // currencyBox
            // 
            currencyBox.FormattingEnabled = true;
            currencyBox.Location = new Point(91, 80);
            currencyBox.Name = "currencyBox";
            currencyBox.Size = new Size(61, 23);
            currencyBox.TabIndex = 23;
            // 
            // newLoyaltyLevel
            // 
            newLoyaltyLevel.Location = new Point(41, 142);
            newLoyaltyLevel.Name = "newLoyaltyLevel";
            newLoyaltyLevel.Size = new Size(59, 23);
            newLoyaltyLevel.TabIndex = 22;
            newLoyaltyLevel.Text = "New";
            newLoyaltyLevel.UseVisualStyleBackColor = true;
            newLoyaltyLevel.Click += newLoyaltyLevel_Click;
            // 
            // loyaltyBox
            // 
            loyaltyBox.FormattingEnabled = true;
            loyaltyBox.Location = new Point(18, 111);
            loyaltyBox.Name = "loyaltyBox";
            loyaltyBox.Size = new Size(42, 23);
            loyaltyBox.TabIndex = 6;
            loyaltyBox.SelectedIndexChanged += loyaltyBox_SelectedIndexChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label17);
            groupBox2.Controls.Add(insuranceCoef);
            groupBox2.Controls.Add(button5);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(saleSum);
            groupBox2.Controls.Add(minLevel);
            groupBox2.Controls.Add(minStanding);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(healCoef);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(repairCoef);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(exchangeCoef);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(buyCoef);
            groupBox2.Enabled = false;
            groupBox2.Location = new Point(14, 114);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(295, 183);
            groupBox2.TabIndex = 16;
            groupBox2.TabStop = false;
            groupBox2.Text = "             Loyalty Level";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(168, 155);
            label17.Name = "label17";
            label17.Size = new Size(61, 15);
            label17.TabIndex = 23;
            label17.Text = "Insurance:";
            // 
            // insuranceCoef
            // 
            insuranceCoef.Location = new Point(235, 153);
            insuranceCoef.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            insuranceCoef.Name = "insuranceCoef";
            insuranceCoef.Size = new Size(53, 23);
            insuranceCoef.TabIndex = 22;
            insuranceCoef.ValueChanged += insuranceCoef_ValueChanged;
            // 
            // button5
            // 
            button5.Location = new Point(92, 28);
            button5.Name = "button5";
            button5.Size = new Size(59, 23);
            button5.TabIndex = 6;
            button5.Text = "Delete";
            button5.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(41, 70);
            label8.Name = "label8";
            label8.Size = new Size(61, 15);
            label8.TabIndex = 21;
            label8.Text = "Min Level:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(21, 99);
            label7.Name = "label7";
            label7.Size = new Size(81, 15);
            label7.TabIndex = 20;
            label7.Text = "Min Standing:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(4, 128);
            label6.Name = "label6";
            label6.Size = new Size(58, 15);
            label6.TabIndex = 19;
            label6.Text = "Sale Sum:";
            // 
            // saleSum
            // 
            saleSum.Location = new Point(68, 124);
            saleSum.Maximum = new decimal(new int[] { 276447231, 23283, 0, 0 });
            saleSum.Name = "saleSum";
            saleSum.Size = new Size(93, 23);
            saleSum.TabIndex = 18;
            saleSum.ValueChanged += saleSum_ValueChanged;
            // 
            // minLevel
            // 
            minLevel.Location = new Point(108, 68);
            minLevel.Name = "minLevel";
            minLevel.Size = new Size(53, 23);
            minLevel.TabIndex = 17;
            minLevel.ValueChanged += minLevel_ValueChanged;
            // 
            // minStanding
            // 
            minStanding.DecimalPlaces = 2;
            minStanding.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            minStanding.Location = new Point(108, 97);
            minStanding.Name = "minStanding";
            minStanding.Size = new Size(53, 23);
            minStanding.TabIndex = 16;
            minStanding.ValueChanged += minStanding_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(189, 19);
            label1.Name = "label1";
            label1.Size = new Size(70, 15);
            label1.TabIndex = 11;
            label1.Text = "Coefficients";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(186, 97);
            label5.Name = "label5";
            label5.Size = new Size(43, 15);
            label5.TabIndex = 15;
            label5.Text = "Repair:";
            // 
            // healCoef
            // 
            healCoef.Location = new Point(235, 66);
            healCoef.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            healCoef.Name = "healCoef";
            healCoef.Size = new Size(53, 23);
            healCoef.TabIndex = 7;
            healCoef.ValueChanged += healCoef_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(199, 39);
            label4.Name = "label4";
            label4.Size = new Size(30, 15);
            label4.TabIndex = 14;
            label4.Text = "Buy:";
            // 
            // repairCoef
            // 
            repairCoef.Location = new Point(235, 95);
            repairCoef.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            repairCoef.Name = "repairCoef";
            repairCoef.Size = new Size(53, 23);
            repairCoef.TabIndex = 8;
            repairCoef.ValueChanged += repairCoef_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(168, 126);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 13;
            label3.Text = "Exchange:";
            // 
            // exchangeCoef
            // 
            exchangeCoef.Location = new Point(235, 124);
            exchangeCoef.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            exchangeCoef.Name = "exchangeCoef";
            exchangeCoef.Size = new Size(53, 23);
            exchangeCoef.TabIndex = 9;
            exchangeCoef.ValueChanged += exchangeCoef_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(195, 68);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 12;
            label2.Text = "Heal:";
            // 
            // buyCoef
            // 
            buyCoef.Location = new Point(235, 37);
            buyCoef.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            buyCoef.Name = "buyCoef";
            buyCoef.Size = new Size(53, 23);
            buyCoef.TabIndex = 10;
            buyCoef.ValueChanged += buyCoef_ValueChanged;
            // 
            // tradersBox
            // 
            tradersBox.FormattingEnabled = true;
            tradersBox.Location = new Point(3, 7);
            tradersBox.Name = "tradersBox";
            tradersBox.Size = new Size(121, 23);
            tradersBox.TabIndex = 1;
            tradersBox.SelectedIndexChanged += tradersBox_SelectedIndexChanged;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(3, 36);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(121, 23);
            SaveButton.TabIndex = 2;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // LoadButton
            // 
            LoadButton.Location = new Point(3, 65);
            LoadButton.Name = "LoadButton";
            LoadButton.Size = new Size(121, 23);
            LoadButton.TabIndex = 3;
            LoadButton.Text = "Load";
            LoadButton.UseVisualStyleBackColor = true;
            LoadButton.Click += LoadButton_Click;
            // 
            // button3
            // 
            button3.Location = new Point(3, 123);
            button3.Name = "button3";
            button3.Size = new Size(121, 23);
            button3.TabIndex = 4;
            button3.Text = "Load Preset";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(3, 94);
            button4.Name = "button4";
            button4.Size = new Size(121, 23);
            button4.TabIndex = 5;
            button4.Text = "Save Preset";
            button4.UseVisualStyleBackColor = true;
            // 
            // TradersEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(LoadButton);
            Controls.Add(SaveButton);
            Controls.Add(tradersBox);
            Controls.Add(groupBox1);
            Name = "TradersEditor";
            Text = "TradersEditor";
            Load += TradersEditor_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridHeight).EndInit();
            InsuranceGroup.ResumeLayout(false);
            InsuranceGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)maxReturnTime).EndInit();
            ((System.ComponentModel.ISupportInitialize)minReturnTime).EndInit();
            ((System.ComponentModel.ISupportInitialize)refreshTime).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)insuranceCoef).EndInit();
            ((System.ComponentModel.ISupportInitialize)saleSum).EndInit();
            ((System.ComponentModel.ISupportInitialize)minLevel).EndInit();
            ((System.ComponentModel.ISupportInitialize)minStanding).EndInit();
            ((System.ComponentModel.ISupportInitialize)healCoef).EndInit();
            ((System.ComponentModel.ISupportInitialize)repairCoef).EndInit();
            ((System.ComponentModel.ISupportInitialize)exchangeCoef).EndInit();
            ((System.ComponentModel.ISupportInitialize)buyCoef).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox tradersBox;
        private Button SaveButton;
        private Button LoadButton;
        private Button button3;
        private Button button4;
        private ComboBox loyaltyBox;
        private NumericUpDown healCoef;
        private NumericUpDown buyCoef;
        private NumericUpDown exchangeCoef;
        private NumericUpDown repairCoef;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private GroupBox groupBox2;
        private NumericUpDown minStanding;
        private NumericUpDown saleSum;
        private NumericUpDown minLevel;
        private Label label6;
        private Label label8;
        private Label label7;
        private Button button5;
        private Button newLoyaltyLevel;
        private CheckBox clothingCheckBox;
        private CheckBox insuranceCheckBox;
        private ComboBox currencyBox;
        private NumericUpDown refreshTime;
        private Label label9;
        private Label label10;
        private GroupBox InsuranceGroup;
        private NumericUpDown maxReturnTime;
        private NumericUpDown minReturnTime;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private NumericUpDown numericUpDown1;
        private Label label15;
        private NumericUpDown gridHeight;
        private Label label16;
        private CheckBox medicCheckBox;
        private Label traderID;
        private CheckBox unlocked;
        private NumericUpDown insuranceCoef;
        private Label label17;
    }
}