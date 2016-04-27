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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FyndDyne
{
    class RestaurantClass
    {
        public string r_id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string image { get; set; }

        public RestaurantClass(string r_id, string name, string phone, string street, string city, string state, string zip, string image)
        {
            this.r_id = r_id;
            this.name = name;
            this.phone = phone;
            address = street + " " + city + " " + " " + state + " " + " " + zip;
            this.image = image;
        }
    }


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string User = null;
        public static string Type = null;   //Customer, Admin, Employee, Manager
        public MainWindow()
        {
            InitializeComponent();
            List<RestaurantClass> reslist = new List<RestaurantClass>();
            try
            {
                var dbCon = DBConnection.Instance();
                dbCon.Open();
                string query = String.Format("SELECT * FROM Restaurant");
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    reslist.Add(new RestaurantClass(reader.GetString("r_id"), reader.GetString("name"), reader.GetString("phone"), reader.GetString("street"), reader.GetString("city"), reader.GetString("state"), reader.GetString("zip"), reader.GetString("image")));
                }
                reader.Close();
                dbCon.Close();

                Restaurant.ItemsSource = reslist;

                

            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
            }

        }

        private void SignUpButtonClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new Register().Show();
        }

        private void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new SignIn().Show();
        }

        private void LogoutButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void CartButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
         
            //List<RestaurantClass> reslist = new List<RestaurantClass>();
            //try
            //{
            //    var dbCon = DBConnection.Instance();
            //    dbCon.Open();
            //    string query = String.Format("SELECT *, R.name AS naam FROM Restaurant AS R NATURAL JOIN PRODUCT AS P WHERE R.name LIKE '{0}' OR P.name LIKE '{0}' OR P.category LIKE '{0}' OR P.type LIKE '{0}' OR R.city LIKE '{0}' OR R.state LIKE '{0}'", Search.Text);
            //    var cmd = new MySqlCommand(query, dbCon.Connection);
            //    var reader = cmd.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        reslist.Add(new RestaurantClass(reader.GetString("r_id"), reader.GetString("naam"), reader.GetString("phone"), reader.GetString("street"), reader.GetString("city"), reader.GetString("state"), reader.GetString("zip"), reader.GetString("image")));
            //    }
            //    reader.Close();
            //    dbCon.Close();

            //    Restaurant.ItemsSource = reslist;
  


            //}
            //catch (Exception ex)
            //{
            //    Trace.WriteLine(ex);
            //}
        }

        private void RestaurantSelected(object sender, MouseButtonEventArgs e)
        {

            RestaurantClass rc = Restaurant.SelectedItem as RestaurantClass;
            new Menu(rc.r_id).Show();
            this.Close();
        }
    }
}
