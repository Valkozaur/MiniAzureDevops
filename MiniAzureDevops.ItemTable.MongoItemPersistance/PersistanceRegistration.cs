using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;
using MiniAzureDevops.ItemTable.Domain.Entities;
using MiniAzureDevops.ItemTable.MongoItemPersistance.Repositories;
using MongoDB.Driver;

using static MiniAzureDevops.ItemTable.MongoItemPersistance.Utillities.CollectionNameHelper;

namespace MiniAzureDevops.ItemTable.MongoItemPersistance
{
    public static class PersistanceRegistration
    {
        //TODO: Move connection and db name to app settings.
        public static IServiceCollection UseMongoDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMongoClient, MongoClient>();
            _ = services.AddScoped(typeof(IAsyncRepository<>), typeof(MongoBaseRepository<>));
            services.AddScoped<IItemRepository, ItemRepository>();

            CreateDatabase(configuration);

            return services;
        }

        private static void CreateDatabase(IConfiguration configuration)
        {
            MongoClient client = new MongoClient(configuration.GetConnectionString("MiniAzureItemTableMongoConnectionString"));
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
        }
    }
}
