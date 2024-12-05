using Hamurgueria.Business.Models;
using Hamurgueria.Business.Models.Categorization;
using Microsoft.EntityFrameworkCore;
using System;

namespace Hamurgueria.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = true;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);

            // IDs de Status
            var statusPendenteId = Guid.NewGuid();
            var statusConcluidoId = Guid.NewGuid();
            var statusCanceladoId = Guid.NewGuid();

            // Seeding para Status
            modelBuilder.Entity<Status>().HasData(
                new Status { Id = statusPendenteId, Name = "Pendente" },
                new Status { Id = statusConcluidoId, Name = "Concluído" },
                new Status { Id = statusCanceladoId, Name = "Cancelado" }
            );

            // Seeding para Categoria
            var category1 = Guid.NewGuid();

            modelBuilder.Entity<Categorie>().HasData(
                new Categorie
                {
                    Id = category1,
                    Name = "Hambúrgueres Clássicos",
                    PathImage = "https://github.com/O-ian-carvalho/backend-hamburguer/blob/master/img/hamburguer.png?raw=true",
                    Description = "Os melhores hambúrgueres tradicionais."
                }
            );

            // Seeding para Produtos
            var product1 = Guid.NewGuid();
            var product2 = Guid.NewGuid();

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = product1,
                    Name = "Cheeseburger",
                    PathImage = "https://github.com/O-ian-carvalho/backend-hamburguer/blob/master/img/hamburguer.png?raw=true",
                    Price = 15.99m,
                    BaseDescription = "Pão, carne e queijo.",
                    FullDescription = "Pão brioche, carne suculenta e queijo cheddar.",
                    CategorieId = category1
                },
                new Product
                {
                    Id = product2,
                    Name = "X-Bacon",
                    PathImage = "https://github.com/O-ian-carvalho/backend-hamburguer/blob/master/img/hamburguer.png?raw=true",
                    Price = 18.50m,
                    BaseDescription = "Pão, carne, bacon e queijo.",
                    FullDescription = "Pão brioche, carne suculenta, bacon crocante e queijo cheddar.",
                    CategorieId = category1
                }
            );

            // Seeding para Usuários
            var user1 = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = user1,
                    Name = "João Silva",
                    Email = "joao@gmail.com",
                    Password = "Senha123"
                }
            );

            // Seeding para Pedidos
            var order1 = Guid.Parse("08dd14b9-4f27-481b-8772-9bcb5362b24f");

            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = order1,
                    UserId = user1,
                    StatusId = statusPendenteId, // Relacionando com Status
                    Value = 15.99m // Cheeseburger
                }
            );
        }
    }
}
