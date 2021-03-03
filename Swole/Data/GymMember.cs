using System;

namespace Swole.Data
{
    public class GymMember
    {
        public Guid MemberId { get; set; }

        public Member? Member { get; set; }

        public Guid GymId { get; set; }

        public Gym? Gym { get; set; }
    }
}
