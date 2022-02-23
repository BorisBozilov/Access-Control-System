namespace WorkTimeControlSystem
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btnEmployees = new System.Windows.Forms.Button();
            this.btnFirms = new System.Windows.Forms.Button();
            this.btnAttendance = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnEnglish = new System.Windows.Forms.Button();
            this.btnBulgarian = new System.Windows.Forms.Button();
            this.btnSerbian = new System.Windows.Forms.Button();
            this.btnMonthlyReport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEmployees
            // 
            this.btnEmployees.Location = new System.Drawing.Point(313, 339);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Size = new System.Drawing.Size(123, 29);
            this.btnEmployees.TabIndex = 5;
            this.btnEmployees.Text = "Users";
            this.btnEmployees.UseVisualStyleBackColor = true;
            this.btnEmployees.Click += new System.EventHandler(this.btnEmployees_Click);
            // 
            // btnFirms
            // 
            this.btnFirms.Location = new System.Drawing.Point(459, 339);
            this.btnFirms.Name = "btnFirms";
            this.btnFirms.Size = new System.Drawing.Size(123, 29);
            this.btnFirms.TabIndex = 4;
            this.btnFirms.Text = "Institutions";
            this.btnFirms.UseVisualStyleBackColor = true;
            this.btnFirms.Click += new System.EventHandler(this.btnFirms_Click);
            // 
            // btnAttendance
            // 
            this.btnAttendance.Location = new System.Drawing.Point(26, 339);
            this.btnAttendance.Name = "btnAttendance";
            this.btnAttendance.Size = new System.Drawing.Size(123, 29);
            this.btnAttendance.TabIndex = 3;
            this.btnAttendance.Text = "Attendance";
            this.btnAttendance.UseVisualStyleBackColor = true;
            this.btnAttendance.Click += new System.EventHandler(this.btnAttendance_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(209, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(227, 280);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // btnEnglish
            // 
            this.btnEnglish.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEnglish.BackgroundImage")));
            this.btnEnglish.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEnglish.Location = new System.Drawing.Point(540, 29);
            this.btnEnglish.Name = "btnEnglish";
            this.btnEnglish.Size = new System.Drawing.Size(42, 28);
            this.btnEnglish.TabIndex = 7;
            this.btnEnglish.UseVisualStyleBackColor = true;
            this.btnEnglish.Click += new System.EventHandler(this.btnEnglish_Click);
            // 
            // btnBulgarian
            // 
            this.btnBulgarian.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBulgarian.BackgroundImage")));
            this.btnBulgarian.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBulgarian.Location = new System.Drawing.Point(540, 63);
            this.btnBulgarian.Name = "btnBulgarian";
            this.btnBulgarian.Size = new System.Drawing.Size(42, 28);
            this.btnBulgarian.TabIndex = 8;
            this.btnBulgarian.UseVisualStyleBackColor = true;
            this.btnBulgarian.Click += new System.EventHandler(this.btnBulgarian_Click);
            // 
            // btnSerbian
            // 
            this.btnSerbian.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSerbian.BackgroundImage")));
            this.btnSerbian.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSerbian.Location = new System.Drawing.Point(540, 97);
            this.btnSerbian.Name = "btnSerbian";
            this.btnSerbian.Size = new System.Drawing.Size(42, 28);
            this.btnSerbian.TabIndex = 9;
            this.btnSerbian.UseVisualStyleBackColor = true;
            this.btnSerbian.Click += new System.EventHandler(this.btnSerbian_Click);
            // 
            // btnMonthlyReport
            // 
            this.btnMonthlyReport.Location = new System.Drawing.Point(169, 339);
            this.btnMonthlyReport.Name = "btnMonthlyReport";
            this.btnMonthlyReport.Size = new System.Drawing.Size(123, 29);
            this.btnMonthlyReport.TabIndex = 10;
            this.btnMonthlyReport.Text = "Monthly Report";
            this.btnMonthlyReport.UseVisualStyleBackColor = true;
            this.btnMonthlyReport.Click += new System.EventHandler(this.btnMonthlyReport_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(610, 389);
            this.Controls.Add(this.btnMonthlyReport);
            this.Controls.Add(this.btnSerbian);
            this.Controls.Add(this.btnBulgarian);
            this.Controls.Add(this.btnEnglish);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnEmployees);
            this.Controls.Add(this.btnFirms);
            this.Controls.Add(this.btnAttendance);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Access Control & Attendance Evidence System - Administrative module";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEmployees;
        private System.Windows.Forms.Button btnFirms;
        private System.Windows.Forms.Button btnAttendance;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnEnglish;
        private System.Windows.Forms.Button btnBulgarian;
        private System.Windows.Forms.Button btnSerbian;
        private System.Windows.Forms.Button btnMonthlyReport;
    }
}

