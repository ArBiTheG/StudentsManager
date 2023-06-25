using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagerData.Tables
{
    public class Student : ICopyable<Student?>, ICloneable<Student?>, IEquatable<Student?>, INotifyPropertyChanged
    {
        int id;
        int person_id;
        Person person;
        int group_id;
        Group group;
        DateTime? date_entry;
        DateTime? date_escaped;
        bool is_escaped;
        string? reason_escaped;
        string? about;

        public Student()
        {
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
                OnPropertyChanged(nameof(Person));
                OnPropertyChanged(nameof(FullName));
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
                OnPropertyChanged(nameof(Group));
                OnPropertyChanged(nameof(FullName));
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
                OnPropertyChanged(nameof(DateEntry));
            }
        }
        /// <summary>
        /// Отчислен?
        /// </summary>
        public bool IsEscaped
        {
            get
            {
                return is_escaped;
            }
            set
            {
                is_escaped = value;
                OnPropertyChanged(nameof(IsEscaped));
            }
        }
        /// <summary>
        /// Дата отчисления
        /// </summary>
        public DateTime? DateEscaped {
            get
            {
                return date_escaped;
            }
            set
            {
                date_escaped = value;
                OnPropertyChanged(nameof(DateEscaped));
            }
        }
        /// <summary>
        /// Причина отчисления
        /// </summary>
        public string? ReasonEscaped {
            get
            {
                return reason_escaped;
            }
            set
            {
                reason_escaped = value;
                OnPropertyChanged(nameof(ReasonEscaped));
            }
        }
        /// <summary>
        /// О студенте
        /// </summary>
        public string? About
        {
            get
            {
                return about;
            }
            set
            {
                about = value;
                OnPropertyChanged(nameof(About));
            }
        }

        public List<Decree> Decrees { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                if (person == null)
                    return string.Empty;
                return Person.FullName;
            }
        }

        public override string ToString()
        {
            return "id: " + id.ToString() + " / name: " + FullName.ToString();
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Student);
        }

        public void Copy(Student? student)
        {
            if (student == null) return;
            student.PersonId = person_id;
            student.Person = person;
            student.GroupId = group_id;
            student.Group = group;
            student.DateEntry = date_entry;
            student.DateEscaped = date_escaped;
            student.IsEscaped = is_escaped;
            student.ReasonEscaped = reason_escaped;
            student.About = about;
        }
        public Student Clone()
        {
            return new Student()
            {
                id = id,
                person_id = person_id,
                person = person,
                group_id = group_id,
                group = group,
                date_entry = date_entry,
                date_escaped = date_escaped,
                is_escaped = is_escaped,
                reason_escaped = reason_escaped,
                about = about
            };
        }

        public bool Equals(Student? other)
        {
            return other is not null &&
                   id == other.id &&
                   person_id == other.person_id &&
                   person == other.person &&
                   group_id == other.group_id &&
                   group == other.group &&
                   date_entry == other.date_entry &&
                   date_escaped == other.date_escaped &&
                   is_escaped == other.is_escaped &&
                   reason_escaped == other.reason_escaped &&
                   about == other.about;
        }

        public static bool operator ==(Student? left, Student? right)
        {
            return EqualityComparer<Student>.Default.Equals(left, right);
        }

        public static bool operator !=(Student? left, Student? right)
        {
            return !(left == right);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
