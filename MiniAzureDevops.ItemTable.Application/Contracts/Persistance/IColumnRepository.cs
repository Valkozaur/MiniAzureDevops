using MiniAzureDevops.ItemTable.Domain.Entities;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiniAzureDevops.ItemTable.Application.Contracts.Persistance
{
    public interface IColumnRepository : IAsyncRepository<Column>
    {
        Task<IEnumerable<Column>> GetColumnsByTableIdAsync(ObjectId tableId);

        Task<bool> HasColumnStories(ObjectId columndId);
    }
}
