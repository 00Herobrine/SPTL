namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            groupBox1 = new GroupBox();
            DeleteProfileButton = new Button();
            editionsBox = new ComboBox();
            button13 = new Button();
            IDLabel = new Label();
            button11 = new Button();
            SkillsButton = new Button();
            HealthButton = new Button();
            button9 = new Button();
            InspectsButton = new Button();
            button6 = new Button();
            WipeButton = new Button();
            label1 = new Label();
            linkLabel2 = new LinkLabel();
            PlayButton = new Button();
            button1 = new Button();
            expLabel = new Label();
            editionLabel = new Label();
            nameLabel = new Label();
            profilesList = new ComboBox();
            groupBox3 = new GroupBox();
            skillProgressBox = new NumericUpDown();
            label3 = new Label();
            saveSkillsButton = new Button();
            label2 = new Label();
            comboBox1 = new ComboBox();
            ResponsesButton = new Button();
            factionImage = new PictureBox();
            settingsGroup = new GroupBox();
            versionWarningCheck = new CheckBox();
            groupBox5 = new GroupBox();
            label13 = new Label();
            backupDeleteInterval = new NumericUpDown();
            profileBackupCheckBox = new CheckBox();
            label12 = new Label();
            label4 = new Label();
            label7 = new Label();
            BackUpInterval = new NumericUpDown();
            label11 = new Label();
            LangBox = new ComboBox();
            ImageCachingCheck = new CheckBox();
            BugsFeedbackBox = new PictureBox();
            donatePicture = new PictureBox();
            label10 = new Label();
            LoadPresetButton = new Button();
            SavePresetButton = new Button();
            minimizeCheck = new CheckBox();
            checkBox1 = new CheckBox();
            button4 = new Button();
            linkLabel3 = new LinkLabel();
            textBox1 = new TextBox();
            OpenFolderButton = new PictureBox();
            button14 = new Button();
            label5 = new Label();
            startServerButton = new Button();
            label6 = new Label();
            stateLabel = new Label();
            groupBox2 = new GroupBox();
            SettingsButton = new PictureBox();
            QuestButton = new Button();
            ModsButton = new Button();
            button5 = new Button();
            dictionaryButton = new Button();
            autoStartCheckBox = new CheckBox();
            autoScrollBox = new CheckBox();
            linkLabel1 = new LinkLabel();
            killServerButton = new Button();
            autoKillCheckBox = new CheckBox();
            pictureBox1 = new PictureBox();
            serverConsole = new RichTextBox();
            groupBox4 = new GroupBox();
            ModsListCheckBox = new CheckedListBox();
            button16 = new Button();
            ModConfig = new Button();
            modsListBox = new ListBox();
            BackupGroup = new GroupBox();
            DayBox = new ComboBox();
            MonthBox = new ComboBox();
            label9 = new Label();
            YearBox = new ComboBox();
            BackupsList = new ListBox();
            SaveRestoreButton = new Button();
            RestoreBackupButton = new Button();
            label8 = new Label();
            BackupProfiles = new ComboBox();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)skillProgressBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)factionImage).BeginInit();
            settingsGroup.SuspendLayout();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)backupDeleteInterval).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BackUpInterval).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BugsFeedbackBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)donatePicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)OpenFolderButton).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SettingsButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox4.SuspendLayout();
            BackupGroup.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(DeleteProfileButton);
            groupBox1.Controls.Add(editionsBox);
            groupBox1.Controls.Add(button13);
            groupBox1.Controls.Add(IDLabel);
            groupBox1.Controls.Add(button11);
            groupBox1.Controls.Add(SkillsButton);
            groupBox1.Controls.Add(HealthButton);
            groupBox1.Controls.Add(button9);
            groupBox1.Controls.Add(InspectsButton);
            groupBox1.Controls.Add(button6);
            groupBox1.Controls.Add(WipeButton);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(linkLabel2);
            groupBox1.Controls.Add(PlayButton);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(expLabel);
            groupBox1.Controls.Add(editionLabel);
            groupBox1.Controls.Add(nameLabel);
            groupBox1.Controls.Add(profilesList);
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Enabled = false;
            groupBox1.Location = new Point(2, -6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(648, 302);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // DeleteProfileButton
            // 
            DeleteProfileButton.Location = new Point(569, 243);
            DeleteProfileButton.Name = "DeleteProfileButton";
            DeleteProfileButton.Size = new Size(75, 23);
            DeleteProfileButton.TabIndex = 30;
            DeleteProfileButton.Text = "Delete";
            DeleteProfileButton.UseVisualStyleBackColor = true;
            DeleteProfileButton.Click += DeleteProfileButton_Click;
            // 
            // editionsBox
            // 
            editionsBox.FormattingEnabled = true;
            editionsBox.Location = new Point(59, 100);
            editionsBox.Name = "editionsBox";
            editionsBox.Size = new Size(160, 23);
            editionsBox.TabIndex = 29;
            editionsBox.SelectedIndexChanged += editionsBox_SelectedIndexChanged;
            // 
            // button13
            // 
            button13.Location = new Point(488, 272);
            button13.Name = "button13";
            button13.Size = new Size(156, 23);
            button13.TabIndex = 27;
            button13.Text = "Encyclopedia";
            button13.UseVisualStyleBackColor = true;
            button13.Click += button13_Click;
            // 
            // IDLabel
            // 
            IDLabel.AutoSize = true;
            IDLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            IDLabel.Location = new Point(6, 82);
            IDLabel.Name = "IDLabel";
            IDLabel.Size = new Size(26, 19);
            IDLabel.TabIndex = 26;
            IDLabel.Text = "ID:";
            // 
            // button11
            // 
            button11.Location = new Point(569, 214);
            button11.Name = "button11";
            button11.Size = new Size(75, 23);
            button11.TabIndex = 23;
            button11.Text = "Traders";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // SkillsButton
            // 
            SkillsButton.Location = new Point(569, 117);
            SkillsButton.Name = "SkillsButton";
            SkillsButton.Size = new Size(75, 23);
            SkillsButton.TabIndex = 24;
            SkillsButton.Text = "Skills";
            SkillsButton.UseVisualStyleBackColor = true;
            SkillsButton.Click += button12_Click;
            // 
            // HealthButton
            // 
            HealthButton.Location = new Point(488, 58);
            HealthButton.Name = "HealthButton";
            HealthButton.Size = new Size(75, 23);
            HealthButton.TabIndex = 22;
            HealthButton.Text = "Health";
            HealthButton.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            button9.Location = new Point(569, 88);
            button9.Name = "button9";
            button9.Size = new Size(75, 23);
            button9.TabIndex = 21;
            button9.Text = "Vanity";
            button9.UseVisualStyleBackColor = true;
            // 
            // InspectsButton
            // 
            InspectsButton.Location = new Point(569, 59);
            InspectsButton.Name = "InspectsButton";
            InspectsButton.Size = new Size(75, 23);
            InspectsButton.TabIndex = 20;
            InspectsButton.Text = "Inspects";
            InspectsButton.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(488, 30);
            button6.Name = "button6";
            button6.Size = new Size(75, 23);
            button6.TabIndex = 18;
            button6.Text = "Name";
            button6.UseVisualStyleBackColor = true;
            // 
            // WipeButton
            // 
            WipeButton.Location = new Point(569, 30);
            WipeButton.Name = "WipeButton";
            WipeButton.Size = new Size(75, 23);
            WipeButton.TabIndex = 14;
            WipeButton.Text = "Wipe";
            WipeButton.UseVisualStyleBackColor = true;
            WipeButton.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(494, 9);
            label1.Name = "label1";
            label1.Size = new Size(140, 21);
            label1.TabIndex = 16;
            label1.Text = "Account Functions:";
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Location = new Point(6, 19);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(49, 15);
            linkLabel2.TabIndex = 12;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Profiles:";
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // PlayButton
            // 
            PlayButton.Location = new Point(144, 37);
            PlayButton.Name = "PlayButton";
            PlayButton.Size = new Size(75, 23);
            PlayButton.TabIndex = 6;
            PlayButton.Text = "Play";
            PlayButton.UseVisualStyleBackColor = true;
            PlayButton.Click += PlayButton_Click;
            // 
            // button1
            // 
            button1.Location = new Point(712, 416);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 5;
            button1.Text = "Play";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // expLabel
            // 
            expLabel.AutoSize = true;
            expLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            expLabel.Location = new Point(6, 121);
            expLabel.Name = "expLabel";
            expLabel.Size = new Size(43, 19);
            expLabel.TabIndex = 4;
            expLabel.Text = "Level:";
            // 
            // editionLabel
            // 
            editionLabel.AutoSize = true;
            editionLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            editionLabel.Location = new Point(6, 101);
            editionLabel.Name = "editionLabel";
            editionLabel.Size = new Size(54, 19);
            editionLabel.TabIndex = 3;
            editionLabel.Text = "Edition:";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            nameLabel.Location = new Point(6, 63);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(48, 19);
            nameLabel.TabIndex = 2;
            nameLabel.Text = "Name:";
            // 
            // profilesList
            // 
            profilesList.AllowDrop = true;
            profilesList.FormattingEnabled = true;
            profilesList.ImeMode = ImeMode.Off;
            profilesList.Location = new Point(6, 37);
            profilesList.Name = "profilesList";
            profilesList.Size = new Size(121, 23);
            profilesList.TabIndex = 0;
            profilesList.SelectedIndexChanged += profilesList_SelectedIndexChanged;
            profilesList.KeyDown += profilesList_KeyDown;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(skillProgressBox);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(saveSkillsButton);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(comboBox1);
            groupBox3.Location = new Point(225, 11);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(253, 285);
            groupBox3.TabIndex = 25;
            groupBox3.TabStop = false;
            groupBox3.Text = "Skills Functions";
            groupBox3.Visible = false;
            // 
            // skillProgressBox
            // 
            skillProgressBox.Location = new Point(171, 17);
            skillProgressBox.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            skillProgressBox.Name = "skillProgressBox";
            skillProgressBox.Size = new Size(76, 23);
            skillProgressBox.TabIndex = 6;
            skillProgressBox.ValueChanged += skillProgressBox_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(110, 20);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 4;
            label3.Text = "Progress:";
            // 
            // saveSkillsButton
            // 
            saveSkillsButton.Location = new Point(186, 48);
            saveSkillsButton.Name = "saveSkillsButton";
            saveSkillsButton.Size = new Size(61, 23);
            saveSkillsButton.TabIndex = 2;
            saveSkillsButton.Text = "Save";
            saveSkillsButton.UseVisualStyleBackColor = true;
            saveSkillsButton.Click += saveSkillsButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 30);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 1;
            label2.Text = "Skill:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 48);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(168, 23);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // ResponsesButton
            // 
            ResponsesButton.Location = new Point(490, 237);
            ResponsesButton.Name = "ResponsesButton";
            ResponsesButton.Size = new Size(75, 23);
            ResponsesButton.TabIndex = 31;
            ResponsesButton.Text = "Responses";
            ResponsesButton.UseVisualStyleBackColor = true;
            ResponsesButton.Click += ResponsesButton_Click;
            // 
            // factionImage
            // 
            factionImage.Location = new Point(37, 158);
            factionImage.Name = "factionImage";
            factionImage.Size = new Size(135, 135);
            factionImage.SizeMode = PictureBoxSizeMode.Zoom;
            factionImage.TabIndex = 13;
            factionImage.TabStop = false;
            // 
            // settingsGroup
            // 
            settingsGroup.Controls.Add(versionWarningCheck);
            settingsGroup.Controls.Add(groupBox5);
            settingsGroup.Controls.Add(label11);
            settingsGroup.Controls.Add(LangBox);
            settingsGroup.Controls.Add(ImageCachingCheck);
            settingsGroup.Controls.Add(BugsFeedbackBox);
            settingsGroup.Controls.Add(donatePicture);
            settingsGroup.Controls.Add(label10);
            settingsGroup.Controls.Add(LoadPresetButton);
            settingsGroup.Controls.Add(SavePresetButton);
            settingsGroup.Controls.Add(minimizeCheck);
            settingsGroup.Controls.Add(checkBox1);
            settingsGroup.Controls.Add(button4);
            settingsGroup.Controls.Add(linkLabel3);
            settingsGroup.Controls.Add(textBox1);
            settingsGroup.Location = new Point(227, 4);
            settingsGroup.Name = "settingsGroup";
            settingsGroup.Size = new Size(253, 285);
            settingsGroup.TabIndex = 6;
            settingsGroup.TabStop = false;
            settingsGroup.Text = "Settings";
            settingsGroup.Visible = false;
            // 
            // versionWarningCheck
            // 
            versionWarningCheck.AutoSize = true;
            versionWarningCheck.Checked = true;
            versionWarningCheck.CheckState = CheckState.Checked;
            versionWarningCheck.Location = new Point(6, 194);
            versionWarningCheck.Name = "versionWarningCheck";
            versionWarningCheck.Size = new Size(117, 19);
            versionWarningCheck.TabIndex = 42;
            versionWarningCheck.Text = "Version Warnings";
            versionWarningCheck.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(label13);
            groupBox5.Controls.Add(backupDeleteInterval);
            groupBox5.Controls.Add(profileBackupCheckBox);
            groupBox5.Controls.Add(label12);
            groupBox5.Controls.Add(label4);
            groupBox5.Controls.Add(label7);
            groupBox5.Controls.Add(BackUpInterval);
            groupBox5.Location = new Point(6, 66);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(165, 97);
            groupBox5.TabIndex = 41;
            groupBox5.TabStop = false;
            groupBox5.Text = "Profile Backups";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(107, 72);
            label13.Name = "label13";
            label13.Size = new Size(40, 15);
            label13.TabIndex = 42;
            label13.Text = "Day(s)";
            // 
            // backupDeleteInterval
            // 
            backupDeleteInterval.Location = new Point(104, 46);
            backupDeleteInterval.Maximum = new decimal(new int[] { 43800, 0, 0, 0 });
            backupDeleteInterval.Name = "backupDeleteInterval";
            backupDeleteInterval.Size = new Size(55, 23);
            backupDeleteInterval.TabIndex = 41;
            backupDeleteInterval.Value = new decimal(new int[] { 90, 0, 0, 0 });
            // 
            // profileBackupCheckBox
            // 
            profileBackupCheckBox.AutoSize = true;
            profileBackupCheckBox.Checked = true;
            profileBackupCheckBox.CheckState = CheckState.Checked;
            profileBackupCheckBox.Location = new Point(95, -1);
            profileBackupCheckBox.Name = "profileBackupCheckBox";
            profileBackupCheckBox.Size = new Size(61, 19);
            profileBackupCheckBox.TabIndex = 32;
            profileBackupCheckBox.Text = "Toggle";
            profileBackupCheckBox.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(107, 28);
            label12.Name = "label12";
            label12.Size = new Size(43, 15);
            label12.TabIndex = 40;
            label12.Text = "Delete:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 28);
            label4.Name = "label4";
            label4.Size = new Size(44, 15);
            label4.TabIndex = 30;
            label4.Text = "Create:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(9, 72);
            label7.Name = "label7";
            label7.Size = new Size(41, 15);
            label7.TabIndex = 31;
            label7.Text = "Min(s)";
            // 
            // BackUpInterval
            // 
            BackUpInterval.Location = new Point(6, 46);
            BackUpInterval.Maximum = new decimal(new int[] { 43800, 0, 0, 0 });
            BackUpInterval.Name = "BackUpInterval";
            BackUpInterval.Size = new Size(55, 23);
            BackUpInterval.TabIndex = 29;
            BackUpInterval.Value = new decimal(new int[] { 1440, 0, 0, 0 });
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(113, 235);
            label11.Name = "label11";
            label11.Size = new Size(62, 15);
            label11.TabIndex = 39;
            label11.Text = "Language:";
            // 
            // LangBox
            // 
            LangBox.FormattingEnabled = true;
            LangBox.Location = new Point(181, 232);
            LangBox.Name = "LangBox";
            LangBox.Size = new Size(61, 23);
            LangBox.TabIndex = 31;
            // 
            // ImageCachingCheck
            // 
            ImageCachingCheck.AutoSize = true;
            ImageCachingCheck.Checked = true;
            ImageCachingCheck.CheckState = CheckState.Checked;
            ImageCachingCheck.Location = new Point(6, 214);
            ImageCachingCheck.Name = "ImageCachingCheck";
            ImageCachingCheck.Size = new Size(106, 19);
            ImageCachingCheck.TabIndex = 38;
            ImageCachingCheck.Text = "Image Caching";
            ImageCachingCheck.UseVisualStyleBackColor = true;
            ImageCachingCheck.CheckedChanged += ImageCachingCheck_CheckedChanged;
            // 
            // BugsFeedbackBox
            // 
            BugsFeedbackBox.Image = SPTLauncher.Properties.Resources.bug;
            BugsFeedbackBox.Location = new Point(44, 251);
            BugsFeedbackBox.Name = "BugsFeedbackBox";
            BugsFeedbackBox.Size = new Size(32, 32);
            BugsFeedbackBox.SizeMode = PictureBoxSizeMode.Zoom;
            BugsFeedbackBox.TabIndex = 37;
            BugsFeedbackBox.TabStop = false;
            BugsFeedbackBox.Click += BugsFeedbackBox_Click;
            // 
            // donatePicture
            // 
            donatePicture.Image = SPTLauncher.Properties.Resources.donate;
            donatePicture.Location = new Point(6, 251);
            donatePicture.Name = "donatePicture";
            donatePicture.Size = new Size(32, 32);
            donatePicture.SizeMode = PictureBoxSizeMode.Zoom;
            donatePicture.TabIndex = 14;
            donatePicture.TabStop = false;
            donatePicture.Click += donatePicture_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(189, 65);
            label10.Name = "label10";
            label10.Size = new Size(42, 15);
            label10.TabIndex = 36;
            label10.Text = "Preset:";
            // 
            // LoadPresetButton
            // 
            LoadPresetButton.Location = new Point(181, 83);
            LoadPresetButton.Name = "LoadPresetButton";
            LoadPresetButton.Size = new Size(58, 23);
            LoadPresetButton.TabIndex = 35;
            LoadPresetButton.Text = "Load";
            LoadPresetButton.UseVisualStyleBackColor = true;
            LoadPresetButton.Click += LoadPresetButton_Click;
            // 
            // SavePresetButton
            // 
            SavePresetButton.Location = new Point(181, 112);
            SavePresetButton.Name = "SavePresetButton";
            SavePresetButton.Size = new Size(58, 23);
            SavePresetButton.TabIndex = 34;
            SavePresetButton.Text = "Save";
            SavePresetButton.UseVisualStyleBackColor = true;
            SavePresetButton.Click += SavePresetButton_Click;
            // 
            // minimizeCheck
            // 
            minimizeCheck.AutoSize = true;
            minimizeCheck.Location = new Point(113, 214);
            minimizeCheck.Name = "minimizeCheck";
            minimizeCheck.Size = new Size(134, 19);
            minimizeCheck.TabIndex = 33;
            minimizeCheck.Text = "Minimize on Launch";
            minimizeCheck.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Enabled = false;
            checkBox1.Location = new Point(6, 232);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(107, 19);
            checkBox1.TabIndex = 28;
            checkBox1.Text = "Profile Caching";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(189, 256);
            button4.Name = "button4";
            button4.Size = new Size(58, 23);
            button4.TabIndex = 3;
            button4.Text = "Save";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // linkLabel3
            // 
            linkLabel3.AutoSize = true;
            linkLabel3.Location = new Point(6, 19);
            linkLabel3.Name = "linkLabel3";
            linkLabel3.Size = new Size(138, 15);
            linkLabel3.TabIndex = 2;
            linkLabel3.TabStop = true;
            linkLabel3.Text = "Tarkov-Changes API Key:";
            linkLabel3.LinkClicked += linkLabel3_LinkClicked;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(6, 37);
            textBox1.Name = "textBox1";
            textBox1.PasswordChar = '*';
            textBox1.Size = new Size(241, 23);
            textBox1.TabIndex = 0;
            textBox1.UseSystemPasswordChar = true;
            // 
            // OpenFolderButton
            // 
            OpenFolderButton.Image = SPTLauncher.Properties.Resources.folder;
            OpenFolderButton.Location = new Point(33, 229);
            OpenFolderButton.Name = "OpenFolderButton";
            OpenFolderButton.Size = new Size(32, 32);
            OpenFolderButton.SizeMode = PictureBoxSizeMode.Zoom;
            OpenFolderButton.TabIndex = 38;
            OpenFolderButton.TabStop = false;
            OpenFolderButton.Click += OpenFolderButton_Click;
            // 
            // button14
            // 
            button14.Location = new Point(67, 177);
            button14.Name = "button14";
            button14.Size = new Size(60, 23);
            button14.TabIndex = 28;
            button14.Text = "Recipes";
            button14.UseVisualStyleBackColor = true;
            button14.Click += button14_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(6, 9);
            label5.Name = "label5";
            label5.Size = new Size(121, 21);
            label5.TabIndex = 2;
            label5.Text = "Server Controls:";
            // 
            // startServerButton
            // 
            startServerButton.Location = new Point(6, 63);
            startServerButton.Name = "startServerButton";
            startServerButton.Size = new Size(71, 23);
            startServerButton.TabIndex = 3;
            startServerButton.Text = "Start";
            startServerButton.UseVisualStyleBackColor = true;
            startServerButton.Click += StartServerButton_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(25, 30);
            label6.Name = "label6";
            label6.Size = new Size(79, 15);
            label6.TabIndex = 4;
            label6.Text = "127.0.0.1:6969";
            // 
            // stateLabel
            // 
            stateLabel.AutoSize = true;
            stateLabel.Location = new Point(20, 45);
            stateLabel.Name = "stateLabel";
            stateLabel.Size = new Size(90, 15);
            stateLabel.TabIndex = 5;
            stateLabel.Text = "Status: OFFLINE";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(SettingsButton);
            groupBox2.Controls.Add(OpenFolderButton);
            groupBox2.Controls.Add(QuestButton);
            groupBox2.Controls.Add(ModsButton);
            groupBox2.Controls.Add(button5);
            groupBox2.Controls.Add(dictionaryButton);
            groupBox2.Controls.Add(autoStartCheckBox);
            groupBox2.Controls.Add(autoScrollBox);
            groupBox2.Controls.Add(linkLabel1);
            groupBox2.Controls.Add(killServerButton);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(stateLabel);
            groupBox2.Controls.Add(startServerButton);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(autoKillCheckBox);
            groupBox2.Controls.Add(button14);
            groupBox2.Location = new Point(656, -6);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(135, 302);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            // 
            // SettingsButton
            // 
            SettingsButton.Image = SPTLauncher.Properties.Resources.settings;
            SettingsButton.Location = new Point(71, 229);
            SettingsButton.Name = "SettingsButton";
            SettingsButton.Size = new Size(32, 32);
            SettingsButton.SizeMode = PictureBoxSizeMode.Zoom;
            SettingsButton.TabIndex = 38;
            SettingsButton.TabStop = false;
            SettingsButton.Click += SettingsButton_Click;
            // 
            // QuestButton
            // 
            QuestButton.Location = new Point(6, 121);
            QuestButton.Name = "QuestButton";
            QuestButton.Size = new Size(121, 23);
            QuestButton.TabIndex = 31;
            QuestButton.Text = "Quest Manager";
            QuestButton.UseVisualStyleBackColor = true;
            QuestButton.Click += QuestButton_Click;
            // 
            // ModsButton
            // 
            ModsButton.Location = new Point(6, 204);
            ModsButton.Name = "ModsButton";
            ModsButton.Size = new Size(121, 23);
            ModsButton.TabIndex = 30;
            ModsButton.Text = "Mods";
            ModsButton.UseVisualStyleBackColor = true;
            ModsButton.Click += ModsButton_Click;
            // 
            // button5
            // 
            button5.Location = new Point(6, 177);
            button5.Name = "button5";
            button5.Size = new Size(59, 23);
            button5.TabIndex = 29;
            button5.Text = "Backups";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // dictionaryButton
            // 
            dictionaryButton.Location = new Point(6, 149);
            dictionaryButton.Name = "dictionaryButton";
            dictionaryButton.Size = new Size(121, 23);
            dictionaryButton.TabIndex = 13;
            dictionaryButton.Text = "Dictionary";
            dictionaryButton.UseVisualStyleBackColor = true;
            dictionaryButton.Click += dictionaryButton_Click;
            // 
            // autoStartCheckBox
            // 
            autoStartCheckBox.AutoSize = true;
            autoStartCheckBox.Location = new Point(81, 66);
            autoStartCheckBox.Name = "autoStartCheckBox";
            autoStartCheckBox.Size = new Size(52, 19);
            autoStartCheckBox.TabIndex = 10;
            autoStartCheckBox.Text = "Auto";
            autoStartCheckBox.UseVisualStyleBackColor = true;
            // 
            // autoScrollBox
            // 
            autoScrollBox.AutoSize = true;
            autoScrollBox.Checked = true;
            autoScrollBox.CheckState = CheckState.Checked;
            autoScrollBox.Location = new Point(19, 260);
            autoScrollBox.Name = "autoScrollBox";
            autoScrollBox.Size = new Size(95, 19);
            autoScrollBox.TabIndex = 8;
            autoScrollBox.Text = "Auto Bottom";
            autoScrollBox.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(25, 283);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(78, 15);
            linkLabel1.TabIndex = 7;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Hide Console";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // killServerButton
            // 
            killServerButton.Enabled = false;
            killServerButton.Location = new Point(6, 92);
            killServerButton.Name = "killServerButton";
            killServerButton.Size = new Size(71, 23);
            killServerButton.TabIndex = 6;
            killServerButton.Text = "Kill";
            killServerButton.UseVisualStyleBackColor = true;
            killServerButton.Click += killServerButton_Click;
            // 
            // autoKillCheckBox
            // 
            autoKillCheckBox.AutoSize = true;
            autoKillCheckBox.Location = new Point(81, 95);
            autoKillCheckBox.Name = "autoKillCheckBox";
            autoKillCheckBox.Size = new Size(52, 19);
            autoKillCheckBox.TabIndex = 9;
            autoKillCheckBox.Text = "Auto";
            autoKillCheckBox.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = SPTLauncher.Properties.Resources.down;
            pictureBox1.Location = new Point(745, 613);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(32, 32);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 37;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // serverConsole
            // 
            serverConsole.Location = new Point(2, 301);
            serverConsole.Name = "serverConsole";
            serverConsole.ReadOnly = true;
            serverConsole.Size = new Size(789, 345);
            serverConsole.TabIndex = 7;
            serverConsole.Text = "";
            serverConsole.KeyPress += serverConsole_KeyPress;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(ModsListCheckBox);
            groupBox4.Controls.Add(button16);
            groupBox4.Controls.Add(ModConfig);
            groupBox4.Controls.Add(modsListBox);
            groupBox4.Location = new Point(793, -6);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(228, 302);
            groupBox4.TabIndex = 8;
            groupBox4.TabStop = false;
            // 
            // ModsListCheckBox
            // 
            ModsListCheckBox.FormattingEnabled = true;
            ModsListCheckBox.Location = new Point(0, 9);
            ModsListCheckBox.Name = "ModsListCheckBox";
            ModsListCheckBox.Size = new Size(228, 256);
            ModsListCheckBox.TabIndex = 33;
            // 
            // button16
            // 
            button16.Location = new Point(116, 273);
            button16.Name = "button16";
            button16.Size = new Size(106, 23);
            button16.TabIndex = 32;
            button16.Text = "Disable";
            button16.UseVisualStyleBackColor = true;
            button16.Click += button16_Click;
            // 
            // ModConfig
            // 
            ModConfig.Enabled = false;
            ModConfig.Location = new Point(6, 273);
            ModConfig.Name = "ModConfig";
            ModConfig.Size = new Size(106, 23);
            ModConfig.TabIndex = 31;
            ModConfig.Text = "Open Config";
            ModConfig.UseVisualStyleBackColor = true;
            ModConfig.Click += ModConfig_Click;
            // 
            // modsListBox
            // 
            modsListBox.FormattingEnabled = true;
            modsListBox.ItemHeight = 15;
            modsListBox.Location = new Point(0, 9);
            modsListBox.Name = "modsListBox";
            modsListBox.Size = new Size(228, 259);
            modsListBox.TabIndex = 0;
            modsListBox.SelectedIndexChanged += modsList_SelectedIndexChanged;
            // 
            // BackupGroup
            // 
            BackupGroup.Controls.Add(DayBox);
            BackupGroup.Controls.Add(MonthBox);
            BackupGroup.Controls.Add(label9);
            BackupGroup.Controls.Add(YearBox);
            BackupGroup.Controls.Add(BackupsList);
            BackupGroup.Controls.Add(SaveRestoreButton);
            BackupGroup.Controls.Add(RestoreBackupButton);
            BackupGroup.Controls.Add(label8);
            BackupGroup.Controls.Add(BackupProfiles);
            BackupGroup.Enabled = false;
            BackupGroup.Location = new Point(793, 296);
            BackupGroup.Name = "BackupGroup";
            BackupGroup.Size = new Size(228, 350);
            BackupGroup.TabIndex = 9;
            BackupGroup.TabStop = false;
            BackupGroup.Text = "Restore Backup";
            // 
            // DayBox
            // 
            DayBox.Enabled = false;
            DayBox.FormattingEnabled = true;
            DayBox.Location = new Point(148, 55);
            DayBox.Name = "DayBox";
            DayBox.Size = new Size(56, 23);
            DayBox.TabIndex = 13;
            DayBox.SelectedIndexChanged += DayBox_SelectedIndexChanged;
            // 
            // MonthBox
            // 
            MonthBox.Enabled = false;
            MonthBox.FormattingEnabled = true;
            MonthBox.Location = new Point(86, 55);
            MonthBox.Name = "MonthBox";
            MonthBox.Size = new Size(56, 23);
            MonthBox.TabIndex = 12;
            MonthBox.SelectedIndexChanged += MonthBox_SelectedIndexChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 40);
            label9.Name = "label9";
            label9.Size = new Size(34, 15);
            label9.TabIndex = 11;
            label9.Text = "Date:";
            // 
            // YearBox
            // 
            YearBox.Enabled = false;
            YearBox.FormattingEnabled = true;
            YearBox.Location = new Point(24, 55);
            YearBox.Name = "YearBox";
            YearBox.Size = new Size(56, 23);
            YearBox.TabIndex = 10;
            YearBox.SelectedIndexChanged += BackupDatesBox_SelectedIndexChanged;
            // 
            // BackupsList
            // 
            BackupsList.Enabled = false;
            BackupsList.FormattingEnabled = true;
            BackupsList.ItemHeight = 15;
            BackupsList.Location = new Point(6, 80);
            BackupsList.Name = "BackupsList";
            BackupsList.Size = new Size(216, 229);
            BackupsList.TabIndex = 9;
            BackupsList.SelectedIndexChanged += BackupsList_SelectedIndexChanged;
            // 
            // SaveRestoreButton
            // 
            SaveRestoreButton.Enabled = false;
            SaveRestoreButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            SaveRestoreButton.Location = new Point(106, 321);
            SaveRestoreButton.Name = "SaveRestoreButton";
            SaveRestoreButton.Size = new Size(116, 23);
            SaveRestoreButton.TabIndex = 3;
            SaveRestoreButton.Text = "Save and Restore";
            SaveRestoreButton.UseVisualStyleBackColor = true;
            SaveRestoreButton.Click += SaveRestoreButton_Click;
            // 
            // RestoreBackupButton
            // 
            RestoreBackupButton.Enabled = false;
            RestoreBackupButton.Location = new Point(6, 321);
            RestoreBackupButton.Name = "RestoreBackupButton";
            RestoreBackupButton.Size = new Size(100, 23);
            RestoreBackupButton.TabIndex = 2;
            RestoreBackupButton.Text = "Restore";
            RestoreBackupButton.UseVisualStyleBackColor = true;
            RestoreBackupButton.Click += RestoreBackupButton_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 25);
            label8.Name = "label8";
            label8.Size = new Size(44, 15);
            label8.TabIndex = 1;
            label8.Text = "Profile:";
            // 
            // BackupProfiles
            // 
            BackupProfiles.FormattingEnabled = true;
            BackupProfiles.Location = new Point(56, 22);
            BackupProfiles.Name = "BackupProfiles";
            BackupProfiles.Size = new Size(165, 23);
            BackupProfiles.TabIndex = 0;
            BackupProfiles.SelectedIndexChanged += BackupProfiles_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1023, 649);
            Controls.Add(ResponsesButton);
            Controls.Add(pictureBox1);
            Controls.Add(settingsGroup);
            Controls.Add(factionImage);
            Controls.Add(BackupGroup);
            Controls.Add(groupBox4);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(serverConsole);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            Text = "Hero's Only Launcher Experience";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)skillProgressBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)factionImage).EndInit();
            settingsGroup.ResumeLayout(false);
            settingsGroup.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)backupDeleteInterval).EndInit();
            ((System.ComponentModel.ISupportInitialize)BackUpInterval).EndInit();
            ((System.ComponentModel.ISupportInitialize)BugsFeedbackBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)donatePicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)OpenFolderButton).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SettingsButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox4.ResumeLayout(false);
            BackupGroup.ResumeLayout(false);
            BackupGroup.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox profilesList;
        private Label nameLabel;
        private Label expLabel;
        private Label editionLabel;
        private Button button1;
        private Label label5;
        private Button startServerButton;
        private Label label6;
        private Label stateLabel;
        private GroupBox groupBox2;
        private Button killServerButton;
        private RichTextBox serverConsole;
        private LinkLabel linkLabel1;
        private CheckBox autoScrollBox;
        private CheckBox autoKillCheckBox;
        private CheckBox autoStartCheckBox;
        private Button PlayButton;
        private LinkLabel linkLabel2;
        private PictureBox factionImage;
        private Button WipeButton;
        private Label label1;
        private Button button6;
        private Button InspectsButton;
        private Button button9;
        private Button HealthButton;
        private Button button11;
        private Button SkillsButton;
        private GroupBox groupBox3;
        private Button saveSkillsButton;
        private Label label2;
        private ComboBox comboBox1;
        private Label label3;
        private GroupBox settingsGroup;
        private NumericUpDown skillProgressBox;
        private LinkLabel linkLabel3;
        private TextBox textBox1;
        private Label IDLabel;
        private Button button4;
        private Button dictionaryButton;
        private Button button13;
        private CheckBox checkBox1;
        private Button button14;
        private Label label7;
        private Label label4;
        private NumericUpDown BackUpInterval;
        private CheckBox profileBackupCheckBox;
        private Button button5;
        private GroupBox groupBox4;
        private ListBox modsListBox;
        private Button ModsButton;
        private Button ModConfig;
        private Button button16;
        private GroupBox BackupGroup;
        private Label label8;
        private ComboBox BackupProfiles;
        private Button SaveRestoreButton;
        private Button RestoreBackupButton;
        private ListBox BackupsList;
        private Label label9;
        private ComboBox YearBox;
        private CheckBox backupCheckBox;
        private ComboBox editionsBox;
        private CheckBox minimizeCheck;
        private Button DeleteProfileButton;
        private Button LoadPresetButton;
        private Button SavePresetButton;
        private Label label10;
        private PictureBox donatePicture;
        private PictureBox pictureBox1;
        private Button QuestButton;
        private PictureBox BugsFeedbackBox;
        private PictureBox OpenFolderButton;
        private PictureBox SettingsButton;
        private CheckBox ImageCachingCheck;
        private ComboBox LangBox;
        private Label label11;
        private ComboBox DayBox;
        private ComboBox MonthBox;
        private CheckedListBox ModsListCheckBox;
        private Button ResponsesButton;
        private Label label12;
        private GroupBox groupBox5;
        private Label label13;
        private NumericUpDown backupDeleteInterval;
        private CheckBox versionWarningCheck;
    }
}