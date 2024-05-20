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
    /// Interaction logic for Accounts.xaml
    /// </summary>
    public partial class Accounts : Page
    {
      DB dB= new DB();
        DataGridTextColumn a = new DataGridTextColumn();
        DataGridTextColumn b = new DataGridTextColumn();
        DataGridTextColumn c = new DataGridTextColumn();
        DataGridTextColumn d = new DataGridTextColumn();
        DataGridTextColumn f = new DataGridTextColumn();
        DataGridTextColumn  g= new DataGridTextColumn();
        DataGridTextColumn h = new DataGridTextColumn();
        DataGridTextColumn i = new DataGridTextColumn();
        DataGridTextColumn j = new DataGridTextColumn();
        DataGridTextColumn k = new DataGridTextColumn();
        
        public Accounts(string path, User user)
        {
            InitializeComponent();
            
            dB.getAllDonationCamps();
            dB.getAllUsers("Hospital");
            dB.getAllUsers("DonationCamp");
            //grdAccounts.ItemsSource=;
            
            
            
        }

        private void tabHospitals_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            
            a.Header = "ID";
            a.Binding = new Binding("ID");

            b.Header = "Name";
            b.Binding = new Binding("Name");

            c.Header = "Address";
            c.Binding = new Binding("Location.Address");

            d.Header = "Contact No";
            d.Binding = new Binding("ContactNo");

            f.Header = "Email";
            f.Binding = new Binding("Email");

            g.Header = "Status";
            g.Binding = new Binding("Status");

            h.Header = "Reg No";
            h.Binding = new Binding("RegNo");

            i.Header = "Collecting";
            i.Binding = new Binding("isCollecting");

            j.Header = "Testing";
            j.Binding = new Binding("isTesting");

            k.Header = "Open Times";
            k.Binding = new Binding("OpenTimes");

            grdAccounts.Columns.Add(a);
            grdAccounts.Columns.Add(b);
            grdAccounts.Columns.Add(h);
            grdAccounts.Columns.Add(c);
            grdAccounts.Columns.Add(i);
            grdAccounts.Columns.Add(j);
            grdAccounts.Columns.Add(d);
            grdAccounts.Columns.Add(f);
            grdAccounts.Columns.Add(k);
            grdAccounts.Columns.Add(g);
          
            grdAccounts.ItemsSource= dB.getAllHospitals();
        }
        
        private void tabDonationCamps_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
          a.Header = "ID";
            a.Binding = new Binding("ID");

            b.Header = "Name";
            b.Binding = new Binding("Name");

            c.Header = "Address";
            c.Binding = new Binding("Location.Address");

            d.Header = "Contact No";
            d.Binding = new Binding("ContactNo");

            f.Header = "Email";
            f.Binding = new Binding("Email");

            g.Header = "Status";
            g.Binding = new Binding("Status");

            h.Header = "Date";
            h.Binding = new Binding("Date");

            i.Header = "Start Time";
            i.Binding = new Binding("StartTime");

            j.Header = "End Time";
            j.Binding = new Binding("EndTime");

            grdAccounts.Columns.Add(a);
            grdAccounts.Columns.Add(b);
            grdAccounts.Columns.Add(c);
            grdAccounts.Columns.Add(h);
            grdAccounts.Columns.Add(i);
            grdAccounts.Columns.Add(j);
            grdAccounts.Columns.Add(d);
            grdAccounts.Columns.Add(f);
            grdAccounts.Columns.Add(g);

            grdAccounts.ItemsSource = dB.getAllDonationCamps();

        }
        
        private void tabHospitalUsers_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            a.Header = "ID";
            a.Binding = new Binding("Id");
            
            i.Header = "Hospital ID";
            i.Binding = new Binding("placeID");

            j.Header = "Hospital Name";
            j.Binding = new Binding("hospital.Name");
            
            b.Header = "Name";
            b.Binding = new Binding("Name");

            c.Header = "NIC";
            c.Binding = new Binding("Location.Address");

            g.Header = "Position";
            g.Binding = new Binding("Position");

            d.Header = "Contact No";
            d.Binding = new Binding("ContactNo");

            f.Header = "Email";
            f.Binding = new Binding("Email");

            h.Header = "Privilages";
            h.Binding = new Binding("Privilages");

            
            grdAccounts.Columns.Add(a);
            grdAccounts.Columns.Add(i);
            grdAccounts.Columns.Add(j);
            grdAccounts.Columns.Add(b);
            grdAccounts.Columns.Add(c);
            grdAccounts.Columns.Add(g);
            grdAccounts.Columns.Add(d);
            grdAccounts.Columns.Add(f);
            grdAccounts.Columns.Add(h);
            
            grdAccounts.ItemsSource = dB.getAllUsers("Hospital");
        }
        
        private void tabCampUsers_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            a.Header = "ID";
            a.Binding = new Binding("Id");
            
            i.Header = "Donation Camp ID";
            i.Binding = new Binding("placeID");

            j.Header = "Donation Camp Name";
            j.Binding = new Binding("donationCamp.Name");
            
            b.Header = "Name";
            b.Binding = new Binding("Name");

            c.Header = "NIC";
            c.Binding = new Binding("Location.Address");

            g.Header = "Position";
            g.Binding = new Binding("Position");

            d.Header = "Contact No";
            d.Binding = new Binding("ContactNo");

            f.Header = "Email";
            f.Binding = new Binding("Email");

            h.Header = "Privilages";
            h.Binding = new Binding("Privilages");

            
            grdAccounts.Columns.Add(a);
            grdAccounts.Columns.Add(i);
            grdAccounts.Columns.Add(j);
            grdAccounts.Columns.Add(b);
            grdAccounts.Columns.Add(c);
            grdAccounts.Columns.Add(g);
            grdAccounts.Columns.Add(d);
            grdAccounts.Columns.Add(f);
            grdAccounts.Columns.Add(h);
            
            grdAccounts.ItemsSource = dB.getAllUsers("DonationCamp");
        }
        
    }
}
