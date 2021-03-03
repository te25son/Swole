using GreenDonut;
using Microsoft.EntityFrameworkCore;
using Swole.Data;

namespace Swole.DataLoaders
{
    public class MemberByIdDataLoader : IdDataLoaderBase<Member>
    {
        public MemberByIdDataLoader(IBatchScheduler batchScheduler, IDbContextFactory<AppDbContext> dbContextFactory)
            : base(batchScheduler, dbContextFactory)
        {
        }
    }
}
