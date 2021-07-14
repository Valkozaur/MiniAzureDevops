using Microsoft.EntityFrameworkCore;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;
using MiniAzureDevops.ItemTable.Domain.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MiniAzureDevops.ItemTable.Persistance.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        protected readonly MiniAzureDbContext db;

        public BaseRepository(MiniAzureDbContext db)
        {
            this.db = db;
        }

        public async Task<T> AddAsync(T entity)
        {
            await this.db.Set<T>().AddAsync(entity);
            await this.db.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await this.db.Set<T>().FindAsync(id);
            db.Entry(entity).State = EntityState.Deleted;
            await this.db.SaveChangesAsync();
        }

        public Task<T> GetByIdAsync(Guid id)
            => this.db.Set<T>().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IReadOnlyList<T>> ListAllAsync()
            => await this.db.Set<T>().ToArrayAsync();

        public async Task UpdateAsync(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            await this.db.SaveChangesAsync();
        }
    }
}
