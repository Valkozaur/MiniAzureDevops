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
        public TableRepository(MiniAzureDbContext db) : base(db)
        {
        }

        public async Task<bool> ColumnNameIsUnique(Guid tableId, string columnName) 
            => await this.db.Tables
                .AsNoTracking()
                .AnyAsync(x => x.Id == tableId && x.Columns.Any(x => x.Name == columnName));

        public async Task<int> GetColumnCountByIdAsync(Guid tableId)
            => await this.db.Tables
                .AsNoTracking()
                .Where(x => x.Id == tableId)
                .Select(x => x.Columns.Count)
                .FirstOrDefaultAsync();

        public Task<bool> IsTableIdUnique(int tableId)
        {
            throw new NotImplementedException();
        }
    }
}
