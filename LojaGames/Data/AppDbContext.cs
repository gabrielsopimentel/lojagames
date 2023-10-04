﻿using LojaGames.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LojaGames.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().ToTable("tb_produtos");
            modelBuilder.Entity<Categoria>().ToTable("tb_categorias");
            modelBuilder.Entity<User>().ToTable("tb_usuarios");


            _ = modelBuilder.Entity<Produto>()
                .HasOne(_ => _.Categoria)
                .WithMany(c => c.Produtos)
                .HasForeignKey("CategoriaId")
                .OnDelete(DeleteBehavior.Cascade);
        }
        //registrar dbset - objeto resposável por manipular a tabela
        public DbSet<Produto> Produtos { get; set; } = null!;
        public DbSet<Categoria> Categorias { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
        {
            public DateOnlyConverter()
                : base(dateOnly =>
                        dateOnly.ToDateTime(TimeOnly.MinValue),
                    dateTime => DateOnly.FromDateTime(dateTime))
            { }
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");

            base.ConfigureConventions(builder);
        }
    }
}
