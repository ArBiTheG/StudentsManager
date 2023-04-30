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
    /// Логика взаимодействия для PhoneWindow.xaml
    /// </summary>
    public partial class PhoneWindow : Window
    {
        public PhoneDialogViewModel ViewModel { get; private set; }
        public PhoneWindow(Phone phone, IStudentsData studentsData)
        {
            InitializeComponent();
            ViewModel = new PhoneDialogViewModel(phone, studentsData);
            DataContext = ViewModel;
        }
        void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
