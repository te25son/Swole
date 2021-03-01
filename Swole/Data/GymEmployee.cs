using System;

namespace Swole.Data
{
    public class GymEmployee
    {
        public Guid EmployeeId { get; set; }

        public Employee? Employee { get; set; }

        public Guid GymId { get; set; }

        public Gym? Gym { get; set; }
    }
}
