using ATM.Application;
using ATM.Contracts.Interfaces;
using Microsoft.Extensions.DependencyInjection;


var serviceCollection = new ServiceCollection();
ConfigureServices(serviceCollection);
var serviceProvider = serviceCollection.BuildServiceProvider();
var service = serviceProvider.GetService<IAtmService>();
service.InitializeAtm();



static void ConfigureServices(IServiceCollection services)
{
    services.AddSingleton<IAtmService, AtmService>();
    services.AddSingleton<IConsoleService, ConsoleService>();
}
