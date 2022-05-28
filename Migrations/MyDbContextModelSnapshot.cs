﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PokemonPocket;

namespace PokemonPocket.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("PokemonPocket.Pokemon", b =>
                {
                    b.Property<int>("PokemonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Attack")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Exp")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Hp")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("workingHp")
                        .HasColumnType("INTEGER");

                    b.HasKey("PokemonId");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("nameindex");

                    b.ToTable("Pokemons");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Pokemon");
                });

            modelBuilder.Entity("PokemonPocket.Charmander", b =>
                {
                    b.HasBaseType("PokemonPocket.Pokemon");

                    b.HasDiscriminator().HasValue("Charmander");
                });

            modelBuilder.Entity("PokemonPocket.Eevee", b =>
                {
                    b.HasBaseType("PokemonPocket.Pokemon");

                    b.HasDiscriminator().HasValue("Eevee");
                });

            modelBuilder.Entity("PokemonPocket.Pikachu", b =>
                {
                    b.HasBaseType("PokemonPocket.Pokemon");

                    b.HasDiscriminator().HasValue("Pikachu");
                });
#pragma warning restore 612, 618
        }
    }
}
