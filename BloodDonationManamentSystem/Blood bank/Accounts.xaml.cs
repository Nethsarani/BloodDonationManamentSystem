using BloodDonationManamentSystem.Models;
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
    /// Interaction logic for Accounts.xaml
    /// </summary>
    public partial class Accounts : Page
    {
      DB dB= new DB();
        public Accounts(string path, User user)
        {
            InitializeComponent();
            dB.getAllHospitals();
            dB.getAllDonationCamps();
            dB.getAllDonors();
            dB.getAllUsers("Hospital");
            dB.getAllUsers("DonationCamp");
            dB.getAllUsers("BloodBank");
            grdAccounts.ItemsSource=;
            
            DataGridTextColumn a= new DataGridTextColumn();
            a.Header="ID";
            a.Binding="{Binding ID}"
            DataGridTextColumn a= new DataGridTextColumn();
            a.Header="ID";
            a.Binding="{Binding ID}"
            DataGridTextColumn a= new DataGridTextColumn();
            a.Header="ID";
            a.Binding="{Binding ID}"
            DataGridTextColumn a= new DataGridTextColumn();
            a.Header="ID";
            a.Binding="{Binding ID}"
            DataGridTextColumn a= new DataGridTextColumn();
            a.Header="ID";
            a.Binding="{Binding ID}"
            
            grdAccounts.Columns.AddRange(a,b);
        }
    }
}
