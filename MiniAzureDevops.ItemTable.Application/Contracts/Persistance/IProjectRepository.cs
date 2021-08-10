using MiniAzureDevops.ItemTable.Domain.Entities;
using System.Threading.Tasks;
using System;

namespace MiniAzureDevops.ItemTable.Application.Contracts.Persistance
{
    public interface IProjectRepository : IAsyncRepository<Project>
    {
        Task<Project> GetProjectById(Guid id);
    }
}
