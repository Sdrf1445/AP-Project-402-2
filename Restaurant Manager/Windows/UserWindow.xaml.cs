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
            User = Classes.User.GetCurrentUSer();
            Frame.Navigate(new RestaurantsUser());
            UsernameBlock.Text = User.FullName;
        }

        private void RestaurantsNavButton_Checked(object sender, RoutedEventArgs e)
        {
            if(Frame != null)
            {
                Frame.Navigate(new RestaurantsUser());

            }
        }

        private void OrderHistoryNavButton_Checked(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new OrderHistoryUser(User.GetCurrentUSer()));
        }

        private void Logout_Checked(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            this.Close();

        }

        private void Exit_Checked(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void Profile_Chcked(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new Profile(User));

        }

        private void Complaints_Checked(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new ComplaintsUser(User));

        }
        public void ShowMessageBox(string message)
        {

            MessageBoxBlock.Content = message;
            MessageBoxBlock.Opacity = 1;
            Task.Factory.StartNew(async () =>
            {
                await Task.Delay(4000);
                this.Dispatcher.Invoke(new Action(() =>
                {
                    MessageBoxBlock.Opacity = 0;
                }));
            }
            );
            /*            MessageBoxBlock.Opacity = 1;
                        Task.Factory.StartNew(async () =>
                        {
                            await Task.Delay(5000);
                            this.Dispatcher.Invoke(new Action(() =>
                            {
                                MessageBoxBlock.Opacity = 0;
                            }));
                        });
            */

        }

        private void Cart_Checked(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new CartUser());

        }
    }
}
