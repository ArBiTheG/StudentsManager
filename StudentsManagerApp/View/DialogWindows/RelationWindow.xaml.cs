﻿using StudentsManagerApp.ViewModel.Dialogs;
using StudentsManagerData.Table;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для RelationWindow.xaml
    /// </summary>
    public partial class RelationWindow : Window
    {
        public RelationDialogViewModel ViewModel { get; private set; }
        public RelationWindow(Relation relation, ObservableCollection<Person> childs, ObservableCollection<Person> parents)
        {
            InitializeComponent();
            ViewModel = new RelationDialogViewModel(relation, childs, parents);
            DataContext = ViewModel;
        }
        void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
