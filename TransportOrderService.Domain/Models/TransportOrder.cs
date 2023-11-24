namespace TransportOrderService.Domain.Models
{
	public sealed class TransportOrder
	{
		public Guid Id { get; set; }
		public Guid FactoryId { get; set; }
		public TransportOrderStatus Status { get; set; }
		public Guid CurrentLocationId { get; set; }
		public Guid DestinationLocationId { get; set; }

		/// <summary>
		/// The AGV provider type that is used to execute this transport order.
		/// Can be extended to multiple AGV providers, since it's possible that
		/// there can be multiple providers on the same factory
		/// </summary>
		public AgvProviderType ProviderType { get; set; }

		public List<TransportOrderBox> Boxes { get; set; }
	}

	public class TransportOrderBox
	{
		public Guid Id { get; set; }
	}
}
