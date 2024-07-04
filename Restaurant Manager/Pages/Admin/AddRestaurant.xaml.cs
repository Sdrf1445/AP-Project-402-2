﻿using Restaurant_Manager.Classes;
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

namespace Restaurant_Manager.Pages.Admin
{
    /// <summary>
    /// Interaction logic for AddRestaurant.xaml
    /// </summary>
    public partial class AddRestaurant : Page
    {
        public AddRestaurant()
        {
            InitializeComponent();
            ReceptionTypeBox.ItemList = new List<string> { "Take Away", "Dining", "Both" };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!RegexValidators.IsUsernameValid(UsernameTextbox.Text))
            {
                new ErrorWindow("Invaild username format");
                return;
            }
            if(ReceptionTypeBox.SelectedIndex == -1)
            {
                new ErrorWindow("Select Reception type");
                return;
            }
            if(!RegexValidators.IsPasswordValid(PasswordTextbox.Text))
            {
                new ErrorWindow("Invalid Password Format");
                return;
            }
            if (PasswordTextbox.Text != RepeatPasswordBox.Text)
            {
                new ErrorWindow("Password does not match");
                return;
            }
            if(!DatabaseFunctions.IsUserNameUniqe(UsernameTextbox.Text))
            {
                new ErrorWindow("Username taken");
                return;
            }
            Classes.Admin.AddRestaurant(UsernameTextbox.Text,PasswordTextbox.Text,NameTextBox.Text,LocationBox.Text,(ReceptionType)ReceptionTypeBox.SelectedIndex,AddressBox.Text);
            var window = Window.GetWindow(this);
            (window as AdminWindow).ShowMessageBox("Success");
        }
    }
}
