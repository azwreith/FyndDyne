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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FyndDyne
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
    }
}
