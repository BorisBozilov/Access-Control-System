namespace WorkTimeControlSystem
{
    partial class Attendance
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
            this.firmComboBox = new System.Windows.Forms.ComboBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.attendanceDataGridView = new System.Windows.Forms.DataGridView();
            this.arrivalEmployeePictureBox = new System.Windows.Forms.PictureBox();
            this.btnShowAttendance = new System.Windows.Forms.Button();
            this.departureEmployeePictureBox = new System.Windows.Forms.PictureBox();
            this.firmTextBox = new System.Windows.Forms.TextBox();
            this.arrivalLabel = new System.Windows.Forms.Label();
            this.departureLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.attendanceDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrivalEmployeePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.departureEmployeePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // firmComboBox
            // 
            this.firmComboBox.FormattingEnabled = true;
            this.firmComboBox.Location = new System.Drawing.Point(55, 16);
            this.firmComboBox.Name = "firmComboBox";
            this.firmComboBox.Size = new System.Drawing.Size(105, 21);
            this.firmComboBox.TabIndex = 4;
            this.firmComboBox.SelectionChangeCommitted += new System.EventHandler(this.firmComboBox_SelectionChangeCommitted);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "dd. MM. yyyy";
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(175, 17);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(100, 20);
            this.dateTimePicker.TabIndex = 1;
            // 
            // attendanceDataGridView
            // 
            this.attendanceDataGridView.AllowUserToAddRows = false;
            this.attendanceDataGridView.AllowUserToDeleteRows = false;
            this.attendanceDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.attendanceDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.attendanceDataGridView.Location = new System.Drawing.Point(296, 16);
            this.attendanceDataGridView.Name = "attendanceDataGridView";
            this.attendanceDataGridView.ReadOnly = true;
            this.attendanceDataGridView.RowTemplate.Height = 20;
            this.attendanceDataGridView.Size = new System.Drawing.Size(702, 284);
            this.attendanceDataGridView.TabIndex = 2;
            this.attendanceDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.attendanceDataGridView_CellContentClick);
            // 
            // arrivalEmployeePictureBox
            // 
            this.arrivalEmployeePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.arrivalEmployeePictureBox.Location = new System.Drawing.Point(17, 108);
            this.arrivalEmployeePictureBox.Name = "arrivalEmployeePictureBox";
            this.arrivalEmployeePictureBox.Size = new System.Drawing.Size(119, 148);
            this.arrivalEmployeePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.arrivalEmployeePictureBox.TabIndex = 3;
            this.arrivalEmployeePictureBox.TabStop = false;
            // 
            // btnShowAttendance
            // 
            this.btnShowAttendance.Location = new System.Drawing.Point(39, 52);
            this.btnShowAttendance.Name = "btnShowAttendance";
            this.btnShowAttendance.Size = new System.Drawing.Size(213, 40);
            this.btnShowAttendance.TabIndex = 0;
            this.btnShowAttendance.Text = "Show Attendance";
            this.btnShowAttendance.UseVisualStyleBackColor = true;
            this.btnShowAttendance.Click += new System.EventHandler(this.btnShowAttendance_Click);
            // 
            // departureEmployeePictureBox
            // 
            this.departureEmployeePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.departureEmployeePictureBox.Location = new System.Drawing.Point(156, 108);
            this.departureEmployeePictureBox.Name = "departureEmployeePictureBox";
            this.departureEmployeePictureBox.Size = new System.Drawing.Size(119, 148);
            this.departureEmployeePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.departureEmployeePictureBox.TabIndex = 5;
            this.departureEmployeePictureBox.TabStop = false;
            // 
            // firmTextBox
            // 
            this.firmTextBox.Location = new System.Drawing.Point(17, 17);
            this.firmTextBox.Name = "firmTextBox";
            this.firmTextBox.Size = new System.Drawing.Size(32, 20);
            this.firmTextBox.TabIndex = 6;
            // 
            // arrivalLabel
            // 
            this.arrivalLabel.AutoSize = true;
            this.arrivalLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.arrivalLabel.Location = new System.Drawing.Point(14, 261);
            this.arrivalLabel.Name = "arrivalLabel";
            this.arrivalLabel.Size = new System.Drawing.Size(68, 13);
            this.arrivalLabel.TabIndex = 7;
            this.arrivalLabel.Text = "Arrival Image";
            // 
            // departureLabel
            // 
            this.departureLabel.AutoSize = true;
            this.departureLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.departureLabel.Location = new System.Drawing.Point(153, 261);
            this.departureLabel.Name = "departureLabel";
            this.departureLabel.Size = new System.Drawing.Size(86, 13);
            this.departureLabel.TabIndex = 8;
            this.departureLabel.Text = "Departure Image";
            // 
            // Attendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(1015, 316);
            this.Controls.Add(this.departureLabel);
            this.Controls.Add(this.arrivalLabel);
            this.Controls.Add(this.firmTextBox);
            this.Controls.Add(this.departureEmployeePictureBox);
            this.Controls.Add(this.btnShowAttendance);
            this.Controls.Add(this.arrivalEmployeePictureBox);
            this.Controls.Add(this.attendanceDataGridView);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.firmComboBox);
            this.Name = "Attendance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Attendance";
            this.Load += new System.EventHandler(this.Attendance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.attendanceDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrivalEmployeePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.departureEmployeePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox firmComboBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.DataGridView attendanceDataGridView;
        private System.Windows.Forms.PictureBox arrivalEmployeePictureBox;
        private System.Windows.Forms.Button btnShowAttendance;
        private System.Windows.Forms.PictureBox departureEmployeePictureBox;
        private System.Windows.Forms.TextBox firmTextBox;
        private System.Windows.Forms.Label arrivalLabel;
        private System.Windows.Forms.Label departureLabel;
    }
}