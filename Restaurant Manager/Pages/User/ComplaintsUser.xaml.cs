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

namespace Restaurant_Manager.Pages.User
{
    /// <summary>
    /// Interaction logic for ComplaintsUser.xaml
    /// </summary>
    public partial class ComplaintsUser : Page
    {
        public Classes.User User { get; set; }
        public ComplaintsUser(Classes.User user)
        {
            InitializeComponent();
            User = user;
            var list = Classes.User.GetAllComplaints();
            bool first = true;
            foreach (var item in list)
            {
                var tile = new ComplaintUserTile(item);
                tile.Margin = new Thickness(0,first ? 0: 200, 0, 0);
                if(first) {first = false;}
                ComplaintsTileList.Children.Add(tile);
                if (item.Answer != null)
                {
                    var answertile = new CommentTile(item.Answer, false, false);
                    answertile.Margin = new Thickness(20, 300, 0, 0);
                    ComplaintsTileList.Children.Add(answertile);

                }
            }
        }

        private void AddComplaint_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddComplaintWindow();
            bool? dialogresult = window.ShowDialog();
            if (dialogresult == true)
            {
                NavigationService.Navigate(new ComplaintsUser(Classes.User.GetCurrentUSer()));
            }

        }
    }
}
