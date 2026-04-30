using MegaTirolesa.Application.Repositories;
using MegaTirolesa.Infrastructure.Persistence;
using MegaTirolesa.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MegaTirolesa.Infrastructure
{
    public static class InfrastructureModule
    {
        extension(IServiceCollection services)
        {
            public IServiceCollection AddInfrastructure(IConfiguration configuration)
            {
                services
                    .AddData(configuration)
                    .AddRepositories();

                return services;
            }
            private IServiceCollection AddData(IConfiguration configuration)
            {
                services
                    .AddDbContext<MegaTirolesaDbContext>(options => options.UseSqlServer(
                        configuration.GetConnectionString("MegaTirolesaDb")));

                return services;
            }

            private IServiceCollection AddRepositories()
            {
                services.AddScoped<IUserRepository, UserRepository>();
                services.AddScoped<IAppointmentRepository, AppointmentRepository>();

                return services;
            }
        }
    }
}
