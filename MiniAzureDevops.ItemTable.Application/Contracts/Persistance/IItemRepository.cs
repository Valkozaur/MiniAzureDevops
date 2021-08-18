using MiniAzureDevops.ItemTable.Domain.Entities;

namespace MiniAzureDevops.ItemTable.Application.Contracts.Persistance
{
    public interface IItemRepository : IAsyncRepository<Item>
    {
        Task<Item> GetByIdAsync(int itemId, Guid projectId);

        Task<IEnumerable<Item>> GetItemsByColumnId(Guid columnId);
    }
}
