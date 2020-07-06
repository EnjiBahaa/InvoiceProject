using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using Wasmah.Entities;

namespace Wasmah.Context
{
    public class DbContext : IdentityDbContext
    {
        public DbContext()
        {
        }
        public DbContext(DbContextOptions<DbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=WasmahDB;Integrated Security=True", opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Product_Invoice> Product_Invoices{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
