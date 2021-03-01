using GreenDonut;
using Microsoft.EntityFrameworkCore;
using Swole.Data;

namespace Swole.DataLoaders
{
    public class GymByIdDataLoader : IdDataLoaderBase<Gym>
    {
        public GymByIdDataLoader(IBatchScheduler batchScheduler, IDbContextFactory<AppDbContext> dbContextFactory)
            : base(batchScheduler, dbContextFactory)
        {
        }
    }
}
