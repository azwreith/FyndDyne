using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace FyndDyne
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            try {
                var dbCon = DBConnection.Instance();
                dbCon.Open();

                bool flag = true;
                if(FirstName.Text.Equals("") || LastName.Text.Equals("") || UserName.Text.Equals("")
                    || Password.Password.Equals("") || ConfirmPassword.Password.Equals("") ||
                    StreetAddress.Text.Equals("") || City.Text.Equals("") || State.Text.Equals("") ||
                    ZipCode.Text.Equals("") || Phone.Text.Equals("") || Email.Text.Equals("")) {
                    MessageBox.Show("Please Fill All Fields!", "Error");
                    flag = false;
                }
                else if(!Password.Password.Equals(ConfirmPassword.Password)) {
                    MessageBox.Show("Passwords Do Not Match!", "Error");
                    flag = false;
                }
                else if(!Regex.IsMatch(ZipCode.Text, "^[0-9]{6}$")) {
                    MessageBox.Show("Invalid Zip!", "Error");
                    flag = false;
                }
                else if(!Regex.IsMatch(Phone.Text, "^[0-9]{10}$")) {
                    MessageBox.Show("Invalid Phone!", "Error");
                    flag = false;
                }
                else if(!Regex.IsMatch(Email.Text, "^[a-zA-Z0-9.]{2,}@[a-zA-Z]*.[a-z]{2,}")) {
                    MessageBox.Show("Passwords Do Not Match!", "Error");
                    flag = false;
                }
                string query = "SELECT * FROM User WHERE u_id='" + UserName.Text + "'";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();
                if(reader.Read()) {
                    MessageBox.Show("Username Already Exists!", "Error");
                    flag = false;
                }
                reader.Close();
                Trace.WriteLine(flag);
                if(flag) {
                    //TODO Backend
                    query = String.Format("INSERT INTO User VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')",
                        UserName.Text,
                        Utilities.MD5(Password.Password),
                        FirstName.Text,
                        LastName.Text,
                        Phone.Text,
                        StreetAddress.Text,
                        City.Text,
                        State.Text,
                        ZipCode.Text,
                        Email.Text
                    );
                    cmd = new MySqlCommand(query, dbCon.Connection);
                    if(cmd.ExecuteNonQuery() == 1) {
                        new SignIn().Show();
                        this.Close();
                    }
                    else {
                        MessageBox.Show("There was some error. Try Again!", "Error");
                    }
                }
                dbCon.Close();
            }
            catch(Exception ex) {
                Trace.WriteLine(ex);
            }
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
            new MainWindow().Show();
        }
    }
}
