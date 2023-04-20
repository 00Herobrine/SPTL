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
            modList = new ListBox();
            Author = new Label();
            AkiVersion = new Label();
            DownloadModButton = new Button();
            linkLabel1 = new LinkLabel();
            ModImage = new PictureBox();
            ModName = new Label();
            Description = new RichTextBox();
            lastUpdated = new Label();
            Downloads = new Label();
            Reviews = new Label();
            Rating = new Label();
            Ratings = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)ModImage).BeginInit();
            SuspendLayout();
            // 
            // modList
            // 
            modList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            modList.FormattingEnabled = true;
            modList.ItemHeight = 15;
            modList.Location = new Point(0, 0);
            modList.Name = "modList";
            modList.Size = new Size(222, 454);
            modList.TabIndex = 0;
            modList.DrawItem += modList_DrawItem;
            modList.SelectedIndexChanged += modList_SelectedIndexChanged;
            // 
            // Author
            // 
            Author.AutoSize = true;
            Author.Location = new Point(386, 20);
            Author.Name = "Author";
            Author.Size = new Size(76, 15);
            Author.TabIndex = 1;
            Author.Text = "Author: Hero";
            // 
            // AkiVersion
            // 
            AkiVersion.AutoSize = true;
            AkiVersion.Location = new Point(386, 35);
            AkiVersion.Name = "AkiVersion";
            AkiVersion.Size = new Size(98, 15);
            AkiVersion.TabIndex = 2;
            AkiVersion.Text = "AKI-Version: 3.5.5";
            // 
            // DownloadModButton
            // 
            DownloadModButton.Location = new Point(713, 417);
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
            linkLabel1.Location = new Point(739, 5);
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
            ModImage.Location = new Point(223, 1);
            ModImage.Name = "ModImage";
            ModImage.Size = new Size(163, 153);
            ModImage.SizeMode = PictureBoxSizeMode.AutoSize;
            ModImage.TabIndex = 5;
            ModImage.TabStop = false;
            // 
            // ModName
            // 
            ModName.AutoSize = true;
            ModName.Location = new Point(386, 5);
            ModName.Name = "ModName";
            ModName.Size = new Size(77, 15);
            ModName.TabIndex = 6;
            ModName.Text = "Name: POOP";
            // 
            // Description
            // 
            Description.Location = new Point(223, 202);
            Description.Name = "Description";
            Description.Size = new Size(484, 238);
            Description.TabIndex = 7;
            Description.Text = "";
            // 
            // lastUpdated
            // 
            lastUpdated.AutoSize = true;
            lastUpdated.Location = new Point(386, 50);
            lastUpdated.Name = "lastUpdated";
            lastUpdated.Size = new Size(156, 15);
            lastUpdated.TabIndex = 8;
            lastUpdated.Text = "Updated: SOMETHING HERE";
            // 
            // Downloads
            // 
            Downloads.AutoSize = true;
            Downloads.Location = new Point(386, 65);
            Downloads.Name = "Downloads";
            Downloads.Size = new Size(78, 15);
            Downloads.TabIndex = 9;
            Downloads.Text = "Downloads: 0";
            // 
            // Reviews
            // 
            Reviews.AutoSize = true;
            Reviews.Location = new Point(386, 80);
            Reviews.Name = "Reviews";
            Reviews.Size = new Size(61, 15);
            Reviews.TabIndex = 10;
            Reviews.Text = "Reviews: 0";
            // 
            // Rating
            // 
            Rating.AutoSize = true;
            Rating.Location = new Point(386, 95);
            Rating.Name = "Rating";
            Rating.Size = new Size(81, 15);
            Rating.TabIndex = 11;
            Rating.Text = "Rating: 0 Stars";
            // 
            // Ratings
            // 
            Ratings.AutoSize = true;
            Ratings.Location = new Point(386, 110);
            Ratings.Name = "Ratings";
            Ratings.Size = new Size(58, 15);
            Ratings.TabIndex = 12;
            Ratings.Text = "Ratings: 0";
            // 
            // button1
            // 
            button1.Location = new Point(169, 1);
            button1.Name = "button1";
            button1.Size = new Size(53, 22);
            button1.TabIndex = 13;
            button1.Text = "More";
            button1.UseVisualStyleBackColor = true;
            button1.Visible = false;
            button1.Click += button1_Click;
            // 
            // ModDownloader
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 452);
            Controls.Add(button1);
            Controls.Add(Ratings);
            Controls.Add(Rating);
            Controls.Add(Reviews);
            Controls.Add(Downloads);
            Controls.Add(lastUpdated);
            Controls.Add(Description);
            Controls.Add(ModName);
            Controls.Add(ModImage);
            Controls.Add(linkLabel1);
            Controls.Add(DownloadModButton);
            Controls.Add(AkiVersion);
            Controls.Add(Author);
            Controls.Add(modList);
            Name = "ModDownloader";
            Text = "ModHandler";
            Load += ModDownloader_Load;
            ((System.ComponentModel.ISupportInitialize)ModImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox modList;
        private Label Author;
        private Label AkiVersion;
        private Button DownloadModButton;
        private LinkLabel linkLabel1;
        private PictureBox ModImage;
        private Label ModName;
        private RichTextBox Description;
        private Label lastUpdated;
        private Label Downloads;
        private Label Reviews;
        private Label Rating;
        private Label Ratings;
        private Button button1;
    }
}