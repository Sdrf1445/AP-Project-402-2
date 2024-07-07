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
using System.Windows.Shapes;

namespace Restaurant_Manager.Windows
{
    /// <summary>
    /// Interaction logic for AddToCartWindow.xaml
    /// </summary>
    public partial class AddToCartWindow : Window
    {
        public Classes.Food Food { get; set; }
        public Classes.Restaurant Restaurant { get; set; }
        public AddToCartWindow(Classes.Food food,Classes.Restaurant restaurant)
        {
            InitializeComponent();
            Food = food;
            Restaurant = restaurant;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            Classes.User.AddToCart(Food.ID,Restaurant.ID);
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
