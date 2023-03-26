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
    public class GroupPageModel : BasePageModel
    {
        ObservableCollection<Group> groups;
        public ObservableCollection<Group> Groups
        {
            get { return groups; }
            set
            {
                groups = value;
                OnPropertyChanged(nameof(Groups));
            }
        }
        public override void Load()
        {
            StudentsContext = new StudentsContext();
            StudentsContext.Groups.Load();
            Groups = StudentsContext.Groups.Local.ToObservableCollection();
        }
        public override void Close()
        {
            throw new NotImplementedException();
        }
        public override void AddField(object? obj)
        {
            throw new NotImplementedException();
        }

        public override void DeleteField(object? selected_obj)
        {
            throw new NotImplementedException();
        }

        public override void EditField(object? selected_obj)
        {
            throw new NotImplementedException();
        }

    }
}
