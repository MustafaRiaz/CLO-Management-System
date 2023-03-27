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
    public partial class AttendanceReportUserControl : UserControl
    {
        public AttendanceReportUserControl()
        {
            InitializeComponent();
            DateTime currentDate = DateTime.Now;
            DateTime currentDateOnly = currentDate.Date;
            getStudentRecord(currentDateOnly);

            //getStudentRecord();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-C42T0RI;Initial Catalog=ProjectB;Integrated Security=True");
        private void getStudentRecord(DateTime date)
        {
            DataTable dt = new DataTable();

            // Check if attendance is already marked on the specified date
            bool isAttendanceMarked = false;
            SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM ClassAttendance WHERE AttendanceDate = @Date", con);
            checkCmd.Parameters.AddWithValue("@Date", date.Date);
            con.Open();
            int count = Convert.ToInt32(checkCmd.ExecuteScalar());
            if (count > 0)
            {
                isAttendanceMarked = true;
            }
            con.Close();

            if (isAttendanceMarked)
            {
                //MessageBox.Show("Attendance is already marked for this date.");
                // Hide or disable the ComboBox column
                attendanceDataGridView.Columns["Status"].ReadOnly = true; // or use .ReadOnly = true; to disable the column
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT Student.Id as StudentId, CONCAT(Student.FirstName, ' ', Student.LastName) AS Name, Student.RegistrationNumber, StudentAttendance.AttendanceStatus FROM Student LEFT JOIN StudentAttendance ON Student.Id = StudentAttendance.StudentId LEFT JOIN ClassAttendance ON StudentAttendance.AttendanceId = ClassAttendance.Id WHERE ClassAttendance.AttendanceDate = @Date", con);
                cmd.Parameters.AddWithValue("@Date", date.Date);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                con.Close();
                // Remove duplicates from the DataTable
                dt = dt.DefaultView.ToTable(true);
                if (dt.Rows.Count == 0)
                {
                    // If attendance is not marked on the specified date, load all the students to mark their attendance
                    cmd = new SqlCommand("SELECT Id as StudentId, CONCAT(FirstName, ' ', LastName) AS Name, RegistrationNumber FROM Student", con);
                    dt = new DataTable();
                    con.Open();
                    sdr = cmd.ExecuteReader();
                    dt.Load(sdr);
                    con.Close();
                }
            }
            else
            {
                attendanceDataGridView.Columns["Status"].ReadOnly = false;
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT Student.Id as StudentId, CONCAT(Student.FirstName, ' ', Student.LastName) AS Name, Student.RegistrationNumber, StudentAttendance.AttendanceStatus FROM Student LEFT JOIN StudentAttendance ON Student.Id = StudentAttendance.StudentId LEFT JOIN ClassAttendance ON StudentAttendance.AttendanceId = ClassAttendance.Id WHERE ClassAttendance.AttendanceDate = @Date", con);
                cmd.Parameters.AddWithValue("@Date", date.Date);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                con.Close();
                // Remove duplicates from the DataTable
                dt = dt.DefaultView.ToTable(true);
                if (dt.Rows.Count == 0)
                {
                    // If attendance is not marked on the specified date, load all the students to mark their attendance
                    cmd = new SqlCommand("SELECT Id as StudentId, CONCAT(FirstName, ' ', LastName) AS Name, RegistrationNumber FROM Student", con);
                    dt = new DataTable();
                    con.Open();
                    sdr = cmd.ExecuteReader();
                    dt.Load(sdr);
                    con.Close();
                }
            }
                attendanceDataGridView.DataSource = dt;
        }
        private void addACButton_Click(object sender, EventArgs e)
        {

        }

        private void attendanceDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void attendanceDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox combo = e.Control as ComboBox;
            if (combo != null)
            {
                combo.SelectedIndexChanged -= new EventHandler(Combo_SelectedIndexChanged);
                combo.SelectedIndexChanged += Combo_SelectedIndexChanged;
            }
        }

        private void attendanceDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private int GetStudentId(int rowIndex)
        {
            DataGridViewRow row = attendanceDataGridView.Rows[rowIndex];
            int studentId = Convert.ToInt32(row.Cells["StudentID"].Value);
            return studentId;
        }
        private int InsertAttendance(DateTime attendanceDate)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO ClassAttendance (AttendanceDate) VALUES (@AttendanceDate); SELECT SCOPE_IDENTITY();", con);
            cmd.Parameters.AddWithValue("@AttendanceDate", attendanceDate.Date);
            con.Open();
            int attendanceId = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return attendanceId;
        }

        private void InsertStudentAttendance(int studentId, int attendanceId, int attendanceStatus)
        {
            
            SqlCommand cmd = new SqlCommand("INSERT INTO StudentAttendance (StudentID, AttendanceID, AttendanceStatus) VALUES (@StudentID, @AttendanceID, @AttendanceStatus)", con);
            cmd.Parameters.AddWithValue("@StudentID", studentId);
            cmd.Parameters.AddWithValue("@AttendanceID", attendanceId);
            cmd.Parameters.AddWithValue("@AttendanceStatus", attendanceStatus);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataGridViewComboBoxEditingControl combo = sender as DataGridViewComboBoxEditingControl;
            if (combo != null)
            {
                string attendanceStatus = combo.SelectedItem.ToString();
                int rowIndex = attendanceDataGridView.CurrentCell.RowIndex;
                int studentId = GetStudentId(rowIndex);
                DateTime attendanceDate = attendanceDatePicker.Value.Date;

                // Retrieve the attendance status ID from the lookup table
                int attendanceStatusId = -1;
                SqlCommand cmd = new SqlCommand("SELECT LookupID FROM Lookup WHERE Name = @Name AND Category = 'Attendance_Status'", con);
                cmd.Parameters.AddWithValue("@Name", attendanceStatus);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    attendanceStatusId = Convert.ToInt32(reader["LookupID"]);
                }
                con.Close();

                // Insert the attendance record into the database
                int attendanceId = InsertAttendance(attendanceDate);
                InsertStudentAttendance(studentId, attendanceId, attendanceStatusId);
            }
        }

        private void updateACButton_Click(object sender, EventArgs e)
        {
            ViewAttendance viewAttendance = new ViewAttendance();
            viewAttendance.Show();
        }

        private void attendanceDatePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt = new DateTime();
            dt = attendanceDatePicker.Value.Date;
            DateTime selectedDate = dt.Date;
            getStudentRecord(selectedDate);
        }
    }
}
