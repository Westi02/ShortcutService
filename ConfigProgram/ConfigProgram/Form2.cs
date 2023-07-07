using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    }
}
