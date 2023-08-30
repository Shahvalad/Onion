using Onion.Application.Interfaces;
using Onion.Domain.Entities;
using Onion.Persistance.Context;
using Onion.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Persistance.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IGenericRepository<Product> ProductRepository { get; set; }
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
            ProductRepository = new GenericRepository<Product>(_context);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
