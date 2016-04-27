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

namespace FyndDyne { 

   class CartClass {
    public string p_id { get; set; }
    public string name { get; set; }
    public string qty { get; set; }
    public string cost { get; set; }

    public CartClass(string p_id, string name, string qty, string price) {
        this.p_id = p_id;
        this.name = name;
        this.qty = "Quantity: " + qty;
        this.cost = "Rs. " + price;
    }

}
    /// <summary>
    /// Interaction logic for Cart.xaml
    /// </summary>
    public partial class Cart : Window
    {
        public Cart()
        {
            InitializeComponent();
            GetCart();
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        private void LogoutButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow.User = null;
            MainWindow.Type = null;
            new MainWindow().Show();
            this.Close();
        }

        private void RemoveItem(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            CartClass cc = button.DataContext as CartClass;
            try {
                var dbCon = DBConnection.Instance();
                dbCon.Open();
                string query = String.Format("DELETE FROM Cart  WHERE u_id='{0}' AND p_id = {1}", MainWindow.User, cc.p_id);
                var cmd = new MySqlCommand(query, dbCon.Connection);
                cmd.ExecuteNonQuery();
                dbCon.Close();
            }
            catch(Exception ex) {
                Trace.WriteLine(ex);
            }
            GetCart();
        }

        private void GetCart() {
            List<CartClass> cart = new List<CartClass>();
            try {
                var dbCon = DBConnection.Instance();
                dbCon.Open();
                string query = String.Format("SELECT p_id, name, qty, price FROM Cart NATURAL JOIN Product WHERE u_id='{0}'", MainWindow.User);
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();
                while(reader.Read()) {
                    cart.Add(new CartClass(reader.GetString("p_id"), reader.GetString("name"), reader.GetString("qty"), reader.GetString("price")));
                }
                reader.Close();
                dbCon.Close();
                CartData.ItemsSource = cart;
            }
            catch(Exception ex) {
                Trace.WriteLine(ex);
            }
        }

        private void Buy_Click(object sender, RoutedEventArgs e) {
            try {
                var dbCon = DBConnection.Instance();
                dbCon.Open();
                string deltype;
                string status;
                if(delivery.IsChecked == true) {
                    deltype = "Delivery";
                    status = "Pending";
                }
                else {
                    deltype = "Takeaway";
                    status = "Delivered";
                }
                string query = String.Format("SELECT SUM(qty*price) FROM cart NATURAL JOIN product"); 
                var cmd = new MySqlCommand(query, dbCon.Connection);
                string total = ((decimal) cmd.ExecuteScalar()).ToString();
                query = String.Format("INSERT INTO Orders(u_id, fde_id, total_cost, delivery_type, status) VALUES ('{0}', null, {1}, '{2}', '{3}')", MainWindow.User, total, deltype, status);
                cmd = new MySqlCommand(query, dbCon.Connection);
                cmd.ExecuteNonQuery();
                query = String.Format("SELECT o_id FROM Orders WHERE u_id = '{0}' ORDER BY o_id DESC", MainWindow.User);
                cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();
                reader.Read();
                var o_id = reader.GetString("o_id");
                reader.Close();
                query = String.Format("SELECT * from CART WHERE u_id = '{0}'", MainWindow.User);
                cmd = new MySqlCommand(query, dbCon.Connection);
                reader = cmd.ExecuteReader();
                int n = 0;
                string[] p_ids = new string[50];
                string[] qts = new string[50];
                while(reader.Read()) {
                    
                    p_ids[n] = reader.GetString("p_id");
                    qts[n] = reader.GetString("qty");
                    n++;
                }
                reader.Close();
                for (int i=0; i< n; i++) {
                    var q = String.Format("INSERT INTO Order_Product VALUES({0}, {1}, {2})", o_id, p_ids[i], qts[i]);
                    var cmd2 = new MySqlCommand(q, dbCon.Connection);
                    cmd2.ExecuteNonQuery();
                }
               
                query = String.Format("DELETE from CART WHERE u_id = '{0}'", MainWindow.User);
                cmd = new MySqlCommand(query, dbCon.Connection);
                cmd.ExecuteNonQuery();
                dbCon.Close();
                MessageBox.Show("Ordered! Your total will be: " + total, "Sucess");
                new MainWindow().Show();
                this.Close();
            }
            catch(Exception ex) {
                Trace.WriteLine(ex);
            }
        }
    }
}
