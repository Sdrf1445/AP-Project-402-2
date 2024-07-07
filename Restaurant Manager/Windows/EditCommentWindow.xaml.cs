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
    /// Interaction logic for EditCommentWindow.xaml
    /// </summary>
    public partial class EditCommentWindow : Window
    {
        public Comment Comment { get; set; }
        public Restaurant Restaurant { get; set; }
        public Food Food { get; set; }
        public EditCommentWindow(Comment comment,Restaurant restaurant,Food food)
        {
            InitializeComponent();
            Comment = comment;
            CommentBox.Text = Comment.Message;
            Restaurant = restaurant;
            Food = food;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            Classes.Comment.EditComment(CommentBox.Text, Comment.ID,Food.ID ,Restaurant.ID);
            this.Close();

        }
    }
}
