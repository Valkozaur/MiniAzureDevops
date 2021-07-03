using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;
using MiniAzureDevops.ItemTable.Domain.Entities;
using MongoDB.Driver;

namespace MiniAzureDevops.ItemTable.Persistance.Repositories
{
    public class StoryRepository : BaseRepository<Story>, IStoryRepository
    {
        protected StoryRepository(IMongoClient client) : base(client)
        {
        }
    }
}
