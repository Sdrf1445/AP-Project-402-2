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
    /// Interaction logic for RestaurantOrderTile.xaml
    /// </summary>
    public partial class RestaurantOrderTile : UserControl
    {
        public Page Page { get; set; }
        public Order Order { get; set; }
        public RestaurantOrderTile(Page page, Order order)
        {
            InitializeComponent();
            Order = order;
            Page = page;

            UsernameBox.Text = $"By @{order.Username}";
            //RestaurantBox.Text = $"From {order.}";
        }
    }
}
