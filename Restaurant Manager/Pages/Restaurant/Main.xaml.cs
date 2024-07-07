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

namespace Restaurant_Manager.Pages.Restaurant
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public Restaurant_Manager.Classes.Restaurant Restaurant { get; set; }
        public Main(Restaurant_Manager.Classes.Restaurant restaurant)
        {
            InitializeComponent();
            Restaurant = restaurant;
            NameBlock.Text = restaurant.Name;
            LocationBlock.Text = restaurant.City;
            AddressBlock.Text = restaurant.Address;
            UsernameBlock.Text = $"Username : {restaurant.Username}";

            foreach(var menu in Classes.Restaurant.GetAllMenus(Restaurant.ID))
            {
                var menuadmintile = new MenuAdminTile(menu, this, Restaurant);
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

        private void NewMenu_Click(object sender, RoutedEventArgs e)
        {
            bool? result = new MenuAddWindow().ShowDialog();
            if(result == true)
            {
                NavigationService.Refresh();
            }
        }
    }
}
