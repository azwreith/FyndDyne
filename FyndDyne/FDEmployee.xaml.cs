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
    /// <summary>
    /// Interaction logic for FDEmployee.xaml
    /// </summary>
    /// 
    
    class Pending {
        string o_id;
        string address;
        string total_cost;

        public Pending(string o_id, string street, string city, string state, string zip, string total_cost) {
            this.o_id = o_id;
            address = street + " " + city + " " + " " + state + " " + " " + zip;
            this.total_cost = total_cost;
        }
    }

    public partial class FDEmployee : Window {
        List<Pending> pending = new List<Pending>();
        public FDEmployee() {
            InitializeComponent();
            
            try {
                var dbCon = DBConnection.Instance();
                dbCon.Open();
                string query = String.Format("SELECT o_id, total_cost, street, city, state, zip, FROM User NATURAL JOIN Orders WHERE fde_id='{0}' AND status='Pending'", MainWindow.User);
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();
                while(reader.Read()) {
                    pending.Add(new Pending(reader.GetString("o_id"), reader.GetString("total_cost"), reader.GetString("street"), reader.GetString("city"), reader.GetString("state"), reader.GetString("zip")));
                }
                dbCon.Close();
            }
            catch(Exception ex) {
                Trace.WriteLine(ex);
            }
        }

        private void DoneButtonClicked(object sender, RoutedEventArgs e) {
            
        }

        private void LogoutButtonClicked(object sender, RoutedEventArgs e) {
            MainWindow.User = null;
            MainWindow.Type = null;
            new MainWindow().Show();
            this.Close();
        }
    }
}