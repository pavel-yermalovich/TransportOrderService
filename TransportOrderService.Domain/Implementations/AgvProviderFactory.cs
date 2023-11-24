using TransportOrderService.Domain.Abstractions;
using TransportOrderService.Domain.Models;

namespace TransportOrderService.Domain.Implementations;

public class AgvProviderFactory : IAgvProviderFactory
{
	public IAgvProviderGateway GetProvider(AgvProviderType providerType)
	{
		switch (providerType)
		{
			case AgvProviderType.KIONGroup:
				return new KIONGroupAgvProviderGateway();
			case AgvProviderType.Daifuku:
				return new DaifukuAgvProviderGateway();
			default:
				throw new ArgumentOutOfRangeException(
					nameof(providerType), 
					providerType, 
					$"Unsupported AGV provider: {nameof(providerType)}");
		}
	}
}