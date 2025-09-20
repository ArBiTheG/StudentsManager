using StudentsManager.Domain.Common;

namespace StudentsManager.Domain.Models
{
    public class Specialty: BaseEntity
    {
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public ICollection<Group> Groups { get; set; } = new List<Group>();
    }
}
