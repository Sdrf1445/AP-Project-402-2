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
    /// Interaction logic for AddCommentOrder.xaml
    /// </summary>
    public partial class AddCommentOrder : Window
    {
        public Order Order { get; set; }
        public AddCommentOrder(Order order)
        {
            InitializeComponent();
            Order = order;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            Order.AddComment(CommentBox.Text, Order.ID);
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
