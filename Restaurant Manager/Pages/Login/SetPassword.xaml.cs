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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Restaurant_Manager.Pages.Login
{
    /// <summary>
    /// Interaction logic for SetPassword.xaml
    /// </summary>
    public partial class SetPassword : Page
    {
        User user;
        public SetPassword(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void LetsGoBtn_Click(object sender, RoutedEventArgs e)
        {
            // regex check

            // create user in data base
            user.Password = PasswordTextbox.Text;

        }
    }
}
