﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniAzureDevops.ItemTable.Application.Contracts.Persistance
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);

        Task<IReadOnlyList<T>> ListAllAsync();

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<T> DeleteAsync(Guid id);
    }
}
