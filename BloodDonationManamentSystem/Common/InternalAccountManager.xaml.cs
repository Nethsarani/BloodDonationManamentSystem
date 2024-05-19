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
    /// Interaction logic for InternalAccountManager.xaml
    /// </summary>
    public partial class InternalAccountManager : Page
    {
      DB dB=new DB();
        public InternalAccountManager(string path, User user)
        {
            InitializeComponent();
            List<User> list1 = new List<User>();
            if (path=="Camp")
            {
                DonationCampUser loggedUser= (DonationCampUser)user;
                //loggedUser.donationCamp = dB.getDonationCamp(user.placeID);
                foreach (User x in dB.getAllUsers("DonationCamp"))
                {
                    if (x.placeID == loggedUser.placeID)
                    {
                        list1.Add(x);
                    }
                }
            }
            else if(path=="Hospital")
            {
                HospitalUser loggedUser = (HospitalUser)user;
                //loggedUser.hospital=dB.getHospital(loggedUser.placeID);
                foreach (HospitalUser x in dB.getAllUsers("Hospital"))
                {
                    if (x.placeID == loggedUser.placeID)
                    {
                        list1.Add(x);
                    }
                } 
            }
            else{
              list1=dB.getAllUsers("BloodBank");
            }
            grdAccounts.ItemsSource=list1;
        }
    }
}
