﻿using Microsoft.EntityFrameworkCore;
using StudentsManagerApp.View.Dialogs;
using StudentsManagerApp.ViewModel.Dialogs;
using StudentsManagerData;
using StudentsManagerData.Tables;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentsManagerApp.ViewModel.Pages
{
    public class SpecialtyPageViewModel : BasePageViewModel
    {
        private IStudentsData? StudentsData;
        private ObservableCollection<Specialty>? specialties;
        public ObservableCollection<Specialty>? Specialties
        {
            get { return specialties; }
            set
            {
                specialties = value;
                OnPropertyChanged(nameof(Specialties));
            }
        }

        public override void Load()
        {
            StudentsData = new StudentsDataProxy();
            // Подгружаем основные данные
            Specialties = StudentsData.GetSpecialties();
        }

        public override void Close()
        {
        }

        public override void AddField(object? obj)
        {
            if (StudentsData == null) return;

            SpecialtyDialogViewModel viewModelDialog = new SpecialtyDialogViewModel(new Specialty(), StudentsData);

            SpecialtyDialogWindow specialtyWindow = new SpecialtyDialogWindow(viewModelDialog);
            if (specialtyWindow.ShowDialog() == true)
            {
                Specialty specialty = viewModelDialog.Specialty;
                StudentsData.Add(specialty);
                StudentsData.SaveChanges();
            }
        }

        public override void EditField(object? selected_obj)
        {
            if (StudentsData == null) return;

            Specialty? specialty = selected_obj as Specialty;
            if (specialty == null) return;

            SpecialtyDialogViewModel viewModelDialog = new SpecialtyDialogViewModel(specialty.Clone(), StudentsData);

            SpecialtyDialogWindow specialtyWindow = new SpecialtyDialogWindow(viewModelDialog);
            if (specialtyWindow.ShowDialog() == true)
            {
                viewModelDialog.Specialty.Copy(specialty);
                StudentsData.Edit(specialty);
                StudentsData.SaveChanges();
            }
        }

        public override void DeleteField(object? selected_obj)
        {
            if (StudentsData == null) return;

            Specialty? specialty = selected_obj as Specialty;
            if (specialty == null) return;

            string text = $"Вы действительно хотите удалить запись '{specialty.FullName}'?";
            var result = MessageBox.Show(text, "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                StudentsData.Remove(specialty);
                StudentsData.SaveChanges();
            }
        }
    }
}
