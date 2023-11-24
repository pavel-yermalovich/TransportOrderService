using TransportOrderService.Domain.Models;

namespace TransportOrderService.Domain.Abstractions;

public class TransportOrderProgress
{
	/// <summary>
	/// Transport order id
	/// </summary>
	public Guid TransportOrderId { get; set; }
	/// <summary>
	/// The status of an order
	/// Possible values: Created = 0, InProgress = 1, Cancelled = 2, Failed = 3, Completed = 4
	/// </summary>
	public TransportOrderStatus Status { get; set; }
	/// <summary>
	/// Collection with box progresses
	/// </summary>
	public IReadOnlyList<TransportOrderBoxProgress> BoxProgresses { get; set; }
}