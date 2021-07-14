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

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ITableRepository, TableRepository>();
            services.AddScoped<IColumnRepository, ColumnRepository >();
            services.AddScoped<IStoryRepository, StoryRepository>();

            return services;
        }
    }
}
