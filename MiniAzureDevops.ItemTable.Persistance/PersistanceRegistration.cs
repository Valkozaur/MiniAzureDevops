using Microsoft.Extensions.DependencyInjection;
using MiniAzureDevops.ItemTable.Domain.Entities;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

using static MiniAzureDevops.ItemTable.Persistance.Utillities.CollectionNameHelper;

namespace MiniAzureDevops.ItemTable.Application
{
    public static class PersistanceRegistration
    {
        //TODO: Move connection and db name to app settings.
        private const string ConnectionString = "mongodb://localhost:27017";
        private const string DatabaseName = "MiniAzure.ItemTable";
        private const string TableName = "TestTable1";

        public static IServiceCollection UseMongoDb(this IServiceCollection services)
        {
            MongoClient client = new MongoClient(ConnectionString);
            var databases = client.GetDatabase(DatabaseName);

            var table = new Table { Name = TableName };

            var tablesCollection = databases.GetCollection<Table>(PluralizeName(nameof(Table)));

            //Create database
            if (!tablesCollection.AsQueryable().Where(x => x.Name == TableName).Any())
            {
                databases.CreateCollection(PluralizeName(nameof(Table)));
                databases.CreateCollection(PluralizeName(nameof(Column)));
                databases.CreateCollection(PluralizeName(nameof(Item)));
                databases.CreateCollection(PluralizeName(nameof(Story)));

                databases.GetCollection<Table>(PluralizeName(nameof(Table))).InsertOne(table);
            }

            return services;
        }
    }
}
