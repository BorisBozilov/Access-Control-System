namespace WorkAttendanceEvidence
{
    //Design by Pongsakorn Poosankam
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
            this.imgCapture = new System.Windows.Forms.PictureBox();
            this.btnReport = new System.Windows.Forms.Button();
            this.reportGroupBox = new System.Windows.Forms.GroupBox();
            this.departureRadioButton = new System.Windows.Forms.RadioButton();
            this.arrivalRadioButton = new System.Windows.Forms.RadioButton();
            this.pinLabel = new System.Windows.Forms.Label();
            this.pinTextBox = new System.Windows.Forms.TextBox();
            this.btnSerbian = new System.Windows.Forms.Button();
            this.btnBulgarian = new System.Windows.Forms.Button();
            this.btnEnglish = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonFindDevice = new System.Windows.Forms.Button();
            this.comboBoxPath = new System.Windows.Forms.ComboBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonOpenAll = new System.Windows.Forms.Button();
            this.buttonCloseAll = new System.Windows.Forms.Button();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.buttonSetId = new System.Windows.Forms.Button();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture)).BeginInit();
            this.reportGroupBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgCapture
            // 
            this.imgCapture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgCapture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgCapture.Location = new System.Drawing.Point(21, 21);
            this.imgCapture.Name = "imgCapture";
            this.imgCapture.Size = new System.Drawing.Size(286, 186);
            this.imgCapture.TabIndex = 1;
            this.imgCapture.TabStop = false;
            this.imgCapture.Click += new System.EventHandler(this.imgCapture_Click);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(342, 176);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(183, 31);
            this.btnReport.TabIndex = 5;
            this.btnReport.Text = "Open dor";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_ClickAsync);
            // 
            // reportGroupBox
            // 
            this.reportGroupBox.Controls.Add(this.departureRadioButton);
            this.reportGroupBox.Controls.Add(this.arrivalRadioButton);
            this.reportGroupBox.Location = new System.Drawing.Point(342, 73);
            this.reportGroupBox.Name = "reportGroupBox";
            this.reportGroupBox.Size = new System.Drawing.Size(111, 69);
            this.reportGroupBox.TabIndex = 21;
            this.reportGroupBox.TabStop = false;
            this.reportGroupBox.Text = "Report :";
            // 
            // departureRadioButton
            // 
            this.departureRadioButton.AutoSize = true;
            this.departureRadioButton.Location = new System.Drawing.Point(18, 46);
            this.departureRadioButton.Name = "departureRadioButton";
            this.departureRadioButton.Size = new System.Drawing.Size(54, 17);
            this.departureRadioButton.TabIndex = 1;
            this.departureRadioButton.TabStop = true;
            this.departureRadioButton.Text = "2. Exit";
            this.departureRadioButton.UseVisualStyleBackColor = true;
            // 
            // arrivalRadioButton
            // 
            this.arrivalRadioButton.AutoSize = true;
            this.arrivalRadioButton.Location = new System.Drawing.Point(18, 19);
            this.arrivalRadioButton.Name = "arrivalRadioButton";
            this.arrivalRadioButton.Size = new System.Drawing.Size(80, 17);
            this.arrivalRadioButton.TabIndex = 0;
            this.arrivalRadioButton.TabStop = true;
            this.arrivalRadioButton.Text = "1. Entrance";
            this.arrivalRadioButton.UseVisualStyleBackColor = true;
            // 
            // pinLabel
            // 
            this.pinLabel.AutoSize = true;
            this.pinLabel.Location = new System.Drawing.Point(339, 28);
            this.pinLabel.Name = "pinLabel";
            this.pinLabel.Size = new System.Drawing.Size(28, 13);
            this.pinLabel.TabIndex = 25;
            this.pinLabel.Text = "PIN:";
            // 
            // pinTextBox
            // 
            this.pinTextBox.Location = new System.Drawing.Point(373, 21);
            this.pinTextBox.MaxLength = 12;
            this.pinTextBox.Name = "pinTextBox";
            this.pinTextBox.Size = new System.Drawing.Size(152, 20);
            this.pinTextBox.TabIndex = 24;
            this.pinTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNumber_KeyPress);
            this.pinTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxNumber_KeyUp);
            this.pinTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxNumber_Validating);
            // 
            // btnSerbian
            // 
            this.btnSerbian.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSerbian.BackgroundImage")));
            this.btnSerbian.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSerbian.Location = new System.Drawing.Point(488, 126);
            this.btnSerbian.Name = "btnSerbian";
            this.btnSerbian.Size = new System.Drawing.Size(37, 25);
            this.btnSerbian.TabIndex = 28;
            this.btnSerbian.UseVisualStyleBackColor = true;
            this.btnSerbian.Click += new System.EventHandler(this.btnSerbian_Click);
            // 
            // btnBulgarian
            // 
            this.btnBulgarian.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBulgarian.BackgroundImage")));
            this.btnBulgarian.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBulgarian.Location = new System.Drawing.Point(488, 95);
            this.btnBulgarian.Name = "btnBulgarian";
            this.btnBulgarian.Size = new System.Drawing.Size(37, 25);
            this.btnBulgarian.TabIndex = 27;
            this.btnBulgarian.UseVisualStyleBackColor = true;
            this.btnBulgarian.Click += new System.EventHandler(this.btnBulgarian_Click);
            // 
            // btnEnglish
            // 
            this.btnEnglish.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEnglish.BackgroundImage")));
            this.btnEnglish.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEnglish.Location = new System.Drawing.Point(488, 64);
            this.btnEnglish.Name = "btnEnglish";
            this.btnEnglish.Size = new System.Drawing.Size(37, 25);
            this.btnEnglish.TabIndex = 26;
            this.btnEnglish.UseVisualStyleBackColor = true;
            this.btnEnglish.Click += new System.EventHandler(this.btnEnglish_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.buttonFindDevice, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxPath, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonConnect, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonOpenAll, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonCloseAll, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBoxId, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonSetId, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonDisconnect, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(18, 230);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(507, 141);
            this.tableLayoutPanel1.TabIndex = 29;
            // 
            // buttonFindDevice
            // 
            this.buttonFindDevice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFindDevice.Location = new System.Drawing.Point(3, 3);
            this.buttonFindDevice.Name = "buttonFindDevice";
            this.buttonFindDevice.Size = new System.Drawing.Size(120, 23);
            this.buttonFindDevice.TabIndex = 0;
            this.buttonFindDevice.Text = "Find Device";
            this.buttonFindDevice.UseVisualStyleBackColor = true;
            this.buttonFindDevice.Click += new System.EventHandler(this.buttonFindDevice_Click);
            // 
            // comboBoxPath
            // 
            this.comboBoxPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.comboBoxPath, 3);
            this.comboBoxPath.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPath.FormattingEnabled = true;
            this.comboBoxPath.Location = new System.Drawing.Point(129, 4);
            this.comboBoxPath.Name = "comboBoxPath";
            this.comboBoxPath.Size = new System.Drawing.Size(375, 21);
            this.comboBoxPath.TabIndex = 1;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConnect.Location = new System.Drawing.Point(3, 32);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(120, 23);
            this.buttonConnect.TabIndex = 2;
            this.buttonConnect.Text = "Open Device";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonOpenAll
            // 
            this.buttonOpenAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.buttonOpenAll, 2);
            this.buttonOpenAll.Location = new System.Drawing.Point(3, 115);
            this.buttonOpenAll.Name = "buttonOpenAll";
            this.buttonOpenAll.Size = new System.Drawing.Size(246, 23);
            this.buttonOpenAll.TabIndex = 4;
            this.buttonOpenAll.Text = "Open All";
            this.buttonOpenAll.UseVisualStyleBackColor = true;
            this.buttonOpenAll.Click += new System.EventHandler(this.buttonOpenAll_Click);
            // 
            // buttonCloseAll
            // 
            this.buttonCloseAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.buttonCloseAll, 2);
            this.buttonCloseAll.Location = new System.Drawing.Point(255, 115);
            this.buttonCloseAll.Name = "buttonCloseAll";
            this.buttonCloseAll.Size = new System.Drawing.Size(249, 23);
            this.buttonCloseAll.TabIndex = 5;
            this.buttonCloseAll.Text = "Close All";
            this.buttonCloseAll.UseVisualStyleBackColor = true;
            this.buttonCloseAll.Click += new System.EventHandler(this.buttonCloseAll_Click);
            // 
            // textBoxId
            // 
            this.textBoxId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxId.Location = new System.Drawing.Point(255, 33);
            this.textBoxId.MaxLength = 5;
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(120, 20);
            this.textBoxId.TabIndex = 6;
            this.textBoxId.Text = "00000";
            this.textBoxId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonSetId
            // 
            this.buttonSetId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSetId.Location = new System.Drawing.Point(381, 32);
            this.buttonSetId.Name = "buttonSetId";
            this.buttonSetId.Size = new System.Drawing.Size(123, 23);
            this.buttonSetId.TabIndex = 7;
            this.buttonSetId.Text = "Rename";
            this.buttonSetId.UseVisualStyleBackColor = true;
            this.buttonSetId.Click += new System.EventHandler(this.buttonSetId_Click);
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDisconnect.Location = new System.Drawing.Point(129, 32);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(120, 23);
            this.buttonDisconnect.TabIndex = 8;
            this.buttonDisconnect.Text = "Close Device";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(545, 391);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnSerbian);
            this.Controls.Add(this.btnBulgarian);
            this.Controls.Add(this.btnEnglish);
            this.Controls.Add(this.pinLabel);
            this.Controls.Add(this.pinTextBox);
            this.Controls.Add(this.reportGroupBox);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.imgCapture);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Access Control & Attendance Evidence System - Control module";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture)).EndInit();
            this.reportGroupBox.ResumeLayout(false);
            this.reportGroupBox.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgCapture;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.GroupBox reportGroupBox;
        private System.Windows.Forms.RadioButton departureRadioButton;
        private System.Windows.Forms.RadioButton arrivalRadioButton;
        private System.Windows.Forms.Label pinLabel;
        private System.Windows.Forms.TextBox pinTextBox;
        private System.Windows.Forms.Button btnSerbian;
        private System.Windows.Forms.Button btnBulgarian;
        private System.Windows.Forms.Button btnEnglish;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonFindDevice;
        private System.Windows.Forms.ComboBox comboBoxPath;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonOpenAll;
        private System.Windows.Forms.Button buttonCloseAll;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Button buttonSetId;
        private System.Windows.Forms.Button buttonDisconnect;
    }
}

