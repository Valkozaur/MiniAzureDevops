using MiniAzureDevops.ItemTable.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiniAzureDevops.ItemTable.Application.Contracts.Persistance
{
    public interface IColumnRepository : IAsyncRepository<Column>
    {
        Task<Column> GetByIdAsync(Guid id);

        Task<IEnumerable<Column>> GetColumnsByTableIdAsync(Guid tableId);

        Task<bool> HasColumnItems(Guid columnId);
    }
}
