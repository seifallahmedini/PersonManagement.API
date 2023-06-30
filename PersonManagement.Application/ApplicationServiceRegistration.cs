using Microsoft.Extensions.DependencyInjection;

namespace PersonManagement.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddScoped<IPersonService, PersonService>();

            return services;
        }
    }
}
