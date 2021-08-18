using Microsoft.EntityFrameworkCore;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;
using MiniAzureDevops.ItemTable.Application.Mapping;
using MiniAzureDevops.ItemTable.Domain.Entities;

namespace MiniAzureDevops.ItemTable.Persistance.Repositories
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(MiniAzureDbContext context) : base(context) {}

        public async Task<T> GetProjectById<T>(Guid id) => await this.Context.Projects.Where(x => x.Id == id).To<T>().FirstOrDefaultAsync();
    }
}
