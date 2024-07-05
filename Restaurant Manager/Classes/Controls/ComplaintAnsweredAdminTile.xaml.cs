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
    /// Interaction logic for ComplaintAnsweredAdminTile.xaml
    /// </summary>
    public partial class ComplaintAnsweredAdminTile : UserControl
    {
        public Complaint Complaint {  get; set; }
        public ComplaintAnsweredAdminTile(Complaint complaint)
        {
            Complaint = complaint;
            InitializeComponent();
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            TitleBlock.Text = Complaint.Title;
            ByBlock.Text = $"By @{Complaint.AuthorUsername}";
            TextBox.Text = Complaint.Description;
            DateBlock.Text = Complaint.Date.ToString("MM/dd/yyyy");
            AnswerDateBlock.Text = Complaint.Answer!.Date.ToString("MM/dd/yyyy");
            AnswerTextBox.Text = Complaint.Answer!.Message;
        }
    }
}