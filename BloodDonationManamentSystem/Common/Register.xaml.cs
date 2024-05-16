using BloodDonationManamentSystem.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        String path;
        MainWindow win;
        bool testing=false;
        bool collecting=false;
        DB dB = new DB();
        public Register(String path)
        {
            InitializeComponent();
            this.path = path;
            if(path=="Hospital")
            {
                EventGrid.Visibility = Visibility.Hidden;
                HospitalGrid.Visibility = Visibility.Visible;
            }
            else if (path == "Camp")
            {
                EventGrid.Visibility = Visibility.Visible;
                HospitalGrid.Visibility = Visibility.Hidden;
            }
        }
        private void winLoad()
        {
            win = (MainWindow)Window.GetWindow(this);
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            Location location = new Location();
            location.District = txtDistrict.Text;
            location.City = txtCity.Text;
            location.Address = txtAddress.Text;
            location.Coordinates = lblLocation.Content.ToString() ;
            List<TimeSpan> opening = new List<TimeSpan>();
            if (this.path == "Hospital")
            {
                Hospital hospital = new Hospital();
                hospital.Name = txtName.Text;
                hospital.Location = location;
                hospital.ContactNo = txtContact.Text;
                hospital.Email = txtEmail.Text;
                hospital.Username = txtUsername.Text;
                hospital.Password = txtPassword.Password;
                hospital.RegNo = txtRegNo.Text;
                hospital.isTesting = testing;
                hospital.isCollecting = collecting;
                hospital.OpenTimes = opening;
                dB.insertToDatabase(hospital, "Hospital");

                HospitalUser user = new HospitalUser();
user.Hospital= dB.getHospital(dB.IDCheck("Hospital", "Username", hospital.Username));
                user.Name = txtName.Text;
                user.Email = txtEmail.Text;
                user.Position = "Admin";
                user.ContactNo = txtContact.Text;
                user.UserName = txtUsername.Text;
                user.Password = txtPassword.Password;
                dB.insertToDatabase(user, "HospitalUsers");
            }
            else if (this.path == "Camp")
            {
                DonationCamp donationCamp = new DonationCamp();
                donationCamp.Name = txtName.Text;
                donationCamp.Location = location;
                donationCamp.ContactNo = txtContact.Text;
                donationCamp.Email = txtEmail.Text;
                donationCamp.Username = txtUsername.Text;
                donationCamp.Password = txtPassword.Password;
                donationCamp.Date = (DateTime)dtpDate.SelectedDate;
                donationCamp.StartTime = txtSTime.Text;
                donationCamp.EndTime = txtETime.Text;
                dB.insertToDatabase(donationCamp, "DonationCamp");
                User user = new DonationCampUser();
                user.Name = txtName.Text;
                user.Email = txtEmail.Text;
                user.Position = "Admin";
                user.ContactNo = txtContact.Text;
                user.UserName = txtUsername.Text;
                user.Password = txtPassword.Password;
                dB.insertToDatabase(user, "DonationCampUsers");
            }
            winLoad();
            win.mainFrame.Navigate(new Login(path));
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            winLoad();
            win.mainFrame.Navigate(new Login(path));
        }

        private void chkCollecting_Checked(object sender, RoutedEventArgs e)
        {
            if(chkCollecting.IsChecked==true)
            {
                collecting = true;
            }
            else
            {
                collecting = false;
            }
            
        }

        private void chkTesting_Checked(object sender, RoutedEventArgs e)
        {
            if (chkTesting.IsChecked == true)
            {
                testing = true;
            }
            else
            {
                testing = false;
            }

        }

        private void dtpDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
