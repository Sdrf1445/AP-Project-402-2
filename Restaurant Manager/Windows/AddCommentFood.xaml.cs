using Restaurant_Manager.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for AddCommentFood.xaml
    /// </summary>
    public partial class AddCommentFood : Window
    {
        public Food Food { get; set; }
        public Restaurant Restaurant { get; set; }
        public AddCommentFood(Food food, Restaurant restaurant)
        {
            InitializeComponent();
            Food = food;
            Restaurant = restaurant;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            Food.AddComment(CommentBox.Text, Food.ID, Restaurant.ID);
            Food.Comments.Add(new Comment(CommentBox.Text, User.CurrentAccoutName));
            this.Close();
        }
    }
}
