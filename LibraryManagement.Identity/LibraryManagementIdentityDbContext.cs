using LibraryManagement.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Identity
{
    public class LibraryManagementIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public LibraryManagementIdentityDbContext(DbContextOptions<LibraryManagementIdentityDbContext> options) : base(options)
        {

        }
    }
}
