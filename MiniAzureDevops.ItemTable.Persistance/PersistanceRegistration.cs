using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;
using MiniAzureDevops.ItemTable.Domain.Entities;
using MiniAzureDevops.ItemTable.Persistance.Repositories;
using MongoDB.Driver;

using static MiniAzureDevops.ItemTable.Persistance.Utillities.CollectionNameHelper;

namespace MiniAzureDevops.ItemTable.Application
{
    public static class PersistanceRegistration
    {
        //TODO: Move connection and db name to app settings.
        public static IServiceCollection UseMongoDb(this IServiceCollection services, IConfiguration configuration)
        {
            MongoClient client = new MongoClient(configuration.GetConnectionString("MiniAzureItemTableConnectionString"));
            var databases = client.GetDatabase(configuration.GetConnectionString("DatabaseName"));


            var testTableName = "TEST";
            var table = new Table { Name = testTableName };
            var tablesCollection = databases.GetCollection<Table>(PluralizeName(nameof(Table)));


            //If we can't get the table 
            var getTable = tablesCollection.Find(x => x.Name == testTableName).FirstOrDefault();
            //we Create the database with tables. 
            if (getTable == null)
            {
                databases.CreateCollection(PluralizeName(nameof(Table)));
                databases.CreateCollection(PluralizeName(nameof(Story)));

                databases.GetCollection<Table>(PluralizeName(nameof(Table))).InsertOne(table);
            }

            return services;
        }

        public static IServiceCollection AddPersitanceServices(this IServiceCollection services)
        {
            services.AddScoped<IMongoClient, MongoClient>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ITableRepository, TableRepository>();
            services.AddScoped<IColumnRepository, ColumnRepository >();
            services.AddScoped<IStoryRepository, StoryRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();

            return services;
        }
    }
}
