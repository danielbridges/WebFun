namespace LuresWebApp.Installers
{
    using System.Web.Mvc;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using LuresWebLib;
    using LuresWebLib.Installers;

    public class WebAppInstaller: IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<LuresRepository>(),
                Classes.FromThisAssembly().BasedOn<IController>().LifestyleTransient(),
                Component.For<IConnectionStringFactory>().ImplementedBy<DatabaseConnectionFactory>()
                );
        }
    }
}