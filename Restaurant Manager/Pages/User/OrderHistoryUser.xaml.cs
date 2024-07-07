using Restaurant_Manager.Classes.Controls;
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
    /// Interaction logic for OrderHistoryUser.xaml
    /// </summary>
    public partial class OrderHistoryUser : Page
    {
        public Classes.User User { get; set; }
        public OrderHistoryUser(Classes.User user)
        {
            InitializeComponent();
            User = user;

            foreach(var item in User.Orders)
            {
                var ordertile = new OrderUserTile(this,item);
                ordertile.Margin = new Thickness(0, 10, 0, 0);
                OrderListBox.Children.Add(ordertile);
            }
        }
    }
}
