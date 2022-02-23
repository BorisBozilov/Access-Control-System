using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WorkTimeControlSystem
{
    public partial class Main : Form
    {      
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            Attendance attendance = new Attendance(Program.LanguageKey);
            attendance.FormClosed += Attendance_FormClosed;
            attendance.Show();
            this.btnAttendance.Enabled = false;
        }

        private void Attendance_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.btnAttendance.Enabled = true;
        }

        private void btnMonthlyReport_Click(object sender, EventArgs e)
        {
            MonthlyReport monthlyReport = new MonthlyReport(Program.LanguageKey);
            monthlyReport.FormClosed += MonthlyReport_FormClosed;
            monthlyReport.Show();
            this.btnMonthlyReport.Enabled = false;
        }

        private void MonthlyReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.btnMonthlyReport.Enabled = true;
        }

        private void btnFirms_Click(object sender, EventArgs e)
        {          
            Firms firm = new Firms(Program.LanguageKey);
            firm.FormClosed += Firm_FormClosed;
            firm.Show();
            this.btnFirms.Enabled = false;
            
        }

        private void Firm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.btnFirms.Enabled = true;
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            Employees employee = new Employees(Program.LanguageKey);
            employee.FormClosed += Employee_FormClosed;
            employee.Show();
            this.btnEmployees.Enabled = false;
        }

        private void Employee_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.btnEmployees.Enabled = true;
        }

        private void btnEnglish_Click(object sender, EventArgs e)
        {
            Program.LanguageKey = 0;
            ChangeLanguage(Program.LanguageKey);

            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != this.Name)
                    Application.OpenForms[i].Close();
            }
        }

        private void btnBulgarian_Click(object sender, EventArgs e)
        {
            Program.LanguageKey = 1;
            ChangeLanguage(Program.LanguageKey);

            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != this.Name)
                    Application.OpenForms[i].Close();
            }
        }

        private void btnSerbian_Click(object sender, EventArgs e)
        {
            Program.LanguageKey = 2;
            ChangeLanguage(Program.LanguageKey);

            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != this.Name)
                    Application.OpenForms[i].Close();
            }
        }

        private void ChangeLanguage(int languageKey)
        {
            Dictionary<string, List<string>> dictControlTexts = new Dictionary<string, List<string>>
            {
                { this.Name.ToString(), new List<string> { "Work Time Control System", "Система за контрол на работното време", "Систем за контролу радног времена" } },
                { this.btnAttendance.Name.ToString(), new List<string> { "Attendance", "Посещаемост", "Посећеност" } },
                { this.btnMonthlyReport.Name.ToString(), new List<string> { "Monthly report", "Месечен отчет", "Месечни извештај" } },
                { this.btnEmployees.Name.ToString(), new List<string> { "Employees", "Служители", "Запослени" } },
                { this.btnFirms.Name.ToString(), new List<string> { "Firms", "Фирми", "Фирме" } }
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

                //foreach (Control control in Controls)
                //{
                //    if (element.Key == control.Name.ToString())
                //    {
                //        control.Text = element.Value[languageKey];
                //    }
                //} 
            }         
        }     
    }
}
