using Domain.AggregatesModel.InventoryAggregate;
using Domain.AggregatesModel.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations
{
    public class InventoryEntityTypeConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> configuration)
        {
            configuration.ToTable("Inventories");

            configuration.HasKey(b => b.Id);

            configuration.Ignore(b => b.DomainEvents);

            configuration.HasOne<Product>()
                .WithMany()
                .IsRequired()
                .HasForeignKey(x => x.ProductId);
        }
    }
}
