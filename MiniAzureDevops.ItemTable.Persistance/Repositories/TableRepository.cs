using Microsoft.EntityFrameworkCore;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;
using MiniAzureDevops.ItemTable.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MiniAzureDevops.ItemTable.Persistance.Repositories
{
    public class TableRepository : BaseRepository<Table>, ITableRepository
    {
        public TableRepository(MiniAzureDbContext context) : base(context) {}

        public Task<Table> GetByIdAsync(Guid tableId)
            => this.All().FirstOrDefaultAsync(t => t.Id == tableId);

        public async Task<bool> ColumnNameIsUnique(Guid tableId, string columnName)
            => await this.AllAsNoTracking()
                        .AnyAsync(c => c.Name == columnName);

        public async Task<int> GetColumnCountByIdAsync(Guid tableId)
            => await this.AllAsNoTracking()
                        .Where(t => t.Id == tableId)
                        .Select(t => t.Columns.Count)
                        .FirstOrDefaultAsync(); 
    }
}
