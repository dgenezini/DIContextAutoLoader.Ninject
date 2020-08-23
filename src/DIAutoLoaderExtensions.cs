using Ninject;
using System.Reflection;

namespace DIContextAutoLoader.Ninject
{
    public static class DIAutoLoaderExtensions
    {
        public static IKernel AutoLoadServices(
            this IKernel kernel,
            params Assembly[] assemblies)
        {
            var InstanceInjectionConfigurarions = ServiceInjectionManager
                .GetServicesInjectionConfigurarions(assemblies);

            foreach (var InstanceInjectionConfigurarion in InstanceInjectionConfigurarions)
            {
                if (InstanceInjectionConfigurarion.Lifetime == InjectionLifetime.Transient)
                {
                    kernel
                        .Bind(InstanceInjectionConfigurarion.ServiceType)
                        .To(InstanceInjectionConfigurarion.ImplementationType)
                        .InTransientScope();
                }
                else if (InstanceInjectionConfigurarion.Lifetime == InjectionLifetime.Scoped)
                {
                    kernel
                        .Bind(InstanceInjectionConfigurarion.ServiceType)
                        .To(InstanceInjectionConfigurarion.ImplementationType);
                }
                else if (InstanceInjectionConfigurarion.Lifetime == InjectionLifetime.Singleton)
                {
                    kernel
                        .Bind(InstanceInjectionConfigurarion.ServiceType)
                        .To(InstanceInjectionConfigurarion.ImplementationType)
                        .InSingletonScope();
                }
            }

            return kernel;
        }
    }
}
