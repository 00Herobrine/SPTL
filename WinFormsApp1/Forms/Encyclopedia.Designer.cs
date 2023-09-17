namespace WinFormsApp1
{
    partial class Encyclopedia
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
            checkedListBox1 = new CheckedListBox();
            SuspendLayout();
            // 
            // checkedListBox1
            // 
            checkedListBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(-1, -1);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(358, 616);
            checkedListBox1.TabIndex = 0;
            // 
            // Encyclopedia
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(356, 595);
            Controls.Add(checkedListBox1);
            Name = "Encyclopedia";
            Text = "Item Examination";
            FormClosing += Connection_FormClosing;
            Load += Encyclopedia_Load;
            ResumeLayout(false);
        }

        #endregion

        private CheckedListBox checkedListBox1;
    }
}