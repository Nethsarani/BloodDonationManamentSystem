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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        String path;
        MainWindow win;
        public Register(String path)
        {
            InitializeComponent();
            this.path = path;
        }
        private void winLoad()
        {
            win = (MainWindow)Window.GetWindow(this);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            winLoad();
            win.mainFrame.Navigate(new Login(path));
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            winLoad();
            win.mainFrame.Navigate(new Login(path));
        }
    }
}
