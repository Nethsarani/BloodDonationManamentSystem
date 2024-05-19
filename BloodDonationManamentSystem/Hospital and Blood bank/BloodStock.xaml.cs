using BloodDonationManamentSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace BloodDonationManamentSystem.Hospital_and_Blood_bank
{
    /// <summary>
    /// Interaction logic for Blood_Stock.xaml
    /// </summary>
    public partial class Blood_Stock : Page
    {
      DB dB=new DB();
        List<BloodStock> list1 = new List<BloodStock>();
        List<BloodStock> list2 = new List<BloodStock>();
        public Blood_Stock(string path, User user)
        {
            InitializeComponent();
            
        }

        public void refresh()
        {
            list1=dB.getAllStock();
            grdStock.ItemsSource = list1;
            cmbType.SelectedIndex = -1;
            cmbDistrict.SelectedIndex = -1;
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            refresh();
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            grdStock.ItemsSource = list1;
            list2 = new List<BloodStock>();
            string selectedType = "";
            string selectedDistrict = "";
            if (cmbType.SelectedIndex != -1)
            {
                selectedType = ((ComboBoxItem)cmbType.SelectedItem).Content.ToString();
            }
            if (cmbDistrict.SelectedIndex != -1)
            {
                selectedDistrict = ((ComboBoxItem)cmbDistrict.SelectedItem).Content.ToString();
            }
            if (cmbType.SelectedIndex != -1 && cmbDistrict.SelectedIndex!=-1)
            {
                foreach (BloodStock stock in list1)
                {
                    if(stock.Location.District==selectedDistrict && stock.BloodType==selectedType)
                    {
                        list2.Add(stock);
                    }
                }
            }
            else if(cmbType.SelectedIndex != -1)
            {
                foreach (BloodStock stock in list1)
                {
                    if (stock.BloodType == selectedType)
                    {
                        list2.Add(stock);
                    }
                }
            }
            else if (cmbDistrict.SelectedIndex != -1)
            {
                foreach (BloodStock stock in list1)
                {
                    if (stock.Location.District == selectedDistrict)
                    {
                        list2.Add(stock);
                    }
                }
            }
            else
            {
                list2 = list1;
            }
            grdStock.ItemsSource = list2;

        }
    }
}
