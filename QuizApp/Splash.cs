using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuizApp
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        int Count = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Chrono -= 1;
            Count += 1;

            MyProgress.Value = Count;
            PercentageLabel.Text = Count + "%";

            if (MyProgress.Value == 100)
            {
                MyProgress.Value = 0;
                timer1.Stop();
                //MessageBox.Show("Time Over");

                Login log = new Login();
                log.Show();

                this.Hide();
            }
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
