using StudentsManagerApp.ViewModel.Dialogs;
using StudentsManagerData.Table;
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
    /// Логика взаимодействия для SchoolWindow.xaml
    /// </summary>
    public partial class SchoolWindow : Window
    {
        public SchoolDialogViewModel ViewModel { get; private set; }
        public SchoolWindow(School school)
        {
            InitializeComponent();
            ViewModel = new SchoolDialogViewModel(school);
            DataContext = ViewModel;
        }
        void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
