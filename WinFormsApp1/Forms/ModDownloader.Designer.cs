using SPTLauncher.UIElements;

namespace SPTLauncher
{
    partial class ModDownloader
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
            modList = new Scroll();
            Author = new Label();
            AkiVersion = new Label();
            DownloadModButton = new Button();
            linkLabel1 = new LinkLabel();
            ModImage = new PictureBox();
            ModName = new Label();
            Description = new RichTextBox();
            lastUpdated = new Label();
            Downloads = new Label();
            downloadProgress = new ProgressBar();
            DownloadLabel = new Label();
            SearchBox = new TextBox();
            label1 = new Label();
            AkiVersionsBox = new ComboBox();
            FilterDescriptionCheck = new CheckBox();
            FilterVersionCheck = new CheckBox();
            FilterAuthorCheck = new CheckBox();
            FilterNameCheck = new CheckBox();
            Comments = new Label();
            Ratings = new Label();
            Favorite = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)ModImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Favorite).BeginInit();
            SuspendLayout();
            // 
            // modList
            // 
            modList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            modList.FormattingEnabled = true;
            modList.ItemHeight = 15;
            modList.Location = new Point(0, 25);
            modList.Name = "modList";
            modList.Size = new Size(239, 394);
            modList.TabIndex = 0;
            modList.SelectedIndexChanged += modList_SelectedIndexChanged;
            modList.MouseWheel += modList_Scrolled;
            // 
            // Author
            // 
            Author.AutoSize = true;
            Author.Location = new Point(395, 49);
            Author.Name = "Author";
            Author.Size = new Size(76, 15);
            Author.TabIndex = 1;
            Author.Text = "Author: Hero";
            // 
            // AkiVersion
            // 
            AkiVersion.AutoSize = true;
            AkiVersion.Location = new Point(395, 64);
            AkiVersion.Name = "AkiVersion";
            AkiVersion.Size = new Size(98, 15);
            AkiVersion.TabIndex = 2;
            AkiVersion.Text = "AKI-Version: 3.5.5";
            // 
            // DownloadModButton
            // 
            DownloadModButton.Location = new Point(245, 179);
            DownloadModButton.Name = "DownloadModButton";
            DownloadModButton.Size = new Size(75, 23);
            DownloadModButton.TabIndex = 3;
            DownloadModButton.Text = "Download";
            DownloadModButton.UseVisualStyleBackColor = true;
            DownloadModButton.Click += DownloadModButton_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(433, 139);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(49, 15);
            linkLabel1.TabIndex = 4;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Website";
            linkLabel1.TextAlign = ContentAlignment.TopRight;
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // ModImage
            // 
            ModImage.Location = new Point(245, 30);
            ModImage.Name = "ModImage";
            ModImage.Size = new Size(144, 144);
            ModImage.SizeMode = PictureBoxSizeMode.CenterImage;
            ModImage.TabIndex = 5;
            ModImage.TabStop = false;
            // 
            // ModName
            // 
            ModName.AutoSize = true;
            ModName.Location = new Point(395, 34);
            ModName.Name = "ModName";
            ModName.Size = new Size(77, 15);
            ModName.TabIndex = 6;
            ModName.Text = "Name: POOP";
            // 
            // Description
            // 
            Description.Location = new Point(245, 235);
            Description.Name = "Description";
            Description.Size = new Size(484, 181);
            Description.TabIndex = 7;
            Description.Text = "";
            // 
            // lastUpdated
            // 
            lastUpdated.AutoSize = true;
            lastUpdated.Location = new Point(395, 79);
            lastUpdated.Name = "lastUpdated";
            lastUpdated.Size = new Size(156, 15);
            lastUpdated.TabIndex = 8;
            lastUpdated.Text = "Updated: SOMETHING HERE";
            // 
            // Downloads
            // 
            Downloads.AutoSize = true;
            Downloads.Location = new Point(395, 94);
            Downloads.Name = "Downloads";
            Downloads.Size = new Size(78, 15);
            Downloads.TabIndex = 9;
            Downloads.Text = "Downloads: 0";
            // 
            // downloadProgress
            // 
            downloadProgress.Location = new Point(245, 206);
            downloadProgress.Name = "downloadProgress";
            downloadProgress.Size = new Size(484, 23);
            downloadProgress.Style = ProgressBarStyle.Continuous;
            downloadProgress.TabIndex = 14;
            // 
            // DownloadLabel
            // 
            DownloadLabel.AutoSize = true;
            DownloadLabel.Location = new Point(326, 185);
            DownloadLabel.Name = "DownloadLabel";
            DownloadLabel.Size = new Size(111, 15);
            DownloadLabel.TabIndex = 15;
            DownloadLabel.Text = "Downloaded: 0B/0B";
            // 
            // SearchBox
            // 
            SearchBox.Location = new Point(0, 1);
            SearchBox.Name = "SearchBox";
            SearchBox.PlaceholderText = "Search...";
            SearchBox.Size = new Size(239, 23);
            SearchBox.TabIndex = 16;
            SearchBox.TextChanged += SearchBox_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(372, 4);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 17;
            label1.Text = "Filters:";
            // 
            // AkiVersionsBox
            // 
            AkiVersionsBox.FormattingEnabled = true;
            AkiVersionsBox.Location = new Point(245, 1);
            AkiVersionsBox.Name = "AkiVersionsBox";
            AkiVersionsBox.Size = new Size(121, 23);
            AkiVersionsBox.TabIndex = 18;
            AkiVersionsBox.SelectedIndexChanged += AkiVersionsBox_SelectedIndexChanged;
            // 
            // FilterDescriptionCheck
            // 
            FilterDescriptionCheck.AutoSize = true;
            FilterDescriptionCheck.Location = new Point(419, 4);
            FilterDescriptionCheck.Name = "FilterDescriptionCheck";
            FilterDescriptionCheck.Size = new Size(86, 19);
            FilterDescriptionCheck.TabIndex = 19;
            FilterDescriptionCheck.Text = "Description";
            FilterDescriptionCheck.UseVisualStyleBackColor = true;
            FilterDescriptionCheck.CheckedChanged += FilterDescriptionCheck_CheckedChanged;
            // 
            // FilterVersionCheck
            // 
            FilterVersionCheck.AutoSize = true;
            FilterVersionCheck.Location = new Point(511, 4);
            FilterVersionCheck.Name = "FilterVersionCheck";
            FilterVersionCheck.Size = new Size(64, 19);
            FilterVersionCheck.TabIndex = 20;
            FilterVersionCheck.Text = "Version";
            FilterVersionCheck.UseVisualStyleBackColor = true;
            FilterVersionCheck.CheckedChanged += FilterVersionCheck_CheckedChanged;
            // 
            // FilterAuthorCheck
            // 
            FilterAuthorCheck.AutoSize = true;
            FilterAuthorCheck.Location = new Point(581, 4);
            FilterAuthorCheck.Name = "FilterAuthorCheck";
            FilterAuthorCheck.Size = new Size(63, 19);
            FilterAuthorCheck.TabIndex = 21;
            FilterAuthorCheck.Text = "Author";
            FilterAuthorCheck.UseVisualStyleBackColor = true;
            FilterAuthorCheck.CheckedChanged += FilterAuthorCheck_CheckedChanged;
            // 
            // FilterNameCheck
            // 
            FilterNameCheck.AutoSize = true;
            FilterNameCheck.Location = new Point(650, 4);
            FilterNameCheck.Name = "FilterNameCheck";
            FilterNameCheck.Size = new Size(58, 19);
            FilterNameCheck.TabIndex = 22;
            FilterNameCheck.Text = "Name";
            FilterNameCheck.UseVisualStyleBackColor = true;
            FilterNameCheck.CheckedChanged += FilterNameCheck_CheckedChanged;
            // 
            // Comments
            // 
            Comments.AutoSize = true;
            Comments.Location = new Point(395, 109);
            Comments.Name = "Comments";
            Comments.Size = new Size(78, 15);
            Comments.TabIndex = 23;
            Comments.Text = "Comments: 0";
            // 
            // Ratings
            // 
            Ratings.AutoSize = true;
            Ratings.Location = new Point(395, 124);
            Ratings.Name = "Ratings";
            Ratings.Size = new Size(58, 15);
            Ratings.TabIndex = 24;
            Ratings.Text = "Ratings: 0";
            // 
            // Favorite
            // 
            Favorite.Image = Properties.Resources.starEmpty;
            Favorite.Location = new Point(395, 142);
            Favorite.Name = "Favorite";
            Favorite.Size = new Size(32, 32);
            Favorite.SizeMode = PictureBoxSizeMode.Zoom;
            Favorite.TabIndex = 25;
            Favorite.TabStop = false;
            Favorite.Click += Favorite_Click;
            Favorite.MouseEnter += Favorite_MouseEnter;
            Favorite.MouseLeave += Favorite_MouseLeave;
            // 
            // ModDownloader
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(739, 420);
            Controls.Add(Favorite);
            Controls.Add(Ratings);
            Controls.Add(Comments);
            Controls.Add(FilterNameCheck);
            Controls.Add(FilterAuthorCheck);
            Controls.Add(FilterVersionCheck);
            Controls.Add(FilterDescriptionCheck);
            Controls.Add(AkiVersionsBox);
            Controls.Add(label1);
            Controls.Add(SearchBox);
            Controls.Add(DownloadLabel);
            Controls.Add(downloadProgress);
            Controls.Add(Downloads);
            Controls.Add(lastUpdated);
            Controls.Add(Description);
            Controls.Add(ModName);
            Controls.Add(linkLabel1);
            Controls.Add(DownloadModButton);
            Controls.Add(AkiVersion);
            Controls.Add(Author);
            Controls.Add(modList);
            Controls.Add(ModImage);
            Name = "ModDownloader";
            Text = "ModHandler";
            FormClosing += ModDownloader_FormClosing;
            Load += ModDownloader_Load;
            ((System.ComponentModel.ISupportInitialize)ModImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)Favorite).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label Author;
        private Label AkiVersion;
        private Button DownloadModButton;
        private LinkLabel linkLabel1;
        private PictureBox ModImage;
        private Label ModName;
        private RichTextBox Description;
        private Label lastUpdated;
        private Label Downloads;
        private Label Ratings;
        private ProgressBar downloadProgress;
        private Label DownloadLabel;
        private TextBox SearchBox;
        private Label label1;
        private ComboBox AkiVersionsBox;
        private CheckBox FilterDescriptionCheck;
        private CheckBox FilterVersionCheck;
        private CheckBox FilterAuthorCheck;
        private CheckBox FilterNameCheck;
        private Label Comments;
        private Scroll modList;
        private Label label2;
        private PictureBox Favorite;
    }
}