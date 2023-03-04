using StudentsManager;
using StudentsManagerApp.View.Pages;
using StudentsManagerApp.ViewModel.Module;
using StudentsManagerData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace StudentsManagerApp.ViewModel
{
    public class MainWindowModel : INotifyPropertyChanged
    {
        StudentsContext studentsContext = new StudentsContext();

        ClockModule clockModule = new ClockModule();

        UserControl? content;

        RelayCommand? changePage;

        public ClockModule Clock { get => clockModule; }

        public UserControl Content
        {
            get
            {
                return content;
            }
            private set
            {
                content = value;
                OnPropertyChanged("Content");
            }
        }

        public RelayCommand ChangePage
        {
            get
            {
                return changePage ??
                  (changePage = new RelayCommand((page) =>
                  {
                      string? pageName = page as string;
                      Console.WriteLine(pageName);
                      if (content != null) content = null;
                      switch (pageName)
                      {
                          case "Person":
                              Content = PersonPage.Create(studentsContext);
                              break;
                          case "Main":
                          default:
                              Content = MainPage.Create(this);
                              break;
                      }
                  }));
            }
        }

        public MainWindowModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
