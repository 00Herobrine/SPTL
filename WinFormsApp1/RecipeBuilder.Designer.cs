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
            textBox1 = new TextBox();
            groupBox2 = new GroupBox();
            button3 = new Button();
            label3 = new Label();
            comboBox2 = new ComboBox();
            checkBox1 = new CheckBox();
            listBox2 = new ListBox();
            button2 = new Button();
            comboBox1 = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(0, 0);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(207, 469);
            listBox1.TabIndex = 0;
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
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(NewRecipeButton);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(209, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(589, 448);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Selected Recipe";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(63, 22);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(121, 23);
            textBox1.TabIndex = 7;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button3);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(comboBox2);
            groupBox2.Controls.Add(checkBox1);
            groupBox2.Controls.Add(listBox2);
            groupBox2.Controls.Add(button2);
            groupBox2.Location = new Point(6, 262);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(493, 180);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Requirements:";
            // 
            // button3
            // 
            button3.Location = new Point(130, -1);
            button3.Name = "button3";
            button3.Size = new Size(42, 23);
            button3.TabIndex = 9;
            button3.Text = "-";
            button3.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(130, 22);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 8;
            label3.Text = "Item ID:";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(184, 19);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 23);
            comboBox2.TabIndex = 7;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(367, 155);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(120, 19);
            checkBox1.TabIndex = 6;
            checkBox1.Text = "Returned on Craft";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 15;
            listBox2.Location = new Point(6, 22);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(120, 154);
            listBox2.TabIndex = 0;
            // 
            // button2
            // 
            button2.Location = new Point(85, -1);
            button2.Name = "button2";
            button2.Size = new Size(42, 23);
            button2.TabIndex = 5;
            button2.Text = "+";
            button2.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(63, 51);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 3;
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
            Load += RecipeBuilder_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBox1;
        private Button NewRecipeButton;
        private GroupBox groupBox1;
        private Label label1;
        private ListBox listBox2;
        private Label label2;
        private ComboBox comboBox1;
        private GroupBox groupBox2;
        private Button button2;
        private CheckBox checkBox1;
        private Label label3;
        private ComboBox comboBox2;
        private Button button3;
        private TextBox textBox1;
    }
}