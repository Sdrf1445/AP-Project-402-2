using Restaurant_Manager.Pages.User;
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
    /// Interaction logic for RestaurantTile.xaml
    /// </summary>
    public partial class RestaurantTile : UserControl
    {

        public static readonly DependencyProperty RestaurantProperty=
            DependencyProperty.Register("RestaurantName", typeof(string), typeof(RestaurantTile), new PropertyMetadata(""));
        public static readonly DependencyProperty LocationProperty=
            DependencyProperty.Register("Location", typeof(string), typeof(RestaurantTile), new PropertyMetadata(""));
        public static readonly DependencyProperty CommentsCountProperty=
            DependencyProperty.Register("CommentsCount", typeof(string), typeof(RestaurantTile), new PropertyMetadata(""));
        public static readonly DependencyProperty CheckedComplaintsProperty=
            DependencyProperty.Register("CheckedComplaints", typeof(string), typeof(RestaurantTile), new PropertyMetadata(""));
        public static readonly DependencyProperty UnCheckedComplaintsProperty=
            DependencyProperty.Register("UnCheckedComplaints", typeof(string), typeof(RestaurantTile), new PropertyMetadata(""));
        public static readonly DependencyProperty VotesCountProperty=
            DependencyProperty.Register("VotesCount", typeof(string), typeof(RestaurantTile), new PropertyMetadata(""));
        public static readonly DependencyProperty StarProperty=
            DependencyProperty.Register("Star", typeof(string), typeof(RestaurantTile), new PropertyMetadata(""));



        public string RestaurantText 
        {
            get { return (string)GetValue(RestaurantProperty); }
            set { SetValue(RestaurantProperty, value); }
        }
        public string LocationText 
        {
            get { return (string)GetValue(LocationProperty); } 
            set { SetValue(LocationProperty, value); }
        }
        public string CommentsCountNumber
        {
            get { return (string)GetValue(CommentsCountProperty); } 
            set { SetValue(CommentsCountProperty, value); }
        }
        public string CheckedComplaintsText 
        {
            get { return (string)GetValue(CheckedComplaintsProperty); } 
            set { SetValue(CheckedComplaintsProperty, value); }
        }
        public string UnCheckedComplaintsText 
        {
            get { return (string)GetValue(UnCheckedComplaintsProperty); } 
            set { SetValue(UnCheckedComplaintsProperty, value); }
        }
        public string VotesCountText 
        {
            get { return (string)GetValue(VotesCountProperty); } 
            set { SetValue(VotesCountProperty, value); }
        }
        public string StarText 
        {
            get { return (string)GetValue(StarProperty); } 
            set { SetValue(StarProperty, value); }
        }
        public Restaurant Restaurant { get; set; }
        public Page Page { get; set; }
        public RestaurantTile(Restaurant restaurant,Page page)
        {
            InitializeComponent();
            this.Page = page;
            this.Restaurant = restaurant;
            this.RestaurantText = restaurant.Name;
            this.LocationText = restaurant.City;
            this.CommentsCountNumber = "0";
            this.StarText = Restaurant.Rating.ToString();
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

        private void UserControl_Click(object sender, MouseButtonEventArgs e)
        {
            Page.NavigationService.Navigate(new MainUser(Restaurant));

        }
    }
}
