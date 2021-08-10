using Microsoft.Extensions.DependencyInjection;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;
using MiniAzureDevops.ItemTable.Persistance;
using MiniAzureDevops.ItemTable.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MiniAzureDevops.ItemTable.Application
{
    public static class PersistanceRegistration
    {
        public static IServiceCollection AddSQLPersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MiniAzureDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("MiniAzureItemTableSQLServerConnectionString")));

            services.AddTransient(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IProjectRepository, ProjectRepository>();
            services.AddTransient<ITableRepository, TableRepository>();
            services.AddTransient<IColumnRepository, ColumnRepository >();
            services.AddTransient<IItemRepository, ItemRepository>();

            return services;
        }
    }
}
