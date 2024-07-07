﻿using Restaurant_Manager.Classes;
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
    /// Interaction logic for FoodRestaurant.xaml
    /// </summary>
    public partial class FoodRestaurant : Page
    {
        public Classes.Food Food { get; set; }
        public Classes.Restaurant Restaurant { get; set; } 
        public FoodRestaurant(Classes.Food food,Classes.Restaurant restaurant)
        {
            InitializeComponent();
            Food = food;
            Restaurant = restaurant;
            FoodNameBlock.Text = food.Name;
            PriceBlock.Text = $"{Food.Price}$";
            RemainingBlock.Text = $"Remaning: {Food.Remaining}";
            RatingBlock.Text = $"{Food.Rating} (30 Votes)";
            Ingridients.Text = $"Ingridients: {Food.Ingredients}";
            foreach (var item in Food.Comments)
            {
                var commenttile = new CommentTile(this,item, allowEdit: item.AuthorUsername == Classes.Restaurant.GetNameByID(Classes.Restaurant.CurrentRestaurantID));
                commenttile.Margin = new Thickness(0, 10, 0, 0);
                commenttile.HorizontalAlignment = HorizontalAlignment.Left;
                CommentListBox.Children.Add(commenttile);
                foreach (var reply in item.Replies)
                {
                    var replytile = new CommentTile(this,reply, false, reply.AuthorUsername == Classes.Restaurant.GetNameByID(Classes.Restaurant.CurrentRestaurantID));
                    replytile.Margin = new Thickness(0, 10, 0, 0);
                    replytile.HorizontalAlignment = HorizontalAlignment.Right;
                    CommentListBox.Children.Add(replytile);

                }
            }
        }

        private void AddComment_Click(object sender, RoutedEventArgs e)
        {
            bool? dialogresult = new AddCommentFood(Food, Restaurant).ShowDialog() ;
            if (dialogresult == true)
            {
                NavigationService.Refresh();
            }
        }
    }
}
