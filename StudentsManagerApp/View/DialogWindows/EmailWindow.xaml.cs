﻿using StudentsManagerData.Table;
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

namespace StudentsManagerApp.View.DialogWindows
{
    /// <summary>
    /// Логика взаимодействия для EmailWindow.xaml
    /// </summary>
    public partial class EmailWindow : Window
    {
        public Email Email { get; private set; }
        public EmailWindow(Email email)
        {
            InitializeComponent();
            Email = email;
            DataContext = Email;
        }

        void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
