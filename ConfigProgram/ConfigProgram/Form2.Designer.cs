namespace ConfigProgram
{
    partial class Form2
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
            cb_Strg = new CheckBox();
            cb_alt = new CheckBox();
            tb_char = new TextBox();
            label1 = new Label();
            btn_close = new Button();
            SuspendLayout();
            // 
            // cb_Strg
            // 
            cb_Strg.AutoSize = true;
            cb_Strg.Location = new Point(12, 44);
            cb_Strg.Name = "cb_Strg";
            cb_Strg.Size = new Size(53, 19);
            cb_Strg.TabIndex = 0;
            cb_Strg.Text = "CTRL";
            cb_Strg.UseVisualStyleBackColor = true;
            // 
            // cb_alt
            // 
            cb_alt.AutoSize = true;
            cb_alt.Location = new Point(71, 44);
            cb_alt.Name = "cb_alt";
            cb_alt.Size = new Size(45, 19);
            cb_alt.TabIndex = 1;
            cb_alt.Text = "ALT";
            cb_alt.UseVisualStyleBackColor = true;
            // 
            // tb_char
            // 
            tb_char.Location = new Point(122, 12);
            tb_char.MaxLength = 1;
            tb_char.Name = "tb_char";
            tb_char.Size = new Size(56, 23);
            tb_char.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(96, 15);
            label1.TabIndex = 4;
            label1.Text = "Single Character:";
            // 
            // btn_close
            // 
            btn_close.Location = new Point(199, 12);
            btn_close.Name = "btn_close";
            btn_close.Size = new Size(116, 51);
            btn_close.TabIndex = 5;
            btn_close.Text = "SAVE";
            btn_close.UseVisualStyleBackColor = true;
            btn_close.Click += btn_close_Click_1;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(327, 75);
            Controls.Add(btn_close);
            Controls.Add(label1);
            Controls.Add(tb_char);
            Controls.Add(cb_alt);
            Controls.Add(cb_Strg);
            Enabled = false;
            MaximizeBox = false;
            MaximumSize = new Size(343, 114);
            MinimizeBox = false;
            MinimumSize = new Size(343, 114);
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Shortcut Creator";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox cb_Strg;
        private CheckBox cb_alt;
        private TextBox tb_char;
        private Label label1;
        private Button btn_close;
    }
}