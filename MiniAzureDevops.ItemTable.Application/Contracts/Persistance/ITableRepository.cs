using MiniAzureDevops.ItemTable.Domain.Entities;

namespace MiniAzureDevops.ItemTable.Application.Contracts.Persistance
{
    public interface ITableRepository : IAsyncRepository<Table>
    {
        Task<Table> GetByIdAsync(Guid tableId);

        Task<int> GetColumnCountByIdAsync(Guid tableId);

        Task<bool> ColumnNameIsUnique(Guid tableId, string columnName);
    }
}
