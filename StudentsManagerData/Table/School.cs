using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudentsManagerData.Table
{
    public class School: ICopyable<School?>, ICloneable<School?>, IEquatable<School?>, INotifyPropertyChanged
    {
        int id;
        string full_name;
        string short_name;
        string? address;
        string? about;

        public School()
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
                OnPropertyChanged(nameof(FullName));
            } 
        }
        /// <summary>
        /// Короткое наименование школы
        /// </summary>
        public string ShortName {
            get
            { 
                return short_name;
            } 
            set 
            { 
                short_name = value;
                OnPropertyChanged(nameof(ShortName));
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
                OnPropertyChanged(nameof(Address));
            }
        }
        /// <summary>
        /// Описание школы
        /// </summary>
        public string? About {
            get
            { 
                return about; 
            } 
            set
            { about = value;
                OnPropertyChanged(nameof(About));
            }
        }
        /// <summary>
        /// Дипломы
        /// </summary>
        public List<Diploma> Diplomas { get; set; }

        public override string ToString()
        {
            return "id: " + id.ToString() + " / name: " + full_name.ToString();
        }
        public override bool Equals(object? obj)
        {
            return Equals(obj as School);
        }

        public void Copy(School? school)
        {
            if (school == null) return;
            FullName = school.full_name;
            ShortName = school.short_name;
            Address = school.address;
            About = school.about;
        }
        public School Clone()
        {
            return new School()
            {
                id = id,
                full_name = full_name,
                short_name = short_name,
                address = address,
                about = about
            };
        }

        public bool Equals(School? other)
        {
            return other is not null &&
                   id == other.id &&
                   full_name == other.full_name &&
                   short_name == other.short_name &&
                   address == other.address &&
                   about == other.about;
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
