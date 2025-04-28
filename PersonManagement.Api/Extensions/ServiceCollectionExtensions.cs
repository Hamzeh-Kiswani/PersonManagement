using Microsoft.EntityFrameworkCore;
using PersonManagement.Api.Data.Context;
using PersonManagement.Api.Repositories;
using PersonManagement.Api.Services;

namespace PersonManagement.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersonManagement(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<PersonContext>(opts =>
                opts.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddScoped<IPersonRepository, PersonRepository>();

            services.AddScoped<IPersonService, PersonService>();

            return services;
        }
    }
}
