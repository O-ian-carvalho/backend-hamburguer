using Hamurgueria.Business.Models.Categorization;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamurgueria.Data.Configuration
{
    public class CategorieMapping : IEntityTypeConfiguration<Categorie>
    {
        public void Configure(EntityTypeBuilder<Categorie> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.PathImage)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.ToTable("Categories");
        }
    }
}
