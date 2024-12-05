using Hamurgueria.Business.Models;
using Hamurgueria.Business.Models.Categorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamurgueria.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext( DbContextOptions<AppDbContext> options) : base(options)
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


            var statusPendenteId = Guid.NewGuid();
            var statusConcluidoId = Guid.NewGuid();
            var statusCanceladoId = Guid.NewGuid();

            // Seeding para Status
            modelBuilder.Entity<Status>().HasData(
                new Status { Id = statusPendenteId, Name = "Pendente" },
                new Status { Id = statusConcluidoId, Name = "Concluído" },
                new Status { Id = statusCanceladoId, Name = "Cancelado" }
            );

            // Seeding para Categorias
            var category1 = Guid.NewGuid();
            var category2 = Guid.NewGuid();

            modelBuilder.Entity<Categorie>().HasData(
                new Categorie
                {
                    Id = category1,
                    Name = "Hambúrgueres Clássicos",
                    PathImage = "https://github.com/O-ian-carvalho/backend-hamburguer/blob/master/img/hamburguer.png?raw=true",
                    Description = "Os melhores hambúrgueres tradicionais."
                },
                new Categorie
                {
                    Id = category2,
                    Name = "Bebidas",
                    PathImage = "https://github.com/O-ian-carvalho/backend-hamburguer/blob/master/img/hamburguer.png?raw=true",
                    Description = "Refresque-se com nossas bebidas."
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
                    Name = "Refrigerante",
                    PathImage = "https://github.com/O-ian-carvalho/backend-hamburguer/blob/master/img/hamburguer.png?raw=true",
                    Price = 4.50m,
                    BaseDescription = "Bebida gelada.",
                    FullDescription = "Refrigerante sabor cola em lata de 350ml.",
                    CategorieId = category2
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
            var order1 = Guid.NewGuid();

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
