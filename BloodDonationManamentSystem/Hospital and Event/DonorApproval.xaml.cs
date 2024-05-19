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
    /// Interaction logic for DonorApproval.xaml
    /// </summary>
    public partial class DonorApproval : Page
    {
        DB dB=new DB();
        Donor loggedDonor;
        MainWindow win;
        string Path;
        User User;
        public DonorApproval(Donor donor, string path, User user)
        {
            InitializeComponent();
            txtName.Text = donor.Name;
            txtNIC.Text = donor.NIC;
            txtEmail.Text = donor.Email;
            txtContactNo.Text = donor.ContactNo;
            txtAddress.Text=donor.Location.Address;
            cmbGender.SelectedItem = donor.Gender;
            cmbDistrict.SelectedItem = donor.Location.District;
            cmbCity.SelectedItem = donor.Location.City;
            cmbType.SelectedItem = donor.BloodType;
            dtpDOB.SelectedDate = donor.DOB.Date;
            loggedDonor= donor;
            Path = path;
            User = user;
        }

        public void refresh()
        {
            chkSuitable.IsChecked = true;
            btnApprove.IsEnabled = true;
            if(string.IsNullOrWhiteSpace(txtName.Text))
            {
                chkSuitable.IsChecked = false;
            }
            if (string.IsNullOrWhiteSpace(txtNIC.Text))
            {
                chkSuitable.IsChecked = false;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                chkSuitable.IsChecked = false;
            }
            if (string.IsNullOrWhiteSpace(txtContactNo.Text))
            {
                chkSuitable.IsChecked = false;
            }
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                chkSuitable.IsChecked = false;
            }
            if (cmbGender.SelectedIndex==-1)
            {
                chkSuitable.IsChecked = false;
            }
            if (cmbDistrict.SelectedIndex==-1)
            {
                chkSuitable.IsChecked = false;
            }
            if (cmbCity.SelectedIndex==-1)
            {
                chkSuitable.IsChecked = false;
            }
            if (cmbType.SelectedIndex==-1)
            {
                chkSuitable.IsChecked = false;
            }
            if (dtpDOB.SelectedDate==null)
            {
                chkSuitable.IsChecked = false;
            }
            if (string.IsNullOrWhiteSpace(txtWeight.Text))
            {
                chkSuitable.IsChecked = false;
            }
            if (string.IsNullOrWhiteSpace(txtHemo.Text))
            {
                chkSuitable.IsChecked = false;
            }
            if (chkGen.IsChecked==false)
            {
                chkSuitable.IsChecked = false;
            }
            if (chkOther.IsChecked == false)
            {
                chkSuitable.IsChecked = false;
            }
            if (chkSurgHeallth.IsChecked == false)
            {
                chkSuitable.IsChecked = false;
            }
            if (chkSexHealth.IsChecked == false)
            {
                chkSuitable.IsChecked = false;
            }
            if (chkSkin.IsChecked == false)
            {
                chkSuitable.IsChecked = false;
            }
            if (chkSuitable.IsChecked == false)
            {
                btnApprove.IsEnabled = false;
            }

        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            refresh();
        }

        private void cmbGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            refresh();
        }

        private void txtNIC_TextChanged(object sender, TextChangedEventArgs e)
        {
            refresh();
        }

        private void txtContactNo_TextChanged(object sender, TextChangedEventArgs e)
        {
            refresh();
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            refresh();
        }

        private void txtAddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            refresh();
        }

        private void cmbDistrict_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            refresh();
        }

        private void cmbCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            refresh();
        }

        private void txtWeight_TextChanged(object sender, TextChangedEventArgs e)
        {
            refresh();
        }

        private void cmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            refresh();
        }

        private void txtHemo_TextChanged(object sender, TextChangedEventArgs e)
        {
            refresh();
        }

        private void chkGen_Checked(object sender, RoutedEventArgs e)
        {
            refresh();
        }

        private void chkOther_Checked(object sender, RoutedEventArgs e)
        {
            refresh();
        }

        private void chkSurgHeallth_Checked(object sender, RoutedEventArgs e)
        {
            refresh();
        }

        private void chkSexHealth_Checked(object sender, RoutedEventArgs e)
        {
            refresh();
        }

        private void chkSkin_Checked(object sender, RoutedEventArgs e)
        {
            refresh();
        }

        private void chkSuitable_Checked(object sender, RoutedEventArgs e)
        {
            refresh();
        }

        private void btnApprove_Click(object sender, RoutedEventArgs e)
        {
            loggedDonor.Name = txtName.Text;
            loggedDonor.Gender = cmbGender.Text;
            loggedDonor.NIC=txtNIC.Text;
            loggedDonor.ContactNo = txtContactNo.Text;
            loggedDonor.Email = txtEmail.Text;
            loggedDonor.DOB = (DateTime)dtpDOB.SelectedDate;
            loggedDonor.Location.Address=txtAddress.Text;
            loggedDonor.Location.District=cmbDistrict.Text;
            loggedDonor.Location.City=cmbCity.Text;
            loggedDonor.BloodType=cmbType.Text;
            HealthCondition health=new HealthCondition();
            health.Weight = float.Parse(txtWeight.Text);
            health.Hemoglobin=float.Parse(txtHemo.Text);
            health.genDis = chkGen.IsChecked.Value;
            health.genDisD = txtGen.Text;
            health.otherDis = chkOther.IsChecked.Value;
            health.otherDisD=txtOtherDis.Text;
            health.surgHis=chkSurgHeallth.IsChecked.Value;
            health.sexHis=chkSexHealth.IsChecked.Value;
            health.skin=chkSkin.IsChecked.Value;
            health.Diseases = txtOther.Text;
            health.Suitability=chkSuitable.IsChecked.Value;
            loggedDonor.health = health;
            dB.approveDonor(loggedDonor);
            win = (MainWindow)Window.GetWindow(this);
            win.mainFrame.Navigate(new HospitalDashboard(Path,User));

        }
    }
}
