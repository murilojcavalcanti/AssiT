using AssiT.BackEnd.Application.Behaviors;
using AssiT.BackEnd.Application.Services.Commands.ContactCommands.CreateContact;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace AssiT.BackEnd.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddHandlers().AddValidators();
            return services;
        }

        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(Config => 
            {
                Config.RegisterServicesFromAssemblyContaining<CreateAssetHandler>();
               // Config.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });
            return services;
        }
        private static IServiceCollection AddValidators(this IServiceCollection services)
        {
        /*
            services.Add<CreateAssetHandler>(ServiceLifetime.Scoped);
        */
            return services;
        }
    }
}
