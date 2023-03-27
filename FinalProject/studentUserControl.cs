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
using System.Xml.Serialization;

namespace FinalProject
{
    public partial class studentUserControl : UserControl
    {

        public studentUserControl()
        {
            InitializeComponent();
            getStudentRecord();
            updateStudentButton.Visible = false;
        }
        public int status = 0;
        public int sId;

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-C42T0RI;Initial Catalog=ProjectB;Integrated Security=True");
        private void getStudentRecord()
        {
            SqlCommand cmd = new SqlCommand("Select * from Student", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            studentsDataGridView.DataSource = dt;
        }

        private void addStudentButton_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT into Student Values(@FirstName,@LastName,@Contact,@Email,@Registration,@Status)", con);
            cmd.Parameters.AddWithValue("@FirstName", firstNameInput.Text);
            cmd.Parameters.AddWithValue("@LastName", lastNameInput.Text);
            cmd.Parameters.AddWithValue("@Contact", contactInput.Text);
            cmd.Parameters.AddWithValue("@Email", emailInput.Text);
            cmd.Parameters.AddWithValue("@Registration", regNoInput.Text);
            //MessageBox.Show(statusInput.Text);
            cmd.Parameters.AddWithValue("@Status", status);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            //clearData();
            MessageBox.Show("Successfully saved");
            getStudentRecord();
            clearData();
        }
        private void clearData()
        {
            firstNameInput.Text = "";
            lastNameInput.Text = "";
            contactInput.Text = "";
            emailInput.Text = "";
            regNoInput.Text = "";
            comboBox1.SelectedIndex = -1;
        }
        private void studentDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }
        private void updateStudentInDB(int sid)
        {
            
            string sStatus;
            sStatus = comboBox1.Text;
            int s;
            if (sStatus == "Active")
            {
                s = 1;
            }
            else
            {
                s = 2;
            }
            sStatus = comboBox1.Text;
            updateStudentButton.Visible = true;
            addStudentButton.Visible = false;
            SqlCommand cmd = new SqlCommand("UPDATE Student SET FirstName=@FirstName, LastName=@LastName, Contact=@Contact, Email=@Email, RegistrationNumber=@Registration, Status=@Status WHERE Id=@idInput", con);
            cmd.Parameters.AddWithValue("@idInput", sid);
            cmd.Parameters.AddWithValue("@FirstName", firstNameInput.Text);
            cmd.Parameters.AddWithValue("@LastName", lastNameInput.Text);
            cmd.Parameters.AddWithValue("@Contact", contactInput.Text);
            cmd.Parameters.AddWithValue("@Email", emailInput.Text);
            cmd.Parameters.AddWithValue("@Registration", regNoInput.Text);
            cmd.Parameters.AddWithValue("@Status", s);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            getStudentRecord();
            clearData();
            MessageBox.Show("Data Update Successfully");
            updateStudentButton.Visible = false;
            addStudentButton.Visible = true;

        }
        private void updateStudent(DataGridViewRow row)
        {
            int idInput = int.Parse(row.Cells[2].Value.ToString());
            firstNameInput.Text = (row.Cells["FirstName"].Value).ToString();
            lastNameInput.Text= (row.Cells["LastName"].Value).ToString();
            contactInput.Text= (row.Cells["Contact"].Value).ToString();
            emailInput.Text= (row.Cells["Email"].Value).ToString();
            regNoInput.Text= (row.Cells["RegistrationNumber"].Value).ToString();
            int status1= int.Parse((row.Cells["Status"].Value).ToString());
            if (status1 == 1)
            {
                comboBox1.Text = "Active";
            }
            else
            {
                comboBox1.Text = "Inactive";
            }
            sId = idInput;
            updateStudentButton.Visible = true;
            addStudentButton.Visible = false;
        }
        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                if (comboBox1.SelectedItem == "Active")
                {
                    status = 1;
                }
                else
                {
                    status = 2;
                }
            }
            
        }

        private void studentLabel_Click(object sender, EventArgs e)
        {

        }

        private void updateStudentButton_Click(object sender, EventArgs e)
        {
            
            updateStudentInDB(sId);
        }

        private void studentsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = studentsDataGridView.Columns[e.ColumnIndex].Name;
            DataGridViewRow row = studentsDataGridView.Rows[e.RowIndex];

            if (colName == "btnUpdate")
            {
                updateStudent(row);
            }
            else if (studentsDataGridView.Columns[e.ColumnIndex].Name == "Delete")
            {
                string id = row.Cells[2].Value.ToString();
                SqlCommand cmd = new SqlCommand("Delete Student WHERE Id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                //clearData();
                MessageBox.Show("Successfully Deleted");
                getStudentRecord();
            }
        }
    }
}
