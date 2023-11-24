using TransportOrderService.Domain.Abstractions;
using TransportOrderService.Domain.DAL;
using TransportOrderService.Domain.Models;

namespace TransportOrderService.Domain.Implementations
{
	public class TransportOrderService : ITransportOrderService
	{
		private readonly ITransportOrderRepository _transportOrderRepository;
		private readonly IAgvProviderFactory _agvProviderFactory;

		public TransportOrderService(
			ITransportOrderRepository transportOrderRepository,
			IAgvProviderFactory agvProviderFactory)
		{
			_transportOrderRepository = transportOrderRepository;
			_agvProviderFactory = agvProviderFactory;
		}

		public TransportOrderProgress GetTransportOrderProgress(Guid transportOrderId)
		{
			var transportOrder = _transportOrderRepository.GetById(transportOrderId);

			IReadOnlyList<TransportOrderBoxProgress> boxProgresses = new List<TransportOrderBoxProgress>();

			if (transportOrder.Status == TransportOrderStatus.InProgress)
			{
				var agvProvider = _agvProviderFactory.GetProvider(transportOrder.ProviderType);

				var boxIds = transportOrder.Boxes.Select(x => x.Id).ToList();
				boxProgresses = agvProvider.GetBoxProgresses(boxIds);
			}

			return new TransportOrderProgress
			{
				TransportOrderId = transportOrderId,
				Status = transportOrder.Status,
				BoxProgresses = boxProgresses
			};
		}
	}
}
