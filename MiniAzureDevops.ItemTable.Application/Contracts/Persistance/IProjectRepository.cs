using MiniAzureDevops.ItemTable.Domain.Entities;

namespace MiniAzureDevops.ItemTable.Application.Contracts.Persistance
{
    public interface IProjectRepository : IAsyncRepository<Project>
    {
        Task<T> GetProjectById<T>(Guid id);
    }
}
