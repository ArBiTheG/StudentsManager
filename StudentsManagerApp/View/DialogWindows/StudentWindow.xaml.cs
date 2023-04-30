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
    /// Логика взаимодействия для StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        public StudentDialogViewModel ViewModel { get; private set; }
         public StudentWindow(Student student, IStudentsData studentsData)
        {
            InitializeComponent();
            ViewModel = new StudentDialogViewModel(student, studentsData);
            DataContext = ViewModel;
        }
        void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
