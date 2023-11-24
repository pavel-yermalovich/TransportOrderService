namespace TransportOrderService.Domain.Abstractions;

public interface ITransportOrderService
{
	TransportOrderProgress GetTransportOrderProgress(Guid transportOrderId);
}