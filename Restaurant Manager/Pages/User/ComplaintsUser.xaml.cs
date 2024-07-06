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

namespace Restaurant_Manager.Pages.User
{
    /// <summary>
    /// Interaction logic for ComplaintsUser.xaml
    /// </summary>
    public partial class ComplaintsUser : Page
    {
        public Classes.User User { get; set; }
        public ComplaintsUser(Classes.User user)
        {
            InitializeComponent();
            User = user;
        }
    }
}
