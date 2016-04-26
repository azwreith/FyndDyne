using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Windows;

namespace FyndDyne {
    /// <summary>
    /// Interaction logic for SignIn.xaml
    /// </summary>
    public partial class SignIn : Window
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void SignUpButtonClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new Register().Show();
        }


        private void SubmitButtonClick(object sender, RoutedEventArgs e)
        {
            string query = null ;
            try {
                var dbCon = DBConnection.Instance();
                dbCon.Open();

                switch(UserType.Text) {
                    case "Customer":
                    query = "SELECT * FROM User WHERE u_id='" + UserName.Text +
                        "' AND password='" + Utilities.MD5(Password.Password) + "'";
                    break;

                    case "FD Employee":
                    query = "SELECT * FROM FD_Employee WHERE fde_id='" + UserName.Text +
                         "' AND password='" + Utilities.MD5(Password.Password) + "'";
                    break;

                    case "Manager":
                    query = "SELECT * FROM Manager WHERE m_id='" + UserName.Text +
                       "' AND password='" + Utilities.MD5(Password.Password) + "'";
                    break;
                }
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();
                if(reader.Read()) {
                    MainWindow.User = reader.GetString(0);
                    Trace.WriteLine(MainWindow.User + " " + MainWindow.Type);
                    if(UserType.Text == "Customer") {
                        MainWindow.Type = UserType.Text;
                        reader.Close();
                        dbCon.Close();
                        this.Close();
                        new MainWindow().Show();
                    }
                    else if(UserType.Text == "FD Employee") {
                        MainWindow.Type = reader.GetString("user_level");
                        if(MainWindow.Type == "Admin") {
                            reader.Close();
                            dbCon.Close();
                            this.Close();
                            new AdminPortal().Show();
                        }
                        else {
                            reader.Close();
                            dbCon.Close();
                            this.Close();
                            new FDEmployee().Show();
                        }
                    }
                    else if(UserType.Text == "Manager") {
                        MainWindow.Type = UserType.Text;
                        reader.Close();
                        dbCon.Close();
                        this.Close();
                        //TODO add Manager Window
                    }
                }
                else {
                    reader.Close();
                    dbCon.Close();
                    MessageBox.Show("Invalid User/Pass", "Error");
                }
            }
            catch(MySqlException ex) {
                Trace.WriteLine(ex);
            }
        }
    }
}
