using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;
using MiniAzureDevops.ItemTable.Domain.Common;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

using static MiniAzureDevops.ItemTable.Persistance.Utillities.CollectionNameHelper;
using static MiniAzureDevops.ItemTable.Persistance.Utillities.Constants;

namespace MiniAzureDevops.ItemTable.Persistance.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        protected readonly IMongoClient mongoClient;
        protected IMongoCollection<T> collection;

        protected BaseRepository(IMongoClient client)
        {
            this.mongoClient = client;
            this.collection = client
                .GetDatabase(DatabaseName)
                .GetCollection<T>(PluralizeName(nameof(T)));
        }

        public async Task<T> AddAsync(T entity)
        {
            await this.collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(ObjectId id)
            => await this.collection.FindOneAndDeleteAsync<T>($"{{ _id: {id} }}");

        public async Task<T> GetByIdAsync(ObjectId id)
        {
           var result = await this.collection.FindAsync($"{{ _id: {id} }}");
           return await result.FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            var result = await this.collection.FindAsync(FilterDefinition<T>.Empty);
            return await result.ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            await this.collection.ReplaceOneAsync(x => x._Id == entity._Id, entity)
        }
    }
}
