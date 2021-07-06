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
    public partial class Subjects : Form
    {
        public Subjects()
        {
            InitializeComponent();
            DisplaySubjects();
        }

        int Key = 0;

        private void Reset()
        {
            SNameTb.Text = "";
            Key = 0;
        }

        SqlConnection Con = new SqlConnection(@"Data Source=AADILAPI;Initial Catalog=Qizdb;Integrated Security=True;Pooling=False");

        private void DisplaySubjects()
        {
            Con.Open();

            string Query = "select * from SunjectTb1";

            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);

            var ds = new DataSet();
            sda.Fill(ds);
            SubjectsDVG.DataSource = ds.Tables[0];

            Con.Close();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (SNameTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }

            else
            {
                try
                {
                    

                    Con.Open();

                    SqlCommand cmd = new SqlCommand("insert into SunjectTb1 (SName) values (@Sn)", Con);

                    cmd.Parameters.AddWithValue("@Sn", SNameTb.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Subject Saved");

                    Con.Close();

                    Reset();

                    DisplaySubjects();
                }

                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void SubjectsDVG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SNameTb.Text = SubjectsDVG.SelectedRows[0].Cells[1].Value.ToString();
                        
            if (SNameTb.Text == "")
            {
                Key = 0;
            }

            else
            {
                Key = Convert.ToInt32(SubjectsDVG.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (SNameTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }

            else
            {
                try
                {
                    int score = 0;

                    Con.Open();

                    SqlCommand cmd = new SqlCommand("update SunjectTb1 set SName = @Sn where SId = @SKey", Con);

                    cmd.Parameters.AddWithValue("@Sn", SNameTb.Text);
                    cmd.Parameters.AddWithValue("@SKey", Key);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Subjects Updates");

                    Con.Close();

                    Reset();

                    DisplaySubjects();
                }

                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Candidates Obj = new Candidates();
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

        private void label2_Click(object sender, EventArgs e)
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
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Candidates Obj = new Candidates();
            Obj.Show();
            this.Hide();
        }
    }
}
