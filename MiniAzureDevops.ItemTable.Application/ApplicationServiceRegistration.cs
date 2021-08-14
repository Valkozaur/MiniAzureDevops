using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MiniAzureDevops.ItemTable.Application.Pipelines;
using System.Reflection;

namespace MiniAzureDevops.ItemTable.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Add all the assemblies to MediatR
            services.AddMediatR(typeof(ApplicationServiceRegistration).GetTypeInfo().Assembly);

            // For all the validators, register them with dependency injection as scoped
            AssemblyScanner.FindValidatorsInAssembly(typeof(ApplicationServiceRegistration).Assembly)
              .ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));

            // Add the custome pipeline validation to DI
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehaviour<,>));

            return services;
        }
    }
}
