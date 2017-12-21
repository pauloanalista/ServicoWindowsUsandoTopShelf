using SimpleInjector;
using Topshelf;
using Topshelf.SimpleInjector;
namespace Qsti.ComunicacaoDetro.SW
{
    public class ConfigureService
    {
        public static void Configure()
        {
            Container container = ConfigureSimpleInjectorService();

            HostFactory.Run(configure =>
            {
                configure.UseSimpleInjector(container);
                configure.Service<ComunicacaoDetroService>(service =>
                {
                    service.ConstructUsing(s => new ComunicacaoDetroService());
                    service.WhenStarted(s => s.Start());
                    service.WhenStopped(s => s.Stop());
                });
                //Setup Account that window service use to run.  
                configure.RunAsLocalSystem();
                configure.SetServiceName("ComunicacaoDetro");
                configure.SetDisplayName("ComunicacaoDetro");
                configure.SetDescription("Obtém informações do globalbus e disponibiliza em cache via redis, o gateway irá consumir os dados posteriormente do cache");
            });
        }

        private static Container ConfigureSimpleInjectorService()
        {
            // Create a new Simple Injector container
            Container container = new Container();

            // Configure the Container
            ConfigureContainer(container);

            // Optionally verify the container's configuration to check for configuration errors.
            container.Verify();

            return container;
        }

        /// <summary>
        /// Register services here
        /// </summary>
        /// <param name="container"></param>
        private static void ConfigureContainer(Container container)
        {
            ////Register the service

            container.Register<IClass1, Class1>();
            //container.Register<IInterface, ConcreteClass>();
            //container.RegisterSingleton<ILog>(LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType));
        }
    }
}
