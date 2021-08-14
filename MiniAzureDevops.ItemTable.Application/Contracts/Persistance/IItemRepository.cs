using MiniAzureDevops.ItemTable.Domain.Entities;

namespace MiniAzureDevops.ItemTable.Application.Contracts.Persistance
{
    public interface IItemRepository : IAsyncRepository<GetItemByIdDto>
    {
        Task<GetItemByIdDto> GetByIdAsync(int itemId, Guid projectId);

        Task<IEnumerable<GetItemByIdDto>> GetItemsByColumnId(Guid columnId);
    }
}
