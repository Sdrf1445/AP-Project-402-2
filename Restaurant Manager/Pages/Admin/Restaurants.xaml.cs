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
            filterControl = new RestaurantFilterControl(new List<string> {"fsfas" , "fasf"});
            filterControl.FilterChanged += FilterControl_FilterChanged;
        }

        private void FilterControl_FilterChanged(object? sender, EventArgs e)
        {

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
    }
}
