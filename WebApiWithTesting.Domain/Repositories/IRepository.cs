using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApiWithTesting.Domain.Repositories
{
    public interface IRepository<T> : IDisposable
    {
        Task<bool> Exists(int id);
        Task<T> GetByIdAsync(int id);
        Task<ICollection<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int entityId);
    }
}