namespace WorkTimeControlSystem
{
    partial class MonthlyReport
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
            this.firmTextBox = new System.Windows.Forms.TextBox();
            this.firmComboBox = new System.Windows.Forms.ComboBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.employeeListBox = new System.Windows.Forms.ListBox();
            this.monthlyReportDataGridView = new System.Windows.Forms.DataGridView();
            this.btnShowReport = new System.Windows.Forms.Button();
            this.monthlyReportTextBox = new System.Windows.Forms.TextBox();
            this.employeeTextBox = new System.Windows.Forms.TextBox();
            this.monthlyReportLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.monthlyReportDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // firmTextBox
            // 
            this.firmTextBox.Location = new System.Drawing.Point(12, 12);
            this.firmTextBox.Name = "firmTextBox";
            this.firmTextBox.Size = new System.Drawing.Size(26, 20);
            this.firmTextBox.TabIndex = 0;
            // 
            // firmComboBox
            // 
            this.firmComboBox.FormattingEnabled = true;
            this.firmComboBox.Location = new System.Drawing.Point(44, 12);
            this.firmComboBox.Name = "firmComboBox";
            this.firmComboBox.Size = new System.Drawing.Size(101, 21);
            this.firmComboBox.TabIndex = 1;
            this.firmComboBox.SelectionChangeCommitted += new System.EventHandler(this.firmComboBox_SelectionChangeCommitted);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "MM  -  yyyy";
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(12, 38);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(133, 20);
            this.dateTimePicker.TabIndex = 2;
            // 
            // employeeListBox
            // 
            this.employeeListBox.FormattingEnabled = true;
            this.employeeListBox.Location = new System.Drawing.Point(12, 90);
            this.employeeListBox.Name = "employeeListBox";
            this.employeeListBox.Size = new System.Drawing.Size(133, 95);
            this.employeeListBox.TabIndex = 3;
            this.employeeListBox.SelectedIndexChanged += new System.EventHandler(this.employeeListBox_SelectedIndexChanged);
            // 
            // monthlyReportDataGridView
            // 
            this.monthlyReportDataGridView.AllowUserToAddRows = false;
            this.monthlyReportDataGridView.AllowUserToDeleteRows = false;
            this.monthlyReportDataGridView.Location = new System.Drawing.Point(160, 12);
            this.monthlyReportDataGridView.Name = "monthlyReportDataGridView";
            this.monthlyReportDataGridView.ReadOnly = true;
            this.monthlyReportDataGridView.Size = new System.Drawing.Size(247, 260);
            this.monthlyReportDataGridView.TabIndex = 0;
            // 
            // btnShowReport
            // 
            this.btnShowReport.Location = new System.Drawing.Point(12, 191);
            this.btnShowReport.Name = "btnShowReport";
            this.btnShowReport.Size = new System.Drawing.Size(133, 35);
            this.btnShowReport.TabIndex = 4;
            this.btnShowReport.Text = "Show report";
            this.btnShowReport.UseVisualStyleBackColor = true;
            this.btnShowReport.Click += new System.EventHandler(this.btnShowReport_Click);
            // 
            // monthlyReportTextBox
            // 
            this.monthlyReportTextBox.Location = new System.Drawing.Point(12, 253);
            this.monthlyReportTextBox.Name = "monthlyReportTextBox";
            this.monthlyReportTextBox.Size = new System.Drawing.Size(133, 20);
            this.monthlyReportTextBox.TabIndex = 5;
            // 
            // employeeTextBox
            // 
            this.employeeTextBox.Location = new System.Drawing.Point(12, 64);
            this.employeeTextBox.Name = "employeeTextBox";
            this.employeeTextBox.Size = new System.Drawing.Size(133, 20);
            this.employeeTextBox.TabIndex = 6;
            // 
            // monthlyReportLabel
            // 
            this.monthlyReportLabel.AutoSize = true;
            this.monthlyReportLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.monthlyReportLabel.Location = new System.Drawing.Point(12, 237);
            this.monthlyReportLabel.Name = "monthlyReportLabel";
            this.monthlyReportLabel.Size = new System.Drawing.Size(102, 13);
            this.monthlyReportLabel.TabIndex = 7;
            this.monthlyReportLabel.Text = "Тotal monthly hours:";
            // 
            // MonthlyReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(419, 283);
            this.Controls.Add(this.monthlyReportLabel);
            this.Controls.Add(this.employeeTextBox);
            this.Controls.Add(this.monthlyReportTextBox);
            this.Controls.Add(this.btnShowReport);
            this.Controls.Add(this.monthlyReportDataGridView);
            this.Controls.Add(this.employeeListBox);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.firmComboBox);
            this.Controls.Add(this.firmTextBox);
            this.Name = "MonthlyReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monthly Report";
            this.Load += new System.EventHandler(this.MonthlyReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.monthlyReportDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox firmTextBox;
        private System.Windows.Forms.ComboBox firmComboBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.DataGridView monthlyReportDataGridView;
        private System.Windows.Forms.Button btnShowReport;
        private System.Windows.Forms.TextBox monthlyReportTextBox;
        private System.Windows.Forms.ListBox employeeListBox;
        private System.Windows.Forms.TextBox employeeTextBox;
        private System.Windows.Forms.Label monthlyReportLabel;
    }
}