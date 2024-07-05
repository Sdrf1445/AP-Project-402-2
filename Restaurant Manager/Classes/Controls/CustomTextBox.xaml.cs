using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for CustomTextBox.xaml
    /// </summary>
    public partial class CustomTextBox : UserControl 
    {
        
        public static readonly DependencyProperty HintProperty=
            DependencyProperty.Register("Hint", typeof(string), typeof(CustomTextBox), new PropertyMetadata(""));
        public static readonly DependencyProperty TextProperty=
            DependencyProperty.Register("Text", typeof(string), typeof(CustomTextBox), new PropertyMetadata(""));


        public string HintText 
        {
            get { return (string)GetValue(HintProperty); }
            set { SetValue(HintProperty, value); }
        }
        public string Text
        {
            get { return (string)GetValue(TextProperty); } 
            set { SetValue(TextProperty, value); }
        }


        public CustomTextBox()
        {
            InitializeComponent();
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            HintBlock.Text = HintText;
            TextBox.TextChanged += TextBox_TextChanged;
            if(Width != null && Width != 0)
            {
                CanvasBox.Width = Width;
                TextBox.Width = Width - 20;
                HintBlock.Width = Width - 20;
                Border.Width = Width;
                GridBox.Width = Width;
            }

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.Text = TextBox.Text;
            if(TextBox.Text == "")
            {
                HintBlock.Visibility = Visibility.Visible;
            }
            else
            {
                HintBlock.Visibility = Visibility.Hidden;
            }
        }
    }
}
