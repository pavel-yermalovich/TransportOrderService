using TransportOrderService.Domain.Abstractions;
using TransportOrderService.Domain.Models;
using TransportOrderService.Domain.Shared;

namespace TransportOrderService.Domain.Implementations;

public class KIONGroupAgvProviderGateway : IAgvProviderGateway
{
	private static readonly IReadOnlyList<TransportOrderBoxProgress> TestTransportOrderBoxProgresses =
		new List<TransportOrderBoxProgress>
		{
			new()
			{
				TransportOrderBoxId = TestIds.Box2Id,
				Progress = 10
			},
			new()
			{
				TransportOrderBoxId = TestIds.Box3Id,
				Progress = 20
			},
			new()
			{
				TransportOrderBoxId = TestIds.Box4Id,
				Progress = 95
			}
		};

	public IReadOnlyList<TransportOrderBoxProgress> GetBoxProgresses(List<Guid> transportOrderBoxIds)
	{
		// Real implementation will be calling API of KION Group AGV provider
		return TestTransportOrderBoxProgresses
			.Where(x => transportOrderBoxIds.Contains(x.TransportOrderBoxId))
			.ToList();
	}
}