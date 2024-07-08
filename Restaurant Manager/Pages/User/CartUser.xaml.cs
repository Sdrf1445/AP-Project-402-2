using Restaurant_Manager.Classes;
using Restaurant_Manager.Classes.Controls;
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

namespace Restaurant_Manager.Pages.User
{
    /// <summary>
    /// Interaction logic for CartUser.xaml
    /// </summary>
    public partial class CartUser : Page
    {
        public CartUser()
        {
            InitializeComponent();
            foreach(var item in Classes.User.Cart.Foods)
            {
                var carttile = new CartFoodTile(item, Classes.Restaurant.GetRestaurantById(Classes.User.CurrentCartRestaurantId),this);
                carttile.Margin = new Thickness(0,10,0,0);
                FoodOrderTileList.Children.Add(carttile);
            }
            TotalCostBox.Text = $"{Classes.User.Cart.SumPrice}$";

        }

        private void Pay_Click(object sender, RoutedEventArgs e)
        {
            Classes.User.PayOrder((bool)CashBox.IsChecked ? PaymentMethod.CASH: PaymentMethod.ONLINE,Classes.User.CurrentCartRestaurantId);
            Classes.User.Cart = new Order(Classes.User.CurrentUsername);
            NavigationService.Navigate(new CartUser());
        }
    }
}
