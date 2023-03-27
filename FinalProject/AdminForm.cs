using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
            studentUserControl1.Visible = true;
            cloUserControl1.Visible = false;
            assessmentUserControl1.Visible = false;
            rubricsUserControl1.Visible = false;
            assessmentComponenetUserControl1.Visible = false;
            rubricLevelUC1.Visible = false;
            evaluationControlForm1.Visible = false;
            attendanceReportUserControl1.Visible = false;

        }
        private void studentUserControl2_Load(object sender, EventArgs e)
        {

        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }

        private void studentButton_Click(object sender, EventArgs e)
        {
            studentUserControl1.Visible = true;
            cloUserControl1.Visible = false;
            assessmentUserControl1.Visible = false;
            rubricsUserControl1.Visible = false;
            assessmentComponenetUserControl1.Visible = false;
            evaluationControlForm1.Visible = false;
            attendanceReportUserControl1.Visible = false;


        }

        private void cloButton_Click(object sender, EventArgs e)
        {
            studentUserControl1.Visible = false;
            cloUserControl1.Visible = true;
            assessmentUserControl1.Visible = false;
            rubricsUserControl1.Visible = false;
            assessmentComponenetUserControl1.Visible = false;
            rubricLevelUC1.Visible = false;
            evaluationControlForm1.Visible = false;
            attendanceReportUserControl1.Visible = false;

        }

        private void assessmentButton_Click(object sender, EventArgs e)
        {
            assessmentUserControl1.Visible = true;
            studentUserControl1.Visible = false;
            cloUserControl1.Visible = false;
            rubricsUserControl1.Visible = false;
            assessmentComponenetUserControl1.Visible = false;
            rubricLevelUC1.Visible = false;
            evaluationControlForm1.Visible = false;
            attendanceReportUserControl1.Visible = false;


        }
        private void rubricButton_Click(object sender, EventArgs e)
        {
            

        }
        private void ACBtn_Click(object sender, EventArgs e)
        {
            rubricsUserControl1.Visible = false;
            assessmentUserControl1.Visible = false;
            rubricLevelUC1.Visible = false;

            studentUserControl1.Visible = false;
            cloUserControl1.Visible = false;
            assessmentComponenetUserControl1.Visible = true;
            evaluationControlForm1.Visible = false;
            attendanceReportUserControl1.Visible = false;

        }

        private void rubricButton_Click_1(object sender, EventArgs e)
        {
            rubricsUserControl1.Visible = true;
            rubricLevelUC1.Visible = false;

            assessmentUserControl1.Visible = false;
            studentUserControl1.Visible = false;
            cloUserControl1.Visible = false;
            evaluationControlForm1.Visible = false;
            assessmentComponenetUserControl1.Visible = false;
            attendanceReportUserControl1.Visible = false;

        }

        private void rubricLevelBtn_Click(object sender, EventArgs e)
        {
            rubricLevelUC1.Visible = true;
            rubricsUserControl1.Visible = false;
            assessmentUserControl1.Visible = false;
            studentUserControl1.Visible = false;
            cloUserControl1.Visible = false;
            assessmentComponenetUserControl1.Visible = false;
            evaluationControlForm1.Visible = false;
            attendanceReportUserControl1.Visible = false;


        }

        private void evaluationBtn_Click(object sender, EventArgs e)
        {
            evaluationControlForm1.Visible = true;
            rubricLevelUC1.Visible = false;
            rubricsUserControl1.Visible = false;
            assessmentUserControl1.Visible = false;
            studentUserControl1.Visible = false;
            cloUserControl1.Visible = false;
            assessmentComponenetUserControl1.Visible = false;
            attendanceReportUserControl1.Visible = false;

        }

        private void attendanceBtn_Click(object sender, EventArgs e)
        {
            attendanceReportUserControl1.Visible    = true;
            evaluationControlForm1.Visible = false;
            rubricLevelUC1.Visible = false;
            rubricsUserControl1.Visible = false;
            assessmentUserControl1.Visible = false;
            studentUserControl1.Visible = false;
            cloUserControl1.Visible = false;
            assessmentComponenetUserControl1.Visible = false;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
