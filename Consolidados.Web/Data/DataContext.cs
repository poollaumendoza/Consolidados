using Consolidados.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace Consolidados.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Container> Containers { get; set; }
        public DbSet<State> States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Contract>()
                .HasIndex(t => t.ContractNumber)
                .IsUnique();

            modelBuilder.Entity<State>()
                .HasIndex(t => t.Name)
                .IsUnique();

            modelBuilder.Entity<Container>()
                .HasIndex(t => t.ContainerName)
                .IsUnique();
        }
    }
}