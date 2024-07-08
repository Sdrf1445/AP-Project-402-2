using Restaurant_Manager.Classes;
using Restaurant_Manager.Classes.Controls;
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

namespace Restaurant_Manager.Pages.Admin
{
    /// <summary>
    /// Interaction logic for Complaints.xaml
    /// </summary>
    public partial class Complaints : Page
    {
        bool IsFilterDisplayed { get; set; } = false;
        ComplaintFilterTile filterControl;
        public Complaints()
        {
            InitializeComponent();
            filterControl = new ComplaintFilterTile();
            filterControl.FilterChanged += FilterControl_FilterChanged;
            var list = Classes.Admin.GetAllComplaints();
            foreach (var item in list)
            {
                //<controls:RestaurantTile StarText="0" VotesCountText="50" RestaurantText="Nice"  LocationText="Nicer" CommentsCountNumber="76" Margin="0,23,0,0" Width="608" Height="151"></controls:RestaurantTile>
                if (item.Status)
                {
                    var complaintadminTile = new ComplaintAnsweredAdminTile(item);
                    complaintadminTile.Margin = new Thickness(0, 23, 0, 0);
                    complaintadminTile.Width = 608;
                    complaintadminTile.Height = 151;
                    ComplaintsTileList.Children.Add(complaintadminTile);
                }
                else
                {
                    var complaintadminTile = new ComplaintAdminTile(item, this);
                    complaintadminTile.Margin = new Thickness(0, 23, 0, 0);
                    complaintadminTile.Width = 608;
                    complaintadminTile.Height = 151;
                    ComplaintsTileList.Children.Add(complaintadminTile);

                }
                /*                var restaurantadminTile = new RestaurantAdminTile(item);
                                restaurantadminTile.Margin = new Thickness(0,23,0,0);
                                restaurantadminTile.Width = 608;
                                restaurantadminTile.Height = 151;
                                RestaurantTileList.Children.Add(restaurantadminTile);
                */
            }
        }

        private void FilterControl_FilterChanged(object? sender, EventArgs e)
        {
            List<Complaint> complaints;
            if(filterControl.SearchBy == SearchBy.Title)
            {
                complaints = Classes.Admin.SearchComplaintsByTitle(SearchBox2.Text,filterControl.ComplaintStatus,filterControl.Order);
            }
            else if(filterControl.SearchBy == SearchBy.RestaurantName)
            {
                complaints = Classes.Admin.SearchComplaintsByRestaurantName(SearchBox2.Text,filterControl.ComplaintStatus,filterControl.Order);
            }
            else if(filterControl.SearchBy == SearchBy.Username)
            {
                complaints = Classes.Admin.SearchComplaintsByUsername(SearchBox2.Text,filterControl.ComplaintStatus,filterControl.Order);
            }
            else
            {
                complaints = Classes.Admin.SearchComplaintsByFullName(SearchBox2.Text,filterControl.ComplaintStatus,filterControl.Order);
            }

            foreach(var item in complaints)
            {
                if(!item.Status)
                {
                    var complaintadminTile = new ComplaintAdminTile(item, this);
                    complaintadminTile.Margin = new Thickness(0, 23, 0, 0);
                    complaintadminTile.Width = 608;
                    complaintadminTile.Height = 151;
                    ComplaintsTileList.Children.Add(complaintadminTile);
                }
                else
                {
                    var complaintadminTile = new ComplaintAnsweredAdminTile(item);
                    complaintadminTile.Margin = new Thickness(0, 23, 0, 0);
                    complaintadminTile.Width = 608;
                    complaintadminTile.Height = 151;
                    ComplaintsTileList.Children.Add(complaintadminTile);
                }
            }

            if (!IsFilterDisplayed)
            {
                ComplaintsTileList.Children.Insert(0, filterControl);
            }
        }

        private void DisplayFilter_Click(object sender, RoutedEventArgs e)
        {
            if (!IsFilterDisplayed)
            {
                ComplaintsTileList.Children.Insert(0, filterControl);
                IsFilterDisplayed = true;
            }
            else
            {
                ComplaintsTileList.Children.RemoveAt(0);
                IsFilterDisplayed = false;
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            List<Complaint> complaints;
            if(filterControl.SearchBy == SearchBy.Title)
            {
                complaints = Classes.Admin.SearchComplaintsByTitle(SearchBox2.Text,filterControl.ComplaintStatus,filterControl.Order);
            }
            else if(filterControl.SearchBy == SearchBy.RestaurantName)
            {
                complaints = Classes.Admin.SearchComplaintsByRestaurantName(SearchBox2.Text,filterControl.ComplaintStatus,filterControl.Order);
            }
            else if(filterControl.SearchBy == SearchBy.Username)
            {
                complaints = Classes.Admin.SearchComplaintsByUsername(SearchBox2.Text,filterControl.ComplaintStatus,filterControl.Order);
            }
            else
            {
                complaints = Classes.Admin.SearchComplaintsByFullName(SearchBox2.Text,filterControl.ComplaintStatus,filterControl.Order);
            }

            foreach(var item in complaints)
            {
                if(!item.Status)
                {
                    var complaintadminTile = new ComplaintAdminTile(item,this);
                    complaintadminTile.Margin = new Thickness(0, 23, 0, 0);
                    complaintadminTile.Width = 608;
                    complaintadminTile.Height = 151;
                    ComplaintsTileList.Children.Add(complaintadminTile);
                }
                else
                {
                    var complaintadminTile = new ComplaintAnsweredAdminTile(item);
                    complaintadminTile.Margin = new Thickness(0, 23, 0, 0);
                    complaintadminTile.Width = 608;
                    complaintadminTile.Height = 151;
                    ComplaintsTileList.Children.Add(complaintadminTile);
                }
            }
            if (!IsFilterDisplayed)
            {
                ComplaintsTileList.Children.Insert(0, filterControl);
            }

        }
        public void Rerender()
        {

            List<Complaint> complaints;
            if(filterControl.SearchBy == SearchBy.Title)
            {
                complaints = Classes.Admin.SearchComplaintsByTitle(SearchBox2.Text,filterControl.ComplaintStatus,filterControl.Order);
            }
            else if(filterControl.SearchBy == SearchBy.RestaurantName)
            {
                complaints = Classes.Admin.SearchComplaintsByRestaurantName(SearchBox2.Text,filterControl.ComplaintStatus,filterControl.Order);
            }
            else if(filterControl.SearchBy == SearchBy.Username)
            {
                complaints = Classes.Admin.SearchComplaintsByUsername(SearchBox2.Text,filterControl.ComplaintStatus,filterControl.Order);
            }
            else
            {
                complaints = Classes.Admin.SearchComplaintsByFullName(SearchBox2.Text,filterControl.ComplaintStatus,filterControl.Order);
            }

            foreach(var item in complaints)
            {
                if(!item.Status)
                {
                    var complaintadminTile = new ComplaintAdminTile(item,this);
                    complaintadminTile.Margin = new Thickness(0, 23, 0, 0);
                    complaintadminTile.Width = 608;
                    complaintadminTile.Height = 151;
                    ComplaintsTileList.Children.Add(complaintadminTile);
                }
                else
                {
                    var complaintadminTile = new ComplaintAnsweredAdminTile(item);
                    complaintadminTile.Margin = new Thickness(0, 23, 0, 0);
                    complaintadminTile.Width = 608;
                    complaintadminTile.Height = 151;
                    ComplaintsTileList.Children.Add(complaintadminTile);
                }
            }
            if (!IsFilterDisplayed)
            {
                ComplaintsTileList.Children.Insert(0, filterControl);
            }
        }
    }
}
