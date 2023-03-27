using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (loginName.Text != null && loginPassword.Text != null)
            {
                if (loginName.Text == "Mustafa" && loginPassword.Text == "maxie")
                {
                
                    AdminForm n = new AdminForm();
                    n.Show();
                }
            }
        }

        private void loginPassword_TextChanged(object sender, EventArgs e)
        {
            loginPassword.UseSystemPasswordChar = true;
        }

        private void showPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (showPassword.Checked == true)
            {
                loginPassword.UseSystemPasswordChar = false;
            }
            else
            {
                loginPassword.UseSystemPasswordChar = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
