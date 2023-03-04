using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudentsManagerData.Table
{
    public class School: ICloneable, IEquatable<School?>, INotifyPropertyChanged
    {
        int id;
        string? full_name;
        string? short_name;
        string? address;
        string? description;

        public School()
        {
        }
        //Используется для клонирования
        private School(int id, string? full_name, string? short_name, string? address, string? description)
        {
            this.id = id;
            this.full_name = full_name;
            this.short_name = short_name;
            this.address = address;
            this.description = description;
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
        /// Полное наименование школы
        /// </summary>
        public string? FullName { 
            get 
            { 
                return full_name;
            } 
            set 
            { 
                full_name = value;
                OnPropertyChanged("FullName");
            } 
        }

        /// <summary>
        /// Короткое наименование школы
        /// </summary>
        public string? ShortName {
            get
            { 
                return short_name;
            } 
            set 
            { 
                short_name = value;
                OnPropertyChanged("ShortName");
            }
        }

        /// <summary>
        /// Адрес школы
        /// </summary>
        public string? Address { 
            get
            {
                return address; 
            }
            set
            { 
                address = value;
                OnPropertyChanged("Address");
            }
        }

        /// <summary>
        /// Описание школы
        /// </summary>
        public string? Description {
            get
            { 
                return description; 
            } 
            set
            { description = value;
                OnPropertyChanged("Description");
            }
        }
        /// <summary>
        /// Дипломы
        /// </summary>
        public List<Diploma> Diplomas { get; set; }

        public object Clone() => new School(id,full_name,short_name,address,description);

        public override bool Equals(object? obj)
        {
            return Equals(obj as School);
        }

        public bool Equals(School? other)
        {
            return other is not null &&
                   id == other.id &&
                   full_name == other.full_name &&
                   short_name == other.short_name &&
                   address == other.address &&
                   description == other.description;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(id, full_name, short_name, address, description);
        }

        public static bool operator ==(School? left, School? right)
        {
            return EqualityComparer<School>.Default.Equals(left, right);
        }

        public static bool operator !=(School? left, School? right)
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
