using Restaurant_Manager.Pages.Admin;
using Restaurant_Manager.Windows;
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
    /// Interaction logic for ComplaintAdminTile.xaml
    /// </summary>
    public partial class ComplaintAdminTile : UserControl
    {
        public Complaint Complaint {  get; set; }
        public Complaints Page { get; set; }
        public ComplaintAdminTile(Complaint complaint,Complaints page)
        {
            Complaint = complaint;
            Page = page;
            InitializeComponent();
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            TitleBlock.Text = Complaint.Title;
            ByBlock.Text = $"By @{Complaint.AuthorUsername}";
            TextBox.Text = Complaint.Description;
            DateBlock.Text = Complaint.Date.ToString("MM/dd/yyyy");
        }

        private void Answer_Click(object sender, RoutedEventArgs e)
        {
            bool? result = new AnswerComplaintWindow(Complaint).ShowDialog();
            if(result == true)
            {
                Page.NavigationService.Navigate(new Complaints());
            }
        }
    }
}
