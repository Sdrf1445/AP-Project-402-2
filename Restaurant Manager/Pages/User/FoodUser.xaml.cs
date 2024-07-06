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

namespace Restaurant_Manager.Pages.Food
{
    /// <summary>
    /// Interaction logic for FoodUser.xaml
    /// </summary>
    public partial class FoodUser : Page
    {
        public Classes.Food Food { get; set; }
        public FoodUser(Classes.Food food)
        {
            InitializeComponent();
            Food = food;
            FoodNameBlock.Text = food.Name;
            PriceBlock.Text = $"{Food.Price}$";
            RemainingBlock.Text = $"Remaning: {Food.Remaining}";
            RatingBlock.Text = $"{Food.Rating} (30 Votes)";
            Ingridients.Text = $"Ingridients: {Food.Ingredients}";
            foreach(var item in Food.Comments)
            {
                //do stuff fo the comment section
            }
        }
    }
}
