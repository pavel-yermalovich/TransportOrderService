namespace TransportOrderService.Domain.Models;

public enum TransportOrderStatus
{
	Created = 0,
	InProgress = 1,
	Cancelled = 2,
	Failed = 3,
	Completed = 4
}