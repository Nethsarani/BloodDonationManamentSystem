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
using Xceed.Wpf.Toolkit;

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
            txtDistrict.ItemsSource = dB.getDistrict();
            
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
            List<TimeRange> opening = new List<TimeRange>();
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
                TimeRange a = new TimeRange() { Date = "Monday", Open = txtO11.Value.ToString(), Close = txtO12.Value.ToString() };
                TimeRange b = new TimeRange() { Date = "Tuesday", Open = txtO21.Value.ToString(), Close = txtO22.Value.ToString() };
                TimeRange c = new TimeRange() { Date = "Wednesday", Open = txtO31.Value.ToString(), Close = txtO32.Value.ToString() };
                TimeRange d = new TimeRange() { Date = "Thursday", Open = txtO41.Value.ToString(), Close = txtO42.Value.ToString() };
                TimeRange f = new TimeRange() { Date = "Friday", Open = txtO51.Value.ToString(), Close = txtO52.Value.ToString() };
                TimeRange g = new TimeRange() { Date = "Saturday", Open = txtO61.Value.ToString(), Close = txtO62.Value.ToString() };
                TimeRange h = new TimeRange() { Date = "Sunday", Open = txtO71.Value.ToString(), Close = txtO72.Value.ToString() };
                opening.Add(a);
                opening.Add(b);
                opening.Add(c);
                opening.Add(d);
                opening.Add(f);
                opening.Add(g);
                opening.Add(h);
                hospital.OpenTimes = opening;
                hospital.Status = "Pending";
                dB.insertToDatabase(hospital, "Hospital");

                HospitalUser user = new HospitalUser();
                System.Windows.MessageBox.Show(dB.IDCheck("Hospital", hospital.Username, "Username").ToString());
                System.Windows.MessageBox.Show(dB.getHospital(dB.IDCheck("Hospital", hospital.Username, "Username")).ID.ToString());
                user.hospital= dB.getHospital(dB.IDCheck("Hospital",  hospital.Username, "Username"));
                user.Name = txtName.Text;
                user.Email = txtEmail.Text;
                user.NIC="00000000";
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
                donationCamp.StartTime = pckSTime.Value.ToString();
                donationCamp.EndTime = pckETime.Value.ToString();
                donationCamp.Status = "Pending";
                dB.insertToDatabase(donationCamp, "DonationCamp");
                DonationCampUser user = new DonationCampUser();
                user.donationCamp= dB.getDonationCamp(dB.IDCheck("DonationCamp", donationCamp.Username, "Username"));
                user.Name = txtName.Text;
                user.Email = txtEmail.Text;
                user.NIC = "00000000"; 
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

        private void txtDistrict_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtCity.ItemsSource = dB.getCity(txtDistrict.SelectedItem.ToString());
        }

        private void refresh()
        {
            btnReg.IsEnabled = true;
            if (txtName.Text == "")
            {
                txtName.BorderBrush = new SolidColorBrush(Color.FromArgb(100,255,0,0));
                btnReg.IsEnabled = false;
            }
            if (txtRegNo.Text == "")
            {
                txtRegNo.BorderBrush = new SolidColorBrush(Color.FromArgb(100, 255, 0, 0));
                btnReg.IsEnabled = false;
            }
            if (txtAddress.Text == "")
            {
                txtAddress.BorderBrush = new SolidColorBrush(Color.FromArgb(100, 255, 0, 0));
                btnReg.IsEnabled = false;
            }
            if (txtDistrict.SelectedIndex == -1)
            {
                txtDistrict.BorderBrush = new SolidColorBrush(Color.FromArgb(100, 255, 0, 0));
                btnReg.IsEnabled = false;
            }
            if (txtCity.SelectedIndex == -1)
            {
                txtCity.BorderBrush = new SolidColorBrush(Color.FromArgb(100, 255, 0, 0));
                btnReg.IsEnabled = false;
            }
            if (txtContact.Text == "")
            {
                txtContact.BorderBrush = new SolidColorBrush(Color.FromArgb(100, 255, 0, 0));
                btnReg.IsEnabled = false;
            }
            if (txtEmail.Text == "")
            {
                txtEmail.BorderBrush = new SolidColorBrush(Color.FromArgb(100, 255, 0, 0));
                btnReg.IsEnabled = false;
            }
            if (txtUsername.Text == "" || dB.userCheck(path, txtUsername.Text) == false)
            {
                txtUsername.BorderBrush = new SolidColorBrush(Color.FromArgb(100, 255, 0, 0));
                btnReg.IsEnabled = false;
            }
            if (txtPassword.Password == "" || txtPassword.Password.Length < 8)
            {
                txtPassword.BorderBrush = new SolidColorBrush(Color.FromArgb(100, 255, 0, 0));
                btnReg.IsEnabled = false;
            }
            if (txtRePassword.Password != txtPassword.Password)
            {
                txtRePassword.BorderBrush = new SolidColorBrush(Color.FromArgb(100, 255, 0, 0));
                btnReg.IsEnabled = false;
            }
        }

        private void txtContact_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtContact.BorderBrush = new SolidColorBrush(Color.FromArgb(100, 171, 173, 179));
            refresh();
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtEmail.BorderBrush = new SolidColorBrush(Color.FromArgb(100, 171, 173, 179));
            refresh();
        }

        private void txtAddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtAddress.BorderBrush = new SolidColorBrush(Color.FromArgb(100, 171, 173, 179));
            refresh();
        }

        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtUsername.BorderBrush = new SolidColorBrush(Color.FromArgb(100, 171, 173, 179));
            refresh();
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            txtPassword.BorderBrush = new SolidColorBrush(Color.FromArgb(100, 171, 173, 179));
            refresh();
        }

        private void txtRePassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            txtRePassword.BorderBrush = new SolidColorBrush(Color.FromArgb(100, 171, 173, 179));
            refresh();
        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtName.BorderBrush = new SolidColorBrush(Color.FromArgb(100, 171, 173, 179));
            refresh();
        }

        private void txtRegNo_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtRegNo.BorderBrush = new SolidColorBrush(Color.FromArgb(100, 171, 173, 179));
            refresh();
        }
    }
}
