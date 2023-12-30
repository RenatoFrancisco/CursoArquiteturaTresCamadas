using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings;

public class ProdutoMapping : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasColumnName("varchar(200)");

        builder.Property(p => p.Description)
            .IsRequired()
            .HasColumnName("varchar(1000)");

        builder.ToTable("Products");
    }
}