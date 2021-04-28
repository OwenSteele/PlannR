using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IReadOnlyCollection<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IReadOnlyCollection<T>> GetPagedListAsync(int page, int size);
    }
}
