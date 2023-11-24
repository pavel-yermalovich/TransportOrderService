using TransportOrderService.Domain.Abstractions;
using TransportOrderService.Domain.DAL;

namespace TransportOrderService.API;

public static class DependencyInjection
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		services.AddTransient<ITransportOrderRepository, TestTransportOrderRepository>();
		services.AddTransient<ITransportOrderService, Domain.Implementations.TransportOrderService>();
		services.AddTransient<IAgvProviderFactory, Domain.Implementations.AgvProviderFactory>();

		return services;
	}
}