using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Next3.Domain.Models;

namespace Next3.Infra.Data.Mapping
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Street)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(a => a.Number)
                .IsRequired();

            builder.Property(a => a.Complement)
              .HasMaxLength(100)
              .IsRequired();

            builder.Property(a => a.City)
              .HasMaxLength(100)
              .IsRequired();

            builder.Property(a => a.District)
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(a => a.Country)
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(a => a.Longitude)
            .IsRequired();

            builder.Property(a => a.Latitude)
          .IsRequired();

            builder.Property(a => a.ZipCode)
           .HasMaxLength(15)
          .IsRequired();

            builder.HasOne(a => a.Restaurant)
             .WithOne(r => r.Address);
        }
    }
}

