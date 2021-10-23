using LibraryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagement.Persistence.Configurations
{
    public class Book_AuthorConfiguration : IEntityTypeConfiguration<Book_Author>
    {
        public void Configure(EntityTypeBuilder<Book_Author> builder)
        {
            builder.HasOne(ba => ba.Book)
                   .WithMany(b => b.Authors)
                   .HasForeignKey(ba => ba.BookId);

            builder.HasOne(ba => ba.Author)
                   .WithMany(a => a.Books)
                   .HasForeignKey(ba => ba.AuthorId);
        }
    }
}
