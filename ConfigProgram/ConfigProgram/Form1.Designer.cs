namespace ConfigProgram
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
            label1 = new Label();
            label2 = new Label();
            comboBox1 = new ComboBox();
            tb_name = new TextBox();
            tb_shortcut = new TextBox();
            label3 = new Label();
            label4 = new Label();
            btn_save = new Button();
            btn_shortcut = new Button();
            label5 = new Label();
            tb_program = new TextBox();
            btn_search = new Button();
            btn_newShortcut = new Button();
            cb_Autostart = new CheckBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(127, 16);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(127, 16);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 2;
            label2.Text = "Shortcut:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(188, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(205, 23);
            comboBox1.TabIndex = 3;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // tb_name
            // 
            tb_name.Location = new Point(188, 75);
            tb_name.Name = "tb_name";
            tb_name.Size = new Size(205, 23);
            tb_name.TabIndex = 5;
            // 
            // tb_shortcut
            // 
            tb_shortcut.Location = new Point(188, 104);
            tb_shortcut.Name = "tb_shortcut";
            tb_shortcut.Size = new Size(205, 23);
            tb_shortcut.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(127, 78);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 7;
            label3.Text = "Name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(127, 107);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 8;
            label4.Text = "Shortcut:";
            // 
            // btn_save
            // 
            btn_save.Location = new Point(12, 12);
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(89, 23);
            btn_save.TabIndex = 9;
            btn_save.Text = "save shortcut";
            btn_save.UseVisualStyleBackColor = true;
            btn_save.Click += btn_save_Click;
            // 
            // btn_shortcut
            // 
            btn_shortcut.Location = new Point(402, 104);
            btn_shortcut.Name = "btn_shortcut";
            btn_shortcut.Size = new Size(104, 23);
            btn_shortcut.TabIndex = 10;
            btn_shortcut.Text = "capture shortcut";
            btn_shortcut.UseVisualStyleBackColor = true;
            btn_shortcut.Click += btn_shortcut_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(127, 136);
            label5.Name = "label5";
            label5.Size = new Size(56, 15);
            label5.TabIndex = 12;
            label5.Text = "Program:";
            // 
            // tb_program
            // 
            tb_program.Location = new Point(188, 133);
            tb_program.Name = "tb_program";
            tb_program.Size = new Size(205, 23);
            tb_program.TabIndex = 11;
            // 
            // btn_search
            // 
            btn_search.Location = new Point(402, 133);
            btn_search.Name = "btn_search";
            btn_search.Size = new Size(104, 23);
            btn_search.TabIndex = 13;
            btn_search.Text = "search";
            btn_search.UseVisualStyleBackColor = true;
            btn_search.Click += btn_search_Click;
            // 
            // btn_newShortcut
            // 
            btn_newShortcut.Location = new Point(12, 41);
            btn_newShortcut.Name = "btn_newShortcut";
            btn_newShortcut.Size = new Size(89, 23);
            btn_newShortcut.TabIndex = 14;
            btn_newShortcut.Text = "new shortcut";
            btn_newShortcut.UseVisualStyleBackColor = true;
            btn_newShortcut.Click += btn_newShortcut_Click;
            // 
            // cb_Autostart
            // 
            cb_Autostart.AutoSize = true;
            cb_Autostart.Location = new Point(12, 177);
            cb_Autostart.Name = "cb_Autostart";
            cb_Autostart.Size = new Size(165, 19);
            cb_Autostart.TabIndex = 15;
            cb_Autostart.Text = "Autostart Shortcut-Service";
            cb_Autostart.UseVisualStyleBackColor = true;
            cb_Autostart.CheckedChanged += cb_Autostart_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(518, 208);
            Controls.Add(cb_Autostart);
            Controls.Add(btn_newShortcut);
            Controls.Add(btn_search);
            Controls.Add(label5);
            Controls.Add(tb_program);
            Controls.Add(btn_shortcut);
            Controls.Add(btn_save);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(tb_shortcut);
            Controls.Add(tb_name);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximizeBox = false;
            MaximumSize = new Size(534, 247);
            MinimumSize = new Size(534, 247);
            Name = "Form1";
            Text = "Shortcut Service Config";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private ComboBox comboBox1;
        private TextBox tb_name;
        private TextBox tb_shortcut;
        private Label label3;
        private Label label4;
        private Button btn_save;
        private Button btn_shortcut;
        private Label label5;
        private TextBox tb_program;
        private Button btn_search;
        private Button btn_newShortcut;
        private CheckBox cb_Autostart;
    }
}