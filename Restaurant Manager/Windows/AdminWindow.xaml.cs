using Restaurant_Manager.Pages.Admin;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Restaurant_Manager.Windows
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private Storyboard myStoryboard;
        public AdminWindow()
        {
            InitializeComponent();
            Frame.Navigate(new Restaurants());
        }

        private void RestaurantsNavButton_Checked(object sender, RoutedEventArgs e)
        {
            if (Frame == null)
            {
                return;
            }
            Frame.Navigate(new Restaurants());

        }

        private void AddRestaurantNavButton_Checked(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new AddRestaurant());
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

        private void Exit_Checked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Complaints_Checked(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new Complaints());
        }

        private void Logout_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
