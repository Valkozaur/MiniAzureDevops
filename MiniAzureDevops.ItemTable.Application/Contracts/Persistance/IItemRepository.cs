using MiniAzureDevops.ItemTable.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiniAzureDevops.ItemTable.Application.Contracts.Persistance
{
    public interface IItemRepository : IAsyncRepository<Item>
    {
        Task<Item> GetByIdAsync(int itemId, Guid projectId);

        Task<IEnumerable<Item>> GetItemsByColumnId(Guid columnId);
    }
}
