﻿using System;
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
    /// Interaction logic for MenuTile.xaml
    /// </summary>
    public partial class MenuTile : UserControl
    {
        public Page Page { get; set; }
        public Menu Menu{ get; set; }
        public Restaurant Restaurant { get; set; }
        public MenuTile(Menu menu,Page page,Restaurant restaurant)
        {
            Menu = menu;
            Page = page;
            Restaurant = restaurant;
            InitializeComponent();
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            NameBlock.Text = Menu.Name;
            Menu.Foods.ForEach(food =>
            {
                FoodTileList.Children.Add(new FoodTile(food,Page,Restaurant));
            });
        }
    }
}
