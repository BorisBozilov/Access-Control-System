using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Globalization;
using UsbRelayNet.RelayLib;
using System.Threading.Tasks;

namespace WorkAttendanceEvidence
{
    //Design by Pongsakorn Poosankam
    public partial class Main : Form
    {
        private readonly RelaysEnumerator _relaysEnumerator = new RelaysEnumerator();
        private Button[] _buttonsClose;
        private Button[] _buttonsOpen;
        private Label[] _labelsName;
        private Label[] _labelsStatus;
        private Relay _selectedRelay;
        private WebCam _webCam;

        // create sql connection object.
        SqlConnection myConnection = new SqlConnection();         

        public Main()
        {
            InitializeComponent();
            this.CreateUI();
            this.UpdateControls();

            this.btnReport.Enabled = false;
            this.pinTextBox.Tag = false;
        }
        
        private void Main_Load(object sender, EventArgs e)
        {
            // Specify connection string
            myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            _webCam = new WebCam();
            _webCam.InitializeWebCam(ref imgCapture);
            _webCam.Start();

            this.ActiveControl = pinTextBox;


            this.buttonFindDevice.PerformClick();
            this.buttonConnect.PerformClick();
        }

        private void CreateUI()
        {
            this._labelsName = Enumerable.Range(0, 2)
                .Select(i => new Label
                {
                    Anchor = AnchorStyles.None,
                    Text = string.Format(@"Channel {0}", i + 1),
                    AutoSize = true
                })
                .ToArray();

            this._labelsStatus = Enumerable.Range(0, 2)
                .Select(i => new Label
                {
                    Dock = DockStyle.Fill,
                    Margin = new Padding(5)
                })
                .ToArray();

            this._buttonsOpen = Enumerable.Range(0, 2)
                .Select(i => new Button
                {
                    Anchor = AnchorStyles.Left | AnchorStyles.Right,
                    Text = @"Open",
                    Tag = i
                })
                .ToArray();

            this._buttonsClose = Enumerable.Range(0, 2)
                .Select(i => new Button
                {
                    Anchor = AnchorStyles.Left | AnchorStyles.Right,
                    Text = @"Close",
                    Tag = i
                })
                .ToArray();

            this._buttonsOpen.ForEach(button => { button.Click += this.OnChannelOpen; });
            this._buttonsClose.ForEach(button => { button.Click += this.OnChannelClose; });

            for (var i = 0; i < 2; i++)
            {
                this.tableLayoutPanel1.Controls.Add(this._labelsName[i], 0, 2 + i);
                this.tableLayoutPanel1.Controls.Add(this._buttonsOpen[i], 1, 2 + i);
                this.tableLayoutPanel1.Controls.Add(this._labelsStatus[i], 2, 2 + i);
                this.tableLayoutPanel1.Controls.Add(this._buttonsClose[i], 3, 2 + i);
            }
        }

        private void UpdateControls()
        {
            this.SuspendDrawing();

            var relaysFound = this.comboBoxPath.Items.Count > 0;
            var connected = this._selectedRelay != null && this._selectedRelay.IsOpened;

            this._labelsName.ForEach(label => label.Enabled = relaysFound);
            this._labelsStatus.ForEach(label => label.Enabled = relaysFound);
            this._buttonsOpen.ForEach(button => button.Enabled = relaysFound);
            this._buttonsClose.ForEach(button => button.Enabled = relaysFound);
            this.buttonConnect.Enabled = relaysFound;
            this.buttonDisconnect.Enabled = false;
            this.buttonOpenAll.Enabled = relaysFound;
            this.buttonCloseAll.Enabled = relaysFound;
            this.textBoxId.Enabled = false;
            this.textBoxId.Text = string.Empty;
            this.buttonSetId.Enabled = false;

            if (relaysFound)
            {
                this.buttonFindDevice.Enabled = !connected;
                this.comboBoxPath.Enabled = !connected;

                if (connected)
                {
                    this.buttonConnect.Enabled = false;
                    this.buttonDisconnect.Enabled = true;
                    this.textBoxId.Enabled = true;
                    this.textBoxId.Text = this._selectedRelay.ReadId();
                    this.buttonSetId.Enabled = true;
                }
                else
                {
                    this.buttonConnect.Enabled = true;
                    this.buttonDisconnect.Enabled = false;
                }

                this._labelsName.ForEach((i, label) =>
                    label.Enabled = connected && i < this._selectedRelay.ChannelsCount);
                this._labelsStatus.ForEach((i, label) =>
                    label.BackColor = connected && i < this._selectedRelay.ChannelsCount
                        ? label.BackColor
                        : Color.Transparent);
                this._buttonsOpen.ForEach((i, button) =>
                    button.Enabled = connected && i < this._selectedRelay.ChannelsCount);
                this._buttonsClose.ForEach((i, button) =>
                    button.Enabled = connected && i < this._selectedRelay.ChannelsCount);
                this.buttonOpenAll.Enabled = connected;
                this.buttonCloseAll.Enabled = connected;
            }

            this.ResumeDrawing();
        }

