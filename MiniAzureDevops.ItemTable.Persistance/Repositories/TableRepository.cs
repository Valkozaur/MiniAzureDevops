using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;
using MiniAzureDevops.ItemTable.Domain.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace MiniAzureDevops.ItemTable.Persistance.Repositories
{
    public class TableRepository : BaseRepository<Table>, ITableRepository
    {
        public TableRepository(IMongoClient client) : base(client)
        {
        }

        public Task<bool> ColumnNameIsUnique(ObjectId tableId, string columnName)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetColumnCountByIdAsync(ObjectId tableId)
        {
            var table = await this.GetByIdAsync(tableId);

            return table.Columns.Count;
        }

        public Task<bool> IsTableIdUnique(int tableId)
        {
            throw new NotImplementedException();
        }
    }
}
