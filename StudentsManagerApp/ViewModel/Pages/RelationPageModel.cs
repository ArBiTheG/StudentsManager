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
    public class RelationPageModel : BasePageModel
    {
        ObservableCollection<Relation> relations;
        public ObservableCollection<Relation> Relations
        {
            get { return relations; }
            set
            {
                relations = value;
                OnPropertyChanged(nameof(Relations));
            }
        }

        public override void Load()
        {
            StudentsContext = new StudentsContext();
            StudentsContext.Relations.Load();
            Relations = StudentsContext.Relations.Local.ToObservableCollection();
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
