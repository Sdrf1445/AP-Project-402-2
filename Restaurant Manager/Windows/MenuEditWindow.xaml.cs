﻿using Restaurant_Manager.Classes;
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
    /// Interaction logic for MenuEditWindow.xaml
    /// </summary>
    public partial class MenuEditWindow : Window
    {
        public Classes.Menu Menu { get; set; }
        public MenuEditWindow(Classes.Menu menu)
        {
            InitializeComponent();
            Menu = menu;
            NameBox.Text = Menu.Name;
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            Restaurant.EditMenuInformation(Menu.ID,NameBox.Text);
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
