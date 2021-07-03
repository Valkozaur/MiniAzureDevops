using MiniAzureDevops.ItemTable.Domain.Entities;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace MiniAzureDevops.ItemTable.Application.Contracts.Persistance
{
    public interface ITableRepository : IAsyncRepository<Table>
    {
        Task<int> GetColumnCountByIdAsync(ObjectId tableId);

        Task<bool> ColumnNameIsUnique(ObjectId tableId, string columnName);

        Task<bool> IsTableIdUnique(int tableId);
    }
}
