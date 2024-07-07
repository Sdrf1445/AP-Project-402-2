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
    /// Interaction logic for MainUser.xaml
    /// </summary>
    public partial class MainUser : Page
    {
        public Restaurant_Manager.Classes.Restaurant Restaurant { get; set; }
        public MainUser(Restaurant_Manager.Classes.Restaurant restaurant)
        {
            InitializeComponent();
            Restaurant = restaurant;
            NameBlock.Text = restaurant.Name;
            LocationBlock.Text = restaurant.City;
            AddressBlock.Text = restaurant.Address;
            UsernameBlock.Text = $"Username: {restaurant.Username}";
            foreach(var menu in Classes.Restaurant.GetAllMenus(Restaurant.ID))
            {
                var menuadmintile = new MenuTile(menu, this,Restaurant);
                MenuList.Children.Add(menuadmintile);
            }
        }

        private void LeftArrow_Click(object sender, RoutedEventArgs e)
        {
            MenuListScroll.ScrollToHorizontalOffset(MenuListScroll.HorizontalOffset - 1);
        }

        private void RightArrow_Click(object sender, RoutedEventArgs e)
        {
            MenuListScroll.ScrollToHorizontalOffset(MenuListScroll.HorizontalOffset + 1);
        }
    }
}
