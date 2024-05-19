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

namespace BloodDonationManamentSystem.Hospital_and_Blood_bank
{
    /// <summary>
    /// Interaction logic for Blood_Stock.xaml
    /// </summary>
    public partial class Blood_Stock : Page
    {
      DB dB=new DB();
        public Blood_Stock(string path, User user)
        {
            InitializeComponent();
            grdStock.ItemSource=dB.getTotalStock();
        }
    }
}
