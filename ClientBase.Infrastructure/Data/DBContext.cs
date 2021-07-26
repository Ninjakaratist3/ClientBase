using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ClientBase.Infrastructure.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            RegisterEntities(modelBuilder, GlobalConfiguration.EntitiesTypes);

            base.OnModelCreating(modelBuilder);
        }

        private static void RegisterEntities(ModelBuilder modelBuilder, IEnumerable<Type> typeToRegisters)
        {
            foreach (var type in typeToRegisters)
            {
                modelBuilder.Entity(type);
            }
        }
    }
}
