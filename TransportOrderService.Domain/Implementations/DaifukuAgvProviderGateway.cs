using TransportOrderService.Domain.Abstractions;
using TransportOrderService.Domain.Models;
using TransportOrderService.Domain.Shared;

namespace TransportOrderService.Domain.Implementations;

public class DaifukuAgvProviderGateway : IAgvProviderGateway
{
	private static readonly IReadOnlyList<TransportOrderBoxProgress> TestTransportOrderBoxProgresses =
		new List<TransportOrderBoxProgress>
		{
			new()
			{
				TransportOrderBoxId = TestIds.Box5Id,
				Progress = 50
			},
			new()
			{
				TransportOrderBoxId = TestIds.Box6Id,
				Progress = 50
			}
		};

	public IReadOnlyList<TransportOrderBoxProgress> GetBoxProgresses(List<Guid> transportOrderBoxIds)
	{
		if (transportOrderBoxIds.Any())
		{
			return TestTransportOrderBoxProgresses
				.Where(x => transportOrderBoxIds.Contains(x.TransportOrderBoxId))
				.ToList();
		}

		return Enumerable.Empty<TransportOrderBoxProgress>().ToList();
	}
}