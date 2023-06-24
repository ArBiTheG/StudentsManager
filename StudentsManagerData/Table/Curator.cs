using Microsoft.EntityFrameworkCore;
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
using System.Xml.Linq;

namespace StudentsManagerData.Table
{
    public class Curator : ICopyable<Curator?>, ICloneable<Curator?>, IEquatable<Curator?>, INotifyPropertyChanged
    {
        private int id;
        private int person_id;
        private Person person;
        private string post;
        private int exp;

        public Curator()
        {

        }

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
        /// Код человека
        /// </summary>
        public int PersonId
        {
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
        public Person Person
        {
            get
            {
                return person;
            }
            set
            {
                person = value;
                OnPropertyChanged(nameof(Person));
            }
        }
        /// <summary>
        /// Должность
        /// </summary>
        public string Post
        {
            get
            {
                return post;
            }
            set
            {
                post = value;
                OnPropertyChanged(nameof(Post));
            }
        }
        /// <summary>
        /// Стаж
        /// </summary>
        public int Exp
        {
            get
            {
                return exp;
            }
            set
            {
                exp = value;
                OnPropertyChanged(nameof(Exp));
            }
        }

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
            return Equals(obj as Curator);
        }

        public Curator Clone()
        {
            return new Curator()
            {
                id = id,
                person_id = person_id,
                person = person,
                post = post,
                exp = exp,
            };
        }

        public void Copy(Curator? entity)
        {
            if (entity == null) return;
            PersonId = entity.person_id;
            Person = entity.person;
            Post = entity.post;
            Exp = entity.exp;
        }

        public bool Equals(Curator? other)
        {
            return other is not null &&
                   id == other.id &&
                   person_id == other.person_id &&
                   person == other.person &&
                   post == other.post &&
                   exp == other.exp;
        }

        public static bool operator ==(Curator? left, Curator? right)
        {
            return EqualityComparer<Curator>.Default.Equals(left, right);
        }

        public static bool operator !=(Curator? left, Curator? right)
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
