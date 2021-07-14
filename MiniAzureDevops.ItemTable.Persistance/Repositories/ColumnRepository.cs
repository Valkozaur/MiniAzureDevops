using Microsoft.EntityFrameworkCore;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;
using MiniAzureDevops.ItemTable.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniAzureDevops.ItemTable.Persistance.Repositories
{
    public class ColumnRepository : BaseRepository<Column>, IColumnRepository
    {

        public ColumnRepository(MiniAzureDbContext db) : base(db)
        {
        }

        public async Task<IEnumerable<Column>> GetColumnsByTableIdAsync(Guid tableId)
            => await this.db.Columns
                .AsNoTracking()
                .Where(x => x.TableId == tableId)
                .ToArrayAsync();

        public async Task<bool> HasColumnStories(Guid columnId) 
            => await this.db.Columns
                .AsNoTracking()
                .Where(x => x.Id == columnId)
                .Select(x => x.Stories.Any())
                .FirstOrDefaultAsync();
    }
}
