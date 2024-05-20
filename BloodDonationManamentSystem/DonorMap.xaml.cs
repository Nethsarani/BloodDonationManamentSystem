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
using System.Xml.Linq;

namespace BloodDonationManamentSystem
{
    /// <summary>
    /// Interaction logic for DonorMap.xaml
    /// </summary>
    public partial class DonorMap : Page
    {
        String ur1 = AppDomain.CurrentDomain.BaseDirectory;
        String ur2;
        String sURL = AppDomain.CurrentDomain.BaseDirectory + "html/map.html";
        DB dB=new DB();
        List<Donor> list1 = new List<Donor>();
        List<Donor> list2 = new List<Donor>();
        MainWindow win;
        string Path;
        User User;
        public DonorMap(string path, User user)
        {
            InitializeComponent();
            ur1 = ur1.Remove(ur1.Length - 10);
            ur2=ur1+ "html/map.html";
            //MessageBox.Show(ur2);
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
            
            Uri uri = new Uri(ur2);
            webBrowser1.Navigate(uri);
            Map();

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

        
        private void Directions()
        {
            if (File.Exists(ur1 + "html\\map_route.html"))
            {
                StreamReader objReader = new StreamReader(ur1 + "html\\map_route.html");
                string line = "";
                line = objReader.ReadToEnd();
                objReader.Close();
                line = line.Replace("[origin]", coordinates);
                line = line.Replace("[destination]", "25.520581, -103.50607");
                StreamWriter page = File.CreateText(ur1 + "html\\map1.html");
                page.Write(line);
                page.Close();
                Uri uri = new Uri(ur1 + "html\\map1.html");
                webBrowser1.Navigate(uri);
                //datos.Width = 140;
            }
        }

        string locName;
        string direct;
        string coordinates= ((MainWindow)Application.Current.MainWindow).coordinates.Content.ToString();

        private void Map()
        {
            Uri uri = new Uri(ur2);
            webBrowser1.Navigate(uri);
        }
        private void setupObjectForScripting(object sender, RoutedEventArgs e)
        {
            ((WebBrowser)sender).ObjectForScripting = new HtmlInteropInternalTestClass();
        }
        private void Marker()
        {
            webBrowser1.InvokeScript("addMarker", new Object[] { 25.520581, -103.40607, locName, "client1.png", direct });
        }

        private void grdDonors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

    // Object used for communication from JS -> WPF
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public class HtmlInteropInternalTestClass
    {
        public void endDragMarkerCS(Decimal Lat, Decimal Lng)
        {
            ((MainWindow)Application.Current.MainWindow).coordinates.Content = Math.Round(Lat, 5) + "," + Math.Round(Lng, 5);
        }
    }


}
