using StudentsManager;
using StudentsManagerApp.View.Pages;
using StudentsManagerApp.ViewModel.Module;
using StudentsManagerApp.ViewModel.Pages;
using StudentsManagerData;
using StudentsManagerData.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace StudentsManagerApp.ViewModel
{
    public class MainWindowModel : INotifyPropertyChanged
    {
        ClockModule clockModule = new ClockModule();

        UserControl? content;

        RelayCommand? changePage;

        static PageInfo[] pageInfo =
        {
            new PageInfo {DisplayName = "Главная", Name = "Main"},
            new PageInfo {DisplayName = "Основные данные", Name = "Person", Enabled = true},
            new PageInfo {DisplayName = "Данные студентов", Name = "Student"},
            new PageInfo {DisplayName = "Управление группами", Name = "Group"},
            new PageInfo {DisplayName = "Управление специальностями", Name = "Specialty", Enabled = true},
            new PageInfo {DisplayName = "Список электронных почт", Name = "Email", Enabled = true},
            new PageInfo {DisplayName = "Список номеров телефонов", Name = "Phone", Enabled = true},
            new PageInfo {DisplayName = "Список хобби", Name = "Hobby", Enabled = true},
            new PageInfo {DisplayName = "Список школ", Name = "School", Enabled = true},
        };

        public ClockModule Clock { get => clockModule; }

        public static PageInfo[] PageInfo { get => pageInfo; }

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
                      if (content != null)
                      {
                          if (content is IClosablePage)
                          {
                              (content as IClosablePage).Close();
                          }
                          content = null;
                      }
                      switch (pageName)
                      {
                          case "Person":
                              Content = new PersonPage();
                              break;
                          case "Student":
                              Content = new StudentPage();
                              break;
                          case "Group":
                              Content = new GroupPage();
                              break;
                          case "Specialty":
                              Content = new SpecialtyPage();
                              break;
                          case "Email":
                              Content = new EmailPage();
                              break;
                          case "Phone":
                              Content = new PhonePage();
                              break;
                          case "Hobby":
                              Content = new HobbyPage();
                              break;
                          case "School":
                              Content = new SchoolPage();
                              break;
                          case "Main":
                          default:
                              Content = MainPage.Create(this);
                              break;
                      }
                  }));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
