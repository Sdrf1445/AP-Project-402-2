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
    /// Interaction logic for CustomComboBox.xaml
    /// </summary>
    public partial class CustomComboBox : UserControl
    {
        public string HintText { get; set; } = "";
        public int SelectedIndex { get; set; } = -1;
        public string? SelectedValue { get; set; }
        public List<string>? ItemList { get; set; }
        public CustomComboBox()
        {
            InitializeComponent();
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            HintBlock.Text = HintText;
            ItemList?.ForEach(x => ComboBox.Items.Add(x));
            ComboBox.SelectionChanged += ComboBox_SelectionChanged;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.SelectedIndex = ComboBox.SelectedIndex;
            SelectedValue = ComboBox.SelectedItem as string;
        }
    }
}
