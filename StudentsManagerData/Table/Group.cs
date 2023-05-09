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
    public class Group: ICopyable<Group?>,ICloneable<Group?>, IEquatable<Group?>, INotifyPropertyChanged
    {
        int id;
        string name;
        int spec_id;
        Specialty specialty;
        byte type_training;
        string? about;
        DateTime date_created;
        bool is_deleted;
        DateTime date_deleted;
        string? reason_deleted;
        int curator_id;
        Curator curator;

        public Group()
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
        /// Наименование группы
        /// </summary>
        public string Name { 
            get 
            {
                return name;
            } 
            set
            { 
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        /// <summary>
        /// Код специальности
        /// </summary>
        public int SpecialtyId { 
            get 
            { 
                return spec_id;
            } 
            set
            { 
                spec_id = value;
            }
        }
        /// <summary>
        /// Объект специальности
        /// </summary>
        public Specialty Specialty { 
            get 
            { 
                return specialty; 
            } 
            set 
            { 
                specialty = value;
                OnPropertyChanged(nameof(Specialty));
            } 
        }
        /// <summary>
        /// Форма обучения
        /// </summary>
        public byte TypeTraining { 
            get 
            { 
                return type_training; 
            } 
            set 
            { 
                type_training = value;
                OnPropertyChanged(nameof(TypeTraining));
            } 
        }
        /// <summary>
        /// Подробности
        /// </summary>
        public string? About {
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
        /// <summary>
        /// Дата создания группы
        /// </summary>
        public DateTime DateCreated { 
            get 
            { 
                return date_created; 
            } 
            set 
            {
                date_created = value;
                OnPropertyChanged(nameof(DateCreated));
            }
        }
        /// <summary>
        /// Удалена ли группа
        /// </summary>
        public bool IsDeleted
        {
            get
            {
                return is_deleted;
            }
            set
            {
                is_deleted = value;
                OnPropertyChanged(nameof(IsDeleted));
            }
        }
        /// <summary>
        /// Дата удаления группы
        /// </summary>
        public DateTime DateDeleted { 
            get 
            {
                return date_deleted; 
            } 
            set 
            { 
                date_deleted = value;
                OnPropertyChanged(nameof(DateDeleted));
            }
        }

        /// <summary>
        /// Причина удаления группы
        /// </summary>
        public string? ReasonDeleted
        {
            get
            {
                return reason_deleted;
            }
            set
            {
                reason_deleted = value;
                OnPropertyChanged(nameof(ReasonDeleted));
            }
        }

        /// <summary>
        /// Код куратора
        /// </summary>
        public int CuratorId
        {
            get
            {
                return curator_id;
            }
            set
            {
                curator_id = value;
            }
        }
        
        /// <summary>
        /// Объект куратора
        /// </summary>
        public Curator Curator
        {
            get
            {
                return curator;
            }
            set
            {
                curator = value;
                OnPropertyChanged(nameof(Curator));
            }
        }

        /// <summary>
        /// Студенты
        /// </summary>
        public List<Student> Students { get; set; }

        public override string ToString()
        {
            return "id: " + id.ToString() + " / name: " + name.ToString();
        }
        public override bool Equals(object? obj)
        {
            return Equals(obj as Group);
        }

        public void Copy(Group? group)
        {
            if (group == null) return;
            Name = group.name;
            SpecialtyId = group.spec_id;
            Specialty = group.specialty;
            TypeTraining = group.type_training;
            About = group.about;
            DateCreated = group.date_created;
            DateDeleted = group.date_deleted;
        }
        public Group Clone()
        {
            return new Group()
            {
                id = id, 
                name = name, 
                spec_id = spec_id, 
                specialty = specialty, 
                type_training = type_training, 
                about = about, 
                date_created = date_created, 
                date_deleted = date_deleted
            };
        }


        public bool Equals(Group? other)
        {
            return other is not null &&
                   id == other.id &&
                   name == other.name &&
                   spec_id == other.spec_id &&
                   specialty == other.specialty &&
                   type_training == other.type_training &&
                   about == other.about &&
                   date_created == other.date_created &&
                   date_deleted == other.date_deleted;
        }

        public static bool operator ==(Group? left, Group? right)
        {
            return EqualityComparer<Group>.Default.Equals(left, right);
        }

        public static bool operator !=(Group? left, Group? right)
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
