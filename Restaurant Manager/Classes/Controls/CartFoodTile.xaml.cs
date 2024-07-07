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
        public CartFoodTile(Food food)
        {
            InitializeComponent();
            Food = food;
            FoodNameBlock.Text = Food.Name;
            RemaningBlock.Text = $"Remaning: {Food.Remaining}";
            PriceBlock.Text = $"{Food.Price}$";
            //NumericUpDown.Number = Food.
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
