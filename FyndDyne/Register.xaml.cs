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

        private void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
            new SignIn().Show();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            bool flag = true;
            if (FirstName.Text.Equals("") || LastName.Text.Equals("") || UserName.Text.Equals("")
                || Password.Password.Equals("") || ConfirmPassword.Password.Equals("") ||
                StreetAddress.Text.Equals("") || City.Text.Equals("") || State.Text.Equals("") ||
                ZipCode.Text.Equals("") || Phone.Text.Equals("") || Email.Text.Equals(""))
            {
                //Display error message
                flag = false;
            }
            else if (!Password.Password.Equals(ConfirmPassword.Password))
            {
                //Display error message
                flag = false;
            }
            else if (!Regex.IsMatch(ZipCode.Text, "^[0-9]{6}$"))
            {
                flag = false;
            }
            else if (!Regex.IsMatch(Phone.Text, "^[0-9]{10}$"))
            {
                flag = false;
            }
            else if (!Regex.IsMatch(Email.Text, "^[a-zA-Z0-9.]{2,}@[a-zA-Z]*.[a-z]{2,}"))
            {
                flag = false;
            }
            //if username already in database.
            Trace.WriteLine(flag);
            if (flag)
            {
                //call helper and register.
                //open sign in page
                this.Close();
                new SignIn().Show();
            }
        }
    }
}
