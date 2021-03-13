using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using Swole.Data;
using Swole.DataLoaders;
using Swole.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Swole.Types
{
    public class GymType : ObjectType<Gym>
    {
        protected override void Configure(IObjectTypeDescriptor<Gym> descriptor)
        {
            descriptor
                .ImplementsNode()
                .IdField(g => g.Id)
                .ResolveNode((context, id) => context.DataLoader<GymByIdDataLoader>().LoadAsync(id, context.RequestAborted));

            descriptor
                .Field(g => g.Employees)
                .ResolveWith<GymResolvers>(i => i.GetEmployeesAsync(default!, default!, default!, default))
                .UseDbContext<AppDbContext>()
                .Name("employees");

            descriptor
                .Field(g => g.Members)
                .ResolveWith<GymResolvers>(i => i.GetEmployeesAsync(default!, default!, default!, default))
                .UseDbContext<AppDbContext>()
                .Name("members");
        }

        private class GymResolvers
        {
            public async Task<IEnumerable<Employee>> GetEmployeesAsync(
                Gym gym,
                [ScopedService] AppDbContext context,
                EmployeeByIdDataLoader employeeById,
                CancellationToken cancellationToken)
            {
                var employeeIds = await context.Gyms
                    .Where(g => g.Id == gym.Id)
                    .Include(g => g.Employees)
                    .SelectMany(g => g.Employees.Select(e => e.GymId))
                    .ToArrayAsync();

                return await employeeById.LoadAsync(employeeIds, cancellationToken);
            }

            public async Task<IEnumerable<Member>> GetMembersAsync(
                Gym gym,
                [ScopedService] AppDbContext context,
                MemberByIdDataLoader memberById,
                CancellationToken cancellationToken)
            {
                var memberIds = await context.Gyms
                    .Where(g => g.Id == gym.Id)
                    .Include(g => g.Members)
                    .SelectMany(g => g.Members.Select(e => e.GymId))
                    .ToArrayAsync();

                return await memberById.LoadAsync(memberIds, cancellationToken);
            }
        }
    }
}
