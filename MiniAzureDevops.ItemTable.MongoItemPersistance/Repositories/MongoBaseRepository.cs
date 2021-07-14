using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;
using MiniAzureDevops.ItemTable.Domain.Common;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using static MiniAzureDevops.ItemTable.MongoItemPersistance.Utillities.CollectionNameHelper;
using static MiniAzureDevops.ItemTable.MongoItemPersistance.Utillities.Constants;

namespace MiniAzureDevops.ItemTable.MongoItemPersistance.Repositories
{
    public class MongoBaseRepository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        protected readonly IMongoClient mongoClient;
        protected IMongoCollection<T> collection;

        public MongoBaseRepository(IMongoClient client)
        {
            this.mongoClient = client;
            this.collection = client
                .GetDatabase(DatabaseName)
                .GetCollection<T>(PluralizeName(typeof(T).Name));
        }

        public async Task<T> AddAsync(T entity)
        {
            await this.collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(Guid id)
            => await this.collection.FindOneAndDeleteAsync<T>($"{{ _id: {id} }}");

        public async Task<T> GetByIdAsync(Guid id)
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
            await this.collection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
        }
    }
}
