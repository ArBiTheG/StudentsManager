using StudentsManager.Domain.Common;

namespace StudentsManager.Domain.Models
{
    public class Group: BaseEntity
    {
        public string Name { get; set; } = null!;
        public int SpecialtyId { get; set; }
        public Specialty Specialty { get; set; } = null!;

        public int? CuratorId { get; set; }
        public Curator? Curator { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
