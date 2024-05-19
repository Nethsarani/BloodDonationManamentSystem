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
    /// Interaction logic for DonorMap.xaml
    /// </summary>
    public partial class DonorMap : Page
    {
        DB dB=new DB();
        List<Donor> list1 = new List<Donor>();
        List<Donor> list2 = new List<Donor>();
        MainWindow win;
        string Path;
        User User;
        public DonorMap(string path, User user)
        {
            InitializeComponent();
            
            if (path=="Camp")
            {
                DonationCampUser loggedUser= (DonationCampUser)user;
                //loggedUser.donationCamp = dB.getDonationCamp(user.placeID);
            }
            else if (path=="Hospital")
            {
                HospitalUser loggedUser = (HospitalUser)user;
                //loggedUser.hospital=dB.getHospital(loggedUser.placeID);
            }
            refresh();
            win = (MainWindow)Window.GetWindow(this);
            Path= path;
            User = user;

        }

        public void refresh()
        {
            list1 = dB.getAllDonors();
            grdDonors.ItemsSource = list1;
            cmbType.SelectedIndex = -1;
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            grdDonors.ItemsSource=list1;
            list2=new List<Donor>();
            string type="";
            if (cmbType.SelectedIndex!=-1)
            {
                ComboBoxItem selected = cmbType.SelectedItem as ComboBoxItem;
                type = selected.Content.ToString();
            }
            
            foreach (Donor donor in list1)
            {
                if (donor.BloodType == type)
                {
                    list2.Add(donor);
                }
            }
            grdDonors.ItemsSource= list2;
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            refresh();
        }

        private void btnApprove_Click(object sender, RoutedEventArgs e)
        {
            Donor don = (sender as Button).DataContext as Donor;
            win.contentFrame.Navigate(new DonorApproval(don,Path,User));
        }
    }
}
