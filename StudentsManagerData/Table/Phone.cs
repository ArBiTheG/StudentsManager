﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagerData.Table
{
    public class Phone: ICloneable, IEquatable<Phone?>
    {
        int id;
        int person_id;
        Person person;
        string? name;
        string? description;

        //Используется для клонирования
        private Phone(int id, int person_id, Person person, string? name, string? description)
        {
            this.id = id;
            this.person_id = person_id;
            this.person = person;
            this.name = name;
            this.description = description;
        }

        /// <summary>
        /// Код
        /// </summary>
        public int Id { get { return id; } }

        /// <summary>
        /// Код человека
        /// </summary>
        public int PersonId { get { return person_id; } set { person_id = value; } }

        /// <summary>
        /// Объект человека
        /// </summary>
        public Person Person { get { return person; } private set { person = value; } }

        /// <summary>
        /// Номер телефона
        /// </summary>
        public string? Name { get { return name; } set { name = value; } }

        /// <summary>
        /// Описание
        /// </summary>
        public string? Description { get { return description; } set { description = value; } }

        public object Clone() => new Phone(id, person_id, person, name, description);

        public override bool Equals(object? obj)
        {
            return Equals(obj as Phone);
        }

        public bool Equals(Phone? other)
        {
            return other is not null &&
                   id == other.id &&
                   person_id == other.person_id &&
                   EqualityComparer<Person>.Default.Equals(person, other.person) &&
                   name == other.name &&
                   description == other.description;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(id, person_id, person, name, description);
        }

        public static bool operator ==(Phone? left, Phone? right)
        {
            return EqualityComparer<Phone>.Default.Equals(left, right);
        }

        public static bool operator !=(Phone? left, Phone? right)
        {
            return !(left == right);
        }
    }
}
