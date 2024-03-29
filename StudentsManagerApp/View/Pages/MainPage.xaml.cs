﻿using StudentsManagerApp.ViewModel;
using StudentsManagerApp.ViewModel.Pages;
using StudentsManagerData;
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

namespace StudentsManagerApp.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : UserControl
    {
        MainWindowModel viewModel;
        public MainPage()
        {
            InitializeComponent();
        }
        static public MainPage Create(MainWindowModel model)
        {
            MainPage page = new MainPage();
            page.viewModel = model;
            page.DataContext = page.viewModel;
            return page;
        }
    }
}
