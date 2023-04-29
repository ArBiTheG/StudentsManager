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
    public class RelationPageViewModel : BasePageViewModel<Relation>
    {
        private ObservableCollection<Person> childs;
        private ObservableCollection<Person> parents;
        public override void Load()
        {
            StudentsContext = new StudentsContext();
            StudentsContext.Relations.Load();
            StudentsContext.Persons.Load();
            PrimaryList = StudentsContext.Relations.Local.ToObservableCollection();
            childs = StudentsContext.Persons.Local.ToObservableCollection();
            parents = StudentsContext.Persons.Local.ToObservableCollection();
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
                StudentsContext.Relations.Add(relation);
                StudentsContext.SaveChanges();
            }
        }

        public override void DeleteField(object? selected_obj)
        {
            Relation? relation = selected_obj as Relation;
            if (relation == null) return;
            StudentsContext.Relations.Remove(relation);
            StudentsContext.SaveChanges();
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
                StudentsContext.Relations.Entry(relation).State = EntityState.Modified;
                StudentsContext.SaveChanges();
            }
        }

    }
}
