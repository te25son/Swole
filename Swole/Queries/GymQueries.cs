using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using Swole.Data;
using Swole.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Swole.Queries
{
    [ExtendObjectType(Name = "Query")]
    public class GymQueries
    {
        [UseAppDbContext]
        public Task<List<Gym>> GetGyms([ScopedService] AppDbContext context) =>
            context.Gyms.ToListAsync();
    }
}
