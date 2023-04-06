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
    public class GroupPageModel : PageModel<Group>
    {
        public override void Load()
        {
            StudentsContext = new StudentsContext();
            StudentsContext.Groups.Load();
            PrimaryList = StudentsContext.Groups.Local.ToObservableCollection();
        }
        public override void Close()
        {
            throw new NotImplementedException();
        }
        public override void AddField(object? obj)
        {
            GroupWindow groupWindow = new GroupWindow(new Group());
            if (groupWindow.ShowDialog() == true)
            {
                Group group = groupWindow.Group;
                StudentsContext.Groups.Add(group);
                StudentsContext.SaveChanges();
            }
        }

        public override void DeleteField(object? selected_obj)
        {
            Group? group = selected_obj as Group;
            if (group == null) return;
            StudentsContext.Groups.Remove(group);
            StudentsContext.SaveChanges();
        }

        public override void EditField(object? selected_obj)
        {
            Group? group = selected_obj as Group;
            if (group == null) return;
            Group vm = group.Clone() as Group;

            GroupWindow groupWindow = new GroupWindow(vm);

            if (groupWindow.ShowDialog() == true)
            {
                group.Load(groupWindow.Group);
                StudentsContext.Groups.Entry(group).State = EntityState.Modified;
                StudentsContext.SaveChanges();
            }
        }

    }
}
