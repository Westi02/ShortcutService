using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConfigProgram
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btn_close_Click_1(object sender, EventArgs e)
        {

            if (cb_Strg.Checked || cb_alt.Checked)
            {
                if (tb_char.Text != "" && tb_char.Text != null)
                {
                    this.Enabled = false;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("You have to type in a Character", "ERROR", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("You have to select at least one checkbox", "ERROR", MessageBoxButtons.OK);
            }


        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (Process p = new Process())
            {
                p.StartInfo.FileName = "https://support.microsoft.com/en-us/windows/keyboard-shortcuts-in-windows-dcc61a57-8ff0-cffe-9796-cb9706c75eec";
                p.StartInfo.UseShellExecute = true;
                p.Start();
            }            
        }
    }
}
