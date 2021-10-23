using LibraryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagement.Persistence.Configurations
{
    public class Library_BookConfiguration : IEntityTypeConfiguration<Library_Book>
    {
        public void Configure(EntityTypeBuilder<Library_Book> builder)
        {
            builder.HasOne(lbb => lbb.Library)
                   .WithMany(lb => lb.Books)
                   .HasForeignKey(lbb => lbb.LibraryId);

            builder.HasOne(lbb => lbb.Book)
                   .WithMany(b => b.Libraries)
                   .HasForeignKey(lbb => lbb.BookId);
        }
    }
}
