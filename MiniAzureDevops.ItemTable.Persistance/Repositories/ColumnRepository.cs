using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;
using MiniAzureDevops.ItemTable.Domain.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniAzureDevops.ItemTable.Persistance.Repositories
{
    public class ColumnRepository : BaseRepository<Column>, IColumnRepository
    {

        public ColumnRepository(IMongoClient client) : base(client)
        {
        }

        public async Task<IEnumerable<Column>> GetColumnsByTableIdAsync(ObjectId tableId)
        {
            var list = await this.collection.FindAsync("{ tableId: tableId}");
            return await list.ToListAsync();
        }

        public async Task<bool> HasColumnStories(ObjectId columndId)
        {
            var column = await this.GetByIdAsync(columndId);
            return column.Stories.Any();
        }
    }
}
