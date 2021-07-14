using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;
using MiniAzureDevops.ItemTable.Domain.Entities;
using MongoDB.Driver;

namespace MiniAzureDevops.ItemTable.MongoItemPersistance.Repositories
{
    public class ItemRepository : MongoBaseRepository<Item>, IItemRepository
    {
        public ItemRepository(IMongoClient client) : base(client)
        {
        }
    }
}
