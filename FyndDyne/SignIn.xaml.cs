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
            this.Hide();
            new AdminPortal().Show();
        }
    }
}
