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
    /// Interaction logic for RestaurantWindow.xaml
    /// </summary>
    public partial class RestaurantWindow : Window
    {
        public RestaurantWindow()
        {
            InitializeComponent();
            Frame.Navigate(new Restaurant_Manager.Pages.Restaurant.Main(new Classes.Restaurant { Name = "Nice" }));
        }
    }
}
