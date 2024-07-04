using Restaurant_Manager.Classes;
using Restaurant_Manager.Classes.Controls;
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
    /// Interaction logic for Verification.xaml
    /// </summary>
    public partial class Verification : Page
    {
        User user;
        public Verification(User user)
        {
            InitializeComponent();
            this.user = user;
            
        }

        private void ResendTextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void VerifyBtn_Click(object sender, RoutedEventArgs e)
        {
            // regex check



            if (Email.Verify(int.Parse(VerificationCode_TextBox.Text)) == true)
            {
                NavigationService.Navigate(new SetPassword(user));
            }
            else
            {
                new ErrorWindow("Wrong code").ShowDialog();
                return;
            }
        }

        private void GoBackBtn_Click(Object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void VerificationCodeTextBox_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
