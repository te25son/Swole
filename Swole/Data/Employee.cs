using System.ComponentModel.DataAnnotations;

namespace Swole.Data
{
    public class Employee : Entity
    {
        [Required]
        [StringLength(100)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string? LastName { get; set; }

        public EmployeeType Type { get; set; }
    }
}
