using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;
using MiniAzureDevops.ItemTable.Domain.Entities;

namespace MiniAzureDevops.ItemTable.Persistance.Repositories
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(MiniAzureDbContext context) : base(context) {}

        public async Task<Project> GetProjectById(Guid id) => await this.Context.Projects.FindAsync(id);
        
    }
}
