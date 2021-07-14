using MiniAzureDevops.ItemTable.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiniAzureDevops.ItemTable.Application.Contracts.Persistance
{
    public interface IColumnRepository : IAsyncRepository<Column>
    {
        Task<IEnumerable<Column>> GetColumnsByTableIdAsync(Guid tableId);
        Task<bool> HasColumnStories(Guid columnId);
    }
}
