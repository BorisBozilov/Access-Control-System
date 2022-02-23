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

namespace WorkTimeControlSystem
{
    public partial class Attendance : Form
    {
        // create sql connection object.
        SqlConnection myConnection = new SqlConnection();     

        public Attendance(int languageKey)
        {
            InitializeComponent();
            ChangeLanguage(languageKey);
        }

        private void Attendance_Load(object sender, EventArgs e)
        {
            // Specify connection string
            myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            myConnection.Open();
            SqlCommand myCommand = new SqlCommand("SELECT Firm_ID, Name from Firms", myConnection);
            SqlDataReader reader;

            reader = myCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Firm_ID", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Load(reader);

            firmComboBox.ValueMember = "Firm_ID";
            firmComboBox.DisplayMember = "Name";
            firmComboBox.DataSource = dt;

            myConnection.Close();    

            firmTextBox.Text = firmComboBox.SelectedValue.ToString();                               
        }

        private void firmComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            firmTextBox.Text = firmComboBox.SelectedValue.ToString();          
            btnShowAttendance.Focus();
        }   

        private void btnShowAttendance_Click(object sender, EventArgs e)
        {
            Dictionary<int, string> selectTableLanguage = new Dictionary<int,string>();

            selectTableLanguage.Add(0, "Select Name, Surname, Last_Name as \"Last name\", Position, Arrival_Time as \"Arrival time\", Departure_Time as \"Departure time\", Work_Time as \"Work time\", Arrival_Image as \"Arrival image\", Departure_Image as \"Departure image\"");

            selectTableLanguage.Add(1, "Select Name as \"Име\", Surname as \"Презиме\", Last_Name as \"Фамилия\", Position as \"Длъжност\", Arrival_Time as \"Час на пристигане\", Departure_Time as \"Час на заминаване\", Work_Time as \"Работно време\", Arrival_Image as \"Изображение на пристигане\", Departure_Image as \"Изображение на заминаване\"");

            selectTableLanguage.Add(2, "Select Name as \"Име\", Surname as \"Средње име\", Last_Name as \"Презиме\", Position as \"Положај\", Arrival_Time as \"Време доласка\", Departure_Time as \"Време одласка\", Work_Time as \"Радно време\", Arrival_Image as \"Слика доласка\", Departure_Image as \"Слика одласка\"");

            myConnection.Open();

            //.ToString("yyyy-MM-dd")
            SqlDataAdapter myAdapter = new SqlDataAdapter(selectTableLanguage[Program.LanguageKey] + " from Employees inner join Work_Attendance on Employees.Employee_ID = Work_Attendance.Employee_ID where (Work_Attendance.Firm_ID = " + firmTextBox.Text.ToString() + " and Work_Attendance.Date_Att = '" + dateTimePicker.Value.Date + "')", myConnection);                      
            DataTable dtAttendance = new DataTable();

            myAdapter.Fill(dtAttendance);
            attendanceDataGridView.DataSource = dtAttendance;

            attendanceDataGridView.Columns[7].Visible = false;
            attendanceDataGridView.Columns[8].Visible = false;

            myConnection.Close();

            if (attendanceDataGridView.Rows.Count != 0)
            {
                DataGridViewRow row = this.attendanceDataGridView.Rows[0];

                ShowImage(row);
            }          
        }

        private void attendanceDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.attendanceDataGridView.Rows[e.RowIndex];

                ShowImage(row);
            }
        }

        private void ShowImage(DataGridViewRow row) 
        {
            Dictionary<int, List<string>> selectImageLanguage = new Dictionary<int, List<string>>
            {
                { 0, new List<string> { "Arrival Image", "Departure Image" } },
                { 1, new List<string> { "Изображение на пристигане", "Изображение на заминаване" } },
                { 2, new List<string> { "Слика доласка", "Слика одласка" } }
            };

            var value = selectImageLanguage[Program.LanguageKey];

            byte[] photo_aray_one = (byte[])row.Cells[value[0]].Value;
            MemoryStream ms1 = new MemoryStream(photo_aray_one);
            arrivalEmployeePictureBox.Image = Image.FromStream(ms1);

            byte[] photo_aray_two = (byte[])row.Cells[value[1]].Value;
            MemoryStream ms2 = new MemoryStream(photo_aray_two);
            departureEmployeePictureBox.Image = Image.FromStream(ms2);
        }

        private void ChangeLanguage(int languageKey)
        {
            Dictionary<string, List<string>> dictControlTexts = new Dictionary<string, List<string>>
            {
                { this.Name.ToString(), new List<string> { "Attendance", "Посещаемост", "Похађање" } },
                { this.btnShowAttendance.Name.ToString(), new List<string> { "Show Attendance", "Покажи посещението", "Прикажи посећеност" } },
                { this.arrivalLabel.Name.ToString(), new List<string> { "Arrival Image", "Изображение на\n пристигане", "Слика доласка" } },
                { this.departureLabel.Name.ToString(), new List<string> { "Departure Image", "Изображение на\n заминаване", "Слика одласка" } },                
            };

            foreach (var controlText in dictControlTexts)
            {
                if (controlText.Key == this.Name.ToString())
                { 
                    this.Text = controlText.Value[languageKey];
                    continue;
                }

                Control ctn = this.Controls[controlText.Key];
                ctn.Text = controlText.Value[languageKey];              
            }
        }
    }
}
