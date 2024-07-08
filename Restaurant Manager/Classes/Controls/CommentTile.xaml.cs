using Restaurant_Manager.Pages.Food;
using Restaurant_Manager.Pages.Restaurant;
using Restaurant_Manager.Pages.User;
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
    /// Interaction logic for CommentTile.xaml
    /// </summary>
    public partial class CommentTile : UserControl
    {
        public Comment Comment { get; set; }
        public Page Page { get; set; }
        public Restaurant Restaurant { get; set; }
        public Food Food { get; set; }
        public Order Order { get; set; } = null;
        public CommentTile(Food food, Restaurant restaurant, Page page, Comment comment, bool allowReply = true, bool allowEdit = false)
        {
            InitializeComponent();
            Comment = comment;
            Page = page;
            Restaurant = restaurant;
            Food = food;
            if (!allowReply)
            {
                ReplyButton.Visibility = Visibility.Collapsed;
                RepliedBlock.Visibility = Visibility.Visible;
            }
            else
            {
                RepliedBlock.Visibility = Visibility.Collapsed;

            }
            if (!allowEdit)
            {
                EditButton.Visibility = Visibility.Collapsed;
            }
            UsernameBlock.Text = $"@{Comment.AuthorUsername}";
            if (!Comment.IsEdited)
            {
                EditedBlock.Visibility = Visibility.Collapsed;
            }
            DescriptionBox.Text = Comment.Message;
            DateBlock.Text = Comment.Date.ToString("MM/dd/yyyy");
        }
        public CommentTile(Order order, Page page, Comment comment, bool allowReply = true, bool allowEdit = false)
        {
            InitializeComponent();
            Comment = comment;
            Page = page;
            Order = order;
            if (!allowReply)
            {
                ReplyButton.Visibility = Visibility.Collapsed;
                RepliedBlock.Visibility = Visibility.Visible;
            }
            else
            {
                RepliedBlock.Visibility = Visibility.Collapsed;

            }
            if (!allowEdit)
            {
                EditButton.Visibility = Visibility.Collapsed;
            }
            UsernameBlock.Text = $"@{Comment.AuthorUsername}";
            if (!Comment.IsEdited)
            {
                EditedBlock.Visibility = Visibility.Collapsed;
            }
            DescriptionBox.Text = Comment.Message;
            DateBlock.Text = Comment.Date.ToString("MM/dd/yyyy");
        }
        public CommentTile(Comment comment, bool allowReply = true, bool allowEdit = false)
        {
            InitializeComponent();
            Comment = comment;
            if (!allowReply)
            {
                ReplyButton.Visibility = Visibility.Collapsed;
                RepliedBlock.Visibility = Visibility.Visible;
            }
            else
            {
                RepliedBlock.Visibility = Visibility.Collapsed;

            }
            if (!allowEdit)
            {
                EditButton.Visibility = Visibility.Collapsed;
            }
            UsernameBlock.Text = $"@Admin";
            if (!Comment.IsEdited)
            {
                EditedBlock.Visibility = Visibility.Collapsed;
            }
            DescriptionBox.Text = Comment.Message;
            DateBlock.Text = Comment.Date.ToString("MM/dd/yyyy");
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (Order == null)
            {
                var editcomment = new EditCommentWindow(Comment, Restaurant, Food);
                bool? dialogresult = editcomment.ShowDialog();
                if (dialogresult == true)
                {
                    if (Page is FoodRestaurant)
                    {
                        Page.NavigationService.Navigate(new FoodRestaurant(Food, Restaurant));
                    }
                    else
                    {
                        Page.NavigationService.Navigate(new FoodUser(Food, Restaurant));
                    }
                }
            }
            else
            {
                var editcomment = new EditCommentWindow(Comment, Order);
                bool? dialogresult = editcomment.ShowDialog();
                if (dialogresult == true)
                {
                    Page.NavigationService.Navigate(new OrderHistoryUser(User.GetCurrentUSer()));
                }

            }

        }

        private void Reply_Click(object sender, RoutedEventArgs e)
        {
            var window = new ReplyCommentWindow(Comment, Food, Restaurant);
            bool? dialogresult = window.ShowDialog();
            if (dialogresult == true)
            {
                if (Page is FoodRestaurant)
                {
                    Page.NavigationService.Navigate(new FoodRestaurant(Food, Restaurant));
                }
                else
                {
                    Page.NavigationService.Navigate(new FoodUser(Food, Restaurant));
                }
            }

        }
    }
}
