using Hamurgueria.Business.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamurgueria.Data.Configuration
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.PathImage)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(p => p.Price)
                .HasColumnType("decimal(10,2)");

            builder.Property(p => p.BaseDescription)
                .HasMaxLength(500);

            builder.Property(p => p.FullDescription)
                .HasMaxLength(1000);

            builder.HasOne(p => p.Categorie)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.CategorieId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.Orders).WithMany(p => p.Products);

            builder.ToTable("Products");
        }
    }
}
