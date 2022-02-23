using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WorkTimeControlSystem
{
    public partial class MonthlyReport : Form
    {
        // create sql connection object.
        SqlConnection myConnection = new SqlConnection();

        public MonthlyReport(int languageKey)
        {
            InitializeComponent();
            ChangeLanguage(languageKey);
        }

        private void MonthlyReport_Load(object sender, EventArgs e)
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

            myConnection.Open();
            myCommand = new SqlCommand("SELECT Employee_ID, concat(TRIM(Name), ' ', TRIM(Last_Name)) as Full_Name from Employees where Firm_ID = " + firmTextBox.Text, myConnection);          

            reader = myCommand.ExecuteReader();
            dt = new DataTable();
            dt.Columns.Add("Employee_ID", typeof(string));
            dt.Columns.Add("Full_Name", typeof(string));
            dt.Load(reader);

            employeeListBox.ValueMember = "Employee_ID";
            employeeListBox.DisplayMember = "Full_Name";
            employeeListBox.DataSource = dt;

            myConnection.Close();

            employeeTextBox.Text = employeeListBox.SelectedValue.ToString();
            employeeTextBox.Text += " " + employeeListBox.GetItemText(employeeListBox.SelectedItem);
        }

        private void firmComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            firmTextBox.Text = firmComboBox.SelectedValue.ToString();
            btnShowReport.Focus();

            // Specify connection string
            myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            myConnection.Open();
            SqlCommand myCommand = new SqlCommand("SELECT Employee_ID, concat(TRIM(Name), ' ', TRIM(Last_Name)) as Full_Name from Employees where Firm_ID = " + firmTextBox.Text , myConnection);
            SqlDataReader reader;

            reader = myCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Employee_ID", typeof(string));
            dt.Columns.Add("Full_Name", typeof(string));
            dt.Load(reader);

            employeeListBox.ValueMember = "Employee_ID";
            employeeListBox.DisplayMember = "Full_Name";          
            employeeListBox.DataSource = dt;

            myConnection.Close();            
        }

        private void employeeListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            employeeTextBox.Text = employeeListBox.SelectedValue.ToString();
            employeeTextBox.Text += " " + employeeListBox.GetItemText(employeeListBox.SelectedItem);
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            string[] employee = employeeTextBox.Text.ToString().Split(' ');

            Dictionary<int, List<string>> selectTableLanguage = new Dictionary<int, List<string>>
            {
                { 0, new List<string> { "Date", "Work Hours" } },

                { 1, new List<string> { "Дата", "Работни часове" } },

                { 2, new List<string> { "Датум", "Радно време" } }
            };

            myConnection.Open();

            //.ToString("yyyy-MM-dd")
            SqlDataAdapter myAdapter = new SqlDataAdapter("select Date_att, (SUM((DATEPART(hh,Work_Time)*60)+DATEPART(mi,Work_Time)+(DATEPART(ss,Work_Time)/(60.0)))*60) as Work_Time from Work_Attendance where (Work_Attendance.Firm_ID = " + firmTextBox.Text.ToString() + " and Work_Attendance.Employee_ID = " + employee[0] + " and (SELECT MONTH(Work_Attendance.Date_Att) AS Month) = '" + dateTimePicker.Value.Month + "'" + " and (SELECT YEAR(Work_Attendance.Date_Att) AS Year) = '" + dateTimePicker.Value.Year + "') GROUP BY Date_att", myConnection);

            DataTable dtMonthlyReport = new DataTable();
            myAdapter.Fill(dtMonthlyReport);

            Dictionary<DateTime, decimal> dictionaryMonthlyReport = GetDict(dtMonthlyReport);
            Dictionary<DateTime, string> dictionaryStringMonthlyReport = new Dictionary<DateTime, string>();         

            //monthlyReportDataGridView.DataSource = dtMonthlyReport;

            decimal sumTime = 0;
            decimal hours = 0;
            decimal minutes = 0;
            decimal seconds = 0;

            foreach (var item in dictionaryMonthlyReport)
            {
                hours = (int)(item.Value / 3600);
                minutes = (int)((item.Value % 3600) / 60);
                seconds = (int)((item.Value % 3600) % 60);
                dictionaryStringMonthlyReport.Add(item.Key, $"{hours}h : {minutes}m : {seconds}s");
            }

            monthlyReportDataGridView.DataSource = (from d in dictionaryStringMonthlyReport orderby d.Key select new { d.Key, d.Value }).ToList();

            var value = selectTableLanguage[Program.LanguageKey];
            monthlyReportDataGridView.Columns[0].HeaderText = value[0];
            monthlyReportDataGridView.Columns[1].HeaderText = value[1];

            foreach (var item in dictionaryMonthlyReport)
            {             
                sumTime += item.Value;
            }

            hours = (int)(sumTime / 3600);
            minutes = (int)((sumTime % 3600) / 60);
            seconds = (int)((sumTime % 3600) % 60);

            monthlyReportTextBox.Text = hours.ToString() + "h : " + minutes.ToString() + "m : " + seconds.ToString() + "s";

            myConnection.Close();
        }

        private Dictionary<DateTime, decimal> GetDict(DataTable dt)
        {
            return dt.AsEnumerable()
              .ToDictionary<DataRow, DateTime, decimal>(row => row.Field<DateTime>(0),
                                        row => row.Field<decimal>(1));
        }

        private void ChangeLanguage(int languageKey)
        {
            Dictionary<string, List<string>> dictControlTexts = new Dictionary<string, List<string>>
            {
                { this.Name.ToString(), new List<string> { "Monthly report", "Месечен отчет", "Месечни извештај" } },
                { this.btnShowReport.Name.ToString(), new List<string> { "Show report", "Покажи отчета", "Прикажи извештај" } },
                { this.monthlyReportLabel.Name.ToString(), new List<string> { "Total monthly hours:", "Общо месечни часове:", "Укупни месечни часови:" } },
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
