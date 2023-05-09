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
    public class Relation: ICopyable<Relation?>, ICloneable<Relation?>, IEquatable<Relation?>, INotifyPropertyChanged
    {
        int id;
        int parent_id;
        Person parent;
        int child_id;
        Person child;
        string? type_relation;

        public Relation()
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
        /// Код родителя
        /// </summary>
        public int ParentId { 
            get 
            { 
                return parent_id; 
            } 
            set 
            {
                parent_id = value; 
            }
        }

        /// <summary>
        /// Объект родителя
        /// </summary>
        public Person Parent {
            get 
            {
                return parent; 
            }
            set
            {
                parent = value;
                OnPropertyChanged(nameof(Parent));
            }
        }

        /// <summary>
        /// Код ребёнка
        /// </summary>
        public int ChildId { 
            get 
            { 
                return child_id;
            } 
            set
            {
                child_id = value;
            } 
        }

        /// <summary>
        /// Объект ребёнка
        /// </summary>
        public Person Child { 
            get 
            {
                return child;
            } 
            set
            {
                child = value;
                OnPropertyChanged(nameof(Child));
            } 
        }
        /// <summary>
        /// Тип отношения
        /// </summary>
        public string? TypeRelation { 
            get
            { 
                return type_relation;
            } 
            set 
            { 
                type_relation = value;
                OnPropertyChanged(nameof(TypeRelation));
            }
        }

        public override string ToString()
        {
            return "id: " + id.ToString();// + " / name: " + name.ToString();
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Relation);
        }

        public void Copy(Relation? relation)
        {
            if (relation == null) return;
            ParentId = relation.parent_id;
            Parent = relation.parent;
            ChildId = relation.child_id;
            Child = relation.child;
            TypeRelation = relation.type_relation;
        }

        public Relation Clone()
        {
            return new Relation()
            {
                id = id, 
                parent_id = parent_id, 
                parent = parent, 
                child_id = child_id, 
                child = child, 
                type_relation = type_relation
            };
        }

        public bool Equals(Relation? other)
        {
            return other is not null &&
                   id == other.id &&
                   parent_id == other.parent_id &&
                   parent == other.parent &&
                   child_id == other.child_id &&
                   child == other.child &&
                   type_relation == other.type_relation;
        }

        public static bool operator ==(Relation? left, Relation? right)
        {
            return EqualityComparer<Relation>.Default.Equals(left, right);
        }

        public static bool operator !=(Relation? left, Relation? right)
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
