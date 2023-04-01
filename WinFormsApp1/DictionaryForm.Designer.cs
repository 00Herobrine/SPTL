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
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            listBox1 = new ListBox();
            dictionaryTabs.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // dictionaryTabs
            // 
            dictionaryTabs.Controls.Add(tabPage1);
            dictionaryTabs.Controls.Add(tabPage2);
            dictionaryTabs.Controls.Add(tabPage3);
            dictionaryTabs.Location = new Point(-2, -2);
            dictionaryTabs.Name = "dictionaryTabs";
            dictionaryTabs.SelectedIndex = 0;
            dictionaryTabs.Size = new Size(806, 455);
            dictionaryTabs.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(listBox1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(798, 427);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Armor";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(798, 427);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Weapons";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(798, 427);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Misc";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(0, 0);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(170, 424);
            listBox1.TabIndex = 0;
            // 
            // DictionaryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dictionaryTabs);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "DictionaryForm";
            Text = "Dictionary";
            dictionaryTabs.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl dictionaryTabs;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private ListBox listBox1;
    }
}