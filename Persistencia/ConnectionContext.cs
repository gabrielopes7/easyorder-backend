using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Models
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-T3CN7CDL\\DBLEARN;Initial Catalog=EasyOrder;TrustServerCertificate=True;Integrated Security=True;",
                    sqlServerOptions => sqlServerOptions.EnableRetryOnFailure());
            }
        }
    }
}
