using Microsoft.EntityFrameworkCore;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;
using MiniAzureDevops.ItemTable.Domain.Entities;

namespace MiniAzureDevops.ItemTable.Persistance.Repositories
{
    public class ColumnRepository : BaseRepository<Column>, IColumnRepository
    {

        public ColumnRepository(MiniAzureDbContext context) : base(context) {}

        public Task<Column> GetByIdAsync(Guid id)
            => this.All()
                .FirstOrDefaultAsync(c => c.Id == id);

        public async Task<IEnumerable<Column>> GetColumnsByTableIdAsync(Guid tableId)
            => await this.AllAsNoTracking()
                        .Where(x => x.TableId == tableId)
                        .ToArrayAsync();

        public async Task<bool> HasColumnItems(Guid columnId)
            => await this.AllAsNoTracking()
                        .Where(x => x.Id == columnId)
                        .Select(x => x.Items.Any())
                        .FirstOrDefaultAsync();
    }
}
