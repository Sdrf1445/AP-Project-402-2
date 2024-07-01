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
using Restaurant_Manager.Classes;
using Restaurant_Manager.Windows;

namespace Restaurant_Manager.Pages.Login
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        public static User user = new User("", "", "", "", "", "");
        public Register()
        {
            InitializeComponent();
            this.DataContext = user;
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            // regex validation

            // email verification
            string emailAddress = EmailTextbox.Text;
            string fullName = FirstnameTextbox.Text + LastnameTextbox.Text;
            Email.SendEmail(emailAddress, fullName);
            // go to verification page
            NavigationService.Navigate(new Verification(user));
        }

        private void Login_Click(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Login());
        }


        private void CustomTextBox_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
