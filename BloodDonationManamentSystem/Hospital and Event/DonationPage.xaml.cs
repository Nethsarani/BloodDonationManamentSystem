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
        public DonationPage(string path, User user)
        {
            InitializeComponent();
            List<Donation> list1 = new List<Donation>();
            if (path == "Camp")
            {
                DonationCampUser loggedUser = (DonationCampUser)user;
                loggedUser.donationCamp = dB.getDonationCamp(user.placeID);
                foreach (Donation x in dB.getAllDonations())
                {
                    if (x.Place.ID == loggedUser.donationCamp.ID)
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
                    if (x.Place.ID == loggedUser.hospital.ID)
                    {
                        list1.Add(x);
                    }
                }
            }
            else{
              list1=dB.getAllDonations();
            }
            grdDonations.ItemSource=list1;
        }
    }
}
