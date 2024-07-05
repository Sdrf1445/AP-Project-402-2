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
    /// Interaction logic for CustomNumbericUpDown.xaml
    /// </summary>
    public partial class CustomNumbericUpDown : UserControl
    {
        public CustomNumbericUpDown()
        {
            InitializeComponent();
        }
        public int Number { get; set; } = 0;
        


        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            if(Width != null && Width != 0)
            {
                CanvasBox.Width = Width;
                TextBox.Width = Width - 20;
                Border.Width = Width;
                GridBox.Width = Width;
            }
            this.TextBox.Text = Number.ToString();
        }

        private void LeftArrow_Click(object sender, MouseButtonEventArgs e)
        {
            if(Number == 0)
            {
                return;
            }
            Number--;
            TextBox.Text = Number.ToString();
        }

        private void RightArrow_Click(object sender, MouseButtonEventArgs e)
        {
            Number++;
            TextBox.Text = Number.ToString();
        }
    }
}
