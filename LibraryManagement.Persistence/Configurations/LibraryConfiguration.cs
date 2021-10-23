using LibraryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagement.Persistence.Configurations
{
    public class LibraryConfiguration : IEntityTypeConfiguration<Library>
    {
        public void Configure(EntityTypeBuilder<Library> builder)
        {
            builder.Property(lb => lb.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(lb => lb.Location)
                   .IsRequired()
                   .HasMaxLength(50);
        }
    }
}
