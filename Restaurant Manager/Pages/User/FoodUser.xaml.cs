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

namespace Restaurant_Manager.Pages.Food
{
    /// <summary>
    /// Interaction logic for FoodUser.xaml
    /// </summary>
    public partial class FoodUser : Page
    {
        public Classes.Food Food { get; set; }
        public Classes.Restaurant Restaurant { get; set; }
        public FoodUser(Classes.Food food,Classes.Restaurant restaurant)
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
                var editAllowed = item.AuthorUsername == Classes.User.CurrentUsername;
                var commentTile = new CommentTile(Food,Restaurant,this, item, allowEdit: editAllowed);
                commentTile.HorizontalAlignment = HorizontalAlignment.Left;
                CommentListBox.Children.Add(commentTile);
                foreach (var reply in item.Replies)
                {
                    editAllowed = reply.AuthorUsername == Classes.User.CurrentUsername;
                    var replyTile = new CommentTile(Food,Restaurant,this, reply, false, allowEdit: editAllowed);
                    commentTile.HorizontalAlignment = HorizontalAlignment.Right;
                    CommentListBox.Children.Add(commentTile);
                }
            }
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double rating = double.Parse(RatingBox.Text);
                if (rating > 5 || rating < 0)
                {
                    new ErrorWindow("Rating must be between 0 and 5").ShowDialog();
                    return;
                }
                Classes.Food.AddRating(rating, Food.ID, Restaurant.ID);
            }
            catch
            {
                new ErrorWindow("Rating must be a number").ShowDialog();
            }
        }

        private void AddComment_Click(object sender, RoutedEventArgs e)
        {
            bool? dialogresult = new AddCommentFood(Food, Restaurant).ShowDialog();
            if(dialogresult == true)
            {
                NavigationService.Refresh();
            }

        }
    }
}
