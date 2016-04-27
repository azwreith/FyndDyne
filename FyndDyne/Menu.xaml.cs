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

    class ProductClass {
        public string p_id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string desc { get; set; }
        public string cost { get; set; }

        public ProductClass(string p_id, string name, string type, string desc, string price) {
            this.p_id = p_id;
            this.name = name;
            this.type = type;
            this.desc = desc;
            this.cost = "Rs. " + price;
        }
    }

    /// <summary>
    /// Interaction logic for Menuxaml.xaml
    /// </summary>
    public partial class Menu : Window
    {
        string r_id;
        public Menu(string r_id)
        {
            InitializeComponent();
            this.r_id = r_id;
            GetMenu();
        }

        private void LogoutButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow.User = null;
            MainWindow.Type = null;
            new MainWindow().Show();
            this.Close();
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        private void GetMenu() {
            List<ProductClass> main = new List<ProductClass>();
            List<ProductClass> breads = new List<ProductClass>();
            List<ProductClass> dessert = new List<ProductClass>();
            try {
                var dbCon = DBConnection.Instance();
                dbCon.Open();
                string query = String.Format("SELECT * FROM PRODUCT WHERE category='Main Course' and r_id='{0}'", r_id);
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();
                while(reader.Read()) {
                    main.Add(new ProductClass(reader.GetString("p_id"), reader.GetString("name"), reader.GetString("type"), reader.GetString("description"), reader.GetString("price")));
                }
                reader.Close();
                query = String.Format("SELECT * FROM PRODUCT WHERE category='Breads' and r_id='{0}'", r_id);
                cmd = new MySqlCommand(query, dbCon.Connection);
                reader = cmd.ExecuteReader();
                while(reader.Read()) {
                    breads.Add(new ProductClass(reader.GetString("p_id"), reader.GetString("name"), reader.GetString("type"), reader.GetString("description"), reader.GetString("price")));
                }
                reader.Close();
                query = String.Format("SELECT * FROM PRODUCT WHERE category='Dessert' and r_id='{0}'", r_id);
                cmd = new MySqlCommand(query, dbCon.Connection);
                reader = cmd.ExecuteReader();
                while(reader.Read()) {
                    dessert.Add(new ProductClass(reader.GetString("p_id"), reader.GetString("name"), reader.GetString("type"), reader.GetString("description"), reader.GetString("price")));
                }
                reader.Close();
                dbCon.Close();
                Main.ItemsSource = main;
                Breads.ItemsSource = breads;
                Desserts.ItemsSource = dessert;

            }
            catch(Exception ex) {
                Trace.WriteLine(ex);
            }


        }

        private void BreadsSelected(object sender, MouseButtonEventArgs e) {
            try {
                if(MainWindow.User != null) {
                    ProductClass pd = Breads.SelectedItem as ProductClass;
                    var dbCon = DBConnection.Instance();
                    dbCon.Open();
                    var query = String.Format("SELECT * FROM Cart WHERE u_id = '{0}' and p_id = {1}", MainWindow.User, pd.p_id);
                    var cmd = new MySqlCommand(query, dbCon.Connection);
                    var reader = cmd.ExecuteReader();
                    String query2;
                    if(reader.Read()) {
                        query2 = String.Format("UPDATE Cart SET qty = {0}+1 WHERE u_id = '{1}' and p_id = {2}", reader.GetString("qty"), MainWindow.User, pd.p_id);
                    }
                    else {
                        query2 = String.Format("INSERT INTO Cart VALUES('{0}', {1}, 1)", MainWindow.User, pd.p_id);
                    }
                    reader.Close();
                    var cmd2 = new MySqlCommand(query2, dbCon.Connection);
                    cmd2.ExecuteNonQuery();
                    dbCon.Close();
                    MessageBox.Show("Added to Cart!");
                }

                else {
                    MessageBox.Show("You need to be logged in!", "Error");
                }
            }
            catch(Exception ex) {
                Trace.WriteLine(ex);
            }
        }
      
        private void MainSelected(object sender, MouseButtonEventArgs e) {
            try {
                if(MainWindow.User != null) {
            
                ProductClass pd = Main.SelectedItem as ProductClass;
                var dbCon = DBConnection.Instance();
                dbCon.Open();
                var query = String.Format("SELECT * FROM Cart WHERE u_id = '{0}' and p_id = {1}", MainWindow.User, pd.p_id);
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();
                String query2;
                if(reader.Read()) {
                    query2 = String.Format("UPDATE Cart SET qty = {0}+1 WHERE u_id = '{1}' and p_id = {2}", reader.GetString("qty"), MainWindow.User, pd.p_id);
                }
                else {
                    query2 = String.Format("INSERT INTO Cart VALUES('{0}', {1}, 1)", MainWindow.User, pd.p_id);
                }
                    reader.Close();
                var cmd2 = new MySqlCommand(query2, dbCon.Connection);
                cmd2.ExecuteNonQuery();
                    dbCon.Close();
                    MessageBox.Show("Added to Cart!");
                }

                else {
                    MessageBox.Show("You need to be logged in!", "Error");
                }
            }
            catch(Exception ex) {
                Trace.WriteLine(ex);
            }
        }
        private void DessertsSelected(object sender, MouseButtonEventArgs e) {
            try {
                if(MainWindow.User != null) {
                    ProductClass pd = Desserts.SelectedItem as ProductClass;
                    var dbCon = DBConnection.Instance();
                    dbCon.Open();
                    var query = String.Format("SELECT * FROM Cart WHERE u_id = '{0}' and p_id = {1}", MainWindow.User, pd.p_id);
                    var cmd = new MySqlCommand(query, dbCon.Connection);
                    var reader = cmd.ExecuteReader();
                    String query2;
                    if(reader.Read()) {
                        query2 = String.Format("UPDATE Cart SET qty = {0}+1 WHERE u_id = '{1}' and p_id = {2}", reader.GetString("qty"), MainWindow.User, pd.p_id);
                    }
                    else {
                        query2 = String.Format("INSERT INTO Cart VALUES('{0}', {1}, 1)", MainWindow.User, pd.p_id);
                    }
                    reader.Close();
                    var cmd2 = new MySqlCommand(query2, dbCon.Connection);
                    cmd2.ExecuteNonQuery();
                    dbCon.Close();
                    MessageBox.Show("Added to Cart!");
                }
                else {
                    MessageBox.Show("You need to be logged in!", "Error");
                }
            }
            catch(Exception ex) {
                Trace.WriteLine(ex);
            }
        }
    }
}
