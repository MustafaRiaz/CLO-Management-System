using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FinalProject
{
    public partial class EvaluationForm : Form
    {
        public EvaluationForm()
        {
            InitializeComponent();
            loadAssessmentData();
            loadStudentData();
        }
        int assessmentId,noc,Sid,Aid=0,Mid;
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-C42T0RI;Initial Catalog=ProjectB;Integrated Security=True");
        public Dictionary<string, int> studentDictionary = new Dictionary<string, int>();
        
        private void loadStudentData()
        {
            SqlCommand cmd = new SqlCommand("SELECT Id, RegistrationNumber FROM Student", con);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                string registrationNO = sdr["RegistrationNumber"].ToString();
                int cloID = Convert.ToInt32(sdr["Id"]);
                studentDictionary[registrationNO] = cloID;
                selectStudent.Items.Add(registrationNO);
            }
            con.Close();
        }
        private void addStudentResult()
        {
            SqlCommand cmd = new SqlCommand("INSERT into Student Values(@StudentId,@AssessmentComponentId,@RubricMeasurementId,@EvaluationDate)", con);
            cmd.Parameters.AddWithValue("@StudentId", Sid);
            cmd.Parameters.AddWithValue("@AssessmentID", Aid);
            cmd.Parameters.AddWithValue("@Contact", Mid);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            //clearData();
            MessageBox.Show("Successfully saved");
            //getStudentRecord();
            //clearData();
        }
        private void loadAssessmentData()
        {
            SqlCommand cmd = new SqlCommand("SELECT Id, Title FROM Assessment", con);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                string title = sdr["Title"].ToString();
                int cloID = Convert.ToInt32(sdr["Id"]);
                studentDictionary[title] = cloID;
                selectAssessment.Items.Add(title);
            }
            con.Close();

        }

        private void EvaluationForm_Load(object sender, EventArgs e)
        {
            ;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void selectAssessment_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = selectAssessment.SelectedItem.ToString();
            int selectedID = studentDictionary[selectedItem];
            assessmentId = selectedID;
            int numBlocks = 0;
            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-C42T0RI;Initial Catalog=ProjectB;Integrated Security=True"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM AssessmentComponent WHERE AssessmentID=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", selectedID);
                    numBlocks = (int)cmd.ExecuteScalar();
                }
            }
            for (int i = 0; i < numBlocks; i++)
            {
                Panel panel = new Panel();
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.Size = new Size(250, 80);

                Label label = new Label();

                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-C42T0RI;Initial Catalog=ProjectB;Integrated Security=True"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT Name FROM AssessmentComponent WHERE AssessmentID=@id ORDER BY Id OFFSET @offset ROWS FETCH NEXT 1 ROWS ONLY", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", selectedID);
                        cmd.Parameters.AddWithValue("@offset", i);
                        label.Text = (string)cmd.ExecuteScalar();
                    }
                }
                label.Font = new Font(label.Font, FontStyle.Bold);
                label.Font = new Font(label.Font.FontFamily, 16);
                label.Location = new Point(10, 10);

                System.Windows.Forms.ComboBox comboBox = new System.Windows.Forms.ComboBox();
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-C42T0RI;Initial Catalog=ProjectB;Integrated Security=True"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT MeasurementLevel FROM RubricLevel WHERE RubricID IN (SELECT RubricID FROM AssessmentComponent WHERE Name=@name AND AssessmentID=@id) ORDER BY Id", conn))
                    {
                        cmd.Parameters.AddWithValue("@name", label.Text);
                        cmd.Parameters.AddWithValue("@id", selectedID);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Map the values to the desired display text
                                string displayText = "";
                                int value = Convert.ToInt32(reader["MeasurementLevel"]);
                                switch (value)
                                {
                                    case 0:
                                        displayText = "Bad";
                                        break;
                                    case 1:
                                        displayText = "Good";
                                        break;
                                    case 2:
                                        displayText = "Hard";
                                        break;
                                }
                                comboBox.Items.Add(new ComboboxItem { Text = displayText, Value = value });
                            }
                        }
                    }
                }
                comboBox.SelectedIndex = 0;
                comboBox.Size = new Size(210, 40);
                comboBox.Location = new Point(10, 38);
                panel.Controls.Add(label);
                panel.Controls.Add(comboBox);
                flowLayoutPanel1.Controls.Add(panel);
            }
            flowLayoutPanel1.Refresh();
        }
        

        private void evaluateBtn_Click(object sender, EventArgs e)
        {

        }

        private void selectStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = selectStudent.SelectedItem.ToString();
            int selectedID = studentDictionary[selectedItem];
            Sid = selectedID;
        }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
    }
}
