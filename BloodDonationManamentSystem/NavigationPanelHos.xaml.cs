using BloodDonationManamentSystem.Hospital_and_Blood_bank;
using BloodDonationManamentSystem.Hospital_and_Event;
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
    /// Interaction logic for NavigationPanelHos.xaml
    /// </summary>
    public partial class NavigationPanelHos : Page
    {
        MainWindow win;
        String path;
        public NavigationPanelHos(String path)
        {
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
            win.contentFrame.Navigate(new HospitalDashboard(path));
        }

        private void btnDonors_Click(object sender, RoutedEventArgs e)
        {
            win = (MainWindow)Window.GetWindow(this);
            win.contentFrame.Navigate(new DonorMap());
        }

        private void btnDonations_Click(object sender, RoutedEventArgs e)
        {
            win = (MainWindow)Window.GetWindow(this);
            win.contentFrame.Navigate(new Donation());
        }

        private void btnAppointments_Click(object sender, RoutedEventArgs e)
        {
            win = (MainWindow)Window.GetWindow(this);
            win.contentFrame.Navigate(new AppointmentPage());
        }

        private void btnStock_Click(object sender, RoutedEventArgs e)
        {
            win = (MainWindow)Window.GetWindow(this);
            win.contentFrame.Navigate(new Blood_Stock());
        }

        private void btnACManager_Click(object sender, RoutedEventArgs e)
        {
            win = (MainWindow)Window.GetWindow(this);
            win.contentFrame.Navigate(new InternalAccountManager());
        }

        private void btnAccounts_Click(object sender, RoutedEventArgs e)
        {
            win = (MainWindow)Window.GetWindow(this);
            win.contentFrame.Navigate(new Accounts());
        }
    }
}
