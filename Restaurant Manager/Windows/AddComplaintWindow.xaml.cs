using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for AddComplaintWindow.xaml
    /// </summary>
    public partial class AddComplaintWindow : Window
    {
        public AddComplaintWindow()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if(!Classes.Restaurant.DoesRestaurantUsernameExist(RestaurantUsernameBox.Text))
            {
                new ErrorWindow("Such restaurant does not exist").ShowDialog();
                return;

            }
            this.DialogResult = true;
            Classes.User.AddComplaint(RestaurantUsernameBox.Text, TitleBox.Text, DescBox.Text);
            this.Close();
        }

        private void Discard_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
