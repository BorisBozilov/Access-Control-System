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
    public partial class Employees : Form
    {
        string firmID;
        bool isNew = false;

        // Create SQL Connection 
        SqlConnection myConnection = new SqlConnection();      
       
        public Employees(int languageKey)
        {
            InitializeComponent();

            this.nameTextBox.Tag = false;
            this.surnameTextBox.Tag = false;
            this.lastNameTextBox.Tag = false;
            this.positionTextBox.Tag = false;
            this.pinTextBox.Tag = false;
            this.phoneTextBox.Tag = false;
            this.addressTextBox.Tag = false;
            this.emailTextBox.Tag = false;

            this.nameTextBox.Validating += new CancelEventHandler(textBoxEmpty_Validating);
            this.surnameTextBox.Validating += new CancelEventHandler(textBoxEmpty_Validating);
            this.lastNameTextBox.Validating += new CancelEventHandler(textBoxEmpty_Validating);
            this.positionTextBox.Validating += new CancelEventHandler(textBoxEmpty_Validating);
            //this.pinTextBox.Validating += new CancelEventHandler(textBoxEmpty_Validating);
            //this.phoneTextBox.Validating += new CancelEventHandler(textBoxEmpty_Validating);
            this.addressTextBox.Validating += new CancelEventHandler(textBoxEmpty_Validating);
            this.emailTextBox.Validating += new CancelEventHandler(textBoxEmpty_Validating);

            ChangeLanguage(languageKey);
        }

        private void Employees_Load(object sender, EventArgs e)
        {
            // Specify connection string
            myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            // Create SQL Command 
            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandText = "Select * from Employees where Employee_ID=(select max(Employee_ID)from Employees)";
            myCommand.CommandType = CommandType.Text;
            myCommand.Connection = myConnection;

            readData(myCommand);
        }

        private void ValidateAccept()
        {
            this.btnAccept.Enabled =
                (bool)this.nameTextBox.Tag &&
                (bool)this.surnameTextBox.Tag &&
                (bool)this.lastNameTextBox.Tag &&
                (bool)this.positionTextBox.Tag &&
                (bool)this.pinTextBox.Tag &&
                (bool)this.phoneTextBox.Tag &&
                (bool)this.addressTextBox.Tag &&
                (bool)this.emailTextBox.Tag;
        }

        //private void textBoxOne_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    TextBox tb = (TextBox)sender;

        //    tb.Text = tb.Text.TrimEnd();
        //    tb.SelectionStart = tb.Text.Length;
        //    tb.SelectionLength = 0;
        //}

        private void textBoxTwo_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            tb.Text = tb.Text.TrimEnd();
            tb.SelectionStart = tb.Text.Length;
            tb.SelectionLength = 0;

            if (((tb.Text.Length == 0) && (e.KeyChar == 97 && e.KeyChar == 65)) || (((e.KeyChar < 97 || e.KeyChar > 122) && (e.KeyChar < 65 || e.KeyChar > 90)) && e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

        private void textBoxEmpty_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text.Length == 0 || tb.Text.Trim().Length == 0)
            {
                tb.BackColor = Color.Red;
                tb.Tag = false;
            }
            else
            {               
                tb.BackColor = System.Drawing.SystemColors.Window;
                tb.Tag = true;
            }
            ValidateAccept();
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
                ValidateAccept();
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
            ValidateAccept();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            // Create SQL Command 
            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandText = "Select * from Employees where Employee_ID=(select min(Employee_ID)from Employees)";
            myCommand.CommandType = CommandType.Text;
            myCommand.Connection = myConnection;

            readData(myCommand);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            // Create SQL Command 
            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandText = "Select * from Employees where Employee_ID=(select max(Employee_ID)from Employees)";
            myCommand.CommandType = CommandType.Text;
            myCommand.Connection = myConnection;

            readData(myCommand);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            // Create SQL Command 
            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandText = "Select * from Employees where Employee_ID=(select max(Employee_ID)from Employees where Employee_ID<" + idTextBox.Text.ToString() + ")";
            myCommand.CommandType = CommandType.Text;
            myCommand.Connection = myConnection;

            readData(myCommand);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            // Create SQL Command 
            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandText = "Select * from Employees where Employee_ID=(select min(Employee_ID)from Employees where Employee_ID>" + idTextBox.Text.ToString() + ")";
            myCommand.CommandType = CommandType.Text;
            myCommand.Connection = myConnection;

            readData(myCommand);
        }

        private void readData(SqlCommand myCommand)
        {
            SqlDataReader myReader = null;

            myConnection.Open();

            myReader = myCommand.ExecuteReader();

            if (myReader.Read())
            {
                idTextBox.Text = myReader["Employee_ID"].ToString();
                nameTextBox.Text = myReader["Name"].ToString();
                surnameTextBox.Text = myReader["Surname"].ToString();
                lastNameTextBox.Text = myReader["Last_Name"].ToString();
                positionTextBox.Text = myReader["Position"].ToString();
                pinTextBox.Text = myReader["PIN"].ToString();
                phoneTextBox.Text = myReader["Phone"].ToString();
                addressTextBox.Text = myReader["Address"].ToString();
                emailTextBox.Text = myReader["Email"].ToString();
                firmTextBox.Text = myReader["Firm_ID"].ToString();
                firmID = myReader["Firm_ID"].ToString();

                if (myReader["Image"] != System.DBNull.Value)
                {
                    byte[] photo_aray = (byte[])myReader["Image"];
                    MemoryStream ms = new MemoryStream(photo_aray);
                    employeePictureBox.Image = Image.FromStream(ms);
                }               
            }

            myConnection.Close();

            myCommand.CommandText = "SELECT Firms.Name FROM Firms WHERE Firms.Firm_ID =" + firmID;

            myConnection.Open();

            myReader = myCommand.ExecuteReader();
            if (myReader.Read())
            {
                firmComboBox.Text = myReader["Name"].ToString();
            }

            myConnection.Close();
        }

        private void enable()
        {
            nameTextBox.Enabled = true;
            surnameTextBox.Enabled = true;
            lastNameTextBox.Enabled = true;
            positionTextBox.Enabled = true;
            pinTextBox.Enabled = true;
            phoneTextBox.Enabled = true;
            addressTextBox.Enabled = true;
            emailTextBox.Enabled = true;
            firmComboBox.Enabled = true;
            btnSelectImage.Enabled = true;          
            btnCancel.Enabled = true;

            btnFirst.Enabled = false;
            btnPrevious.Enabled = false;
            btnNext.Enabled = false;
            btnLast.Enabled = false;
            btnNew.Enabled = false;
            btnChange.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void disable()
        {
            nameTextBox.Enabled = false;
            surnameTextBox.Enabled = false;
            lastNameTextBox.Enabled = false;
            positionTextBox.Enabled = false;
            pinTextBox.Enabled = false;
            phoneTextBox.Enabled = false;
            addressTextBox.Enabled = false;
            emailTextBox.Enabled = false;
            firmComboBox.Enabled = false;
            btnSelectImage.Enabled = false;
            btnAccept.Enabled = false;
            btnCancel.Enabled = false;

            btnFirst.Enabled = true;
            btnPrevious.Enabled = true;
            btnNext.Enabled = true;
            btnLast.Enabled = true;
            btnNew.Enabled = true;
            btnChange.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            isNew = true;

            idTextBox.Text = "***";
            nameTextBox.Text = "";
            surnameTextBox.Text = "";
            lastNameTextBox.Text = "";
            positionTextBox.Text = "";
            pinTextBox.Text = "";
            phoneTextBox.Text = "";
            addressTextBox.Text = "";
            emailTextBox.Text = "";
            string[] s = { "\\bin" };
            string path = Application.StartupPath.Split(s, StringSplitOptions.None)[0] + "\\Images\\blank-profile-picture.png";
            employeePictureBox.Image = Image.FromFile(path);

            enable();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            this.nameTextBox.Tag = true;
            this.surnameTextBox.Tag = true;
            this.lastNameTextBox.Tag = true;
            this.positionTextBox.Tag = true;
            this.pinTextBox.Tag = true;
            this.phoneTextBox.Tag = true;
            this.addressTextBox.Tag = true;
            this.emailTextBox.Tag = true;

            ValidateAccept();

            isNew = false;

            enable();
        }

        private void getCurrentElement()
        {
            // Create SQL Command 
            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandText = "Select * from Employees where Employee_ID=" + idTextBox.Text.ToString();
            myCommand.CommandType = CommandType.Text;
            myCommand.Connection = myConnection;

            readData(myCommand);
        }

        private void getLastElement()
        {
            // Create SQL Command 
            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandText = "Select * from Employees where Employee_ID=(select max(Employee_ID)from Employees)";
            myCommand.CommandType = CommandType.Text;
            myCommand.Connection = myConnection;

            readData(myCommand);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            nameTextBox.BackColor = System.Drawing.SystemColors.Window;
            surnameTextBox.BackColor = System.Drawing.SystemColors.Window;
            lastNameTextBox.BackColor = System.Drawing.SystemColors.Window;
            positionTextBox.BackColor = System.Drawing.SystemColors.Window;
            pinTextBox.BackColor = System.Drawing.SystemColors.Window;
            phoneTextBox.BackColor = System.Drawing.SystemColors.Window;
            addressTextBox.BackColor = System.Drawing.SystemColors.Window;
            emailTextBox.BackColor = System.Drawing.SystemColors.Window;            

            if (isNew == true)
            {
                getLastElement();
            }
            else
            {
                getCurrentElement();
            }

            disable();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            // Create SQL Command 
            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandType = CommandType.Text;
            myCommand.Connection = myConnection;

            if (isNew == true)
            {
                myCommand.CommandText = "INSERT INTO Employees (Name, Surname, Last_Name, Position, PIN, Phone, Address, Email, Image, Firm_ID) VALUES (@Name, @Surname, @LastName, @Position, @PIN, @Phone, @Address, @Email, @Image, @Firm_ID)";
            }
            else
            {
                myCommand.CommandText = "UPDATE Employees SET Name = @Name, Surname = @Surname, Last_Name = @LastName, Position = @Position, PIN = @PIN, Phone = @Phone, Address = @Address, Email = @Email, Image = @Image, Firm_ID = @Firm_ID WHERE Employee_ID=" + idTextBox.Text.ToString();              
            }

            // create your parameters
            myCommand.Parameters.Add("@Name", System.Data.SqlDbType.NChar);
            myCommand.Parameters.Add("@Surname", System.Data.SqlDbType.NChar);
            myCommand.Parameters.Add("@LastName", System.Data.SqlDbType.NChar);
            myCommand.Parameters.Add("@Position", System.Data.SqlDbType.NChar);
            myCommand.Parameters.Add("@PIN", System.Data.SqlDbType.NChar);
            myCommand.Parameters.Add("@Phone", System.Data.SqlDbType.NChar);
            myCommand.Parameters.Add("@Address", System.Data.SqlDbType.NChar);
            myCommand.Parameters.Add("@Email", System.Data.SqlDbType.NChar);
            myCommand.Parameters.Add("@Firm_ID", System.Data.SqlDbType.Int);

            // set values to parameters from textboxes

            addressTextBox.Text = addressTextBox.Text.Trim();
            emailTextBox.Text = emailTextBox.Text.Trim();            

            myCommand.Parameters["@Name"].Value = nameTextBox.Text;
            myCommand.Parameters["@Surname"].Value = surnameTextBox.Text;
            myCommand.Parameters["@LastName"].Value = lastNameTextBox.Text;
            myCommand.Parameters["@Position"].Value = positionTextBox.Text;
            myCommand.Parameters["@PIN"].Value = pinTextBox.Text;
            myCommand.Parameters["@Phone"].Value = phoneTextBox.Text;
            myCommand.Parameters["@Address"].Value = addressTextBox.Text;
            myCommand.Parameters["@Email"].Value = emailTextBox.Text;
            myCommand.Parameters["@Firm_ID"].Value = int.Parse(firmTextBox.Text);

            //if (employeePictureBox.Image != null)
            //{
                //using MemoryStream:  
                MemoryStream ms = new MemoryStream();
                employeePictureBox.Image.Save(ms, ImageFormat.Jpeg);
                byte[] photo_aray = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(photo_aray, 0, photo_aray.Length);
                myCommand.Parameters.AddWithValue("@Image", photo_aray);
            //}

            // open sql connection
            myConnection.Open();

            // execute the query and return number of rows affected, should be one
            int RowsAffected = myCommand.ExecuteNonQuery();

            // close connection when done
            myConnection.Close();

            if (isNew == true)
            {
                getLastElement();
            }
            else
            {
                getCurrentElement();
            }

            disable();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Dictionary<int, List<string>> messages = new Dictionary<int, List<string>>();

            messages.Add(0, new List<string> { "Do you really want to delete this employee?", "Confirm employee deletion" });

            messages.Add(1, new List<string> { "Наистина ли искате да изтриете тoзи служител?", "Потвърдете изтриването на служителя" });

            messages.Add(2, new List<string> { "Да ли заиста желите да избришете овог запосленог?", "Потврди брисање запосленог" });
                      
            var value = messages[Program.LanguageKey];
            DialogResult dr = MessageBox.Show(value[0], value[1], MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                  
            if (dr == DialogResult.Yes)
            {
                myConnection.Open();

                // Create SQL Command 
                SqlCommand myCommand = new SqlCommand();
                myCommand.CommandText = "DELETE from Employees WHERE Employee_ID=" + idTextBox.Text.ToString();
                myCommand.CommandType = CommandType.Text;
                myCommand.Connection = myConnection;

                int result = myCommand.ExecuteNonQuery();

                myConnection.Close();

                myCommand.CommandText = "Select * from Employees where Employee_ID=(select max(Employee_ID)from Employees where Employee_ID<" + idTextBox.Text.ToString() + ")";

                readData(myCommand);
            }
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            // Wrap the creation of the OpenFileDialog instance in a using statement,
            // rather than manually calling the Dispose method to ensure proper disposal
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "(*.jpg;*.jpeg;*.bmp)| *.jpg; *.jpeg; *.bmp";

                if (dlg.ShowDialog() == DialogResult.OK)
                {

                    // Create a new Bitmap object from the picture file on disk,
                    // and assign that to the PictureBox.Image property
                    employeePictureBox.Image = new Bitmap(dlg.FileName);
                }
            }
        }

        private void firmComboBox_Enter(object sender, EventArgs e)
        {
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
        }

        private void firmComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            firmTextBox.Text = firmComboBox.SelectedValue.ToString();
            //firmComboBox.Text = firmComboBox.SelectedText;

            btnSelectImage.Focus();
        }

        private void ChangeLanguage(int languageKey)
        {
            Dictionary<string, List<string>> dictControlTexts = new Dictionary<string, List<string>>
            {
                { this.Name.ToString(), new List<string> { "Users", "Служители", "Запослени" } },
                { this.nameLabel.Name.ToString(), new List<string> { "Name", "Име", "Име" } },
                { this.surnameLabel.Name.ToString(), new List<string> { "Surname", "Презиме", "Средње име" } },
                { this.lastNameLabel.Name.ToString(), new List<string> { "Last name", "Фамилия", "Презиме" } },
                { this.positionLabel.Name.ToString(), new List<string> { "Position", "Длъжност", "Положај" } },
                { this.pinLabel.Name.ToString(), new List<string> { "PIN", "ЕГН", "ЈМБГ" } },
                { this.phoneLabel.Name.ToString(), new List<string> { "Phone", "Телефон", "Телефон" } },
                { this.addressLabel.Name.ToString(), new List<string> { "Address", "Aдрес", "Адреса" } },
                { this.emailLabel.Name.ToString(), new List<string> { "Email", "Електронна поща", "Емаил" } },
                { this.firmLabel.Name.ToString(), new List<string> { "Firm", "Фирма", "Фирма" } },

                { this.btnNew.Name.ToString(), new List<string> { "New", "Нов", "Нови" } },
                { this.btnChange.Name.ToString(), new List<string> { "Change", "Измени", "Промени" } },
                { this.btnDelete.Name.ToString(), new List<string> { "Delete", "Изтрий", "Избриши" } },
                { this.btnAccept.Name.ToString(), new List<string> { "Accept", "Приеми", "Прихвати" } },
                { this.btnCancel.Name.ToString(), new List<string> { "Cancel", "Откажи", "Откажи" } },
                { this.btnSelectImage.Name.ToString(), new List<string> { "Select Image", "Изберете изображение", "Изаберите слику" } }
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
