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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        String path;
        MainWindow win;
        public Login(String path)
        {
            this.path = path;
            InitializeComponent();
        }

        private void winLoad()
        {
            win = (MainWindow)Window.GetWindow(this);
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            winLoad();
            win.mainFrame.Navigate(new Register(path));
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            winLoad();
            if (this.path == "Hospital")
            {
                //Canvas.SetZIndex(win.mainFrame, 0);
                win.mainFrame.Visibility = Visibility.Collapsed;
                win.contentFrame.Navigate(new HospitalDashboard());
                win.navigationFrame.Navigate(new NavigationPanelHos());
            }
            else if(this.path == "Camp")
            {
                win.mainFrame.Visibility = Visibility.Collapsed;
                //win.contentFrame.Navigate (new ());
            }
            else if(this.path == "Bank")
            {
                win.mainFrame.Visibility = Visibility.Collapsed;
                win.contentFrame.Navigate(new bankDashboard());
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            winLoad();
            win.mainFrame.Navigate(new Home());
        }
    }
}
