using GreenDonut;
using Microsoft.EntityFrameworkCore;
using Swole.Data;

namespace Swole.DataLoaders
{
    public class EmployeeByIdDataLoader : IdDataLoaderBase<Employee>
    {
        public EmployeeByIdDataLoader(IBatchScheduler batchScheduler, IDbContextFactory<AppDbContext> dbContextFactory) 
            : base(batchScheduler, dbContextFactory)
        {
        }
    }
}
