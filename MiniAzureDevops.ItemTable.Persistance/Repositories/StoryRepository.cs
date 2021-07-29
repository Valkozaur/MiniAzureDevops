using Microsoft.EntityFrameworkCore;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;
using MiniAzureDevops.ItemTable.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniAzureDevops.ItemTable.Persistance.Repositories
{
    public class StoryRepository : BaseRepository<Story>, IStoryRepository
    {
        public StoryRepository(MiniAzureDbContext db) : base(db)
        {
        }

        public async Task<IReadOnlyCollection<Story>> GetStoriesByColumnId(Guid columnId)
        {
            return await this.db.Story
                .Where(s => s.ColumnId == columnId)
                .ToArrayAsync();
        }
    }
}
