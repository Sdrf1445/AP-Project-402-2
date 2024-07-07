using Restaurant_Manager.Classes;
using Restaurant_Manager.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Restaurant_Manager.Pages.User
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        public Classes.User User { get; set; }
        public Profile(Classes.User user)
        {
            InitializeComponent();
            GenderBox.ItemList = new List<string> { "Male", "Female" };
            User = user;
            UsernameBox.Text = user.Username;
            FirstNameBox.Text = user.Name;
            LastNameBox.Text = user.LastName;
            MoblieBox.Text = user.PhoneNumber;
            PostalCodeBox.Text = user.PostalCode?.ToString();
            EmailBox.Text = user.Email;

            if (User.Gender == Classes.Gender.MALE)
            {
                GenderBox.SelectedIndex = 0;
            }
            else if (User.Gender == Classes.Gender.FEMALE)
            {
                GenderBox.SelectedIndex = 1;
            }


        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            if(!RegexValidators.IsEmailValid(EmailBox.Text))
            {
                new ErrorWindow("Email is invaild").ShowDialog();
                return;
            }
            try
            {
                int postcode = int.Parse(PostalCodeBox.Text);
                Classes.User.EditUserInfo((Gender)GenderBox.SelectedIndex, postcode, EmailBox.Text);
            }
            catch
            {
                new ErrorWindow("Postal Code is not a number").ShowDialog();
                return;
            }

        }
    }
}
