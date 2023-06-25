using StudentsManagerApp.ViewModel.Dialogs;
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

namespace StudentsManagerApp.View.Dialogs
{
    /// <summary>
    /// Логика взаимодействия для GroupDialogWindow.xaml
    /// </summary>
    public partial class GroupDialogWindow : Window
    {
        public GroupDialogWindow(GroupDialogViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
