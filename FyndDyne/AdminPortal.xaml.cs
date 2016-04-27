using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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
    /// Interaction logic for AdminPortal.xaml
    /// </summary>
    public partial class AdminPortal : Window
    {
        public AdminPortal()
        {
            InitializeComponent();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.User = null;
            MainWindow.Type = null;
            new MainWindow().Show();
            this.Close();
        }

        private void SubmitButtonAction(object sender, RoutedEventArgs e)
        {
            string query = "INSERT INTO Manager values('" + UserName.Text + "', '"+ Utilities.MD5(Password.Password) +
                "', '" + FirstName.Text + "', '" + LastName.Text + "');" ;
            string query2 = "INSERT INTO Restaurant values( 1,'" + UserName.Text + "', '" + Name.Text +
                "','" + Phone.Text + "','" + StreetAddress.Text + "','" + City.Text + "','" + State.Text +
                "','" + ZipCode.Text + "', '');";
            try {
                var dbCon = DBConnection.Instance();
                dbCon.Open();
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();
                cmd = new MySqlCommand(query2, dbCon.Connection);
                reader = cmd.ExecuteReader();
                reader.Close();
                dbCon.Close();
                this.Close();
                new AdminPortal().Show();                  
            }
            catch(MySqlException ex) {
                Trace.WriteLine(ex);
            }
            Trace.WriteLine(query);
            Trace.WriteLine(query2);
        }
    }
}
