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
        public CommentTile(Page page,Comment comment,bool allowReply = true , bool allowEdit = false)
        {
            InitializeComponent();
            Comment = comment;
            Page = page;
            if (!allowReply)
            {
                ReplyButton.Visibility = Visibility.Collapsed;
            }
            if(!allowEdit)
            {
                EditButton.Visibility = Visibility.Collapsed;
            }
            UsernameBlock.Text = $"@{Comment.AuthorUsername}";
            if(!Comment.IsEdited)
            {
                EditedBlock.Visibility = Visibility.Collapsed;
            }
            DescriptionBox.Text = Comment.Message;
            DateBlock.Text = Comment.Date.ToString("MM/dd/yyyy");
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var editcomment = new EditCommentWindow(Comment);
            bool? dialogresult = editcomment.ShowDialog();
            if(dialogresult == true)
            {
                Page.NavigationService.Refresh();
            }

        }

        private void Reply_Click(object sender, RoutedEventArgs e)
        {
            var window = new ReplyCommentWindow(Comment);
            bool? dialogresult = window.ShowDialog();
            if(dialogresult == true)
            {
                Page.NavigationService.Refresh();
            }

        }
    }
}
