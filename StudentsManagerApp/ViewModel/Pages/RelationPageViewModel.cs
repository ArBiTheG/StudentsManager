using StudentsManagerData.Table;
using StudentsManagerData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentsManagerApp.View.DialogWindows;

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
            RelationWindow relationWindow = new RelationWindow(new Relation(), childs, parents);
            if (relationWindow.ShowDialog() == true)
            {
                Relation relation = relationWindow.ViewModel.Relation;
                StudentsData.Add(relation);
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

        public override void EditField(object? selected_obj)
        {
            Relation? relation = selected_obj as Relation;
            if (relation == null) return;
            Relation vm = relation.Clone() as Relation;

            RelationWindow relationWindow = new RelationWindow(vm, childs, parents);

            if (relationWindow.ShowDialog() == true)
            {
                relation.Load(relationWindow.ViewModel.Relation);
                StudentsData.Edit(relation);
                StudentsData.SaveChanges();
            }
        }

    }
}
