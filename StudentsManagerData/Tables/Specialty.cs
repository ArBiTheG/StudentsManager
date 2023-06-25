using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagerData.Tables
{
    public class Specialty: ICopyable<Specialty?>, ICloneable<Specialty?>, IEquatable<Specialty?>, INotifyPropertyChanged
    {
        int id;
        string code;
        string name;
        string skill;
        int duration;
        string? about;
        DateTime? date_created;
        DateTime? date_deleted;
        bool is_deleted;
        string? reason_deleted;

        public Specialty()
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
                OnPropertyChanged(nameof(Code));
                OnPropertyChanged(nameof(FullName));
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
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(FullName));
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
                OnPropertyChanged(nameof(Skill));
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
                OnPropertyChanged(nameof(Duration));
            } 
        }
        /// <summary>
        /// Описание специальности
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
                OnPropertyChanged(nameof(DateCreated));
            }
        }
        /// <summary>
        /// Набор прекращён?
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
                OnPropertyChanged(nameof(DateDeleted));
            } 
        }
        /// <summary>
        /// Причина прекращения набора на специальность
        /// </summary>
        public string? ReasonDeleted { 
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
        /// Полное имя
        /// </summary>
        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{code} {name}";
            }
        }

        /// <summary>
        /// Группы
        /// </summary>
        public List<Group> Groups { get; set; }

        public override string ToString()
        {
            return "id: " + id.ToString() + " / name: " + name.ToString();
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Specialty);
        }

        public void Copy(Specialty? specialty)
        {
            if (specialty == null) return;
            specialty.Code = code;
            specialty.Name = name;
            specialty.Skill = skill;
            specialty.Duration = duration;
            specialty.About = about;
            specialty.DateCreated = date_created;
            specialty.DateDeleted = date_deleted;
            specialty.IsDeleted = is_deleted;
            specialty.ReasonDeleted = reason_deleted;
        }
        public Specialty Clone()
        {
            return new Specialty()
            {
                id = id,
                code = code,
                name = name,
                skill = skill,
                duration = duration,
                about = about,
                date_created = date_created,
                date_deleted = date_deleted,
                is_deleted = is_deleted,
                reason_deleted = reason_deleted
            };
        }

        public bool Equals(Specialty? other)
        {
            return other is not null &&
                   id == other.id &&
                   code == other.code &&
                   name == other.name &&
                   skill == other.skill &&
                   duration == other.duration &&
                   about == other.about &&
                   date_created == other.date_created &&
                   date_deleted == other.date_deleted &&
                   is_deleted == other.is_deleted &&
                   reason_deleted == other.reason_deleted;
        }

        public static bool operator ==(Specialty? left, Specialty? right)
        {
            return EqualityComparer<Specialty>.Default.Equals(left, right);
        }

        public static bool operator !=(Specialty? left, Specialty? right)
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
