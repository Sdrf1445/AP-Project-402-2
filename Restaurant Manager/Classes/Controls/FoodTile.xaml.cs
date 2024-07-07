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
    /// Interaction logic for FoodTile.xaml
    /// </summary>
    public partial class FoodTile : UserControl
    {
        public Food Food { get; set; }
        public Page Page { get;set; }
        public Restaurant Restaurant { get; set; }
        public FoodTile(Food food,Page page,Restaurant restaurant)
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

        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            /*            var window = new AddToCartWindow(Food);
                        bool? dialogresult = window.ShowDialog();
                        if(dialogresult  == true)
                        {
                            Page.NavigationService.Refresh();
                        }
            */
            bool result = Classes.User.AddToCart(Food.ID, Restaurant.ID);
            if(!result)
            {
                new ErrorWindow("Cannot do that").ShowDialog();

            }
        }
    }
}
