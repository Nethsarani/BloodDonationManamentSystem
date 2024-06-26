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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace BloodDonationManamentSystem
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        DB dB = new DB();
        MainWindow win ;
        public Home()
        {       
            InitializeComponent();
        }

        private void winLoad()
        {
            win = (MainWindow)Window.GetWindow(this);
        }

        private void btnHospital_Click(object sender, RoutedEventArgs e)
        {
            //dB.TestData();   
            winLoad();
            win.mainFrame.Navigate(new Login("Hospital"));
        }

        private void btnCamp_Click(object sender, RoutedEventArgs e)
        {
            winLoad();
            win.mainFrame.Navigate(new Login("Camp"));
        }

        private void btnBank_Click(object sender, RoutedEventArgs e)
        {
            winLoad();
            win.mainFrame.Navigate(new Login("Bank"));
        }
    }
}
