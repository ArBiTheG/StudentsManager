using StudentsManager.Domain.Common;

namespace StudentsManager.Domain.Models
{
    public class Person: BaseEntity
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string FullName => $"{LastName} {FirstName} {MiddleName}";
    }
}
