using GreenDonut;
using HotChocolate.DataLoader;
using Microsoft.EntityFrameworkCore;
using Swole.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Swole.DataLoaders
{
    public class IdDataLoaderBase<TEntity> : BatchDataLoader<Guid, TEntity>
        where TEntity : Entity
    {
        private readonly IDbContextFactory<AppDbContext> _dbContextFactory;

        public IdDataLoaderBase(IBatchScheduler batchScheduler, IDbContextFactory<AppDbContext> dbContextFactory)
            : base(batchScheduler)
        {
            _dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));
        }

        protected override async Task<IReadOnlyDictionary<Guid, TEntity>> LoadBatchAsync(IReadOnlyList<Guid> keys, CancellationToken cancellationToken)
        {
            await using AppDbContext dbContext = _dbContextFactory.CreateDbContext();

            return await dbContext.Set<TEntity>()
                .Where(s => keys.Contains(s.Id))
                .ToDictionaryAsync(t => t.Id, cancellationToken);
        }
    }
}
