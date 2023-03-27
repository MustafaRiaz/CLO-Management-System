namespace FinalProject
{
    partial class ViewAttendance
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
            this.attendanceDataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.attendanceDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // attendanceDataGrid
            // 
            this.attendanceDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.attendanceDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.attendanceDataGrid.Location = new System.Drawing.Point(0, 0);
            this.attendanceDataGrid.Name = "attendanceDataGrid";
            this.attendanceDataGrid.RowHeadersWidth = 51;
            this.attendanceDataGrid.RowTemplate.Height = 24;
            this.attendanceDataGrid.Size = new System.Drawing.Size(800, 450);
            this.attendanceDataGrid.TabIndex = 0;
            this.attendanceDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.attendanceDataGrid_CellContentClick);
            // 
            // ViewAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.attendanceDataGrid);
            this.Name = "ViewAttendance";
            this.Text = "ViewAttendance";
            ((System.ComponentModel.ISupportInitialize)(this.attendanceDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView attendanceDataGrid;
    }
}