using StudentsManagerData.Tables;
using StudentsManagerData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentsManagerApp.View.DialogWindows;
using StudentsManagerApp.ViewModel.Dialogs;

namespace StudentsManagerApp.ViewModel.Pages
{
    public class RelationPageViewModel : BasePageViewModel
    {
        private IStudentsData StudentsData;
        private ObservableCollection<Relation> relations;
        private ObservableCollection<Person> childs;
        private ObservableCollection<Person> parents;
        public override void Load()
        {
            StudentsData = new StudentsDataProxy();
            // Подгружаем второстепенные данные
            childs = StudentsData.GetPersons();
            parents = StudentsData.GetPersons();
            // Подгружаем основные данные
            Relations = StudentsData.GetRelations();
        }
        public ObservableCollection<Relation> Relations
        {
            get { return relations; }
            set
            {
                relations = value;
                OnPropertyChanged(nameof(Relations));
            }
        }

        public override void Close()
        {
            throw new NotImplementedException();
        }

        public override void AddField(object? obj)
        {
            RelationDialogViewModel viewModelDialog = new RelationDialogViewModel(new Relation(), StudentsData);
            viewModelDialog.LoadChilds();
            viewModelDialog.LoadParents();

            RelationWindow relationWindow = new RelationWindow(viewModelDialog);
            if (relationWindow.ShowDialog() == true)
            {
                Relation relation = viewModelDialog.Relation;
                StudentsData.Add(relation);
                StudentsData.SaveChanges();
            }
        }

        public override void EditField(object? selected_obj)
        {
            Relation? relation = selected_obj as Relation;
            if (relation == null) return;

            RelationDialogViewModel viewModelDialog = new RelationDialogViewModel((Relation)relation.Clone(), StudentsData);
            viewModelDialog.LoadChilds();
            viewModelDialog.LoadParents();

            RelationWindow relationWindow = new RelationWindow(viewModelDialog);
            if (relationWindow.ShowDialog() == true)
            {
                viewModelDialog.Relation.Copy(relation);
                StudentsData.Edit(relation);
                StudentsData.SaveChanges();
            }
        }

        public override void DeleteField(object? selected_obj)
        {
            Relation? relation = selected_obj as Relation;
            if (relation == null) return;
            StudentsData.Remove(relation);
            StudentsData.SaveChanges();
        }
    }
}
