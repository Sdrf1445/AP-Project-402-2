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
    /// Interaction logic for EditCommentWindow.xaml
    /// </summary>
    public partial class EditCommentWindow : Window
    {
        public Comment Comment { get; set; }
        public EditCommentWindow(Comment comment)
        {
            InitializeComponent();
            Comment = comment;
            CommentBox.Text = Comment.Message;
        }
    }
}
