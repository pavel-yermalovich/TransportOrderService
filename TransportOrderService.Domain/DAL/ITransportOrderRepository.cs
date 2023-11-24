using TransportOrderService.Domain.Models;

namespace TransportOrderService.Domain.DAL;

public interface ITransportOrderRepository
{
	TransportOrder GetById(Guid id);
}