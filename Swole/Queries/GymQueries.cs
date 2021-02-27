using HotChocolate;
using HotChocolate.Types;
using Swole.Data;
using System.Linq;

namespace Swole.Queries
{
    [ExtendObjectType(Name = "Query")]
    public class GymQueries
    {
        public IQueryable<Gym> GetGyms([Service] AppDbContext context) =>
            context.Gyms;
    }
}
