using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
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

        public Task<Gym> GetGymAsync(
            [ID(nameof(Gym))] Guid id,
            GymByIdDataLoader dataLoader,
            CancellationToken cancellationToken)
        {
            return dataLoader.LoadAsync(id, cancellationToken);
        }
    }
}
