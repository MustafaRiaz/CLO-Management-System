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

namespace FinalProject
{
    public partial class ViewAttendance : Form
    {
        public ViewAttendance()
        {
            InitializeComponent();
            getStudentRecord();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-C42T0RI;Initial Catalog=ProjectB;Integrated Security=True");

        private void getStudentRecord()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT s.FirstName + ' ' + s.LastName as 'Student Name', l.Name as 'Attendance_Status' FROM StudentAttendance sa INNER JOIN Student s ON sa.StudentId = s.Id INNER JOIN Lookup l ON sa.AttendanceStatus = l.LookupID WHERE l.Category = 'Attendance_Status'", con);
                DataTable dt = new DataTable();
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                con.Close();
                // Remove duplicates from the DataTable
                dt = dt.DefaultView.ToTable(true);
                attendanceDataGrid.DataSource = dt;
            }
            catch (Exception ex)
            {
                // Handle the exception and show an error message to the user
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void attendanceDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
