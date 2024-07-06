using Restaurant_Manager.Classes;
using Restaurant_Manager.Pages.User;
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
using System.Windows.Shapes;

namespace Restaurant_Manager.Windows
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public User User { get; set; }
        public UserWindow()
        {
            InitializeComponent();
            Frame.Navigate(new RestaurantsUser());
            UsernameBlock.Text = User.GetFullNameByUsername(User.FullName);
        }

        private void RestaurantsNavButton_Checked(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new RestaurantsUser());
        }

        private void OrderHistoryNavButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Logout_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Exit_Checked(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void Profile_Chcked(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new Profile(User));

        }
    }
}
