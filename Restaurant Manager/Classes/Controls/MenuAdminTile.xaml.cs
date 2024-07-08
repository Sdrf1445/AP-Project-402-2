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
    /// Interaction logic for MenuAdminTile.xaml
    /// </summary>
    public partial class MenuAdminTile : UserControl
    {
        public Page Page { get; set; }
        public Menu Menu{ get; set; }
        public Restaurant Restaurant { get; set; }
        public MenuAdminTile(Menu menu,Page page,Restaurant restaurant)
        {
            Menu = menu;
            Page = page;
            Restaurant = restaurant;
            InitializeComponent();
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            NameBlock.Text = Menu.Name;
            Menu.Foods.ForEach(food =>
            {
                FoodTileList.Children.Add(new FoodAdminTile(food,Page, Restaurant));
            });
            //<Button Height="40" BorderBrush="Green" BorderThickness="2" Content="Add" FontWeight="Bold" FontSize="15" Background="LightGreen"></Button>
            Button button = new Button { BorderBrush = Brushes.Green, BorderThickness = new Thickness(2),Content = "Add" , FontWeight=  FontWeights.Bold , FontSize = 15 , Background = Brushes.LightGreen };
            button.Click += Button_Click;
            FoodTileList.Children.Add(button);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool? result = new FoodAddWindow(Menu).ShowDialog();
            if(result == true)
            {
                Page.NavigationService.Navigate(new Pages.Restaurant.Main(Restaurant));
            }
        }

        private void Edit_Click(object sender, MouseButtonEventArgs e)
        {
            bool? result = new MenuEditWindow(this.Menu).ShowDialog();

            if (result == true)
            {
                Page.NavigationService.Navigate(new Pages.Restaurant.Main(Restaurant));
            }

        }
    }
}
