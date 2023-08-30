using Onion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Interfaces
{
    public interface IUnitOfWork
    {
        public IGenericRepository<Product> ProductRepository { get; set; }

        public Task Save();
    }
}
