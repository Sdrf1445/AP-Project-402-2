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
    /// Interaction logic for RestaurantFilterControl.xaml
    /// </summary>
    public partial class RestaurantFilterControl : UserControl
    {
        public event EventHandler FilterChanged;
        public ReceptionType ReceptionType { get; set; } = ReceptionType.BOTH;
        public RatingsOrder RatingsOrder { get; set; } = RatingsOrder.Ascending;
        public string Location { get; set; } = "";
        public List<string> Locations { get; set; }
        public RestaurantFilterControl(List<string> Locations)
        {
            InitializeComponent();
            this.Locations = Locations;
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            foreach(var i in Locations)
            {
                var radioButton = new RadioButton();
                radioButton.Style = Application.Current.FindResource("Shared.RadioButton") as Style;
                radioButton.FontSize = 12;
                radioButton.Margin = new Thickness(0,10,0,0);
                radioButton.Content = i;
                radioButton.Height = 20;
                radioButton.GroupName = "LocationGroup";
                LocationBox.Children.Add(radioButton);
            }
        }
    }
    public enum RatingsOrder
    {
        Ascending,
        Descending,
    }
}