using Microsoft.EntityFrameworkCore;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;
using MiniAzureDevops.ItemTable.Domain.Entities;

namespace MiniAzureDevops.ItemTable.Persistance.Repositories
{
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {
        public ItemRepository(MiniAzureDbContext context) : base(context)
        {
        }

        public Task<Item> GetByIdAsync(int itemId, Guid projectId)
            => this.All().FirstOrDefaultAsync(i => i.Id == itemId && i.ProjectId == projectId);

        public async Task<IEnumerable<Item>> GetItemsByColumnId(Guid columnId)
            => await this.AllAsNoTracking()
                    .Where(i => i.ColumnId == columnId)
                    .ToArrayAsync();
    }
}
