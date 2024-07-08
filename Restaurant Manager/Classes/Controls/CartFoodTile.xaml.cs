using Restaurant_Manager.Pages.User;
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

namespace Restaurant_Manager.Classes.Controls
{
    /// <summary>
    /// Interaction logic for CartFoodTile.xaml
    /// </summary>
    public partial class CartFoodTile : UserControl
    {
        public Food Food { get; set; }
        public Restaurant Restaurant { get; set; }
        public Page Page { get; set; }
        public CartFoodTile(Food food,Restaurant restaurant, Page page)
        {
            InitializeComponent();
            Food = food;
            Restaurant = restaurant;
            FoodNameBlock.Text = Food.Name;
            RemaningBlock.Text = $"Remaning: {Food.Remaining}";
            PriceBlock.Text = $"{Food.Price}$";
            NumericUpdown.Number = Food.NumberOrdered!.Value;
            Page = page;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            bool result = User.UpdateNumberOfFoodOrdered(Food.ID, NumericUpdown.Number, Restaurant.ID);
            if(!result)
            {
                NumericUpdown.Number = Food.NumberOrdered!.Value;
                new ErrorWindow("Not enough remaning").ShowDialog();
            }
        }

        private void Delete_Clicked(object sender, MouseButtonEventArgs e)
        {
            Classes.User.RemoveFromCart(Food.ID);
            Page.NavigationService.Navigate(new CartUser());
        }
    }
}
