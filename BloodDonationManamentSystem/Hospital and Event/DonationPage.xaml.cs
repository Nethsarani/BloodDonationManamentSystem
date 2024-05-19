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

namespace BloodDonationManamentSystem.Hospital_and_Event
{
    /// <summary>
    /// Interaction logic for Donation.xaml
    /// </summary>
    public partial class DonationPage : Page
    {
        DB dB=new DB();
        List<Donation> list1 = new List<Donation>();
        List<Donation> list2 = new List<Donation>();
        public DonationPage(string path, User user)
        {
            InitializeComponent();
            
            if (path == "Camp")
            {
                DonationCampUser loggedUser = (DonationCampUser)user;
                loggedUser.donationCamp = dB.getDonationCamp(user.placeID);
                foreach (Donation x in dB.getAllDonations())
                {
                    if (x.collectionPoint.ID == loggedUser.donationCamp.ID)
                    {
                        list1.Add(x);
                    }
                }
            }
            else if(path=="Hospital")
            {
                HospitalUser loggedUser = (HospitalUser)user;
                loggedUser.hospital = dB.getHospital(loggedUser.placeID);
                foreach (Donation x in dB.getAllDonations())
                {
                    if (x.collectionPoint.ID == loggedUser.hospital.ID)
                    {
                        list1.Add(x);
                    }
                }
            }
            else{
              list1=dB.getAllDonations();
            }
            refresh();
        }

        public void refresh()
        {
            grdDonations.ItemsSource = list1;
            cmbType.SelectedIndex = -1;
            dtpDate.SelectedDate = null;
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            if (cmbType.SelectedIndex != -1 && dtpDate.SelectedDate != null)
            {
                foreach (Donation x in list1)
                {
                    if (x.Donor.BloodType == cmbType.SelectedItem.ToString() && x.Date==dtpDate.SelectedDate)
                    {
                        list2.Add(x);
                    }
                }
            }
            else if(cmbType.SelectedIndex!=-1)
            {
                foreach (Donation x in list1)
                {
                    if (x.Donor.BloodType == cmbType.SelectedItem.ToString())
                    {
                        list2.Add(x);
                    }
                }
            }
            else if(dtpDate.SelectedDate!=null)
            {
                foreach (Donation x in list1)
                {
                    if (x.Date == dtpDate.SelectedDate)
                    {
                        list2.Add(x);
                    }
                }
            }
            else
            {
                list2 = list1;
            }   
            grdDonations.ItemsSource = list2;
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            refresh();
        }
    }
}
