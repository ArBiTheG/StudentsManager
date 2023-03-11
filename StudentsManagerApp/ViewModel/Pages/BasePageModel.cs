using StudentsManager;
using StudentsManagerData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagerApp.ViewModel.Pages
{
    public abstract class BasePageModel: INotifyPropertyChanged
    {
        protected StudentsContext StudentsContext;

        RelayCommand? addCommand;
        RelayCommand? editCommand;
        RelayCommand? deleteCommand;

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
        /// Добавление записи
        /// </summary>
        /// 
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


        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
