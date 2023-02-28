using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace StudentsManagerApp.ViewModel.Module
{
    public class ClockModule : INotifyPropertyChanged
    {
        Timer timer;

        DateTime сurrent;
        DateTime start;

        public string Current
        {
            get => сurrent.ToString("t");
        }
        public string Start
        {
            get => start.ToString();
        }

        public ClockModule()
        {
            start = DateTime.Now;

            сurrent = start;


            timer = new Timer(1000);
            timer.Elapsed += Tick;
            timer.Start();
        }
        private void Tick(object sender, ElapsedEventArgs e)
        {
            DateTime old = сurrent;
            сurrent = DateTime.Now;
            if (сurrent.Minute != old.Minute)
            {
                OnPropertyChanged("Current");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
