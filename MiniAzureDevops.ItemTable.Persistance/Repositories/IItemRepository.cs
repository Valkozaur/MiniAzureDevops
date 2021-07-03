using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;
using MiniAzureDevops.ItemTable.Domain.Entities;
using MongoDB.Driver;

namespace MiniAzureDevops.ItemTable.Persistance.Repositories
{
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {
        public ItemRepository(IMongoClient client) : base(client)
        {
        }
    }
}
