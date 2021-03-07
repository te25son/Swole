using Swole.Data;
using System.Collections.Generic;

namespace Swole.Mutations.Payloads
{
    public class AddGymPayload : PayloadBase<Gym>
    {
        public AddGymPayload(Gym gym)
            : base(gym)
        {
        }

        public AddGymPayload(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }
    }
}