        private void UpdateChannelsStatus()
        {
            if (this._selectedRelay != null && this._selectedRelay.IsOpened)
            {
                var channelsStatus = this._selectedRelay.ReadChannels();

                for (var i = 0; i < 2; i++)
                {
                    if (i < this._selectedRelay.ChannelsCount)
                    {
                        if ((channelsStatus & (1 << i)) != 0)
                        {
                            this._labelsStatus[i].BackColor = Color.Green;
                        }
                        else
                        {
                            this._labelsStatus[i].BackColor = Color.Red;
                        }
                    }
                    else
                    {
                        this._labelsStatus[i].BackColor = Color.Transparent;
                    }
                }
            }
        }

        private void buttonFindDevice_Click(object sender, EventArgs e)
        {
            this.comboBoxPath.Items.Clear();
            var items = this._relaysEnumerator.CollectInfo()
                .Select(x => new RelayItem(x))
                .ToArray();
            this.comboBoxPath.Items.AddRange(items);

            if (items.Length > 0)
            {
                this.comboBoxPath.SelectedIndex = 0;
            }

            this.UpdateControls();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (this._selectedRelay == null)
            {
                if (this.comboBoxPath.Items.Count > 0)
                {
                    this._selectedRelay = this.comboBoxPath.Items
                        .OfType<RelayItem>()
                        .Select(x => new Relay(x.RelayInfo))
                        .FirstOrDefault();
                }
            }

            if (!this._selectedRelay.IsOpened)
            {
                this._selectedRelay.Open();
            }

            this.UpdateControls();
            this.UpdateChannelsStatus();
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            if (this._selectedRelay.IsOpened)
            {
                this._selectedRelay.Close();
            }

            this.UpdateControls();
            this.UpdateChannelsStatus();
        }

        private void OnChannelOpen(object sender, EventArgs e)
        {
            if (this._selectedRelay != null)
            {
                var button = sender as Button;
                var channel = Convert.ToInt32(button != null ? button.Tag : -1);

                if (channel >= 0)
                {
                    this._selectedRelay.WriteChannel(channel + 1, true);
                    this.UpdateChannelsStatus();
                }
            }
        }

        private void OnChannelClose(object sender, EventArgs e)
        {
            if (this._selectedRelay != null)
            {
                var button = sender as Button;
                var channel = Convert.ToInt32(button != null ? button.Tag : -1);

                if (channel >= 0)
                {
                    this._selectedRelay.WriteChannel(channel + 1, false);
                    this.UpdateChannelsStatus();
                }
            }
        }

        private void buttonOpenAll_Click(object sender, EventArgs e)
        {
            this._selectedRelay.WriteChannels(true);
            this.UpdateChannelsStatus();
        }

        private void buttonCloseAll_Click(object sender, EventArgs e)
        {
            this._selectedRelay.WriteChannels(false);
            this.UpdateChannelsStatus();
        }

        private void buttonSetId_Click(object sender, EventArgs e)
        {
            if (this._selectedRelay != null && this._selectedRelay.IsOpened)
            {
                this._selectedRelay.WriteId(this.textBoxId.Text);
            }

            this.UpdateControls();
        }

