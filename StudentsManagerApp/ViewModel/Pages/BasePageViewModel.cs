using StudentsManager;
using StudentsManagerApp.View.DialogWindows;
using StudentsManagerData;
using StudentsManagerData.Table;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentsManagerApp.ViewModel.Pages
{
    public abstract class BasePageViewModel: INotifyPropertyChanged
    {
        bool loaded;

        RelayCommand? addCommand;
        RelayCommand? editCommand;
        RelayCommand? deleteCommand;
        RelayCommand? updateCommand;

        protected BasePageViewModel()
        {
            Task.Run(()=> {
                Loaded = false;
                Load();
                Loaded = true;
            }
            );
        }

        public bool Loaded
        {
            get { return loaded; }
            private set
            {
                loaded = value;
                OnPropertyChanged(nameof(Loaded));
            }
        }

        /// <summary>
        /// Команда добавления записи
        /// </summary>
        public RelayCommand AddCommand { get { return addCommand ?? (addCommand = new RelayCommand(AddField)); } }
        
        /// <summary>
        /// Команда редактирования записи
        /// </summary>
        public RelayCommand EditCommand { get { return editCommand ?? (editCommand = new RelayCommand(EditField)); } }
        
        /// <summary>
        /// Команда удаления записи
        /// </summary>
        public RelayCommand DeleteCommand { get { return deleteCommand ??(deleteCommand = new RelayCommand(DeleteField)); } }
        
        /// <summary>
        /// Команда обновления записей
        /// </summary>
        public RelayCommand UpdateCommand { get { return updateCommand ?? (updateCommand = new RelayCommand(Update)); } }


        /// <summary>
        /// Загрузка модели
        /// </summary>
        public abstract void Load();

        /// <summary>
        /// Закрытие модели
        /// </summary>
        public abstract void Close();

        /// <summary>
        /// Добавление записи
        /// </summary>
        public abstract void AddField(object? obj);

        /// <summary>
        /// Редактирование записи
        /// </summary>
        /// <param name="selected_obj">Выбранный объект</param>
        public abstract void EditField(object? selected_obj);

        /// <summary>
        /// Удаление записи
        /// </summary>
        /// <param name="selected_obj">Выбранный объект</param>
        public abstract void DeleteField(object? selected_obj);

        /// <summary>
        /// Обновить данные
        /// </summary>
        public void Update(object? obj)
        {
            Load();
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
