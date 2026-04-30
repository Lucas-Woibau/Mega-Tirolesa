using MegaTirolesa.Application.Common;
using MegaTirolesa.Application.FluentValidation.AppointmentValidator;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace MegaTirolesa.Application
{
    public static class ApplicationModule
    {
        extension(IServiceCollection services)
        {
            public IServiceCollection AddApplication()
            {
                services
                    .AddHandlers()
                    .AddValidation();

                return services;
            }

            private IServiceCollection AddHandlers()
            {
                services.AddScoped<IMediator, Mediator>();

                services.Scan(s =>
                    s.FromAssemblies(typeof(ApplicationModule).Assembly)
                        .AddClasses(c => c.AssignableTo(typeof(IHandler<,>)))
                        .AsImplementedInterfaces()
                        .WithTransientLifetime()
                );

                return services;
            }

            private IServiceCollection AddValidation()
            {
                services
                    .AddValidatorsFromAssemblyContaining<CreateAppointmentValidator>();

                return services;
            }
        }
    }
}
