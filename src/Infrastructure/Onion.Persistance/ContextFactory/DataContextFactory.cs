using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Onion.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//"server = DESKTOP-2MLCRJH; database = onion; trusted_connection = true; TrustServerCertificate = True;"
namespace Onion.Persistance.ContextFactory
{


    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        private readonly IConfiguration _configuration;
        public DataContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DataContext CreateDbContext(string[] args)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();

            optionsBuilder.UseSqlServer(connectionString);

            return new DataContext(optionsBuilder.Options);
        }
    }
}
