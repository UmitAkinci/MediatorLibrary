using System.Reflection;
using MediatorLibrarySample.CQRS.Decorators;
using MediatorLibrarySample.CQRS.Meditor;
using MediatorLibrarySample.CQRS.Processor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace MediatorLibrarySample.CQRS
{
    public static class BuilderExtensions
    {
        public static IServiceCollection AddAdessoMeditor(this IServiceCollection services, params Assembly[] assemblies)
        {
            AddRequiredServices(services);
            RegisterServices(services, assemblies, typeof(IAdessoRequestHandler<,>));

            return services;
        }
        private static IServiceCollection RegisterServices(this IServiceCollection services, Assembly[] assemblies, Type registerationObj)
        {

            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes();
                var handlers = types.Where(x => x.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == registerationObj));
                foreach (var handle in handlers)
                {
                    var interfaces = handle.GetInterfaces();
                    foreach (var handleInterface in interfaces)
                    {
                        services.AddTransient(handleInterface, handle);
                    }
                }
            }



            //services.Decorate(typeof(IAdessoRequestHandler<,>), typeof(AdessoCommandHandlerDecorator<,>));
            //services.Decorate(typeof(IAdessoRequestHandler<,>), typeof(AdessoQueryHandlerDecorator<,>));

            return services;
        }
        private static void AddRequiredServices(IServiceCollection services)
        {
            services.TryAdd(new ServiceDescriptor(typeof(IAdessoMediator), typeof(AdessoMediator), ServiceLifetime.Transient));
            services.AddScoped(typeof(IAdessoPipelineBehavior<,>), typeof(AdessoRequestPreProcessor<,>));
        }
    }
}
