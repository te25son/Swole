using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Swole.Data
{
    public abstract class Employee : Entity
    {
        [Required]
        [StringLength(100)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string? LastName { get; set; }

        public virtual EmployeeType Type { get; set; }
    }
}
