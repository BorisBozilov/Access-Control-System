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
    public partial class Firms : Form
    {
        bool isNew = false;       

        // create sql connection object.
        SqlConnection myConnection = new SqlConnection(); 

        public Firms(int languageKey)
        {
            InitializeComponent();

            this.nameTextBox.Tag = false;
            this.vinTextBox.Tag = false;
            this.mnTextBox.Tag = false;
            this.addressTextBox.Tag = false;
            this.cityTextBox.Tag = false;
            this.zipCodeTextBox.Tag = false;
            this.emailTextBox.Tag = false;
            this.webAddressTextBox.Tag = false;
            this.phoneTextBox.Tag = false;
            
            this.emailTextBox.Tag = false;

            this.nameTextBox.Validating += new CancelEventHandler(textBoxEmpty_Validating);
            this.addressTextBox.Validating += new CancelEventHandler(textBoxEmpty_Validating);
            this.cityTextBox.Validating += new CancelEventHandler(textBoxEmpty_Validating);
            this.emailTextBox.Validating += new CancelEventHandler(textBoxEmpty_Validating);
            this.webAddressTextBox.Validating += new CancelEventHandler(textBoxEmpty_Validating);

            ChangeLanguage(languageKey);
        }

        private void Firms_Load(object sender, EventArgs e)
        {
            // Specify connection string
            myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            
            // Create SQL Command 
            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandText = "Select * from Firms where Firm_ID=(select max(Firm_ID)from Firms)";
            myCommand.CommandType = CommandType.Text;
            myCommand.Connection = myConnection;

            readData(myCommand);
        }

        private void ValidateAccept()
        {
            this.btnAccept.Enabled =
                (bool)this.nameTextBox.Tag &&
                (bool)this.vinTextBox.Tag &&
                (bool)this.mnTextBox.Tag &&
                (bool)this.addressTextBox.Tag &&
                (bool)this.cityTextBox.Tag &&
                (bool)this.zipCodeTextBox.Tag &&
                (bool)this.emailTextBox.Tag &&
                (bool)this.webAddressTextBox.Tag &&
                (bool)this.phoneTextBox.Tag;
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

        private void textBoxTypeOneNumber_KeyUp(object sender, KeyEventArgs e)
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

        private void textBoxTypeTwoNumber_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text.Length > 0)
            {
                if (tb.Text.Length == 5)
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
            myCommand.CommandText = "Select * from Firms where Firm_ID=(select min(Firm_ID)from Firms)";
            myCommand.CommandType = CommandType.Text;
            myCommand.Connection = myConnection;

            readData(myCommand);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            // Create SQL Command 
            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandText = "Select * from Firms where Firm_ID=(select max(Firm_ID)from Firms)";
            myCommand.CommandType = CommandType.Text;
            myCommand.Connection = myConnection;

            readData(myCommand);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            // Create SQL Command 
            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandText = "Select * from Firms where Firm_ID=(select max(Firm_ID)from Firms where Firm_ID<" + idTextBox.Text.ToString() + ")";
            myCommand.CommandType = CommandType.Text;
            myCommand.Connection = myConnection;

            readData(myCommand);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            // Create SQL Command 
            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandText = "Select * from Firms where Firm_ID=(select min(Firm_ID)from Firms where Firm_ID>" + idTextBox.Text.ToString() + ")";
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
                idTextBox.Text = myReader["Firm_ID"].ToString();
                nameTextBox.Text = myReader["Name"].ToString();
                vinTextBox.Text = myReader["VIN"].ToString();
                mnTextBox.Text = myReader["MN"].ToString();
                addressTextBox.Text = myReader["Address"].ToString();
                cityTextBox.Text = myReader["City"].ToString();
                zipCodeTextBox.Text = myReader["Zip_Code"].ToString();
                emailTextBox.Text = myReader["Email"].ToString();
                webAddressTextBox.Text = myReader["Web_Address"].ToString();
                phoneTextBox.Text = myReader["Phone"].ToString();
            }
                              
            myConnection.Close();
        }

        private void enable()
        {
            nameTextBox.Enabled = true;
            vinTextBox.Enabled = true;
            mnTextBox.Enabled = true;
            cityTextBox.Enabled = true;
            zipCodeTextBox.Enabled = true;
            phoneTextBox.Enabled = true;
            addressTextBox.Enabled = true;
            emailTextBox.Enabled = true;
            webAddressTextBox.Enabled = true;          
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
            vinTextBox.Enabled = false;
            mnTextBox.Enabled = false;
            cityTextBox.Enabled = false;
            zipCodeTextBox.Enabled = false;
            phoneTextBox.Enabled = false;
            addressTextBox.Enabled = false;
            emailTextBox.Enabled = false;
            webAddressTextBox.Enabled = false;
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
            vinTextBox.Text = "";
            mnTextBox.Text = "";
            addressTextBox.Text = "";
            cityTextBox.Text = "";
            zipCodeTextBox.Text = "";
            emailTextBox.Text = "";
            webAddressTextBox.Text = "";
            phoneTextBox.Text = "";

            enable();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            this.nameTextBox.Tag = true;
            this.vinTextBox.Tag = true;
            this.mnTextBox.Tag = true;
            this.addressTextBox.Tag = true;
            this.cityTextBox.Tag = true;
            this.zipCodeTextBox.Tag = true;
            this.emailTextBox.Tag = true;
            this.webAddressTextBox.Tag = true;
            this.phoneTextBox.Tag = true;

            ValidateAccept();

            isNew = false;

            enable();
        }

        private void getCurrentElement()
        {
            // Create SQL Command 
            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandText = "Select * from Firms where Firm_ID=" + idTextBox.Text.ToString();
            myCommand.CommandType = CommandType.Text;
            myCommand.Connection = myConnection;

            readData(myCommand);
        }

        private void getLastElement()
        {
            // Create SQL Command 
            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandText = "Select * from Firms where Firm_ID=(select max(Firm_ID)from Firms)";
            myCommand.CommandType = CommandType.Text;
            myCommand.Connection = myConnection;

            readData(myCommand);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            nameTextBox.BackColor = System.Drawing.SystemColors.Window;
            vinTextBox.BackColor = System.Drawing.SystemColors.Window;
            mnTextBox.BackColor = System.Drawing.SystemColors.Window;
            addressTextBox.BackColor = System.Drawing.SystemColors.Window;
            cityTextBox.BackColor = System.Drawing.SystemColors.Window;
            zipCodeTextBox.BackColor = System.Drawing.SystemColors.Window;
            emailTextBox.BackColor = System.Drawing.SystemColors.Window;
            webAddressTextBox.BackColor = System.Drawing.SystemColors.Window;
            phoneTextBox.BackColor = System.Drawing.SystemColors.Window;            

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
                myCommand.CommandText = "INSERT INTO Firms (Name, VIN, MN, Address, City, Zip_Code, Email, Web_Address, Phone) VALUES(@Name, @VIN, @MN, @Address, @City, @ZipCode, @Email, @WebAddress, @Phone)";
            }
            else
            {
                myCommand.CommandText = "UPDATE Firms SET Name = @Name, VIN = @VIN, MN = @MN, Address = @Address, City = @City, Zip_Code = @ZipCode, Email = @Email, Web_Address = @WebAddress, Phone = @Phone WHERE Firm_ID=" + idTextBox.Text.ToString();
            }

            // create your parameters
            myCommand.Parameters.Add("@Name", System.Data.SqlDbType.NChar);
            myCommand.Parameters.Add("@VIN", System.Data.SqlDbType.NChar);
            myCommand.Parameters.Add("@MN", System.Data.SqlDbType.NChar);
            myCommand.Parameters.Add("@Address", System.Data.SqlDbType.NChar);
            myCommand.Parameters.Add("@City", System.Data.SqlDbType.NChar);
            myCommand.Parameters.Add("@ZipCode", System.Data.SqlDbType.NChar);
            myCommand.Parameters.Add("@Email", System.Data.SqlDbType.NChar);
            myCommand.Parameters.Add("@WebAddress", System.Data.SqlDbType.NChar);
            myCommand.Parameters.Add("@Phone", System.Data.SqlDbType.NChar);

            // set values to parameters from textboxes

            addressTextBox.Text = addressTextBox.Text.Trim();
            emailTextBox.Text = emailTextBox.Text.Trim();
            webAddressTextBox.Text = webAddressTextBox.Text.Trim();                       

            myCommand.Parameters["@Name"].Value = nameTextBox.Text;
            myCommand.Parameters["@VIN"].Value = vinTextBox.Text;
            myCommand.Parameters["@MN"].Value = mnTextBox.Text;
            myCommand.Parameters["@Address"].Value = addressTextBox.Text;
            myCommand.Parameters["@City"].Value = cityTextBox.Text;
            myCommand.Parameters["@ZipCode"].Value = zipCodeTextBox.Text;
            myCommand.Parameters["@Email"].Value = emailTextBox.Text;
            myCommand.Parameters["@WebAddress"].Value = webAddressTextBox.Text;
            myCommand.Parameters["@Phone"].Value = phoneTextBox.Text;

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

            messages.Add(0, new List<string> { "Do you really want to delete this firm?", "Confirm firm deletion", "There are employees in this firm. If you delete this firm all employees will be deleted. Do you realy want to delete this firm?" });

            messages.Add(1, new List<string> { "Наистина ли искате да изтриете тази фирма?", "Потвърдете изтриването на фирмата", "В тази фирма има служители. Ако изтриете тази фирма, всички служители ще бъдат изтрити. Наистина ли искате да изтриете тази фирма?" });

            messages.Add(2, new List<string> { "Да ли заиста желите да избришете ову фирму?", "Потврди брисање фирме", "У овој фирми има запослених. Ако избришете ову фирму, сви запослени ће бити избрисани. Да ли стварно желите да избришете ову фирму?" });
                    
            var value = messages[Program.LanguageKey];

            DialogResult dr1 = MessageBox.Show(value[0], value[1], MessageBoxButtons.YesNo, MessageBoxIcon.Warning);          
            if (dr1 == DialogResult.Yes)
            {
                myConnection.Open();

                // Create SQL Command 
                SqlCommand myCommand = new SqlCommand();
                myCommand.CommandText = "SELECT Employee_ID from Employees WHERE Firm_ID=" + idTextBox.Text.ToString();
                myCommand.CommandType = CommandType.Text;
                myCommand.Connection = myConnection;

                SqlDataReader myReader = myCommand.ExecuteReader();
                bool hasRows = myReader.HasRows;

                myConnection.Close();

                if (hasRows)
                {
                    DialogResult dr2 = MessageBox.Show(value[2], value[1], MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                   
                    if (dr2 == DialogResult.Yes)
                    {
                        myCommand.CommandText = "DELETE from Employees WHERE Firm_ID=" + idTextBox.Text.ToString();

                        myConnection.Open();
                        int result = myCommand.ExecuteNonQuery();
                        myConnection.Close();

                        myCommand.CommandText = "DELETE from Firms WHERE Firm_ID=" + idTextBox.Text.ToString();

                        myConnection.Open();
                        result = myCommand.ExecuteNonQuery();
                        myConnection.Close();

                        myCommand.CommandText = "Select * from Firms where Firm_ID=(select max(Firm_ID)from Firms where Firm_ID<" + idTextBox.Text.ToString() + ")";

                        readData(myCommand);
                    }
                }
                else
                {
                    myCommand.CommandText = "DELETE from Firms WHERE Firm_ID=" + idTextBox.Text.ToString();

                    myConnection.Open();
                    int result = myCommand.ExecuteNonQuery();
                    myConnection.Close();

                    myCommand.CommandText = "Select * from Firms where Firm_ID=(select max(Firm_ID)from Firms where Firm_ID<" + idTextBox.Text.ToString() + ")";

                    readData(myCommand);
                }
            }
        }

        private void ChangeLanguage(int languageKey)
        {
            Dictionary<string, List<string>> dictControlTexts = new Dictionary<string, List<string>>
            {
                { this.Name.ToString(), new List<string> { "Institutions", "Фирми", "Фирме" } },
                { this.nameLabel.Name.ToString(), new List<string> { "Name", "Име", "Име" } },
                { this.vinLabel.Name.ToString(), new List<string> { "VIN", "ДИН", "ПИБ" } },
                { this.mnLabel.Name.ToString(), new List<string> { "CRN", "РНФ", "МБ" } },
                { this.addressLabel.Name.ToString(), new List<string> { "Address", "Aдрес", "Адреса" } },
                { this.cityLabel.Name.ToString(), new List<string> { "City", "Град", "Град" } },
                { this.zipCodeLabel.Name.ToString(), new List<string> { "Zip code", "Пощенски код", "Поштански број" } },
                { this.emailLabel.Name.ToString(), new List<string> { "Email", "Електронна поща", "Емаил" } },
                { this.webAddressLabel.Name.ToString(), new List<string> { "Web address", "Уеб адрес", "Веб адреса" } },
                { this.phoneLabel.Name.ToString(), new List<string> { "Phone", "Телефон", "Телефон" } },
                { this.btnNew.Name.ToString(), new List<string> { "New", "Нова", "Нова" } },
                { this.btnChange.Name.ToString(), new List<string> { "Change", "Измени", "Промени" } },
                { this.btnDelete.Name.ToString(), new List<string> { "Delete", "Изтрий", "Избриши" } },
                { this.btnAccept.Name.ToString(), new List<string> { "Accept", "Приеми", "Прихвати" } },
                { this.btnCancel.Name.ToString(), new List<string> { "Cancel", "Откажи", "Откажи" } }
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
