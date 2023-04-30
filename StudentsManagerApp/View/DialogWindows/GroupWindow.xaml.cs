using StudentsManagerApp.ViewModel.Dialogs;
using StudentsManagerData;
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
    /// Логика взаимодействия для GroupWindow.xaml
    /// </summary>
    public partial class GroupWindow : Window
    {
        public GroupDialogViewModel ViewModel { get; private set; }
        public GroupWindow(Group group, IStudentsData studentsData)
        {
            InitializeComponent();
            ViewModel = new GroupDialogViewModel(group, studentsData);
            DataContext = ViewModel;
        }

        void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
