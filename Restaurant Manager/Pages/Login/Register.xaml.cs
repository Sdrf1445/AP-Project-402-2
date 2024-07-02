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
        public User user;
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {

            // regex validation
            user = new User(UsernameBox.Text,NameBox.Text,LastNameBox.Text,MobileBox.Text,EmailBox.Text);

            if(!RegexValidators.IsNameValid(user.Name))
            {
                new ErrorWindow("Name must be between 3 and 32 characters").ShowDialog();
                return;
            }
            if(!RegexValidators.IsNameValid(user.LastName))
            {
                new ErrorWindow("Last Name must be between 3 and 32 characters").ShowDialog();
                return;
            }
            if(!RegexValidators.IsMobileValid(user.PhoneNumber))
            {
                new ErrorWindow("Invalid Phone Number").ShowDialog();
                return;
            }
            if(!RegexValidators.IsEmailValid(user.Email))
            {
                new ErrorWindow("Invalid Email").ShowDialog();
                return;
            }
            if(!RegexValidators.IsUsernameValid(user.Username))
            {
                new ErrorWindow("Invalid Username").ShowDialog();
                return;
            }
            //database verification
            if(!DatabaseFunctions.IsUserNameUniqe(user.Username))
            {
                new ErrorWindow("Username taken").ShowDialog();
                return;
            }
            if(!DatabaseFunctions.IsMobilePhoneUniqe(user.PhoneNumber))
            {
                new ErrorWindow("Phone number taken").ShowDialog();
                return;
            }
            
            // email verification
            string emailAddress = user.Email;
            string fullName = user.Name + " " + user.LastName;
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
