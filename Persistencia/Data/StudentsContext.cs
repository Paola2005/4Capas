using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.Data
{
    public class StudentsContext:DbContext
    {
        public StudentsContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public async Task<int> SaveChangeAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
