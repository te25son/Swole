using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Swole.Data
{
    public class Member : Entity
    {
        [Required]
        [StringLength(100)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string? LastName { get; set; }

        [Required]
        [StringLength(200)]
        public string? EmailAddress { get; set; }

        public ICollection<GymEmployee> Employees { get; set; } = new List<GymEmployee>();
    }
}
