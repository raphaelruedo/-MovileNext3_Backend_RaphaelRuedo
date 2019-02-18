using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Next3.Domain.Models;

namespace Next3.Infra.Data.Mapping
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Observation)
                .HasMaxLength(250);

            builder.Property(o => o.UserId)
                .IsRequired();

            builder.HasOne(o => o.OrderStatus)
             .WithMany(os => os.Orders)
             .HasForeignKey(o => o.OrderStatusId);

            builder.HasOne(o => o.Address)
                .WithMany(os => os.Orders)
                .HasForeignKey(o => o.AddressId);

            builder.HasOne(o => o.Address)
               .WithMany(os => os.Orders)
               .HasForeignKey(o => o.AddressId);

        }
    }
}
