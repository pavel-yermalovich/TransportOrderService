namespace TransportOrderService.Domain.Models;

public class TransportOrderBoxProgress
{
	/// <summary>
	/// Id of the box in the transport order
	/// </summary>
	public Guid TransportOrderBoxId { get; set; }
	/// <summary>
	/// Progress of the delivery of the box in percentage by the distance between the original location and the destination
	///  </summary>
	public int Progress { get; set; }
}