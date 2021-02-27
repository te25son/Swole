using Swole.Data;

namespace Swole.Mutations.Payloads
{
    public class AddGymPayload
    {
        public AddGymPayload(Gym gym) => Gym = gym;

        public Gym Gym { get; }
    }
}
