using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rekrutacja.Entities
{
    public class AppDbContext : DbContext
    {
        private string _connectionString = "Server=Albert-PC\\REKRUTACJA;Database=RekrutacjaDb;Trusted_Connection=True;";

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

    }
}
