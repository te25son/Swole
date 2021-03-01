using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Swole.Data;
using Swole.DataLoaders;
using Swole.Mutations;
using Swole.Queries;
using Swole.Types;

namespace Swole
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPooledDbContextFactory<AppDbContext>(options => options.UseSqlite("Data Source=swole.db"));

            services
                .AddGraphQLServer()

                .AddQueryType(d => d.Name("Query"))
                    .AddTypeExtension<GymQueries>()

                .AddMutationType(d => d.Name("Mutation"))
                    .AddTypeExtension<GymMutations>()

                .AddType<GymType>()

                .AddDataLoader<GymByIdDataLoader>()
                .AddDataLoader<EmployeeByIdDataLoader>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL("/swole/api/v1");
            });
        }
    }
}
