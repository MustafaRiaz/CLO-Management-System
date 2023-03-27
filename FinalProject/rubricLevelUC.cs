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
    public partial class rubricLevelUC : UserControl
    {
        public rubricLevelUC()
        {
            InitializeComponent();
            mlInput.DataSource = new string[] { "Easy", "Medium", "Hard" };
            loadRubricsIDData();
            getRLRecord();
            
        }
        int RLid,id;
        private void rubricLevelUC_Load(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-C42T0RI;Initial Catalog=ProjectB;Integrated Security=True");

        
        private void addRLButton_Click(object sender, EventArgs e)
        {
            /*int mLevel;
            if()*/
            SqlCommand cmd = new SqlCommand("INSERT into RubricLevel Values(@RubricID,@Details,@measurementLevel)", con);
            cmd.Parameters.AddWithValue("@RubricID", id);
            cmd.Parameters.AddWithValue("@Details", detailsInput.Text);
            cmd.Parameters.AddWithValue("@measurementLevel", mlInput.SelectedIndex+1);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully saved");
            getRLRecord();
        }
        private void getRLRecord()
        {
            SqlCommand cmd = new SqlCommand("Select * from RubricLevel", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            RLDataGridView.DataSource = dt;
        }

        private void RLDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = RLDataGridView.Columns[e.ColumnIndex].Name;
            DataGridViewRow row = RLDataGridView.Rows[e.RowIndex];

            if (colName == "Update")
            {

                updateRL(row);
            }
            if (RLDataGridView.Columns[e.ColumnIndex].Name == "Delete")
            {
                int id = int.Parse(row.Cells[2].Value.ToString());
                SqlCommand cmd = new SqlCommand("Delete AssessmentComponent WHERE Id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                //clearData();
                MessageBox.Show("Successfully Deleted");
                getRLRecord();
            }
           
        }
        
        private void updateRL(DataGridViewRow row)
        {
            int idInput = int.Parse(row.Cells[2].Value.ToString());
            RubricIdInput.Text = (row.Cells["Name"].Value).ToString();
            detailsInput.Text = (row.Cells["rubricID"].Value).ToString();
            mlInput.Text = (row.Cells["TotalMarks"].Value).ToString();
            RLid = idInput;
            updateRLButton.Visible = true;
            addRLButton.Visible = false;
        }
        private void updateRLInDB(int AcId)
        {
            DateTime currentDate = DateTime.Now;
            DateTime currentDateOnly = currentDate.Date;
            updateRLButton.Visible = true;
            addRLButton.Visible = false;
            SqlCommand cmd = new SqlCommand("UPDATE RubricLevel SET RubricID=@RubricID,Details=@Details,MeasurementLevel=@MeasurementLevel WHERE Id=@RLID", con);
            cmd.Parameters.AddWithValue("@RLID", AcId.ToString());
            cmd.Parameters.AddWithValue("@RubricID", RubricIdInput.Text);
            cmd.Parameters.AddWithValue("@Details", detailsInput.Text);
            cmd.Parameters.AddWithValue("@MeasurementLevel", mlInput.SelectedItem.ToString());
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            getRLRecord();
            MessageBox.Show("Data Update Successfully");
            updateRLButton.Visible = false;
            addRLButton.Visible = true;
        }

        private void updateRLButton_Click(object sender, EventArgs e)
        {
            updateRLInDB(RLid);
        }
        public Dictionary<string, int> rubricDictionary = new Dictionary<string, int>();

        private void RubricIdInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = RubricIdInput.SelectedItem.ToString();
            int selectedID = rubricDictionary[selectedItem];
            id = selectedID;
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
                RubricIdInput.Items.Add(rubricDetails);
            }
            con.Close();
        }
    }
}
