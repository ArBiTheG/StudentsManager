using StudentsManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagerApp.ViewModel.Pages
{
    public abstract class BaseHandleModel
    {
        RelayCommand? addCommand;
        RelayCommand? editCommand;
        RelayCommand? deleteCommand;

        /// <summary>
        /// Команда добавления записи
        /// </summary>
        public RelayCommand AddCommand { get { return addCommand ?? (addCommand = new RelayCommand(Add)); } }
        /// <summary>
        /// Команда редактирования записи
        /// </summary>
        public RelayCommand EditCommand { get { return editCommand ?? (editCommand = new RelayCommand(Edit)); } }
        /// <summary>
        /// Команда удаления записи
        /// </summary>
        public RelayCommand DeleteCommand { get { return deleteCommand ??(deleteCommand = new RelayCommand(Delete)); } }
        /// <summary>
        /// Добавление записи
        /// </summary>
        /// 
        public abstract void Add(object? obj);
        /// <summary>
        /// Редактирование записи
        /// </summary>
        /// <param name="selected_obj">Выбранный объект</param>
        public abstract void Edit(object? selected_obj);
        /// <summary>
        /// Удаление записи
        /// </summary>
        /// <param name="selected_obj">Выбранный объект</param>
        public abstract void Delete(object? selected_obj);
    }
}
