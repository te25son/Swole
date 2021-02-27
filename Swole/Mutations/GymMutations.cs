using HotChocolate;
using HotChocolate.Types;
using Swole.Data;
using Swole.Mutations.Inputs;
using Swole.Mutations.Payloads;
using System.Threading.Tasks;

namespace Swole.Mutations
{
    [ExtendObjectType(Name = "Mutation")]
    public class GymMutations
    {
        public async Task<AddGymPayload> AddGymAsync(
            AddGymInput input,
            [Service] AppDbContext context)
        {
            var gym = new Gym { Name = input.Name };

            context.Gyms.Add(gym);
            await context.SaveChangesAsync();

            return new AddGymPayload(gym);
        }
    }
}
