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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        String path;
        MainWindow win;
        DB dB=new DB();
        public Login(String path)
        {
            this.path = path;
            InitializeComponent();
            lblError.Visibility = Visibility.Hidden;
            if (path=="Bank")
            {
                lblRegister.Visibility = Visibility.Hidden;
                btnReg.Visibility = Visibility.Hidden;
            }
            lblRegister.Content = "Register as a new " + path;
        }

        private void winLoad()
        {
            win = (MainWindow)Window.GetWindow(this);
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            winLoad();
            win.mainFrame.Navigate(new Register(path));
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            winLoad();
            //Models.User user;
            if (this.path == "Hospital")
            {
                HospitalUser user =(HospitalUser)dB.Login(txtUsername.Text, txtPassword.Password, "HospitalUsers");
                
                //Canvas.SetZIndex(win.mainFrame, 0);
                if(user!=null)
                {
                    user.hospital = dB.getHospital(user.placeID);
                    win.mainFrame.Visibility = Visibility.Collapsed;
                    win.contentFrame.Navigate(new HospitalDashboard(path, user));
                    win.navigationFrame.Navigate(new NavigationPanelHos(path, user));
                    win.topFrame.Navigate(new TopBar());
                }
                else
                {
                    lblError.Visibility = Visibility.Visible;
                }
            }
            else if(this.path == "Camp")
            {
                DonationCampUser user = (DonationCampUser) dB.Login(txtUsername.Text, txtPassword.Password, "DonationCampUsers");
                user.donationCamp=dB.getDonationCamp(user.placeID);
                if (user != null)
                {
                    win.mainFrame.Visibility = Visibility.Collapsed;
                    win.contentFrame.Navigate(new HospitalDashboard(path, user));
                    win.navigationFrame.Navigate(new NavigationPanelHos(path, user));
                    win.topFrame.Navigate(new TopBar());
                }
                else { lblError.Visibility = Visibility.Visible; }
                    
            }
            else if(this.path == "Bank")
            {
                User user = dB.Login(txtUsername.Text, txtPassword.Password, "BloodBankUsers");
                if (user != null)
                {
                    win.mainFrame.Visibility = Visibility.Collapsed;
                    win.contentFrame.Navigate(new bankDashboard(user));
                    win.navigationFrame.Navigate(new NavigationPanelHos(path, user));
                    win.topFrame.Navigate(new TopBar());
                }
                else { lblError.Visibility = Visibility.Visible; }
                    
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            winLoad();
            win.mainFrame.Navigate(new Home());
        }

        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            //lblError.Visibility = Visibility.Collapsed;
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            lblError.Visibility = Visibility.Hidden;
        }

        private void lblError_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }
    }
}
