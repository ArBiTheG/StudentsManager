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
    public class PhonePageModel : PageModel<Phone>
    {
        public override void Load()
        {
            StudentsContext = new StudentsContext();
            StudentsContext.Phones.Load();
            PrimaryList = StudentsContext.Phones.Local.ToObservableCollection();
        }

        public override void Close()
        {
            throw new NotImplementedException();
        }


        public override void AddField(object? obj)
        {
            PhoneWindow phoneWindow = new PhoneWindow(new Phone());
            if (phoneWindow.ShowDialog() == true)
            {
                Phone phone = phoneWindow.Phone;
                StudentsContext.Phones.Add(phone);
                StudentsContext.SaveChanges();
            }
        }

        public override void DeleteField(object? selected_obj)
        {
            Phone? phone = selected_obj as Phone;
            if (phone == null) return;
            StudentsContext.Phones.Remove(phone);
            StudentsContext.SaveChanges();
        }

        public override void EditField(object? selected_obj)
        {
            Phone? phone = selected_obj as Phone;
            if (phone == null) return;
            Phone vm = phone.Clone() as Phone;

            PhoneWindow phoneWindow = new PhoneWindow(vm);

            if (phoneWindow.ShowDialog() == true)
            {
                phone.Write(phoneWindow.Phone);
                StudentsContext.Phones.Entry(phone).State = EntityState.Modified;
                StudentsContext.SaveChanges();
            }
        }

    }
}
