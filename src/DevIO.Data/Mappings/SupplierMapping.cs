using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings;

public class SupplierMapping : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder.Property(p => p.Document)
            .IsRequired()
            .HasColumnType("varchar(14)");

        builder.HasOne(p => p.Address)
            .WithOne(a => a.Supplier);

        builder.HasMany(p => p.Products)
            .WithOne(p => p.Supplier)
            .HasForeignKey(p => p.SupplierId);

        builder.ToTable("Suppliers");
    }
}