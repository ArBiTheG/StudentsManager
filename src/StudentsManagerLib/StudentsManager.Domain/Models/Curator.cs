using StudentsManager.Domain.Common;

namespace StudentsManager.Domain.Models
{
    public class Curator: BaseEntity
    {
        public int PersonId { get; set; }
        public Person Person { get; set; } = null!;
        public ICollection<Group> Groups { get; set; } = new List<Group>();
    }
}
