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
        string Path;
        User User;
        public AppointmentPage(string path,User user)
        {
            InitializeComponent();
            refresh();
        }

        public void refresh()
        {
            if (Path == "Camp")
            {
                DonationCampUser loggedUser = (DonationCampUser)User;
                loggedUser.donationCamp = dB.getDonationCamp(User.placeID);
                foreach (Appointment x in dB.getAllAppointments())
                {
                    if (x.Place.ID == loggedUser.donationCamp.ID)
                    {
                        list1.Add(x);
                    }
                }
            }
            else if (Path == "Hospital")
            {
                HospitalUser loggedUser = (HospitalUser)User;
                loggedUser.hospital = dB.getHospital(loggedUser.placeID);
                foreach (Appointment x in dB.getAllAppointments())
                {
                    if (x.Place.ID == loggedUser.hospital.ID)
                    {
                        list1.Add(x);
                    }
                }

            }
            else
            {
                list1 = dB.getAllAppointments();
            }
            grdTable.ItemsSource = list1;
            cmbStatus.SelectedIndex = -1;
            cmbType.SelectedIndex = -1;
            dtpDate.SelectedDate = null;
        }
        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            grdTable.ItemsSource = list1;
            list2 = new List<Appointment>();
            string selectedType = "";
            string selectedStatus = "";
            if (cmbType.SelectedIndex != -1)
            {
                selectedType = ((ComboBoxItem)cmbType.SelectedItem).Content.ToString();
            }
            if(cmbStatus.SelectedIndex != -1)
            {
                selectedStatus = ((ComboBoxItem)cmbStatus.SelectedItem).Content.ToString();
            }
            
            if (cmbType.SelectedIndex!=-1 && cmbStatus.SelectedIndex!=-1 && dtpDate.SelectedDate!=null)
            {
                foreach(Appointment x in list1)
                {
                    if(x.Description==selectedType && x.Status==selectedStatus && x.Date.Date==dtpDate.SelectedDate)
                    {
                        list2.Add(x);
                    }
                }
            }
            else if (cmbType.SelectedIndex!=-1 && cmbStatus.SelectedIndex!=-1)
            {
                foreach (Appointment x in list1)
                {
                    if (x.Description == selectedType && x.Status == selectedStatus)
                    {
                        list2.Add(x);
                    }
                }
            }
            else if (cmbType.SelectedIndex!=-1 && dtpDate.SelectedDate!=null)
            {
                foreach (Appointment x in list1)
                {
                    if (x.Description == selectedType && x.Date.Date == dtpDate.SelectedDate)
                    {
                        list2.Add(x);
                    }
                }
            }
            else if (cmbStatus.SelectedIndex!=-1 && dtpDate.SelectedDate!=null) 
            {
                foreach (Appointment x in list1)
                {
                    if (x.Status == selectedStatus && x.Date.Date == dtpDate.SelectedDate)
                    {
                        list2.Add(x);
                    }
                }
            }
            else if (cmbType.SelectedIndex != -1)
            {
                foreach (Appointment x in list1)
                {
                    if (x.Description == selectedType)
                    {
                        list2.Add(x);
                    }
                }
            }
            else if(cmbStatus.SelectedIndex != -1)
            {
                foreach (Appointment x in list1)
                {
                    if (x.Status == selectedStatus)
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

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            refresh();
        }

        private void btnAttend_Click(object sender, RoutedEventArgs e)
        {
            Appointment appointment = (sender as Button).DataContext as Appointment;
            dB.approveAppointment(appointment);
        }
    }
}
