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
            listBox1 = new ListBox();
            Author = new Label();
            AKIVersion = new Label();
            DownloadModButton = new Button();
            linkLabel1 = new LinkLabel();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(0, 0);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(222, 454);
            listBox1.TabIndex = 0;
            // 
            // Author
            // 
            Author.AutoSize = true;
            Author.Location = new Point(228, 9);
            Author.Name = "Author";
            Author.Size = new Size(76, 15);
            Author.TabIndex = 1;
            Author.Text = "Author: Hero";
            // 
            // AKIVersion
            // 
            AKIVersion.AutoSize = true;
            AKIVersion.Location = new Point(228, 24);
            AKIVersion.Name = "AKIVersion";
            AKIVersion.Size = new Size(98, 15);
            AKIVersion.TabIndex = 2;
            AKIVersion.Text = "AKI-Version: 3.5.5";
            // 
            // DownloadModButton
            // 
            DownloadModButton.Location = new Point(713, 417);
            DownloadModButton.Name = "DownloadModButton";
            DownloadModButton.Size = new Size(75, 23);
            DownloadModButton.TabIndex = 3;
            DownloadModButton.Text = "Download";
            DownloadModButton.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(729, 9);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(59, 15);
            linkLabel1.TabIndex = 4;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "URL HERE";
            linkLabel1.TextAlign = ContentAlignment.TopRight;
            // 
            // ModDownloader
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 452);
            Controls.Add(linkLabel1);
            Controls.Add(DownloadModButton);
            Controls.Add(AKIVersion);
            Controls.Add(Author);
            Controls.Add(listBox1);
            Name = "ModDownloader";
            Text = "ModHandler";
            Load += ModDownloader_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private Label Author;
        private Label AKIVersion;
        private Button DownloadModButton;
        private LinkLabel linkLabel1;
    }
}