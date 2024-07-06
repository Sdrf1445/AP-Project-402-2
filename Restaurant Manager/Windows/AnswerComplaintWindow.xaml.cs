using Restaurant_Manager.Classes;
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
using System.Windows.Shapes;

namespace Restaurant_Manager.Windows
{
    /// <summary>
    /// Interaction logic for AnswerComplaintWindow.xaml
    /// </summary>
    public partial class AnswerComplaintWindow : Window
    {
        public Complaint Complaint { get; set; }
        public AnswerComplaintWindow(Complaint complaint)
        {
            Complaint = complaint;
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if(TextBox.Text == "")
            {
                new ErrorWindow("Cannot be empty").ShowDialog();
                return;
            }
            this.DialogResult = true;
            Admin.AnswerComplaint(TextBox.Text, Complaint.ID);
        }
    }
}
