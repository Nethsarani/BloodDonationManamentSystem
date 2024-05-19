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
    /// Interaction logic for TopBar.xaml
    /// </summary>
    public partial class TopBar : Page
    {
        MainWindow win;
        public TopBar(User user)
        {
            InitializeComponent();
            lblUser.Content = "Logged in as: " + user.Name; 
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            win = (MainWindow)Window.GetWindow(this);
            win.contentFrame.Navigate(new DonorApproval());
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            win = (MainWindow)Window.GetWindow(this);
            win.mainFrame.Navigate(new Home());
            win.contentFrame.Navigate(null);
            win.topFrame.Navigate(null);
            win.navigationFrame.Navigate(null);
        }
    }
}
