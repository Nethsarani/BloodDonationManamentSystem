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
    /// Interaction logic for HospitalDashboard.xaml
    /// </summary>
    public partial class HospitalDashboard : Page
    {
        public HospitalDashboard(String path, Models.User user)
        {
            InitializeComponent();
            if(path=="Camp")
            {
                subGridHos.Visibility = Visibility.Collapsed;
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
