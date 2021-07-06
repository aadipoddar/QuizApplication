using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuizApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            GetSubjects();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=AADILAPI;Initial Catalog=Qizdb;Integrated Security=True;Pooling=False");

        public static string CandName = "" , SubName = "";

        private void GetSubjects()
        {
            Con.Open();

            SqlCommand cmd = new SqlCommand("select SName from SunjectTb1", Con);
            SqlDataReader rdr;

            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("SName", typeof(string));
            dt.Load(rdr);

            SubjectCB.ValueMember = "SName";
            SubjectCB.DataSource = dt;



            Con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(UnameTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Enter candidate name and password");
            }

            else
            {
                Con.Open();

                SqlDataAdapter sda = new SqlDataAdapter("select count(*) from CandidateTb1 where CPass = '" + PasswordTb.Text + "' and CName = '" + UnameTb.Text + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows[0][0].ToString() == "1") 
                {
                    CandName = UnameTb.Text;
                    SubName = SubjectCB.SelectedValue.ToString();
                    Exams Obj = new Exams();
                    Obj.Show();
                    this.Hide();
                    Con.Close();
                }

                else
                {
                    MessageBox.Show("Wrong candidate or wrong password");

                    UnameTb.Text = "";
                    PasswordTb.Text = "";
                }

                Con.Close();
            }
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Login_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            AdminLogin obj = new AdminLogin();
            obj.Show();
            this.Hide();
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
    }
}
