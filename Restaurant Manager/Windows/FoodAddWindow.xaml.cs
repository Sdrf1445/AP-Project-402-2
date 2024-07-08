using Microsoft.Win32;
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
    /// Interaction logic for FoodAddWindow.xaml
    /// </summary>
    public partial class FoodAddWindow : Window
    {
        public Classes.Menu Menu { get; set; }
        public string ImagePath { get; set; } = null;
        public FoodAddWindow(Classes.Menu menu)
        {
            InitializeComponent();
            Menu = menu;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Classes.Restaurant.AddFoodToMenu(Menu.ID, NameBox.Text, RemainingBox.Number, IngrediantsBox.Text, double.Parse(PriceBox.Text),ImagePath);
                this.DialogResult = true;
                this.Close();
            }
            catch
            {
                new ErrorWindow("Price must be a number").ShowDialog();
            }
        }

        private void ChooseImage_Click(object sender, RoutedEventArgs e)
        {

            var dialog = new OpenFileDialog();
            bool? dialogresult = dialog.ShowDialog();
            if (dialogresult != true)
            {
                return;
            }

            var path = dialog.FileName;
            ImageBox.Source = new BitmapImage(new Uri(path, UriKind.Absolute));
            ImagePath = path;
        }

        private void Discard_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
