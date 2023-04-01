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
    public class DiplomaPageModel : PageModel<Diploma>
    {
        public override void Load()
        {
            StudentsContext = new StudentsContext();
            StudentsContext.Diplomas.Load();
            PrimaryList = StudentsContext.Diplomas.Local.ToObservableCollection();
        }
        public override void Close()
        {
            throw new NotImplementedException();
        }

        public override void AddField(object? obj)
        {
            DiplomaWindow diplomaWindow = new DiplomaWindow(new Diploma());
            if (diplomaWindow.ShowDialog() == true)
            {
                Diploma diploma = diplomaWindow.Diploma;
                StudentsContext.Diplomas.Add(diploma);
                StudentsContext.SaveChanges();
            }
        }

        public override void DeleteField(object? selected_obj)
        {
            Diploma? diploma = selected_obj as Diploma;
            if (diploma == null) return;
            StudentsContext.Diplomas.Remove(diploma);
            StudentsContext.SaveChanges();
        }

        public override void EditField(object? selected_obj)
        {
            Diploma? diploma = selected_obj as Diploma;
            if (diploma == null) return;
            Diploma vm = diploma.Clone() as Diploma;

            DiplomaWindow diplomaWindow = new DiplomaWindow(vm);

            if (diplomaWindow.ShowDialog() == true)
            {
                diploma.Write(diplomaWindow.Diploma);
                StudentsContext.Diplomas.Entry(diploma).State = EntityState.Modified;
                StudentsContext.SaveChanges();
            }
        }
    }
}
