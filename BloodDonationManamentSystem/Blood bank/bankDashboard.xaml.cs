﻿using BloodDonationManamentSystem.Models;
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

namespace BloodDonationManamentSystem
{
    /// <summary>
    /// Interaction logic for bankDashboard.xaml
    /// </summary>
    public partial class bankDashboard : Page
    {
        DB dB=new DB();
        public bankDashboard(User user)
        {
            InitializeComponent();
            grdRequest.ItemsSource = dB.getAllRequests();
            grdPenHos.ItemsSource = dB.getAllHospitals();
            grdPenCamp.ItemsSource= dB.getAllDonationCamps();
            grdStock.ItemsSource=dB.getTotalStock();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnApprove_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
