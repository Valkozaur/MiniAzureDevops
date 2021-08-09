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
    public class MongoBaseRepository<T> : IAsyncRepository<T>
    {
        protected readonly IMongoClient mongoClient;
        protected IMongoCollection<BaseEntity<T>> collection;

        public MongoBaseRepository(IMongoClient client)
        {
            this.mongoClient = client;
            this.collection = client
                .GetDatabase(DatabaseName)
                .GetCollection<BaseEntity<T>>(ItemsCollectionName);
        }

        public async Task<BaseEntity<T>> AddAsync(BaseEntity<T> entity)
        {
            await this.collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(T id)
            => await this.collection.FindOneAndDeleteAsync<T>($"{{ _id: {id} }}");

        public async Task<BaseEntity<T>> GetByIdAsync(T id)
        {
            var result = await this.collection.FindAsync($"{{ _id: {id} }}");
            return await result.FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<BaseEntity<T>>> ListAllAsync()
        {
            var result = await this.collection.FindAsync(FilterDefinition<BaseEntity<T>>.Empty);
            return await result.ToListAsync();
        }

        public async Task UpdateAsync(BaseEntity<T> entity)
        {
            await this.collection.ReplaceOneAsync(x => x.Id.Equals(entity.Id), entity);
        }
    }
}
