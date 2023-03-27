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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FinalProject
{
    public partial class evaluationControlForm : UserControl
    {
        
        public evaluationControlForm()
        {
            InitializeComponent();
            loadStudentData();
            loadAssessmentData();  
        }
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

        }private void loadAssessmentData()
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
        private void evaluationControlForm_Load(object sender, EventArgs e)
        {

        }

        private void evaluateButton_Click(object sender, EventArgs e)
        {
            EvaluationForm evaluationForm = new EvaluationForm();
            evaluationForm.Show();
        }


        private void selectStudent_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
