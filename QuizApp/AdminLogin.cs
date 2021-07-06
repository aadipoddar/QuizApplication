using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuizApp
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(PasswordTb.Text == "")
            {
                MessageBox.Show("Enter the password");
            }

            else if(PasswordTb.Text == "Password")
            {
                Questions obj = new Questions();
                obj.Show();
            }

            else
            {
                MessageBox.Show("Wrong password");

                PasswordTb.Text = "";

            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
