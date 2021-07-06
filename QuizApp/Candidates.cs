using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuizApp
{
    public partial class Candidates : Form
    {
        public Candidates()
        {
            InitializeComponent();
            DisplayCandidates();
        }

        private void Reset()
        {
            CNameTb.Text    = "";
            CAgeTb.Text     = "";
            PhoneTb.Text    = "";
            AddressTb.Text  = "";
            PasswordTb.Text = "";
        }

        SqlConnection Con = new SqlConnection(@"Data Source=AADILAPI;Initial Catalog=Qizdb;Integrated Security=True;Pooling=False");

        

        private void DisplayCandidates()
        {
            Con.Open();

            string Query = "select * from CandidateTb1";

            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);

            var ds = new DataSet();
            sda.Fill(ds);
            CandidatesDVG.DataSource = ds.Tables[0];

            Con.Close();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (CNameTb.Text == "" || CAgeTb.Text == "" || PasswordTb.Text == "" || PhoneTb.Text == "" || AddressTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }

            else
            {
                try
                {
                    int score = 0;

                    Con.Open();

                    SqlCommand cmd = new SqlCommand("insert into CandidateTb1 (CName,CAge,CPass,CScore,CAdd,Cphone) values (@Cn,@Ca,@Cp,@Cs,@Cad,@Cph)", Con);

                    cmd.Parameters.AddWithValue("@Cn", CNameTb.Text);
                    cmd.Parameters.AddWithValue("@Ca", CAgeTb.Text);
                    cmd.Parameters.AddWithValue("@Cp", PasswordTb.Text);
                    cmd.Parameters.AddWithValue("@Cs", score);
                    cmd.Parameters.AddWithValue("@Cad", AddressTb.Text);
                    cmd.Parameters.AddWithValue("@Cph", PhoneTb.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Candidate Saved");

                    Con.Close();

                    Reset();

                    DisplayCandidates();
                }

                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            Reset();
        }


        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (CNameTb.Text == "" || CAgeTb.Text == "" || CAgeTb.Text == "Age" || PasswordTb.Text == "" || PhoneTb.Text == "" || AddressTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }

            else
            {
                try
                {
                    int score = 0;

                    Con.Open();

                    SqlCommand cmd = new SqlCommand("update CandidateTb1 set CName = @Cn , CAge = @Ca , CPass = @Cp , CScore = @Cs , CAdd = @Cad , Cphone = @Cph where CId = @CKey", Con);

                    cmd.Parameters.AddWithValue("@Cn", CNameTb.Text);
                    cmd.Parameters.AddWithValue("@Ca", CAgeTb.Text);
                    cmd.Parameters.AddWithValue("@Cs", score);
                    cmd.Parameters.AddWithValue("@Cp", PasswordTb.Text);
                    cmd.Parameters.AddWithValue("@Cad", AddressTb.Text);
                    cmd.Parameters.AddWithValue("@Cph", PhoneTb.Text);
                    cmd.Parameters.AddWithValue("@CKey", Key);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Candidate Updates");

                    Con.Close();

                    Reset();

                    DisplayCandidates();
                }

                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        int Key = 0;

        private void CandidatesDVG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CNameTb.Text    = CandidatesDVG.SelectedRows[0].Cells[1].Value.ToString();
            CAgeTb.Text     = CandidatesDVG.SelectedRows[0].Cells[2].Value.ToString();
            PasswordTb.Text = CandidatesDVG.SelectedRows[0].Cells[3].Value.ToString();
            AddressTb.Text  = CandidatesDVG.SelectedRows[0].Cells[5].Value.ToString();
            PhoneTb.Text    = CandidatesDVG.SelectedRows[0].Cells[6].Value.ToString();

            if(CNameTb.Text == "")
            {
                Key = 0;
            }

            else
            {
                Key = Convert.ToInt32(CandidatesDVG.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Subjects Obj = new Subjects();
            Obj.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Questions Obj = new Questions();
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

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            About Obj = new About();
            Obj.Show();
        }
    }
}
