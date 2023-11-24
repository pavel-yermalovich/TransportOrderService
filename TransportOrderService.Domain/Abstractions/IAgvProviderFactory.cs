using TransportOrderService.Domain.Models;

namespace TransportOrderService.Domain.Abstractions;

public interface IAgvProviderFactory
{
	IAgvProviderGateway GetProvider(AgvProviderType providerType);
}