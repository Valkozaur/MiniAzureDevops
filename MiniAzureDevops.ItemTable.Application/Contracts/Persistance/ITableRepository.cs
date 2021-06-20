using MiniAzureDevops.ItemTable.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace MiniAzureDevops.ItemTable.Application.Contracts.Persistance
{
    public interface ITableRepository : IAsyncRepository<Table>
    {
        Task<int> GetColumnCountByIdAsync(Guid tableId);

        Task<bool> ColumnNameIsUnique(Guid tableId, string columnName);
    }
}
