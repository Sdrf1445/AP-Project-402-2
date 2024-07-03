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
    /// Interaction logic for CustomPasswordBox.xaml
    /// </summary>
    public partial class CustomPasswordBox : UserControl
    {
        public static readonly DependencyProperty HintProperty=
            DependencyProperty.Register("Hint2", typeof(string), typeof(CustomTextBox), new PropertyMetadata(""));
        public static readonly DependencyProperty TextProperty=
            DependencyProperty.Register("Text2", typeof(string), typeof(CustomTextBox), new PropertyMetadata(""));


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
        public CustomPasswordBox()
        {
            InitializeComponent();
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            HintBlock.Text = HintText;
            TextBox.PasswordChanged += TextBox_PasswordChanged;

        }

        private void TextBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            this.Text = TextBox.Password;
            if(TextBox.Password == "")
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
