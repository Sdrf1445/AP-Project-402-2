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
    /// Interaction logic for ComplaintFilterTile.xaml
    /// </summary>
    public enum TimeOrder { Ascending = 0, Descending = 1 }
    public enum SearchBy { Username, FullName, RestaurantName, Title }
    public enum ComplaintStatus { NoFilter , Checked, Unchecked }
    public partial class ComplaintFilterTile : UserControl
    {
        public event EventHandler FilterChanged;
        public TimeOrder Order { get; set; } = TimeOrder.Ascending;
        public SearchBy SearchBy { get; set; } = SearchBy.Title;
        public ComplaintStatus ComplaintStatus { get; set; } = ComplaintStatus.NoFilter;

        public ComplaintFilterTile()
        {
            InitializeComponent();
        }

        private void Ascending_Click(object sender, RoutedEventArgs e)
        {
            Order = TimeOrder.Ascending;
            FilterChanged?.Invoke(this, EventArgs.Empty);
        }

        private void Descending_Click(object sender, RoutedEventArgs e)
        {
            Order = TimeOrder.Descending;
            FilterChanged?.Invoke(this, EventArgs.Empty);

        }

        private void Username_Chcked(object sender, RoutedEventArgs e)
        {
            SearchBy = SearchBy.Username;
            FilterChanged?.Invoke(this, EventArgs.Empty);
        }

        private void FullName_Checked(object sender, RoutedEventArgs e)
        {
            SearchBy = SearchBy.FullName;
            FilterChanged?.Invoke(this, EventArgs.Empty);
        }

        private void RestaurantName_Checked(object sender, RoutedEventArgs e)
        {
            SearchBy = SearchBy.RestaurantName;
            FilterChanged?.Invoke(this, EventArgs.Empty);
        }

        private void Title_Checked(object sender, RoutedEventArgs e)
        {
            SearchBy = SearchBy.Title;
            FilterChanged?.Invoke(this, EventArgs.Empty);
        }

        private void NoFilter_Checked(object sender, RoutedEventArgs e)
        {
            ComplaintStatus = ComplaintStatus.NoFilter;
            FilterChanged?.Invoke(this, EventArgs.Empty);
        }

        private void Checked_Checked(object sender, RoutedEventArgs e)
        {
            ComplaintStatus = ComplaintStatus.Checked;
            FilterChanged?.Invoke(this, EventArgs.Empty);
        }

        private void Unchecked_Checked(object sender, RoutedEventArgs e)
        {
            ComplaintStatus = ComplaintStatus.Unchecked;
            FilterChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
