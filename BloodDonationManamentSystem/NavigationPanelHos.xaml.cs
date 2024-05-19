using BloodDonationManamentSystem.Hospital_and_Blood_bank;
using BloodDonationManamentSystem.Hospital_and_Event;
using BloodDonationManamentSystem.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BloodDonationManamentSystem
{
    /// <summary>
    /// Interaction logic for NavigationPanelHos.xaml
    /// </summary>
    public partial class NavigationPanelHos : Page
    {
        MainWindow win;
        String path;
        User loggedUser;
        public NavigationPanelHos(String path, User user)
        {
            loggedUser = user;
            InitializeComponent();
            this.path = path;
            if (path =="Camp" )
            {
                btnDonors.Visibility = Visibility.Collapsed;
                btnStock.Visibility = Visibility.Collapsed;
                btnAccounts.Visibility = Visibility.Collapsed;
            }
            if (path == "Hospital")
            {
                btnAccounts.Visibility = Visibility.Collapsed;
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            win = (MainWindow)Window.GetWindow(this);
            if(path=="Camp" || path=="Hospital")
            {
                win.contentFrame.Navigate(new HospitalDashboard(path, loggedUser));
            }
            else
            {
                win.contentFrame.Navigate(new bankDashboard(loggedUser));
            }
            
        }

        private void btnDonors_Click(object sender, RoutedEventArgs e)
        {
            win = (MainWindow)Window.GetWindow(this);
            win.contentFrame.Navigate(new DonorMap(path, loggedUser));
        }

        private void btnDonations_Click(object sender, RoutedEventArgs e)
        {
            win = (MainWindow)Window.GetWindow(this);
            win.contentFrame.Navigate(new DonationPage(path,loggedUser));
        }

        private void btnAppointments_Click(object sender, RoutedEventArgs e)
        {
            win = (MainWindow)Window.GetWindow(this);
            win.contentFrame.Navigate(new AppointmentPage(path,loggedUser));
        }

        private void btnStock_Click(object sender, RoutedEventArgs e)
        {
            win = (MainWindow)Window.GetWindow(this);
            win.contentFrame.Navigate(new Blood_Stock(path, loggedUser));
        }

        private void btnACManager_Click(object sender, RoutedEventArgs e)
        {
            win = (MainWindow)Window.GetWindow(this);
            win.contentFrame.Navigate(new InternalAccountManager(path, loggedUser));
        }

        private void btnAccounts_Click(object sender, RoutedEventArgs e)
        {
            win = (MainWindow)Window.GetWindow(this);
            win.contentFrame.Navigate(new Accounts(path, loggedUser));
        }
    }
}
