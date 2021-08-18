using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;
using MiniAzureDevops.ItemTable.Application.Mapping;
using MiniAzureDevops.ItemTable.Domain.Entities;

namespace MiniAzureDevops.ItemTable.Persistance.Repositories
{
    public class TableRepository : BaseRepository<Table>, ITableRepository
    {
        public TableRepository(MiniAzureDbContext context, IMapper mapper) : base(context) {}

        public Task<Table> GetByIdAsync(Guid tableId)
            => this.All().FirstOrDefaultAsync(t => t.Id == tableId);

        public async Task<bool> ColumnNameIsUnique(Guid tableId, string columnName)
            => await this.AllAsNoTracking().AnyAsync(c => c.Name == columnName);

        public async Task<int> GetColumnCountByIdAsync(Guid tableId)
            => await this.AllAsNoTracking()
                        .Where(t => t.Id == tableId)
                        .Select(t => t.Columns.Count)
                        .FirstOrDefaultAsync();

        public async Task<IEnumerable<T>> GetByProjectIdAsync<T>(Guid projectId)
            => await this.AllAsNoTracking()
                        .Where(t => t.ProjectId == projectId)
                        .To<T>()
                        .ToArrayAsync();
    }
}
