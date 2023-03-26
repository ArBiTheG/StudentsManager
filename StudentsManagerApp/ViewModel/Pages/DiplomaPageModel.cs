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
    public class DiplomaPageModel : BasePageModel
    {
        ObservableCollection<Diploma> diplomas;
        public ObservableCollection<Diploma> Diplomas
        {
            get { return diplomas; }
            set
            {
                diplomas = value;
                OnPropertyChanged(nameof(Diplomas));
            }
        }

        public override void Load()
        {
            StudentsContext = new StudentsContext();
            StudentsContext.Diplomas.Load();
            Diplomas = StudentsContext.Diplomas.Local.ToObservableCollection();
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
