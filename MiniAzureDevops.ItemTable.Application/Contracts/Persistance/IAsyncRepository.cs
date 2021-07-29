using MiniAzureDevops.ItemTable.Domain.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiniAzureDevops.ItemTable.Application.Contracts.Persistance
{
    public interface IAsyncRepository<T>
    {
        Task<BaseEntity<T>> GetByIdAsync(T id);

        Task<IReadOnlyList<BaseEntity<T>>> ListAllAsync();

        Task<BaseEntity<T>> AddAsync(BaseEntity<T> entity);

        Task UpdateAsync(BaseEntity<T> entity);

        Task DeleteAsync(T id);
    }
}
