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
    /// Interaction logic for Appointment.xaml
    /// </summary>
    public partial class AppointmentPage : Page
    {
        DB dB = new DB();
        public AppointmentPage(string path,User user)
        {
            InitializeComponent();
            List<Appointment> list1 = new List<Appointment>();
            if (path == "Camp")
            {
                DonationCampUser loggedUser = (DonationCampUser)user;
                loggedUser.donationCamp = dB.getDonationCamp(user.placeID);
                foreach (Appointment x in dB.getAllAppointments())
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
                foreach (Appointment x in dB.getAllAppointments())
                {
                    if (x.Place.ID == loggedUser.hospital.ID)
                    {
                        list1.Add(x);
                    }
                }

            }
            else{
              list1=getAllAppointments();
            }
            grdTable.ItemsSource = list1;
        }
    }
}
