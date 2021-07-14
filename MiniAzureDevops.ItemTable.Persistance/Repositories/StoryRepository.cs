using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;
using MiniAzureDevops.ItemTable.Domain.Entities;

namespace MiniAzureDevops.ItemTable.Persistance.Repositories
{
    public class StoryRepository : BaseRepository<Story>, IStoryRepository
    {
        public StoryRepository(MiniAzureDbContext db) : base(db)
        {
        }
    }
}
