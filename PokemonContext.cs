using Microsoft.EntityFrameworkCore;
using System;
// Name: Tan Wei Heng
// Admin:201450s
namespace PokemonPocket
{
    public class MyDbContext : DbContext
    {
        public string DbPath { get; set; }

        public DbSet<Pokemon> Pokemons { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var path = Environment.CurrentDirectory;
            DbPath = System.IO.Path.Join(path, "PokemonPocket.db");
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map table names
            modelBuilder.Entity<Pokemon>();
            // this doesnt work..
            // .HasIndex(p => new { p.Name })
            // .HasDatabaseName("nameindex").IsUnique();
            modelBuilder.Entity<Eevee>();
            modelBuilder.Entity<Charmander>();
            modelBuilder.Entity<Pikachu>();
            base.OnModelCreating(modelBuilder);
        }
    }
}