namespace App
{
    using System.Reflection;

    using App.Controllers;

    using Autofac;
    using Autofac.Integration.WebApi;

    using CurrencyToWords;

    public static class IocConfig
    {
        public static IContainer BuildContainer()
        {
            var b = new ContainerBuilder();
            

            var thisAssembly = typeof(ChequeController).Assembly;
            b.RegisterApiControllers(thisAssembly);

            b.RegisterType<CurrencyWordService>().As<ICurrencyWordService>();

            return b.Build();
        }
    }
}