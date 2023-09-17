namespace SPTLauncher.Forms.Reporting
{
    partial class Feedback
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
            richTextBox1 = new RichTextBox();
            groupBox1 = new GroupBox();
            FeedbackBox = new RadioButton();
            BugReportBox = new RadioButton();
            button1 = new Button();
            comboBox1 = new ComboBox();
            groupBox2 = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox1.Location = new Point(0, -1);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(449, 318);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Bottom;
            groupBox1.Controls.Add(FeedbackBox);
            groupBox1.Controls.Add(BugReportBox);
            groupBox1.Location = new Point(5, 318);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(186, 50);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Issue Type";
            // 
            // FeedbackBox
            // 
            FeedbackBox.AutoSize = true;
            FeedbackBox.Location = new Point(105, 20);
            FeedbackBox.Name = "FeedbackBox";
            FeedbackBox.Size = new Size(75, 19);
            FeedbackBox.TabIndex = 4;
            FeedbackBox.TabStop = true;
            FeedbackBox.Text = "Feedback";
            FeedbackBox.UseVisualStyleBackColor = true;
            FeedbackBox.CheckedChanged += FeedbackBox_CheckedChanged;
            // 
            // BugReportBox
            // 
            BugReportBox.AutoSize = true;
            BugReportBox.Location = new Point(6, 20);
            BugReportBox.Name = "BugReportBox";
            BugReportBox.Size = new Size(84, 19);
            BugReportBox.TabIndex = 3;
            BugReportBox.TabStop = true;
            BugReportBox.Text = "Bug Report";
            BugReportBox.UseVisualStyleBackColor = true;
            BugReportBox.CheckedChanged += BugReportBox_CheckedChanged_1;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom;
            button1.Location = new Point(365, 336);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Submit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(6, 18);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(149, 23);
            comboBox1.TabIndex = 3;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Bottom;
            groupBox2.Controls.Add(comboBox1);
            groupBox2.Location = new Point(197, 318);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(161, 50);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Severity";
            // 
            // Feedback
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(448, 372);
            Controls.Add(groupBox2);
            Controls.Add(button1);
            Controls.Add(groupBox1);
            Controls.Add(richTextBox1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Feedback";
            Text = "Feedback";
            FormClosing += Feedback_FormClosing;
            Load += Feedback_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox richTextBox1;
        private GroupBox groupBox1;
        private Button button1;
        private RadioButton FeedbackBox;
        private RadioButton BugReportBox;
        private ComboBox comboBox1;
        private GroupBox groupBox2;
    }
}