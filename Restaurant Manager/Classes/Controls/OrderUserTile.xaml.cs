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
    /// Interaction logic for OrderUserTile.xaml
    /// </summary>
    public partial class OrderUserTile : UserControl
    {
        public Page Page { get; set; }
        public Order Order { get; set; }
        public OrderUserTile(Page page, Order order)
        {
            InitializeComponent();
            Order = order;
            Page = page;

            UsernameBox.Text = $"By @{order.Username}";
            PriceBox.Text = $"{order.SumPrice}$";
            ScoreBox.Text = $"{order.Rating?.Value}";
            //RestaurantBox.Text = $"From {order.}";
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double rating = double.Parse(ScoreBox.Text);
                if (rating < 0 || rating > 5)
                {
                    new ErrorWindow("Rating is not in range");
                    return;
                }
                Order.AddRating(rating, Order.ID);
            }
            catch
            {
                new ErrorWindow("Rating must be a number");
            }
        }

        private void AddComment_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddCommentOrder(Order);
            bool? dialogresult = window.ShowDialog();
            if(dialogresult == true)
            {
                Page.NavigationService.Navigate(new OrderHistoryUser(User.GetCurrentUSer()));
            }
        }
    }
}
