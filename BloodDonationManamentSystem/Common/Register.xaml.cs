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
        }
        private void winLoad()
        {
            win = (MainWindow)Window.GetWindow(this);
        }

        

        

        

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            Location location = new Location();
            List<TimeSpan> opening = new List<TimeSpan>();
            if (this.path == "Hospital")
            {
                Hospital hospital = new Hospital(txtName.Text,location,txtContact.Text,txtEmail.Text,txtUsername.Text,txtPassword.Password,txtRegNo.Text ,testing,collecting,opening);
                dB.insertToDatabase(hospital, "Hospital");
            }
            else if (this.path == "Camp")
            {
                DonationCamp donationCamp = new DonationCamp(txtName.Text, location, txtContact.Text, txtEmail.Text, txtUsername.Text, txtPassword.Password, dtpDate.SelectedDate,txtSTime.Text,txtETime.Text);
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
    }
}
