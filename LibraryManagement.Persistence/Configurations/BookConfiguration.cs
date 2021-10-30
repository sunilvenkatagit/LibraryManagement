using LibraryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagement.Persistence.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(b => b.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(b => b.Description)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(b => b.Genre)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(b => b.PublisherId)
                   .IsRequired();
        }
    }
}
