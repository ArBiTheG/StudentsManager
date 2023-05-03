using StudentsManagerApp.ViewModel.Dialogs;
using StudentsManagerData;
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
    /// Логика взаимодействия для SpecialtyWindow.xaml
    /// </summary>
    public partial class SpecialtyWindow : Window
    {
        public SpecialtyDialogViewModel ViewModel { get; private set; }
        public SpecialtyWindow(Specialty specialty, IStudentsData studentsData)
        {
            InitializeComponent();
            ViewModel = new SpecialtyDialogViewModel(specialty, studentsData);
            DataContext = ViewModel;
        }

        void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
