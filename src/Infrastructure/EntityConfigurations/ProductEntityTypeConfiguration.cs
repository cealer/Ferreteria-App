using Domain.AggregatesModel.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> configuration)
        {
            configuration.ToTable("Products");

            configuration.HasKey(b => b.Id);

            configuration.Ignore(b => b.DomainEvents);

            configuration.Property(b => b.Id)
                .HasColumnName("ProductId");

            configuration.Property(b => b.Category)
                .HasMaxLength(20)
                .IsRequired();

            configuration.Property(b => b.Code)
                 .HasMaxLength(20)
                .IsRequired();

            configuration.Property(b => b.Description)
                .HasMaxLength(100)
                .IsRequired();

            //Address value object persisted as owned entity type supported since EF Core 2.0
            configuration.Property(b => b.Price)
                .IsRequired()
                .HasColumnType("decimal(8,2)");
        }
    }
}
