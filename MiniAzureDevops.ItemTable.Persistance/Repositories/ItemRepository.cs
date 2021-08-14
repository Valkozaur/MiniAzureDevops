using Microsoft.EntityFrameworkCore;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;
using MiniAzureDevops.ItemTable.Domain.Entities;

namespace MiniAzureDevops.ItemTable.Persistance.Repositories
{
    public class ItemRepository : BaseRepository<GetItemByIdDto>, IItemRepository
    {
        public ItemRepository(MiniAzureDbContext context) : base(context)
        {
        }

        public Task<GetItemByIdDto> GetByIdAsync(int itemId, Guid projectId)
            => this.All().FirstOrDefaultAsync(i => i.Id == itemId && i.ProjectId == projectId);

        public async Task<IEnumerable<GetItemByIdDto>> GetItemsByColumnId(Guid columnId)
            => await this.AllAsNoTracking()
                    .Where(i => i.ColumnId == columnId)
                    .ToArrayAsync();
    }
}
