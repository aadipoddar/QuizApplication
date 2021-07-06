using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizApp
{
    public partial class Questions : Form
    {
        public Questions()
        {
            InitializeComponent();
            GetSubjects();
            DisplayQuestions();
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

        private void Reset()
        {
            QuestTb.Text  = "";
            Op1Tb.Text    = "";
            Op2Tb.Text    = "";
            Op3Tb.Text    = "";
            Op4Tb.Text    = "";
            AnswerTb.Text = "";
            SubjectCB.SelectedIndex = 0;
        }

        private void DisplayQuestions()
        {
            Con.Open();

            string Query = "select * from QuestionTb1";

            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);

            var ds = new DataSet();
            sda.Fill(ds);
            QuestionDVG.DataSource = ds.Tables[0];

            Con.Close();
        }

        private void bunifuMaterialTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (QuestTb.Text == "" || Op1Tb.Text == "" || Op2Tb.Text == "" || Op3Tb.Text == "" || Op4Tb.Text == "" || AnswerTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }

            else
            {
                try
                {


                    Con.Open();

                    SqlCommand cmd = new SqlCommand("insert into QuestionTb1 (QDesc,QO1,QO2,QO3,QO4,QA,QS) values (@Qd,@Q1,@Q2,@Q3,@Q4,@Qan,@Qsu)", Con);

                    cmd.Parameters.AddWithValue("@Qd",  QuestTb.Text);
                    cmd.Parameters.AddWithValue("@Q1",  Op1Tb.Text);
                    cmd.Parameters.AddWithValue("@Q2",  Op2Tb.Text);
                    cmd.Parameters.AddWithValue("@Q3",  Op3Tb.Text);
                    cmd.Parameters.AddWithValue("@Q4",  Op4Tb.Text);
                    cmd.Parameters.AddWithValue("@Qan", AnswerTb.Text);
                    cmd.Parameters.AddWithValue("@Qsu", SubjectCB.SelectedValue.ToString());

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Question Added");

                    Con.Close();

                    Reset();

                    DisplayQuestions();
                }

                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Subjects Obj = new Subjects();
            Obj.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Candidates Obj = new Candidates();
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
            Candidates Obj = new Candidates();
            Obj.Show();
            this.Hide();
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            Reset();
        }


        int Key = 0;

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (QuestTb.Text == "" || Op1Tb.Text == "" || Op2Tb.Text == "" || Op3Tb.Text == "" || Op4Tb.Text == "" || AnswerTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }

            else
            {
                try
                {


                    Con.Open();

                    SqlCommand cmd = new SqlCommand("update QuestionTb1 set QDesc = @Qd , QO1 = @Q1 , QO2 = @Q2 , QO3 = @Q3 , QO4 = @Q4 , QA = @Qan , QS = @Qsu where QId = @QKey", Con);

                    cmd.Parameters.AddWithValue("@Qd",  QuestTb.Text);
                    cmd.Parameters.AddWithValue("@Q1",  Op1Tb.Text);
                    cmd.Parameters.AddWithValue("@Q2",  Op2Tb.Text);
                    cmd.Parameters.AddWithValue("@Q3",  Op3Tb.Text);
                    cmd.Parameters.AddWithValue("@Q4",  Op4Tb.Text);
                    cmd.Parameters.AddWithValue("@Qan", AnswerTb.Text);
                    cmd.Parameters.AddWithValue("@Qsu", SubjectCB.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@QKey", Key);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Question Updated");

                    Con.Close();

                    Reset();

                    DisplayQuestions();
                }

                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void QuestionDVG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            QuestTb.Text            = QuestionDVG.SelectedRows[0].Cells[1].Value.ToString();
            Op1Tb.Text              = QuestionDVG.SelectedRows[0].Cells[2].Value.ToString();
            Op2Tb.Text              = QuestionDVG.SelectedRows[0].Cells[3].Value.ToString();
            Op3Tb.Text              = QuestionDVG.SelectedRows[0].Cells[4].Value.ToString();
            Op4Tb.Text              = QuestionDVG.SelectedRows[0].Cells[5].Value.ToString();
            AnswerTb.Text           = QuestionDVG.SelectedRows[0].Cells[6].Value.ToString();
            SubjectCB.SelectedValue = QuestionDVG.SelectedRows[0].Cells[7].Value.ToString();

            if (QuestTb.Text == "")
            {
                Key = 0;
            }

            else
            {
                Key = Convert.ToInt32(QuestionDVG.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            About Obj = new About();
            Obj.Show();
        }
    }
}
