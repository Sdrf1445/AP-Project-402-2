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
    /// Interaction logic for RestaurantAdminTile.xaml
    /// </summary>
    public partial class RestaurantAdminTile : UserControl
    {
        public string RestaurantText { get; set; } = "Name";
        public string LocationText { get; set; } = "Location";
        public string CommentsCountNumber { get; set; } = "0";
        public string CheckedComplaintsText { get; set; } = "0";
        public string UnCheckedComplaintsText { get;set;} = "0";
        public string VotesCountText { get; set; } = "0";
        public string StarText { get; set; } = "0";
        public RestaurantAdminTile()
        {
            InitializeComponent();
        }
        
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.NameBlock.Text = RestaurantText;
            this.LocationBlock.Text = LocationText;
            this.CommentsComplaintsBlock.Text = $"{CommentsCountNumber} Comments , {UnCheckedComplaintsText + CheckedComplaintsText} Complaints";
            this.UncheckedComplaintsBox.Text = $"{UnCheckedComplaintsText} Unchecked Complaints";
            this.CheckedComplaints.Text = $"{CheckedComplaintsText} Checked Complaints";
            this.VoteCounter.Text = $"{StarText} ({VotesCountText} Votes)";
            int StarCount = int.Parse(StarText);
            string FilledStarSource = "/Images/FilledStar.png";

            if(StarCount > 4)
            {
                Star5.Source = new BitmapImage(new Uri(FilledStarSource,UriKind.Relative));
            }
            if(StarCount > 3)
            {
                Star4.Source = new BitmapImage(new Uri(FilledStarSource,UriKind.Relative));
            }
            if(StarCount > 2)
            {
                Star3.Source = new BitmapImage(new Uri(FilledStarSource,UriKind.Relative));
            }
            if(StarCount > 1)
            {
                Star2.Source = new BitmapImage(new Uri(FilledStarSource,UriKind.Relative));
            }
            if(StarCount > 0)
            {
                Star1.Source = new BitmapImage(new Uri(FilledStarSource,UriKind.Relative));
            }
        }
    }
}
