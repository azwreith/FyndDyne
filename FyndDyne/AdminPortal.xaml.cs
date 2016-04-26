using System;
using System.Collections.Generic;
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
    }
}
