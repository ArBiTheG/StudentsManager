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
    public class HobbyPageViewModel : BasePageViewModel<Hobby>
    {
        private ObservableCollection<Person> persons;
        public override void Load()
        {
            StudentsContext = new StudentsContext();
            StudentsContext.Hobbies.Load();
            StudentsContext.Persons.Load();
            PrimaryList = StudentsContext.Hobbies.Local.ToObservableCollection();
            persons = StudentsContext.Persons.Local.ToObservableCollection();
        }

        public override void Close()
        {
            throw new NotImplementedException();
        }

        public override void AddField(object? obj)
        {
            HobbyWindow hobbyWindow = new HobbyWindow(new Hobby(), persons);
            if (hobbyWindow.ShowDialog() == true)
            {
                Hobby hobby = hobbyWindow.ViewModel.Hobby;
                StudentsContext.Hobbies.Add(hobby);
                StudentsContext.SaveChanges();
            }
        }

        public override void DeleteField(object? selected_obj)
        {
            Hobby? hobby = selected_obj as Hobby;
            if (hobby == null) return;
            StudentsContext.Hobbies.Remove(hobby);
            StudentsContext.SaveChanges();
        }

        public override void EditField(object? selected_obj)
        {
            Hobby? hobby = selected_obj as Hobby;
            if (hobby == null) return;
            Hobby vm = hobby.Clone() as Hobby;

            HobbyWindow hobbyWindow = new HobbyWindow(vm, persons);

            if (hobbyWindow.ShowDialog() == true)
            {
                hobby.Load(hobbyWindow.ViewModel.Hobby);
                StudentsContext.Hobbies.Entry(hobby).State = EntityState.Modified;
                StudentsContext.SaveChanges();
            }
        }

    }
}
