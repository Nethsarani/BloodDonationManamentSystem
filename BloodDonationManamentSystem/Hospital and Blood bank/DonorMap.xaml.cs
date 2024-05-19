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
    /// Interaction logic for DonorMap.xaml
    /// </summary>
    public partial class DonorMap : Page
    {
        public DonorMap(string path, User user)
        {
            InitializeComponent();
            List<Appointment> list1 = new List<Appointment>();
            if (path=="Camp")
            {
                DonationCampUser loggedUser= (DonationCampUser)user;
                //loggedUser.donationCamp = dB.getDonationCamp(user.placeID);
            }
            else
            {
                HospitalUser loggedUser = (HospitalUser)user;
                //loggedUser.hospital=dB.getHospital(loggedUser.placeID);
            }
            grdDonors.ItemSource=dB.getAllDonors();
        }
    }
}
