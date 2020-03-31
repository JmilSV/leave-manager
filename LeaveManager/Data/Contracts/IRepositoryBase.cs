using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManager.Data.Contracts
{
    public interface IRepositoryBase<T>: IDisposable
    {
        Task<ICollection<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task<bool> CreateAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
        Task<int> SaveAsync();
    }
}
