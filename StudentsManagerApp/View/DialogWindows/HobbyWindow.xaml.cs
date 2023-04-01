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
    /// Логика взаимодействия для HobbyWindow.xaml
    /// </summary>
    public partial class HobbyWindow : Window
    {
        public Hobby Hobby { get; private set; }
        public HobbyWindow(Hobby hobby)
        {
            InitializeComponent();
            Hobby = hobby;
            DataContext = Hobby;
        }

        void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
