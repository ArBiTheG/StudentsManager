using StudentsManager.Domain.Common;

namespace StudentsManager.Domain.Models
{
    public class Student: BaseEntity
    {
        public int PersonId { get; set; }
        public Person Person { get; set; } = null!;

        public int GroupId { get; set; }
        public Group Group { get; set; } = null!;
    }
}
