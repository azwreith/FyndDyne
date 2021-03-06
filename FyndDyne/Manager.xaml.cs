﻿using System;
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
    /// Interaction logic for Manager.xaml
    /// </summary>
    public partial class Manager : Window
    {
        public Manager()
        {
            InitializeComponent();
        }

        private void LogoutButtonClicked(object sender, RoutedEventArgs e)
        {
            MainWindow.User = null;
            MainWindow.Type = null;
            new MainWindow().Show();
            this.Close();
        }


        private void DoneButtonClicked(object sender, RoutedEventArgs e)
        {

        }

        private void ShowPendingOrders(object sender, RoutedEventArgs e)
        {
            Pending.Visibility = Visibility.Visible;
            Orders.Visibility = Visibility.Hidden;
            AddItem.Visibility = Visibility.Hidden;
        }

        private void AddItems(object sender, RoutedEventArgs e)
        {
            Pending.Visibility = Visibility.Hidden;
            Orders.Visibility = Visibility.Hidden;
            AddItem.Visibility = Visibility.Visible;
        }

        private void ViewOrders(object sender, RoutedEventArgs e)
        {
            Pending.Visibility = Visibility.Hidden;
            Orders.Visibility = Visibility.Visible;
            AddItem.Visibility = Visibility.Hidden;
        }

        private void SubmitButtonClicked(object sender, RoutedEventArgs e) {
        }


    }
}
