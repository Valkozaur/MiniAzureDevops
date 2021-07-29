using Microsoft.EntityFrameworkCore;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;
using MiniAzureDevops.ItemTable.Domain.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MiniAzureDevops.ItemTable.Persistance.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T>
    {
        protected readonly MiniAzureDbContext db;

        public BaseRepository(MiniAzureDbContext db)
        {
            this.db = db;
        }

        public async Task<BaseEntity<T>> AddAsync(BaseEntity<T> entity)
        {
            await this.db.Set<BaseEntity<T>>().AddAsync(entity);
            await this.db.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(T id)
        {
            var entity = await this.db.Set<BaseEntity<T>>().FindAsync(id);
            db.Entry(entity).State = EntityState.Deleted;
            await this.db.SaveChangesAsync();
        }

        public Task<BaseEntity<T>> GetByIdAsync(T id)
            => this.db.Set<BaseEntity<T>>().FirstOrDefaultAsync(x => x.Id.Equals(id));

        public async Task<IReadOnlyList<BaseEntity<T>>> ListAllAsync()
            => await this.db.Set<BaseEntity<T>>().ToArrayAsync();

        public async Task UpdateAsync(BaseEntity<T> entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            await this.db.SaveChangesAsync();
        }
    }
}
