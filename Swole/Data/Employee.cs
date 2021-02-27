using System;
using System.ComponentModel.DataAnnotations;

namespace Swole.Data
{
    public class Employee
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string? LastName { get; set; }
    }
}
