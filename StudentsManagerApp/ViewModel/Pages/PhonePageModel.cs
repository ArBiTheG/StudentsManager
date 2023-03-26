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
    public class PhonePageModel : BasePageModel
    {
        ObservableCollection<Phone> phones;
        public ObservableCollection<Phone> Phones
        {
            get { return phones; }
            set
            {
                phones = value;
                OnPropertyChanged(nameof(Phones));
            }
        }

        public override void Load()
        {
            StudentsContext = new StudentsContext();
            StudentsContext.Phones.Load();
            Phones = StudentsContext.Phones.Local.ToObservableCollection();
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
