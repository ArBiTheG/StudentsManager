using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagerData.Table
{
    public class Decree : ICopyable<Decree?>, ICloneable<Decree?>, IEquatable<Decree?>, INotifyPropertyChanged
    {
        private int id;
        private int student_id;
        private Student student;
        private string? description;
        private int type_decree;


        /// <summary>
        /// Код
        /// </summary>
        public int Id
        {
            get
            {
                return id;
            }
        }

        /// <summary>
        /// Код студента
        /// </summary>
        public int StudentId
        {
            get
            {
                return student_id;
            }
            set
            {
                student_id = value;
            }
        }

        /// <summary>
        /// Объект студента
        /// </summary>
        public Student Student
        {
            get
            {
                return student;
            }
            set
            {
                student = value;
                OnPropertyChanged(nameof(Student));
            }
        }

        /// <summary>
        /// Описание приказа
        /// </summary>
        public string? Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        /// <summary>
        /// Идентификатор
        /// </summary>
        public int TypeDecree
        {
            get
            {
                return type_decree;
            }
            set
            {
                type_decree = value;
                OnPropertyChanged(nameof(TypeDecree));
            }
        }

        public void Copy(Decree? entity)
        {
            if (entity == null) return;
            StudentId = entity.student_id;
            Student = entity.student;
            Description = entity.description;
            TypeDecree = entity.type_decree;
        }
        public Decree Clone()
        {
            return new Decree()
            {
                id = id,
                student_id = student_id,
                student = student,
                description = description,
                type_decree = type_decree
            };
        }

        public override string ToString()
        {
            return "id: " + id.ToString();
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Decree);
        }

        public bool Equals(Decree? other)
        {
            return other is not null &&
                   id == other.id &&
                   student_id == other.student_id &&
                   student == other.student &&
                   description == other.description &&
                   type_decree == other.type_decree;
        }

        public static bool operator ==(Decree? left, Decree? right)
        {
            return EqualityComparer<Decree>.Default.Equals(left, right);
        }

        public static bool operator !=(Decree? left, Decree? right)
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
