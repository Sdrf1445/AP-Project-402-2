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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void CreateOne_Click(object sender, MouseButtonEventArgs e)
        {
            foreach(var window in Application.Current.Windows)
            {
                if(window is LoginWindow)
                {
                    var loginWindow = (LoginWindow)window;
                    loginWindow.LoginFrame.Source = new Uri("../Pages/Login/Register.xaml",UriKind.Relative);
                }
            }
        }
    }
}
