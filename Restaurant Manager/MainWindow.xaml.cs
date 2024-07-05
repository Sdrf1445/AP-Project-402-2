using Restaurant_Manager.Classes;
using Restaurant_Manager.Windows;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Restaurant_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Hide();
            //new AdminWindow().ShowDialog();
            Food food = new Food(45, 74, "fsfa", "fasdfasf", 4.5);
            new FoodEditWindow(food).ShowDialog();
            //var LoginWindow = new LoginWindow();
            //LoginWindow.ShowDialog();
            Database.Instance.Dispose();
            this.Close();
        }
    }
}