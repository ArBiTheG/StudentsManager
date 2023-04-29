using StudentsManagerData.Table;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagerApp.ViewModel.Dialogs
{
    public class RelationDialogViewModel
    {
        public Relation Relation { get; set; }
        public ObservableCollection<Person> Childs { get; set; }
        public ObservableCollection<Person> Parents { get; set; }
        public RelationDialogViewModel(Relation relation, ObservableCollection<Person> childs, ObservableCollection<Person> parents) {
            Relation = relation;
            Childs = childs;
            Parents = parents;
        }
    }
}