        private void ValidateReport()
        {
            this.btnReport.Enabled = (bool)this.pinTextBox.Tag;
        }

        private void textBoxNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            tb.Text = tb.Text.TrimEnd();
            tb.SelectionStart = tb.Text.Length;
            tb.SelectionLength = 0;

            if (((tb.Text.Length == 0) && (e.KeyChar < 48)) ||
                ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

        private void textBoxNumber_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text.Length > 0)
            {
                if (tb.Text.Length == 10)
                {
                    tb.Tag = true;
                    tb.BackColor = SystemColors.Window;
                }
                else
                {
                    tb.Tag = false;
                    tb.BackColor = Color.Red;
                }
                ValidateReport();
            }
        }

        private void textBoxNumber_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text.Length == 0)
            {
                tb.Tag = false;
                tb.BackColor = Color.Red;
            }
            ValidateReport();
        }

        private async void btnReport_ClickAsync(object sender, EventArgs e)
        {
            int employeeId;
            int firmId;
            int attendanceId;

            _webCam.Stop();
            _webCam.InitializeWebCam(ref imgCapture);
            _webCam.Start();

            imgCapture.Image = imgCapture.Image;

            Dictionary<int, List<string>> messages = new Dictionary<int, List<string>>();

            messages.Add(0, new List<string> { "You have already reported arrival! You can only report departure.", "You have reported arrival sussesfully!", "You have reported departure sussesfully!", "You haven't reported arrival! You can't report departure. Report arrival first.", "PIN does not exist! Enter the correct PIN!" });

            messages.Add(1, new List<string> { "Вече сте заявили пристигане! Можете само да отчетете заминаване.", "Заявихте успешно пристигането си!", "Заявихте успешно заминаването си!", "Не сте заявили пристигане! Не можете да заявите заминаване. Заявете първо пристигане.", "ЕГН-то не съществува! Въведете правилното ЕГН!" });

            messages.Add(2, new List<string> { "Већ сте пријавили долазак! Можете само пријавити одлазак.", "Успешно сте пријавили долазак!", "Успешно сте пријавили одлазак!", "Нисте пријавили долазак! Не можете пријавити одлазак. Прво пријавите долазак.", "ЈМБГ не постоји! Унесите тачан ЈМБГ!" });

            var value = messages[Program.LanguageKey];

            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandText = "Select Employee_ID, Firm_ID from Employees where PIN = " + pinTextBox.Text.ToString();
            myCommand.CommandType = CommandType.Text;
            myCommand.Connection = myConnection;

            SqlDataReader myReader = null;

            myConnection.Open();

            myReader = myCommand.ExecuteReader();

            if (myReader.Read())
            {
                employeeId = int.Parse(myReader["Employee_ID"].ToString());               
                //pinLabel.Text = employeeId.ToString(); 
                          
                firmId = int.Parse(myReader["Firm_ID"].ToString());
                //pinLabel.Text = firmId.ToString(); 

                myConnection.Close();

                if (arrivalRadioButton.Checked == true)
                {
                    //MessageBox.Show("You have selected arrival!");                   

                    this.buttonOpenAll.PerformClick();

                    await Task.Delay(5000);

                    this.buttonCloseAll.PerformClick();

                    DateTime today = DateTime.Today;
                    //Select * from [Time_Evidence_20_20].[dbo].[Work_Attendance] where Employee_ID = 1 and Date_Att = '2020-01-17' and Departure_Time IS NULL
                    myCommand.CommandText = "Select * from Work_Attendance where (Employee_ID = " + employeeId.ToString() + " and Date_Att = '" + today.ToString("yyyy-MM-dd") + "' and Departure_Time IS NULL)";

                    myConnection.Open();

                    myReader = myCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        myConnection.Close();
                        MessageBox.Show(value[0]);                                                                     
                    }
                    else
                    {
                        myConnection.Close();
                        MessageBox.Show(value[1]);

                        SqlCommand command = new SqlCommand();
                        command.CommandText = "INSERT INTO Work_Attendance (Date_Att, Arrival_Time, Arrival_Image, Firm_ID, Employee_ID) VALUES (@Date_Att, @Arrival_Time, @Arrival_Image, @Firm_ID, @Employee_ID)";
                        command.CommandType = CommandType.Text;
                        command.Connection = myConnection;

                        // create your parameters
                        command.Parameters.Add("@Date_Att", System.Data.SqlDbType.Date);
                        command.Parameters.Add("@Arrival_Time", System.Data.SqlDbType.Time);
                        command.Parameters.Add("@Firm_ID", System.Data.SqlDbType.Int);
                        command.Parameters.Add("@Employee_ID", System.Data.SqlDbType.Int);

                        TimeSpan arrTime = DateTime.Now.TimeOfDay;

                        // set values to parameters from textboxes                     
                        command.Parameters["@Date_Att"].Value = today.ToString("yyyy-MM-dd");
                        command.Parameters["@Arrival_Time"].Value = arrTime;
                        command.Parameters["@Firm_ID"].Value = firmId;
                        command.Parameters["@Employee_ID"].Value = employeeId;

                        //if (employeePictureBox.Image != null)
                        //{
                        //using MemoryStream:  
                        MemoryStream ms = new MemoryStream();
                        imgCapture.Image.Save(ms, ImageFormat.Jpeg);
                        byte[] photo_aray = new byte[ms.Length];
                        ms.Position = 0;
                        ms.Read(photo_aray, 0, photo_aray.Length);
                        command.Parameters.AddWithValue("@Arrival_Image", photo_aray);
                        //}

                        // open sql connection
                        myConnection.Open();

                        // execute the query and return number of rows affected, should be one
                        int RowsAffected = command.ExecuteNonQuery();

                        // close connection when done
                        myConnection.Close();
                    }                    
                }
                else
                {
                    //MessageBox.Show("You have selected departure!");

                    this.buttonOpenAll.PerformClick();

                    await Task.Delay(5000);

                    this.buttonCloseAll.PerformClick();

                    DateTime today = DateTime.Today;
                    myCommand.CommandText = "Select * from Work_Attendance where (Employee_ID = " + employeeId.ToString() + " and Date_Att = '" + today.ToString("yyyy-MM-dd") + "' and Arrival_Time IS NOT NULL and Departure_Time IS NULL)";                   

                    myConnection.Open();

                    myReader = myCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        attendanceId = myReader.GetInt32(0);

                        myConnection.Close();
                        MessageBox.Show(value[2]);

                        SqlCommand command = new SqlCommand();
                        command.CommandText = "UPDATE Work_Attendance SET Departure_Time = @Departure_Time, Departure_Image = @Departure_Image WHERE (Attendance_ID = " + attendanceId.ToString() + ")";                       
                        command.CommandType = CommandType.Text;
                        command.Connection = myConnection;

                        // create your parameters
                        command.Parameters.Add("@Departure_Time", System.Data.SqlDbType.Time);                                             

                        TimeSpan deprTime = DateTime.Now.TimeOfDay;

                        // set values to parameters from textboxes                     
                        command.Parameters["@Departure_Time"].Value = deprTime;                                            

                        //if (employeePictureBox.Image != null)
                        //{
                        //using MemoryStream:  
                        MemoryStream ms = new MemoryStream();
                        imgCapture.Image.Save(ms, ImageFormat.Jpeg);
                        byte[] photo_aray = new byte[ms.Length];
                        ms.Position = 0;
                        ms.Read(photo_aray, 0, photo_aray.Length);
                        command.Parameters.AddWithValue("@Departure_Image", photo_aray);
                        //}

                        // open sql connection
                        myConnection.Open();

                        // execute the query and return number of rows affected, should be one
                        int RowsAffected = command.ExecuteNonQuery();

                        // close connection when done
                        myConnection.Close();

                        //myCommand.CommandText = "Select * from Work_Attendance where (Employee_ID = " + employeeId.ToString() + " and Date_Att = '" + today.ToString("yyyy-MM-dd") + "' and Departure_Time IS NOT NULL)";

                        myCommand.CommandText = "Select * from Work_Attendance where (Attendance_ID = " + attendanceId.ToString() + ")";
                
                        myConnection.Open();
                        myReader = myCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            TimeSpan arrivalTime = (TimeSpan)myReader["Arrival_Time"];
                            TimeSpan departureTime = (TimeSpan)myReader["Departure_Time"];

                            //DateTime arrivalTime = (DateTime)myReader["Arrival_Time"];
                            //DateTime arrivalTime = DateTime.ParseExact(strArrivalTime, "HH:mm:ss.fff", CultureInfo.InvariantCulture);

                            //DateTime departureTime = (DateTime)myReader["Departure_Time"];
                            //DateTime departureTime = DateTime.ParseExact(strDepartureTime, "HH:mm:ss.fff", CultureInfo.InvariantCulture);
                            
                            myConnection.Close();

                            command.CommandText = "UPDATE Work_Attendance SET Work_Time = @Work_Time WHERE (Attendance_ID = " + attendanceId.ToString() + ")";

                            command.Parameters.Add("@Work_Time", System.Data.SqlDbType.Time);

                            command.Parameters["@Work_Time"].Value = departureTime - arrivalTime;

                            // open sql connection
                            myConnection.Open();

                            // execute the query and return number of rows affected, should be one
                            RowsAffected = command.ExecuteNonQuery();

                            // close connection when done
                            myConnection.Close();
                        }                                             
                    }
                    else
                    {
                        myConnection.Close();
                        MessageBox.Show(value[3]);
                    }                 
                }
            }
            else 
            {
                MessageBox.Show(value[4]);
                myConnection.Close();
            }      
        }

        private void btnEnglish_Click(object sender, EventArgs e)
        {
            Program.LanguageKey = 0;
            ChangeLanguage(Program.LanguageKey);
        }

        private void btnBulgarian_Click(object sender, EventArgs e)
        {
            Program.LanguageKey = 1;
            ChangeLanguage(Program.LanguageKey);
        }

        private void btnSerbian_Click(object sender, EventArgs e)
        {
            Program.LanguageKey = 2;
            ChangeLanguage(Program.LanguageKey);
        }

        private void ChangeLanguage(int languageKey)
        {
            Dictionary<string, List<string>> dictControlTexts = new Dictionary<string, List<string>>
            {
                { this.Name.ToString(), new List<string> { "Work Attendance Evidence", "Евиденция за присъствие на работа", "Евиденција доласка на посао" } },
                { this.reportGroupBox.Name.ToString(), new List<string> { "Report", "Докладвай", "Пријави" } },
                { this.arrivalRadioButton.Name.ToString(), new List<string> { "Arrival", "Пристигане", "Долазак" } },
                { this.departureRadioButton.Name.ToString(), new List<string> { "Departure", "Тръгване", "Одлазак" } },
                { this.pinLabel.Name.ToString(), new List<string> { "PIN", "ЕГН", "ЈМБГ" } },
                { this.btnReport.Name.ToString(), new List<string> { "Report", "Докладвай", "Пријави" } }
            };

            foreach (var controlText in dictControlTexts)
            {
                if (controlText.Key == this.Name.ToString())
                {
                    this.Text = controlText.Value[languageKey];
                    continue;
                }             

                foreach (Control control in Controls)
                {
                    if (controlText.Key == control.Name.ToString())
                    {
                        control.Text = controlText.Value[languageKey];
                    }
                } 
            }

            var arrival = dictControlTexts[this.arrivalRadioButton.Name.ToString()];
            arrivalRadioButton.Text = arrival[languageKey];

            var departure = dictControlTexts[this.departureRadioButton.Name.ToString()];
            departureRadioButton.Text = departure[languageKey];
        }

        private void imgCapture_Click(object sender, EventArgs e)
        {
            _webCam.Stop();
            _webCam.InitializeWebCam(ref imgCapture);
            _webCam.Start();
        }
    }
}
