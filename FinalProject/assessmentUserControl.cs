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

namespace FinalProject
{
    public partial class assessmentUserControl : UserControl
    {
        public assessmentUserControl()
        {
            InitializeComponent();
            getAssessmentRecord();
        }
        int Aid;
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-C42T0RI;Initial Catalog=ProjectB;Integrated Security=True");
        private void addStudentButton_Click(object sender, EventArgs e)
        {
            DateTime currentDate = DateTime.Now;
            DateTime currentDateOnly = currentDate.Date;
            SqlCommand cmd = new SqlCommand("INSERT into Assessment Values(@Title,@DateCreated,@TotalMarks,@TotalWeightage)", con);
            cmd.Parameters.AddWithValue("@Title", titleInput.Text);
            cmd.Parameters.AddWithValue("@DateCreated", currentDateOnly);
            cmd.Parameters.AddWithValue("@TotalMarks", totalMarksInput.Text);
            cmd.Parameters.AddWithValue("@TotalWeightage", totalWeightageInput.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            //clearData();
            MessageBox.Show("Successfully saved");
            getAssessmentRecord();
        }
        
        private void getAssessmentRecord()
        {
            SqlCommand cmd = new SqlCommand("Select * from Assessment", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            assessmentDataGridView.DataSource = dt;
        }
        private void firstNameInput_TextChanged(object sender, EventArgs e)
        {

        }
        private void updateAssessmentInDB(int id)
        {
            DateTime currentDate = DateTime.Now;
            DateTime currentDateOnly = currentDate.Date;
            SqlCommand cmd = new SqlCommand("UPDATE Assessment SET Title=@Title, TotalMarks=@TotalMarks, TotalWeightage=@TotalWeightage WHERE Id=@idInput", con);
            cmd.Parameters.AddWithValue("@idInput", id);
            cmd.Parameters.AddWithValue("@Title", titleInput.Text);
            cmd.Parameters.AddWithValue("@TotalMarks", totalMarksInput.Text);
            cmd.Parameters.AddWithValue("@TotalWeightage", totalWeightageInput.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            getAssessmentRecord();
            updateAssessmentButton.Visible = false;
            addAssessmentButton.Visible = true;
            MessageBox.Show("Data Updated Successfully");
        }
        private void updateAssessment(DataGridViewRow row)
        {
            int idInput = int.Parse(row.Cells[2].Value.ToString());
            Aid = idInput;
            titleInput.Text = row.Cells["Title"].Value.ToString();
            totalMarksInput.Text = row.Cells["TotalMarks"].Value.ToString();
            totalWeightageInput.Text = row.Cells["TotalWeightage"].Value.ToString();
            updateAssessmentButton.Visible = true;
            addAssessmentButton.Visible = false;
        }

        private void assessmentDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = assessmentDataGridView.Columns[e.ColumnIndex].Name;
            DataGridViewRow row = assessmentDataGridView.Rows[e.RowIndex];

            if (colName == "Update")
            {

                updateAssessment(row);
            }
            if (assessmentDataGridView.Columns[e.ColumnIndex].Name == "Delete")
            {
                int id = int.Parse(row.Cells[2].Value.ToString());
                SqlCommand cmd = new SqlCommand("Delete Assessment WHERE Id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                //clearData();
                MessageBox.Show("Successfully Deleted");
                getAssessmentRecord();
            }
        }

        private void updateAssessmentButton_Click(object sender, EventArgs e)
        {
            updateAssessmentInDB(Aid);
        }
    }
}
