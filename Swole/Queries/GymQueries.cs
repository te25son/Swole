using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using Swole.Data;
using Swole.DataLoaders;
using Swole.Extensions;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Swole.Queries
{
    [ExtendObjectType(Name = "Query")]
    public class GymQueries
    {
        [UseAppDbContext]
        public Task<List<Gym>> GetGyms([ScopedService] AppDbContext context) =>
            context.Gyms.ToListAsync();

        public Task<Gym> GetGymAsync(Guid id, GymByIdDataLoader dataLoader, CancellationToken cancellationToken) =>
            dataLoader.LoadAsync(id, cancellationToken);
    }
}
