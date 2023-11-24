using TransportOrderService.Domain.Models;

namespace TransportOrderService.Domain.Abstractions;

public interface IAgvProviderGateway
{
	IReadOnlyList<TransportOrderBoxProgress> GetBoxProgresses(List<Guid> transportOrderBoxIds);
}