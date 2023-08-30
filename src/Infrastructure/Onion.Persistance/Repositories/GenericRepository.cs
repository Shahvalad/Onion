using Microsoft.EntityFrameworkCore;
using Onion.Application.Interfaces;
using Onion.Domain.Common;
using Onion.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Persistance.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DataContext _db;
        private DbSet<T> Table => _db.Set<T>();
        public GenericRepository(DataContext db)
        {
            _db = db;
        }


        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            Table.Remove(entity);
        }

        public async Task<List<T>> GetAllAsync()
        {
            var list = await Table.ToListAsync();
            return list;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await Table.FindAsync(id);
        }


        public Task<T> GetBy(Expression<Func<T, bool>> predicate)
        {
            return Table.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Guid id, T entity)
        {
            var existingEntity = GetByIdAsync(id);
            _db.Entry(existingEntity).CurrentValues.SetValues(entity);
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }

    }
}
