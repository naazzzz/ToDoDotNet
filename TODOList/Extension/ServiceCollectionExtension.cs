using System.Reflection;
using TODOList.Attributes;

namespace TODOList.Extension;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServicesWithAttribute(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var serviceTypes = assembly.GetTypes()
            .Where(type => type.IsClass && !type.IsAbstract && type.GetCustomAttribute<RegisterService>() != null)
            .ToList();

        foreach (var serviceType in serviceTypes)
        {
            var attribute = serviceType.GetCustomAttribute<RegisterService>();
            var interfaceType = serviceType.GetInterfaces().FirstOrDefault(i => i.Name == $"I{serviceType.Name}");
            if (interfaceType != null)
            {
                switch (attribute.Lifetime)
                {
                    case ServiceLifetime.Scoped:
                        services.AddScoped(interfaceType, serviceType);
                        break;
                    case ServiceLifetime.Singleton:
                        services.AddSingleton(interfaceType, serviceType);
                        break;
                    case ServiceLifetime.Transient:
                        services.AddTransient(interfaceType, serviceType);
                        break;
                }
            }
        }

        return services;
    }
}