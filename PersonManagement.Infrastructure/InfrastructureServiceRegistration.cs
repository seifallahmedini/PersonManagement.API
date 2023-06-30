using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonManagement.Domain.Entities;
using PersonManagement.Domain.Interfaces;

namespace PersonManagement.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            var serviceProviderRep = services.BuildServiceProvider();

            using (var scope = serviceProviderRep.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.EnsureCreated();
            }
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRepository<Person>, PersonRepository>();

            return services;
        }
    }
}
