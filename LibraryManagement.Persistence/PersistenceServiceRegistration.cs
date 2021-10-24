using LibraryManagement.Application.Contracts.Persistence;
using LibraryManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagement.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPeristenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LibraryManagementDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("LibraryManagementConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ILibraryRepository, LibraryRepository>();
            services.AddScoped<IBookRepository, BookRepository>();

            return services;
        }
    }
}
