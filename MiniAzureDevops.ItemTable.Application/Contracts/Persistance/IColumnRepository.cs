using MiniAzureDevops.ItemTable.Domain.Entities;

namespace MiniAzureDevops.ItemTable.Application.Contracts.Persistance
{
    public interface IColumnRepository : IAsyncRepository<Column>
    {
        Task<Column> GetByIdAsync(Guid id);

        Task<IEnumerable<Column>> GetColumnsByTableIdAsync(Guid tableId);

        Task<bool> HasColumnItems(Guid columnId);
    }
}
