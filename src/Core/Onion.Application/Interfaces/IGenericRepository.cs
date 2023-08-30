using Onion.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();

        Task<T> GetByIdAsync(Guid id);

        Task<T> GetBy(Expression<Func<T,bool>> predicate);

        Task AddAsync(T entity);

        Task UpdateAsync(Guid id, T entity);

        Task DeleteAsync(T entity);

        Task Save();
    }
}
