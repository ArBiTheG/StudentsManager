using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagerData.Table
{
    [NotMapped]
    public class Gender
    {
        public static Gender[] List = new Gender[]
        {
            new Gender("Мужской"),
            new Gender("Женский"),
        };
        private static byte NextId = 0;
        public int Id { get; private set; }
        public string Name { get; private set; }
        private Gender(string name)
        {
            Id = ++NextId;
            Name = name;
            Trace.WriteLine($"Создан новый Gender - id:{Id} name:{Name}");
        }
    }
}
