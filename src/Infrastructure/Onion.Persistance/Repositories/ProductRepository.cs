using Microsoft.EntityFrameworkCore;
using Onion.Application.Interfaces;
using Onion.Domain.Entities;
using Onion.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Persistance.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {

        public ProductRepository(DataContext db) : base(db)
        {
        }
    }
}
