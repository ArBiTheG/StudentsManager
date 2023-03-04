using StudentsManagerData.Table;
using StudentsManagerData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StudentsManagerApp.ViewModel.Pages
{
    public class GroupPageModel : BaseHandleModel
    {
        StudentsContext studentsContext;
        public ObservableCollection<Group> Groups { get; set; }
        public GroupPageModel(StudentsContext studentsContext)
        {
            this.studentsContext = studentsContext;
            this.studentsContext.Groups.Load();
            Groups = this.studentsContext.Groups.Local.ToObservableCollection();
        }
        public override void Add(object? obj)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object? selected_obj)
        {
            throw new NotImplementedException();
        }

        public override void Edit(object? selected_obj)
        {
            throw new NotImplementedException();
        }
    }
}
