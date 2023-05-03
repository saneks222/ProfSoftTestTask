using Autofac;
using ProfSoftTestTask.Repository;

namespace ProfSoftTestTask.Application.Extensions
{
    public static class AppExtension
    {

        public static IApp AddIoC(this IApp app)
        {
            app.Container = ConfigureContainer();

            return app;
        }
        /// <summary>
        /// Регестрирует зависимости 
        /// </summary>
        /// <returns>IContainer</returns>
        private static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ConfigurationRepositoryInMemory>().As<IConfigurationRepository>();

            return builder.Build();
        }
    }
}
