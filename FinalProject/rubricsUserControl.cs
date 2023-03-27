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
    public partial class rubricsUserControl : UserControl
    {
        public rubricsUserControl()
        {
            InitializeComponent();
            getRubricsRecord();
            getRubricsID();
        }
        int RID;
        int rubricID = 0;
        int id;
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-C42T0RI;Initial Catalog=ProjectB;Integrated Security=True");
        public Dictionary<string, int> cloDictionary = new Dictionary<string, int>();
        private void addRubricButton_Click(object sender, EventArgs e)
        {
            rubricID++;
            DateTime currentDate = DateTime.Now;
            DateTime currentDateOnly = currentDate.Date;

            //string dateCreated = currentDateOnly.ToString("yyyy-MM-dd");
            SqlCommand cmd = new SqlCommand("INSERT into Rubric Values(@id,@Details,@CloID)", con);
            cmd.Parameters.AddWithValue("@id", rubricID);
            cmd.Parameters.AddWithValue("@Details", rubricsDetailsInput.Text);
            cmd.Parameters.AddWithValue("@CloID", id);
            
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            //clearData();
            MessageBox.Show("Successfully saved");
            getRubricsRecord();
            //clearData();
        }
        private void loadCloIDData()
        {
            
            SqlCommand cmd = new SqlCommand("SELECT id, Name FROM CLO", con);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            
            while (sdr.Read())
            {
                string cloName = sdr["Name"].ToString();
                int cloID = Convert.ToInt32(sdr["id"]);

                // add the CLO name and ID to the dictionary
                cloDictionary[cloName] = cloID;

                // add the CLO name to the combobox
                cloIDInput.Items.Add(cloName);
            }
            con.Close();
        }
        private void getRubricsRecord()
        {
            SqlCommand cmd = new SqlCommand("Select * from Rubric", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            rubricsDataGridView.DataSource = dt;
        }private void getRubricsID()
        {
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 ID FROM Rubric ORDER BY ID DESC", con);
            con.Open();
            object result = cmd.ExecuteScalar();
            if (result != null)
            {
                rubricID = Convert.ToInt32(result);
            }
            con.Close();

        }
        private void cloIDInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = cloIDInput.SelectedItem.ToString();

            int selectedID = cloDictionary[selectedItem];
            id = selectedID;

        }
        private void rubricsUserControl_Load(object sender, EventArgs e)
        {
            loadCloIDData();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rubricsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = rubricsDataGridView.Columns[e.ColumnIndex].Name;
            DataGridViewRow row = rubricsDataGridView.Rows[e.RowIndex];

            if (colName == "Update")
            {
                updateRubrics(row);
            }
            if (rubricsDataGridView.Columns[e.ColumnIndex].Name == "Delete")
            {
                int id = int.Parse(row.Cells[2].Value.ToString());
                SqlCommand cmd = new SqlCommand("Delete Rubric WHERE Id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                //clearData();
                MessageBox.Show("Successfully Deleted");
                getRubricsRecord();
            }
        }
        private void updateRubrics(DataGridViewRow row)
        {
            int idInput = int.Parse(row.Cells[2].Value.ToString());
            rubricsDetailsInput.Text = (row.Cells["Details"].Value).ToString();
            cloIDInput.Text = (row.Cells["cloID"].Value).ToString();
            RID = idInput;
            updateRubricButton.Visible = true;
            addRubricButton.Visible = false;
        }
        private void updateRubricInDB(int RID)
        {
            updateRubricButton.Visible = true;
            addRubricButton.Visible = false;
            SqlCommand cmd = new SqlCommand("UPDATE Rubric SET Details=@Details,cloid=@cloID WHERE Id=@idInput", con);
            cmd.Parameters.AddWithValue("@idInput", RID.ToString());
            cmd.Parameters.AddWithValue("@Details", rubricsDetailsInput.Text);
            cmd.Parameters.AddWithValue("@cloID", cloIDInput.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            getRubricsRecord();
            updateRubricButton.Visible = false;
            addRubricButton.Visible = true;
        }

        private void updateRubricButton_Click(object sender, EventArgs e)
        {
            updateRubricInDB(RID);
            MessageBox.Show("Data Update Successfully");
        }
    }
}
