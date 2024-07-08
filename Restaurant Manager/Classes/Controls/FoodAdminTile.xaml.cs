using Restaurant_Manager.Pages.Restaurant;
using Restaurant_Manager.Windows;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for FoodAdminTile.xaml
    /// </summary>
    public partial class FoodAdminTile : UserControl
    {
        public Food Food { get; set; }
        public Page Page { get;set; }
        public Restaurant Restaurant { get; set; }
        public FoodAdminTile(Food food,Page page,Restaurant restaurant)
        {
            InitializeComponent();
            Food = food;
            Page = page;
            Restaurant = restaurant;
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            NameBox.Text = Food.Name;
            DescBox.Text = Food.Ingredients;
            ImageBox.Source = Food.ReadImage(Food.MenuID, Food.ID);
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            bool? dialogresult = new FoodEditWindow(Food).ShowDialog();
            if(dialogresult != true)
            {
                return;
            }
            Page.NavigationService.Navigate(new Main(Restaurant));
        }

        private void View_Click(object sender, RoutedEventArgs e)
        {
            Page.NavigationService.Navigate(new FoodRestaurant(Food,Restaurant));
        }
    }
}
