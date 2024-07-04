using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for FoodAdminTile.xaml
    /// </summary>
    public partial class FoodAdminTile : UserControl
    {
        public Food Food { get; set; }
        public FoodAdminTile(Food food)
        {
            InitializeComponent();
            Food = food;
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            NameBox.Text = Food.Name;
            DescBox.Text = Food.Ingredients;
            var filepath = System.IO.Path.Join(Environment.CurrentDirectory,Food.ImageSource);
            if(File.Exists(filepath))
            {
                ImageBox.Source = new BitmapImage(new Uri(filepath,UriKind.Absolute));
            }
        }
    }
}
