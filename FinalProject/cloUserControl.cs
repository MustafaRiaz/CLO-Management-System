using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace FinalProject
{
    public partial class cloUserControl : UserControl
    {
        public cloUserControl()
        {
            InitializeComponent();
            getcloRecord();
        }
        public int Cid;
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-C42T0RI;Initial Catalog=ProjectB;Integrated Security=True");
        private void addCLOButton_Click(object sender, EventArgs e)
        {
            DateTime currentDate = DateTime.Now;
            DateTime currentDateOnly = currentDate.Date;
            
            //string dateCreated = currentDateOnly.ToString("yyyy-MM-dd");
            SqlCommand cmd = new SqlCommand("INSERT into CLO Values(@Name,@DateCreated,@DateUpdated)", con);
            cmd.Parameters.AddWithValue("@Name", cloInput.Text);
            cmd.Parameters.AddWithValue("@DateCreated", currentDateOnly);
            cmd.Parameters.AddWithValue("@DateUpdated", currentDateOnly);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            //clearData();
            MessageBox.Show("Successfully saved");
            getcloRecord();
            //clearData();
        }
        private void getcloRecord()
        {
            SqlCommand cmd = new SqlCommand("Select * from Clo", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            cloDataGridView.DataSource = dt;
        }

        private void cloDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = cloDataGridView.Columns[e.ColumnIndex].Name;
            DataGridViewRow row = cloDataGridView.Rows[e.RowIndex];

            if (colName == "Update")
            {

                updateClo(row);
            }
            if (cloDataGridView.Columns[e.ColumnIndex].Name == "Delete")
            {
                int id = int.Parse(row.Cells[2].Value.ToString());
                SqlCommand cmd = new SqlCommand("Delete CLO WHERE Id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                //clearData();
                MessageBox.Show("Successfully Deleted");
                getcloRecord();
            }
        }
        private void updateCloInDB(int id)
        {
            DateTime currentDate = DateTime.Now;
            DateTime currentDateOnly = currentDate.Date;
            string cloName=cloInput.Text;
            SqlCommand cmd = new SqlCommand("UPDATE CLO SET Name=@Name, DateUpdated=@DateUpdated WHERE Id=@idInput", con);
            cmd.Parameters.AddWithValue("@idInput", id);
            cmd.Parameters.AddWithValue("@Name", cloName);
            cmd.Parameters.AddWithValue("@DateUpdated", currentDateOnly);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            getcloRecord();
            updateCLOButton.Visible = false;
            addCLOButton.Visible = true;
        }
        private void updateClo(DataGridViewRow row)
        {
            int idInput = int.Parse(row.Cells[2].Value.ToString());
            Cid = idInput;
            cloInput.Text = row.Cells["Name"].Value.ToString();
            updateCLOButton.Visible = true;
            addCLOButton.Visible = false;
        }

        private void updateCLOButton_Click(object sender, EventArgs e)
        {
            updateCloInDB(Cid);
        }

        private void cloInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void studentLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
