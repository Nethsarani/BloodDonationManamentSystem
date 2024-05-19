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
        List<Appointment> list1 = new List<Appointment>();
        List<Appointment> list2 = new List<Appointment>();
        public AppointmentPage(string path,User user)
        {
            InitializeComponent();
            
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
              list1=dB.getAllAppointments();
            }
            refresh();
        }

        public void refresh()
        {
            grdTable.ItemsSource = list1;
            cmbStatus.SelectedIndex = -1;
            cmbType.SelectedIndex = -1;
            dtpDate.SelectedDate = null;
        }
        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            if(cmbType.SelectedIndex!=-1 && cmbStatus.SelectedIndex!=-1 && dtpDate.SelectedDate!=null)
            {
                foreach(Appointment x in list1)
                {
                    if(x.Description==cmbType.SelectedItem.ToString() && x.Status==cmbStatus.SelectedItem.ToString() && x.Date.Date==dtpDate.SelectedDate)
                    {
                        list2.Add(x);
                    }
                }
            }
            else if (cmbType.SelectedIndex!=-1 && cmbStatus.SelectedIndex!=-1)
            {
                foreach (Appointment x in list1)
                {
                    if (x.Description == cmbType.SelectedItem.ToString() && x.Status == cmbStatus.SelectedItem.ToString())
                    {
                        list2.Add(x);
                    }
                }
            }
            else if (cmbType.SelectedIndex!=-1 && dtpDate.SelectedDate!=null)
            {
                foreach (Appointment x in list1)
                {
                    if (x.Description == cmbType.SelectedItem.ToString() && x.Date.Date == dtpDate.SelectedDate)
                    {
                        list2.Add(x);
                    }
                }
            }
            else if (cmbStatus.SelectedIndex!=0 && dtpDate.SelectedDate!=null) 
            {
                foreach (Appointment x in list1)
                {
                    if (x.Status == cmbStatus.SelectedItem.ToString() && x.Date.Date == dtpDate.SelectedDate)
                    {
                        list2.Add(x);
                    }
                }
            }
            else if (cmbType.SelectedIndex != 0)
            {
                foreach (Appointment x in list1)
                {
                    if (x.Description == cmbType.SelectedItem.ToString())
                    {
                        list2.Add(x);
                    }
                }
            }
            else if(cmbStatus.SelectedIndex != 0)
            {
                foreach (Appointment x in list1)
                {
                    if (x.Status == cmbStatus.SelectedItem.ToString())
                    {
                        list2.Add(x);
                    }
                }
            }
            else if(dtpDate.SelectedDate!=null)
            {
                foreach (Appointment x in list1)
                {
                    if (x.Date.Date == dtpDate.SelectedDate)
                    {
                        list2.Add(x);
                    }
                }
            }
            else
            {
                list2 = list1;
            }
            grdTable.ItemsSource = list2;
        }
    }
}
