using MiniAzureDevops.ItemTable.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiniAzureDevops.ItemTable.Application.Contracts.Persistance
{
    public interface IStoryRepository : IAsyncRepository<Story>
    {
        Task<IReadOnlyCollection<Story>> GetStoriesByColumnId(Guid columnId);
    }
}
