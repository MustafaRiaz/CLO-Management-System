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
    public partial class assessmentComponenetUserControl : UserControl
    {
        public assessmentComponenetUserControl()
        {
            InitializeComponent();
            loadRubricsIDData();
            loadAssessmentIDData();
            getACRecord();
        }
        public int id,Aid;

        public Dictionary<string, int> rubricDictionary = new Dictionary<string, int>();
        public Dictionary<string, int> acDictionary = new Dictionary<string, int>();

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-C42T0RI;Initial Catalog=ProjectB;Integrated Security=True");
        private void addACButton_Click(object sender, EventArgs e)
        {
            DateTime currentDate = DateTime.Now;
            DateTime currentDateOnly = currentDate.Date;
            SqlCommand cmd = new SqlCommand("INSERT into AssessmentComponent Values(@Name,@RubricID,@TotalMarks,@DateCreated,@DateUpdated,@AssessmentID)", con);
            cmd.Parameters.AddWithValue("@Name", nameInput.Text);
            cmd.Parameters.AddWithValue("@TotalMarks", lastNameInput.Text);
            cmd.Parameters.AddWithValue("@RubricID", id);
            cmd.Parameters.AddWithValue("@DateCreated", currentDateOnly);
            cmd.Parameters.AddWithValue("@DateUpdated", currentDateOnly);
            cmd.Parameters.AddWithValue("@AssessmentID", Aid);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            //clearData();
            MessageBox.Show("Successfully saved");
            getACRecord();
        }
        private void loadRubricsIDData()
        {
            SqlCommand cmd = new SqlCommand("SELECT Id, details, cloid FROM Rubric", con);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                string rubricDetails = sdr["details"].ToString();
                int cloID = Convert.ToInt32(sdr["Id"]);
                rubricDictionary[rubricDetails] = cloID;
                rubricsID.Items.Add(rubricDetails);
            }
            con.Close();
        
       }
        private void loadAssessmentIDData()
        {

            SqlCommand cmd = new SqlCommand("SELECT id,Title FROM Assessment", con);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                string Title = sdr["Title"].ToString();
                int assessmentID = Convert.ToInt32(sdr["id"]);
                acDictionary[Title] = assessmentID;
                acInput.Items.Add(Title);
            }
            con.Close();
        }
        private void getACRecord()
        {
            SqlCommand cmd = new SqlCommand("Select * from AssessmentComponent", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            AssessmentCompDataGridView.DataSource = dt;
        }

        private void rubricsID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = rubricsID.SelectedItem.ToString();

            int selectedID = rubricDictionary[selectedItem];
            id = selectedID;
            //MessageBox.Show(id.ToString());
        }

        private void AssessmentCompDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = AssessmentCompDataGridView.Columns[e.ColumnIndex].Name;
            DataGridViewRow row = AssessmentCompDataGridView.Rows[e.RowIndex];

            if (colName == "Update")
            {

                updateAC(row);
            }
            if (AssessmentCompDataGridView.Columns[e.ColumnIndex].Name == "Delete")
            {
                int id = int.Parse(row.Cells[2].Value.ToString());
                SqlCommand cmd = new SqlCommand("Delete AssessmentComponent WHERE Id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                //clearData();
                MessageBox.Show("Successfully Deleted");
                getACRecord();
            }
        }
        private void updateAC(DataGridViewRow row)
        {
            int idInput = int.Parse(row.Cells[2].Value.ToString());
            nameInput.Text= (row.Cells["Name"].Value).ToString();
            rubricsID.Text = (row.Cells["rubricID"].Value).ToString();
            totalMarksInput.Text = (row.Cells["TotalMarks"].Value).ToString();
            lastNameInput.Text = (row.Cells["assessmentID"].Value).ToString();
            Aid = idInput;
            updateACButton.Visible = true;
            addACButton.Visible = false;
        }
        private void acInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = acInput.SelectedItem.ToString();

            int selectedID = acDictionary[selectedItem];
            Aid = selectedID;
            //MessageBox.Show(Aid.ToString());
        }

        private void updateACButton_Click(object sender, EventArgs e)
        {
            updateACInDB(Aid);
        }

        private void updateACInDB(int AcId)
        {
            DateTime currentDate = DateTime.Now;
            DateTime currentDateOnly = currentDate.Date;
            updateACButton.Visible = true;
            addACButton.Visible = false;
            SqlCommand cmd = new SqlCommand("UPDATE AssessmentComponent SET Name=@Name,RubricId=@RubricID,TotalMarks=@TotalMarks,DateUpdated=@DateUpdated,assessmentID=@assessmentID  WHERE Id=@AcID", con);
            cmd.Parameters.AddWithValue("@AcID", AcId.ToString());
            cmd.Parameters.AddWithValue("@Name", nameInput.Text);
            cmd.Parameters.AddWithValue("@RubricID", rubricsID.Text);
            cmd.Parameters.AddWithValue("@TotalMarks", totalMarksInput.Text);
            cmd.Parameters.AddWithValue("@DateUpdated", currentDateOnly.ToString());
            cmd.Parameters.AddWithValue("@assessmentid", acInput.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            getACRecord();
            MessageBox.Show("Data Update Successfully");
            updateACButton.Visible = false;
            addACButton.Visible = true;
        }
    }
}
