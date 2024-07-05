using Restaurant_Manager.Classes;
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
    /// Interaction logic for ChangePasswordWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {
        public Restaurant Restaurant { get; set; }
        public ChangePasswordWindow(Restaurant restaurant)
        {
            InitializeComponent();
            Restaurant = restaurant;
        }

        private void SetPassword_Click(object sender, RoutedEventArgs e)
        {
            if (!RegexValidators.IsPasswordValid(PasswordTextbox.Text))
            {
                new ErrorWindow("Invaild password format").ShowDialog();
                return;
            }
            if(PasswordTextbox.Text != ConfirmPasswordTextBox.Text)
            {
                new ErrorWindow("Passwords does not match").ShowDialog();
                return;
            }
            Admin.ChangeRestaurantPassword(Restaurant.ID, PasswordTextbox.Text);
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
