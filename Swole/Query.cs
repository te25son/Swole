using HotChocolate;
using Swole.Data;
using System.Linq;

namespace Swole
{
    public class Query
    {
        public IQueryable<Gym> GetGyms([Service] AppDbContext context) =>
            context.Gyms;
    }
}
