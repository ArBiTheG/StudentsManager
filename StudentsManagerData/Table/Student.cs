using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagerData.Table
{
    public class Student: ICloneable, IEquatable<Student?>, INotifyPropertyChanged
    {
        int id;
        int person_id;
        Person person;
        int group_id;
        Group group;
        DateTime? date_entry;
        DateTime? date_escape;
        bool is_escaped;
        string? reason;

        public Student()
        {
        }
        //Используется для клонирования
        private Student(int id, int person_id, Person person, int group_id, Group group, DateTime? date_entry, DateTime? date_escape, bool is_escaped, string? reason)
        {
            this.id = id;
            this.person_id = person_id;
            this.person = person;
            this.group_id = group_id;
            this.group = group;
            this.date_entry = date_entry;
            this.date_escape = date_escape;
            this.is_escaped = is_escaped;
            this.reason = reason;
        }

        /// <summary>
        /// Код
        /// </summary>
        public int Id { 
            get 
            { 
                return id; 
            } 
        }

        /// <summary>
        /// Код человека
        /// </summary>
        public int PersonId { 
            get 
            { 
                return person_id; 
            } 
            set 
            { 
                person_id = value;
            } 
        }

        /// <summary>
        /// Объект человека
        /// </summary>
        public Person Person { 
            get 
            { 
                return person; 
            } 
            set 
            { 
                person = value;
                OnPropertyChanged("Person");
                OnPropertyChanged("FullName");
            } 
        }

        /// <summary>
        /// Код группы
        /// </summary>
        public int GroupId { 
            get 
            { 
                return group_id; 
            } 
            set 
            { 
                group_id = value; 
            } 
        }

        /// <summary>
        /// Объект группы
        /// </summary>
        public Group Group { 
            get 
            { 
                return group; 
            } 
            set 
            { 
                group = value;
                OnPropertyChanged("Group");
                OnPropertyChanged("FullName");
            } 
        }
        /// <summary>
        /// Дата поступления
        /// </summary>
        public DateTime? DateEntry { 
            get 
            { 
                return date_entry; 
            } 
            set 
            { 
                date_entry = value;
                OnPropertyChanged("DateEntry");
            } 
        }
        /// <summary>
        /// Дата отчисления
        /// </summary>
        public DateTime? DateEscape { 
            get 
            { 
                return date_escape; 
            } 
            set 
            { 
                date_escape = value;
                OnPropertyChanged("DateEscape");
            } 
        }
        /// <summary>
        /// Отчислен?
        /// </summary>
        public bool IsEscaped { 
            get 
            { 
                return is_escaped; 
            } 
            set 
            { 
                is_escaped = value;
                OnPropertyChanged("IsEscaped");
            } 
        }
        /// <summary>
        /// Причина отчисления
        /// </summary>
        public string? Reason { 
            get 
            { 
                return reason; 
            } 
            set 
            { 
                reason = value;
                OnPropertyChanged("Reason");
            }
        }

        /// <summary>
        /// Полное имя
        /// </summary>
        [NotMapped]
        public string FullName
        {
            get
            {
                if (Person == null || Group == null)
                    return null;
                return $"{Person.FullName} - {Group.Name}";
            }
        }

        /// <summary>
        /// Загрузить значения в поля
        /// </summary>
        /// <param name="student">Откуда будут взяты значения полей</param>
        public void Load(Student student)
        {
            PersonId = student.person_id;
            Person = student.person;
            Person = student.person;
            GroupId = student.group_id;
            Group = student.group;
            DateEntry = student.date_entry;
            DateEscape = student.date_escape;
            IsEscaped = student.is_escaped;
            Reason = student.reason;
        }
        public object Clone() => new Student(id,person_id,person,group_id,group,date_entry,date_escape,is_escaped,reason);

        public override bool Equals(object? obj)
        {
            return Equals(obj as Student);
        }

        public bool Equals(Student? other)
        {
            return other is not null &&
                   id == other.id &&
                   person_id == other.person_id &&
                   EqualityComparer<Person>.Default.Equals(person, other.person) &&
                   group_id == other.group_id &&
                   EqualityComparer<Group>.Default.Equals(group, other.group) &&
                   date_entry == other.date_entry &&
                   date_escape == other.date_escape &&
                   is_escaped == other.is_escaped &&
                   reason == other.reason;
        }

        public static bool operator ==(Student? left, Student? right)
        {
            return EqualityComparer<Student>.Default.Equals(left, right);
        }

        public static bool operator !=(Student? left, Student? right)
        {
            return !(left == right);
        }
        public new string ToString()
        {
            return "id: "+ id.ToString() + " / name: " + FullName.ToString();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
