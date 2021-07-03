using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiniAzureDevops.ItemTable.Application.Contracts.Persistance
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetByIdAsync(ObjectId id);

        Task<IReadOnlyList<T>> ListAllAsync();

        Task<T> AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(ObjectId id);
    }
}
