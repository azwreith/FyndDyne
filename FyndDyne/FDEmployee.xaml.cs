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
    
    class PendingClass {
        public string o_id { get; set; }
        public string address { get; set; }
        public string total_cost { get; set; }

        public PendingClass(string o_id, string street, string city, string state, string zip, string total_cost) {
            this.o_id = o_id;
            address = street + " " + city + " " + " " + state + " " + " " + zip;
            this.total_cost = total_cost;
        }
        
    }

    class CompletedClass {
        public string o_id { get; set; }
        public string total_cost { get; set; }

        public CompletedClass(string o_id, string total_cost) {
            this.o_id = o_id;
            this.total_cost = total_cost;
        }
    }

    public partial class FDEmployee : Window {

        public FDEmployee() {
            InitializeComponent();

            GetPending();
            GetCompleted();
            
        }

        private void DoneButtonClicked(object sender, RoutedEventArgs e) {
            
            Button button = sender as Button;
            PendingClass pc = button.DataContext as PendingClass;
            try {
                var dbCon = DBConnection.Instance();
                dbCon.Open();
                string query = String.Format("UPDATE Orders SET status='Delivered' WHERE o_id='{0}'", pc.o_id);
                var cmd = new MySqlCommand(query, dbCon.Connection);
                cmd.ExecuteNonQuery();
                dbCon.Close();
            }
            catch(Exception ex) {
                Trace.WriteLine(ex);
            }
            GetPending();
            GetCompleted();

        }

        private void LogoutButtonClicked(object sender, RoutedEventArgs e) {
            MainWindow.User = null;
            MainWindow.Type = null;
            new MainWindow().Show();
            this.Close();
        }

        private void GetPending() {
            List<PendingClass> Pending = new List<PendingClass>();
            try {
                var dbCon = DBConnection.Instance();
                dbCon.Open();
                string query = String.Format("SELECT o_id, total_cost, street, city, state, zip FROM User NATURAL JOIN Orders WHERE fde_id='{0}' AND status='Pending'", MainWindow.User);
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();
                while(reader.Read()) {
                    Pending.Add(new PendingClass(reader.GetString("o_id"), reader.GetString("street"), reader.GetString("city"), reader.GetString("state"), reader.GetString("zip"), reader.GetString("total_cost")));
                }
                reader.Close();
                dbCon.Close();
                PendingList.ItemsSource = Pending;
            }
            catch(Exception ex) {
                Trace.WriteLine(ex);
            }
        }

        private void GetCompleted() {
            List<CompletedClass> Completed = new List<CompletedClass>();
            try {
                var dbCon = DBConnection.Instance();
                dbCon.Open();
                string query = String.Format("SELECT o_id, total_cost FROM Orders WHERE fde_id='{0}' AND status='Delivered'", MainWindow.User);
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();
                while(reader.Read()) {
                    Completed.Add(new CompletedClass(reader.GetString("o_id"), reader.GetString("total_cost")));
                }
                reader.Close();
                dbCon.Close();
                CompletedList.ItemsSource = Completed;
                
            }
            catch(Exception ex) {
                Trace.WriteLine(ex);
            }
        }
    }
}