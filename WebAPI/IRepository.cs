using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Repositories
{
    public interface IRepository<T>
    {
        Task CreateAsync(T entity);
        Task UpdateAsync();
        Task DeleteAsync(int Id);
        Task<T> GetAsync();
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int Id);
    }
}
