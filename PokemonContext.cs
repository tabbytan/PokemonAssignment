using Microsoft.EntityFrameworkCore;
using System;

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
            base.OnModelCreating(modelBuilder);
        }
    }
}