using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Swole.Data
{
    public class Gym : Entity
    {
        [Required]
        [StringLength(200)]
        public string? Name { get; set; }

        public ICollection<Member>? Members { get; set; }

        public ICollection<GymEmployee> Employees { get; set; } = new List<GymEmployee>();
    }
}
