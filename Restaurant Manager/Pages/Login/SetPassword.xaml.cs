using Restaurant_Manager.Classes;
using Restaurant_Manager.Windows;
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

namespace Restaurant_Manager.Pages.Login
{
    /// <summary>
    /// Interaction logic for SetPassword.xaml
    /// </summary>
    public partial class SetPassword : Page
    {
        Classes.User user;
        public SetPassword(Classes.User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void LetsGoBtn_Click(object sender, RoutedEventArgs e)
        {
            // regex check
            if (!RegexValidators.IsPasswordValid(PasswordTextbox.Text))
            {
                new ErrorWindow("Password is invalid").ShowDialog();
                return;
            }
            if (PasswordTextbox.Text != ConfirmPasswordTextBox.Text)
            {
                new ErrorWindow("Passwords does not match").ShowDialog();
                return;
            }
            // create user in data base
            user.PasswordHash = Security.CreateMD5(PasswordTextbox.Text);

            Database.Instance.Users.Add(user);
            Database.Instance.SaveChanges();
        }
    }
}
