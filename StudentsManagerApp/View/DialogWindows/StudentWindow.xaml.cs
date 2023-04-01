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
    /// Логика взаимодействия для StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        public Student Student { get; private set; }
        public StudentWindow(Student student)
        {
            InitializeComponent();
            Student = student;
            DataContext = Student;
        }
        void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
