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

namespace Restaurant_Manager.Pages.Restaurant
{
    /// <summary>
    /// Interaction logic for RestaurantOrders.xaml
    /// </summary>
    public partial class RestaurantOrders : Page
    {
        public RestaurantOrders()
        {
            InitializeComponent();
            foreach(var item in Classes.Restaurant.GetAllOrders())
            {
                var tile = new RestaurantOrderTile(this,item);
                this.Margin = new Thickness(0,200,0, 0);
                ComplaintsTileList.Children.Add(tile);
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DisplayFilter_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
