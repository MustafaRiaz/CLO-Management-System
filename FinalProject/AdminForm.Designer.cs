namespace FinalProject
{
    partial class AdminForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            this.headerPanel = new System.Windows.Forms.Panel();
            this.headerImage = new System.Windows.Forms.PictureBox();
            this.studentButton = new System.Windows.Forms.Button();
            this.cloButton = new System.Windows.Forms.Button();
            this.assessmentButton = new System.Windows.Forms.Button();
            this.AssessmentComponentBtn = new System.Windows.Forms.Button();
            this.rubricButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.attendanceBtn = new System.Windows.Forms.Button();
            this.evaluationBtn = new System.Windows.Forms.Button();
            this.rubricLevelBtn = new System.Windows.Forms.Button();
            this.rubricLevelUC1 = new FinalProject.rubricLevelUC();
            this.assessmentComponenetUserControl1 = new FinalProject.assessmentComponenetUserControl();
            this.rubricsUserControl1 = new FinalProject.rubricsUserControl();
            this.assessmentUserControl1 = new FinalProject.assessmentUserControl();
            this.cloUserControl1 = new FinalProject.cloUserControl();
            this.studentUserControl2 = new FinalProject.studentUserControl();
            this.studentUserControl1 = new FinalProject.studentUserControl();
            this.evaluationControlForm1 = new FinalProject.evaluationControlForm();
            this.attendanceReportUserControl1 = new FinalProject.AttendanceReportUserControl();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerImage)).BeginInit();
            this.menuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.Controls.Add(this.headerImage);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(331, 158);
            this.headerPanel.TabIndex = 0;
            // 
            // headerImage
            // 
            this.headerImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerImage.ErrorImage = ((System.Drawing.Image)(resources.GetObject("headerImage.ErrorImage")));
            this.headerImage.Image = ((System.Drawing.Image)(resources.GetObject("headerImage.Image")));
            this.headerImage.Location = new System.Drawing.Point(0, 0);
            this.headerImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.headerImage.Name = "headerImage";
            this.headerImage.Size = new System.Drawing.Size(331, 158);
            this.headerImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.headerImage.TabIndex = 0;
            this.headerImage.TabStop = false;
            // 
            // studentButton
            // 
            this.studentButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(35)))), ((int)(((byte)(91)))));
            this.studentButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.studentButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.studentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentButton.ForeColor = System.Drawing.Color.White;
            this.studentButton.Location = new System.Drawing.Point(0, 158);
            this.studentButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.studentButton.Name = "studentButton";
            this.studentButton.Size = new System.Drawing.Size(331, 68);
            this.studentButton.TabIndex = 1;
            this.studentButton.Text = "Student";
            this.studentButton.UseVisualStyleBackColor = false;
            this.studentButton.Click += new System.EventHandler(this.studentButton_Click);
            // 
            // cloButton
            // 
            this.cloButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(35)))), ((int)(((byte)(91)))));
            this.cloButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.cloButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cloButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cloButton.ForeColor = System.Drawing.Color.White;
            this.cloButton.Location = new System.Drawing.Point(0, 226);
            this.cloButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cloButton.Name = "cloButton";
            this.cloButton.Size = new System.Drawing.Size(331, 68);
            this.cloButton.TabIndex = 2;
            this.cloButton.Text = "CLO";
            this.cloButton.UseVisualStyleBackColor = false;
            this.cloButton.Click += new System.EventHandler(this.cloButton_Click);
            // 
            // assessmentButton
            // 
            this.assessmentButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(35)))), ((int)(((byte)(91)))));
            this.assessmentButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.assessmentButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.assessmentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.assessmentButton.ForeColor = System.Drawing.Color.White;
            this.assessmentButton.Location = new System.Drawing.Point(0, 294);
            this.assessmentButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.assessmentButton.Name = "assessmentButton";
            this.assessmentButton.Size = new System.Drawing.Size(331, 68);
            this.assessmentButton.TabIndex = 3;
            this.assessmentButton.Text = "Assessment";
            this.assessmentButton.UseVisualStyleBackColor = false;
            this.assessmentButton.Click += new System.EventHandler(this.assessmentButton_Click);
            // 
            // AssessmentComponentBtn
            // 
            this.AssessmentComponentBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(35)))), ((int)(((byte)(91)))));
            this.AssessmentComponentBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.AssessmentComponentBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AssessmentComponentBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AssessmentComponentBtn.ForeColor = System.Drawing.Color.White;
            this.AssessmentComponentBtn.Location = new System.Drawing.Point(0, 362);
            this.AssessmentComponentBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AssessmentComponentBtn.Name = "AssessmentComponentBtn";
            this.AssessmentComponentBtn.Size = new System.Drawing.Size(331, 68);
            this.AssessmentComponentBtn.TabIndex = 4;
            this.AssessmentComponentBtn.Text = "Assessment Component";
            this.AssessmentComponentBtn.UseVisualStyleBackColor = false;
            this.AssessmentComponentBtn.Click += new System.EventHandler(this.ACBtn_Click);
            // 
            // rubricButton
            // 
            this.rubricButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(35)))), ((int)(((byte)(91)))));
            this.rubricButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.rubricButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rubricButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rubricButton.ForeColor = System.Drawing.Color.White;
            this.rubricButton.Location = new System.Drawing.Point(0, 430);
            this.rubricButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rubricButton.Name = "rubricButton";
            this.rubricButton.Size = new System.Drawing.Size(331, 68);
            this.rubricButton.TabIndex = 5;
            this.rubricButton.Text = "Rubrics";
            this.rubricButton.UseVisualStyleBackColor = false;
            this.rubricButton.Click += new System.EventHandler(this.rubricButton_Click_1);
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.exitButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.ForeColor = System.Drawing.Color.White;
            this.exitButton.Location = new System.Drawing.Point(0, 718);
            this.exitButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(331, 68);
            this.exitButton.TabIndex = 6;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.MidnightBlue;
            this.menuPanel.Controls.Add(this.attendanceBtn);
            this.menuPanel.Controls.Add(this.evaluationBtn);
            this.menuPanel.Controls.Add(this.rubricLevelBtn);
            this.menuPanel.Controls.Add(this.exitButton);
            this.menuPanel.Controls.Add(this.rubricButton);
            this.menuPanel.Controls.Add(this.AssessmentComponentBtn);
            this.menuPanel.Controls.Add(this.assessmentButton);
            this.menuPanel.Controls.Add(this.cloButton);
            this.menuPanel.Controls.Add(this.studentButton);
            this.menuPanel.Controls.Add(this.headerPanel);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuPanel.Location = new System.Drawing.Point(0, 0);
            this.menuPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(331, 786);
            this.menuPanel.TabIndex = 0;
            // 
            // attendanceBtn
            // 
            this.attendanceBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(35)))), ((int)(((byte)(91)))));
            this.attendanceBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.attendanceBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.attendanceBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attendanceBtn.ForeColor = System.Drawing.Color.White;
            this.attendanceBtn.Location = new System.Drawing.Point(0, 634);
            this.attendanceBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.attendanceBtn.Name = "attendanceBtn";
            this.attendanceBtn.Size = new System.Drawing.Size(331, 68);
            this.attendanceBtn.TabIndex = 9;
            this.attendanceBtn.Text = "Attendance";
            this.attendanceBtn.UseVisualStyleBackColor = false;
            this.attendanceBtn.Click += new System.EventHandler(this.attendanceBtn_Click);
            // 
            // evaluationBtn
            // 
            this.evaluationBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(35)))), ((int)(((byte)(91)))));
            this.evaluationBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.evaluationBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.evaluationBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.evaluationBtn.ForeColor = System.Drawing.Color.White;
            this.evaluationBtn.Location = new System.Drawing.Point(0, 566);
            this.evaluationBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.evaluationBtn.Name = "evaluationBtn";
            this.evaluationBtn.Size = new System.Drawing.Size(331, 68);
            this.evaluationBtn.TabIndex = 8;
            this.evaluationBtn.Text = "Evaluation";
            this.evaluationBtn.UseVisualStyleBackColor = false;
            this.evaluationBtn.Click += new System.EventHandler(this.evaluationBtn_Click);
            // 
            // rubricLevelBtn
            // 
            this.rubricLevelBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(35)))), ((int)(((byte)(91)))));
            this.rubricLevelBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.rubricLevelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rubricLevelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rubricLevelBtn.ForeColor = System.Drawing.Color.White;
            this.rubricLevelBtn.Location = new System.Drawing.Point(0, 498);
            this.rubricLevelBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rubricLevelBtn.Name = "rubricLevelBtn";
            this.rubricLevelBtn.Size = new System.Drawing.Size(331, 68);
            this.rubricLevelBtn.TabIndex = 7;
            this.rubricLevelBtn.Text = "Rubric Level";
            this.rubricLevelBtn.UseVisualStyleBackColor = false;
            this.rubricLevelBtn.Click += new System.EventHandler(this.rubricLevelBtn_Click);
            // 
            // rubricLevelUC1
            // 
            this.rubricLevelUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rubricLevelUC1.Location = new System.Drawing.Point(331, 0);
            this.rubricLevelUC1.Name = "rubricLevelUC1";
            this.rubricLevelUC1.Size = new System.Drawing.Size(1037, 786);
            this.rubricLevelUC1.TabIndex = 8;
            // 
            // assessmentComponenetUserControl1
            // 
            this.assessmentComponenetUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.assessmentComponenetUserControl1.Location = new System.Drawing.Point(331, 0);
            this.assessmentComponenetUserControl1.Margin = new System.Windows.Forms.Padding(4);
            this.assessmentComponenetUserControl1.Name = "assessmentComponenetUserControl1";
            this.assessmentComponenetUserControl1.Size = new System.Drawing.Size(1037, 786);
            this.assessmentComponenetUserControl1.TabIndex = 7;
            // 
            // rubricsUserControl1
            // 
            this.rubricsUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rubricsUserControl1.Location = new System.Drawing.Point(331, 0);
            this.rubricsUserControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rubricsUserControl1.Name = "rubricsUserControl1";
            this.rubricsUserControl1.Size = new System.Drawing.Size(1037, 786);
            this.rubricsUserControl1.TabIndex = 6;
            // 
            // assessmentUserControl1
            // 
            this.assessmentUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.assessmentUserControl1.Location = new System.Drawing.Point(331, 0);
            this.assessmentUserControl1.Margin = new System.Windows.Forms.Padding(5);
            this.assessmentUserControl1.Name = "assessmentUserControl1";
            this.assessmentUserControl1.Size = new System.Drawing.Size(1037, 786);
            this.assessmentUserControl1.TabIndex = 4;
            // 
            // cloUserControl1
            // 
            this.cloUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cloUserControl1.Location = new System.Drawing.Point(331, 0);
            this.cloUserControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cloUserControl1.Name = "cloUserControl1";
            this.cloUserControl1.Size = new System.Drawing.Size(1037, 786);
            this.cloUserControl1.TabIndex = 3;
            // 
            // studentUserControl2
            // 
            this.studentUserControl2.BackColor = System.Drawing.Color.White;
            this.studentUserControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.studentUserControl2.Location = new System.Drawing.Point(331, 0);
            this.studentUserControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.studentUserControl2.Name = "studentUserControl2";
            this.studentUserControl2.Size = new System.Drawing.Size(1037, 786);
            this.studentUserControl2.TabIndex = 1;
            this.studentUserControl2.Load += new System.EventHandler(this.studentUserControl2_Load);
            // 
            // studentUserControl1
            // 
            this.studentUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.studentUserControl1.Location = new System.Drawing.Point(331, 0);
            this.studentUserControl1.Margin = new System.Windows.Forms.Padding(2);
            this.studentUserControl1.Name = "studentUserControl1";
            this.studentUserControl1.Size = new System.Drawing.Size(1035, 778);
            this.studentUserControl1.TabIndex = 1;
            // 
            // evaluationControlForm1
            // 
            this.evaluationControlForm1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.evaluationControlForm1.Location = new System.Drawing.Point(331, 0);
            this.evaluationControlForm1.Name = "evaluationControlForm1";
            this.evaluationControlForm1.Size = new System.Drawing.Size(1037, 786);
            this.evaluationControlForm1.TabIndex = 9;
            // 
            // attendanceReportUserControl1
            // 
            this.attendanceReportUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.attendanceReportUserControl1.Location = new System.Drawing.Point(331, 0);
            this.attendanceReportUserControl1.Name = "attendanceReportUserControl1";
            this.attendanceReportUserControl1.Size = new System.Drawing.Size(1037, 786);
            this.attendanceReportUserControl1.TabIndex = 10;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1368, 786);
            this.Controls.Add(this.attendanceReportUserControl1);
            this.Controls.Add(this.evaluationControlForm1);
            this.Controls.Add(this.rubricLevelUC1);
            this.Controls.Add(this.assessmentComponenetUserControl1);
            this.Controls.Add(this.rubricsUserControl1);
            this.Controls.Add(this.assessmentUserControl1);
            this.Controls.Add(this.cloUserControl1);
            this.Controls.Add(this.studentUserControl2);
            this.Controls.Add(this.menuPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1382, 822);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.headerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerImage)).EndInit();
            this.menuPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private studentUserControl studentUserControl1;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.PictureBox headerImage;
        private System.Windows.Forms.Button studentButton;
        private System.Windows.Forms.Button cloButton;
        private System.Windows.Forms.Button assessmentButton;
        private System.Windows.Forms.Button AssessmentComponentBtn;
        private System.Windows.Forms.Button rubricButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Panel menuPanel;
        private studentUserControl studentUserControl2;
        private cloUserControl cloUserControl1;
        private assessmentUserControl assessmentUserControl1;
        private rubricsUserControl rubricsUserControl1;
        private assessmentComponenetUserControl assessmentComponenetUserControl1;
        private System.Windows.Forms.Button rubricLevelBtn;
        private rubricLevelUC rubricLevelUC1;
        private System.Windows.Forms.Button evaluationBtn;
        private evaluationControlForm evaluationControlForm1;
        private System.Windows.Forms.Button attendanceBtn;
        private AttendanceReportUserControl attendanceReportUserControl1;
    }
}