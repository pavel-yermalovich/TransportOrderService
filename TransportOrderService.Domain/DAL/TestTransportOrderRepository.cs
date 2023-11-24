using TransportOrderService.Domain.Models;
using TransportOrderService.Domain.Shared;

namespace TransportOrderService.Domain.DAL;

public class TestTransportOrderRepository : ITransportOrderRepository
{
	private static readonly List<TransportOrder> TestTransportOrders = new()
	{
		// CREATED
		new TransportOrder
		{
			Id = TestIds.Order1Id,
			FactoryId = TestIds.Factory1Id,
			Status = TransportOrderStatus.Created,
			CurrentLocationId = TestIds.Location1Id,
			DestinationLocationId = TestIds.Location2Id,
			ProviderType = AgvProviderType.KIONGroup,
			Boxes = new List<TransportOrderBox>
			{
				new() { Id = TestIds.Box1Id }
			}
		},

		// IN PROGRESS
		new TransportOrder
		{
			Id = TestIds.Order2Id,
			FactoryId = TestIds.Factory1Id,
			Status = TransportOrderStatus.InProgress,
			CurrentLocationId = TestIds.Location1Id,
			DestinationLocationId = TestIds.Location2Id,
			ProviderType = AgvProviderType.KIONGroup,
			Boxes = new List<TransportOrderBox>
			{
				new() { Id = TestIds.Box2Id },
				new() { Id = TestIds.Box3Id }, 
				new() { Id = TestIds.Box4Id }
			}
		},

		new TransportOrder
		{
			Id = TestIds.Order3Id,
			FactoryId = TestIds.Factory1Id,
			Status = TransportOrderStatus.InProgress,
			CurrentLocationId = TestIds.Location1Id,
			DestinationLocationId = TestIds.Location2Id,
			ProviderType = AgvProviderType.Daifuku,
			Boxes = new List<TransportOrderBox>
			{
				new() { Id = TestIds.Box5Id },
				new() { Id = TestIds.Box6Id }
			}
		}
	};

	public TransportOrder GetById(Guid id)
	{
		return TestTransportOrders.FirstOrDefault(x => x.Id == id);
	}
}