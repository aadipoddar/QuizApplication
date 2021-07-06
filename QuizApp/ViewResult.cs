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
    public partial class ViewResult : Form
    {
        public ViewResult()
        {
            InitializeComponent();
            GetSubjects();
            GetCandidate();
            DisplayResults();
        }


        SqlConnection Con = new SqlConnection(@"Data Source=AADILAPI;Initial Catalog=Qizdb;Integrated Security=True;Pooling=False");

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

        private void GetCandidate()
        {
            Con.Open();

            SqlCommand cmd = new SqlCommand("select SName from CandidateTb1", Con);
            SqlDataReader rdr;

            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("SName", typeof(string));
            dt.Load(rdr);

            Cbox.ValueMember = "SName";
            Cbox.DataSource = dt;



            Con.Close();
        }

        private void DisplayResults()
        {
            Con.Open();

            string Query = "select * from ResultTb1";

            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);

            var ds = new DataSet();
            sda.Fill(ds);
            ResultsDVG.DataSource = ds.Tables[0];

            Con.Close();
        }

        private void FilterBySub()
        {
            Con.Open();

            string Query = "select * from ResultTb1 where RSubject = '" + SubjectCB.SelectedValue.ToString() + "'";

            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);

            var ds = new DataSet();
            sda.Fill(ds);
            ResultsDVG.DataSource = ds.Tables[0];

            Con.Close();
        }

        private void FilterByCandidate()
        {
            Con.Open();

            string Query = "select * from ResultTb1 where RCndidate = '" + Cbox.SelectedValue.ToString() + "'";

            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);

            var ds = new DataSet();
            sda.Fill(ds);
            ResultsDVG.DataSource = ds.Tables[0];

            Con.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SubjectCB_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FilterBySub();
        }

        private void Cbox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FilterByCandidate();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Candidates Obj = new Candidates();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Questions Obj = new Questions();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Subjects Obj = new Subjects();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            About Obj = new About();
            Obj.Show();
            //this.Hide();
        }
    }
}
