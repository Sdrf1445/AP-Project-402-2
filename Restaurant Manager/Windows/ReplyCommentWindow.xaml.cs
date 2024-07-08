using Restaurant_Manager.Classes;
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
using System.Windows.Shapes;

namespace Restaurant_Manager.Windows
{
    /// <summary>
    /// Interaction logic for ReplyCommentWindow.xaml
    /// </summary>
    public partial class ReplyCommentWindow : Window
    {
        public Comment Comment { get; set; }
        public Food Food { get; set; }
        public Restaurant Restaurant { get; set; }
        public ReplyCommentWindow(Comment comment,Food food,Restaurant restaurant)
        {
            InitializeComponent();
            Comment = comment;
            Food = food;
            Restaurant = restaurant;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            Classes.Food.ReplyComment(CommentBox.Text, Comment.ID, Food.ID, Restaurant.ID);
            Comment.Replies.Add(new Comment(CommentBox.Text, User.CurrentAccoutName));
            this.Close();


        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
