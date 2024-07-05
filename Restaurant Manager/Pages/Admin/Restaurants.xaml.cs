using Restaurant_Manager.Classes;
using Restaurant_Manager.Classes.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Restaurant_Manager.Pages.Admin
{
    /// <summary>
    /// Interaction logic for Restaurants.xaml
    /// </summary>
    public partial class Restaurants : Page
    {
        bool IsFilterDisplayed { get; set; } = false;
        RestaurantFilterControl filterControl;
        public Restaurants()
        {
            InitializeComponent();
            filterControl = new RestaurantFilterControl(Classes.Admin.GetAllRestaurantCities());
            filterControl.FilterChanged += FilterControl_FilterChanged;
            var list = Classes.Admin.GetAllRestaurants();
            foreach(var item in list )
            {
                //<controls:RestaurantTile StarText="0" VotesCountText="50" RestaurantText="Nice"  LocationText="Nicer" CommentsCountNumber="76" Margin="0,23,0,0" Width="608" Height="151"></controls:RestaurantTile>
                var restaurantadminTile = new RestaurantAdminTile(item);
                restaurantadminTile.Margin = new Thickness(0,23,0,0);
                restaurantadminTile.Width = 608;
                restaurantadminTile.Height = 151;
                RestaurantTileList.Children.Add(restaurantadminTile);
            }
            
        }

        private void FilterControl_FilterChanged(object? sender, EventArgs e)
        {
            List<Classes.Restaurant> list;
            RestaurantTileList.Children.Clear();
            if(filterControl.Location == "No Filter")
            {
               list = Classes.Admin.FilterRestaurants(filterControl.ReceptionType, filterControl.RatingsOrder,null,SearchBox2.Text);

            }
            else
            {
               list = Classes.Admin.FilterRestaurants(filterControl.ReceptionType, filterControl.RatingsOrder,filterControl.Location,SearchBox2.Text);
            }
            foreach(var item in list )
            {
                //<controls:RestaurantTile StarText="0" VotesCountText="50" RestaurantText="Nice"  LocationText="Nicer" CommentsCountNumber="76" Margin="0,23,0,0" Width="608" Height="151"></controls:RestaurantTile>
                var restaurantadminTile = new RestaurantAdminTile(item);
                restaurantadminTile.Margin = new Thickness(0,23,0,0);
                restaurantadminTile.Width = 608;
                restaurantadminTile.Height = 151;
                RestaurantTileList.Children.Add(restaurantadminTile);
            }
            if(IsFilterDisplayed)
            {
                RestaurantTileList.Children.Insert(0, filterControl);
            }
        }

        private void DisplayFilter_Click(object sender, RoutedEventArgs e)
        {
            if(!IsFilterDisplayed)
            {
                RestaurantTileList.Children.Insert(0, filterControl);
                IsFilterDisplayed = true;
            }
            else
            {
                RestaurantTileList.Children.RemoveAt(0);
                IsFilterDisplayed = false;
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            List<Classes.Restaurant> list;
            RestaurantTileList.Children.Clear();
            if(filterControl.Location == "No Filter")
            {
               list = Classes.Admin.FilterRestaurants(filterControl.ReceptionType, filterControl.RatingsOrder,null,SearchBox2.Text);

            }
            else
            {
               list = Classes.Admin.FilterRestaurants(filterControl.ReceptionType, filterControl.RatingsOrder,filterControl.Location,SearchBox2.Text);
            }
            foreach(var item in list )
            {
                //<controls:RestaurantTile StarText="0" VotesCountText="50" RestaurantText="Nice"  LocationText="Nicer" CommentsCountNumber="76" Margin="0,23,0,0" Width="608" Height="151"></controls:RestaurantTile>
                var restaurantadminTile = new RestaurantAdminTile(item);
                restaurantadminTile.Margin = new Thickness(0,23,0,0);
                restaurantadminTile.Width = 608;
                restaurantadminTile.Height = 151;
                RestaurantTileList.Children.Add(restaurantadminTile);
            }
            if(IsFilterDisplayed)
            {
                RestaurantTileList.Children.Insert(0, filterControl);
            }
            
        }

    }
}
