using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagerData.Table
{
    public class Specialty: ICloneable, IEquatable<Specialty?>, INotifyPropertyChanged
    {
        int id;
        string code;
        string name;
        string skill;
        int duration;
        string? description;
        DateTime? date_created;
        DateTime? date_deleted;
        bool is_deleted;
        string? reason;

        public Specialty()
        {
        }
        //Используется для клонирования
        private Specialty(int id, string? code, string? name, string? skill, int duration, string? description, DateTime? date_created, DateTime? date_deleted, bool is_deleted, string? reason)
        {
            this.id = id;
            this.code = code;
            this.name = name;
            this.skill = skill;
            this.duration = duration;
            this.description = description;
            this.date_created = date_created;
            this.date_deleted = date_deleted;
            this.is_deleted = is_deleted;
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
        /// Шифр специальности
        /// </summary>
        public string Code { 
            get 
            { 
                return code; 
            }
            set 
            { 
                code = value;
                OnPropertyChanged("Code");
            } 
        }

        /// <summary>
        /// Наименование специальности
        /// </summary>
        public string Name { 
            get 
            { 
                return name; 
            } 
            set 
            { 
                name = value;
                OnPropertyChanged("Name");
            } 
        }

        /// <summary>
        /// Квалификация выпускника
        /// </summary>
        public string Skill { 
            get 
            { 
                return skill; 
            }
            set 
            { 
                skill = value;
                OnPropertyChanged("Skill");
            } 
        }

        /// <summary>
        /// Длительность обучения
        /// </summary>
        /// <remarks>
        /// Указывается в месяцах
        /// </remarks>
        public int Duration { 
            get 
            {
                return duration; 
            } 
            set 
            { 
                duration = value;
                OnPropertyChanged("Duration");
            } 
        }
        /// <summary>
        /// Описание специальности
        /// </summary>
        public string? Description { 
            get 
            { 
                return description; 
            } 
            set 
            { 
                description = value;
                OnPropertyChanged("Description");
            } 
        }
        /// <summary>
        /// Дата начала набора на специальность
        /// </summary>
        public DateTime? DateCreated { 
            get 
            { 
                return date_created; 
            } 
            set 
            { 
                date_created = value;
                OnPropertyChanged("DateCreated");
            } 
        }
        /// <summary>
        /// Дата прекращения набора на специальность
        /// </summary>
        public DateTime? DateDeleted { 
            get 
            { 
                return date_deleted; 
            } 
            set 
            { 
                date_deleted = value;
                OnPropertyChanged("DateDeleted");
            } 
        }
        /// <summary>
        /// Набор прекращён?
        /// </summary>
        public bool IsDeleted { 
            get 
            { 
                return is_deleted;
            } 
            set 
            { 
                is_deleted = value;
                OnPropertyChanged("IsDeleted");
            }
        }
        /// <summary>
        /// Причина прекращения набора на специальность
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
        /// Группы
        /// </summary>
        public List<Group> Groups { get; set; }

        /// <summary>
        /// Загрузить значения в поля
        /// </summary>
        /// <param name="specialty">Откуда будут взяты значения полей</param>
        public void Load(Specialty specialty)
        {
            Code = specialty.code;
            Name = specialty.name;
            Skill = specialty.skill;
            Duration = specialty.duration;
            Description = specialty.description;
            DateCreated = specialty.date_created;
            DateDeleted = specialty.date_deleted;
            IsDeleted = specialty.is_deleted;
            Reason = specialty.reason;
        }
        public object Clone() => new Specialty(id,code,name,skill,duration,description,date_created,date_deleted, is_deleted,reason);

        public override bool Equals(object? obj)
        {
            return Equals(obj as Specialty);
        }

        public bool Equals(Specialty? other)
        {
            return other is not null &&
                   id == other.id &&
                   code == other.code &&
                   name == other.name &&
                   skill == other.skill &&
                   duration == other.duration &&
                   description == other.description &&
                   date_created == other.date_created &&
                   date_deleted == other.date_deleted &&
                   is_deleted == other.is_deleted &&
                   reason == other.reason;
        }

        public static bool operator ==(Specialty? left, Specialty? right)
        {
            return EqualityComparer<Specialty>.Default.Equals(left, right);
        }

        public static bool operator !=(Specialty? left, Specialty? right)
        {
            return !(left == right);
        }

        public new string ToString()
        {
            return "id: " + id.ToString() + " / name: " + name.ToString();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
