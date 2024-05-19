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
    /// Interaction logic for HospitalDashboard.xaml
    /// </summary>

    
    public partial class HospitalDashboard : Page
    {
       MainWindow win;
        DB dB = new DB();
        public HospitalDashboard(String path, Models.User user)
        {
            InitializeComponent();
            List<Appointment> list1 = new List<Appointment>();
            List<Appointment> list2 = new List<Appointment>();
            if (path=="Camp")
            {
                subGridHos.Visibility = Visibility.Collapsed;
                DonationCampUser loggedUser= (DonationCampUser)user;
                //loggedUser.donationCamp = dB.getDonationCamp(user.placeID);
                foreach (Appointment x in dB.getAllAppointments())
                {
                    if (x.Place.ID == loggedUser.donationCamp.ID && x.Status == "Pending")
                    {
                        list1.Add(x);
                    }
                }
                

            }
            else
            {
                HospitalUser loggedUser = (HospitalUser)user;
                //loggedUser.hospital=dB.getHospital(loggedUser.placeID);
                foreach (Appointment x in dB.getAllAppointments())
                {
                    if (x.Place.ID == loggedUser.placeID && x.Status == "Pending")
                    {
                        list1.Add(x);
                    }
                } 

            }
            foreach (Appointment x in list1)
            {
                if (x.Description == "Registration")
                {
                    list2.Add(x);
                }
            }
            grdPenDonor.ItemsSource = list2;
            grdPenAppoint.ItemsSource = list1;

            grdStock.ItemsSource=dB.getTotalStock();
        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        
        private void winLoad()
        {
            win = (MainWindow)Window.GetWindow(this);
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
          winLoad();
          win.contentFrame.Navigate(new DonationPage(win.NavigationFrame.path, win.NavigationFrame.user));

        }
    }
}
