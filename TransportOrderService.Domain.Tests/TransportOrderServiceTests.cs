using Moq;
using NUnit.Framework;
using TransportOrderService.Domain.Abstractions;
using TransportOrderService.Domain.DAL;
using TransportOrderService.Domain.Models;

namespace TransportOrderService.Domain.Tests
{
	[TestFixture]
	public class TransportOrderServiceTests
	{
		private Mock<ITransportOrderRepository> _transportOrderRepositoryMock;
		private Mock<IAgvProviderFactory> _agvProviderFactoryMock;
		private Mock<IAgvProviderGateway> _daifukuProviderGatewayMock;

		private Implementations.TransportOrderService _instance;

		[SetUp]
		public void SetUp()
		{
			_transportOrderRepositoryMock = new Mock<ITransportOrderRepository>();
			_agvProviderFactoryMock = new Mock<IAgvProviderFactory>();
			_daifukuProviderGatewayMock = new Mock<IAgvProviderGateway>();

			_instance = new Implementations.TransportOrderService(
				_transportOrderRepositoryMock.Object, 
				_agvProviderFactoryMock.Object);
		}

		[TearDown]
		public void TearDown()
		{
			_transportOrderRepositoryMock.VerifyAll();
			_agvProviderFactoryMock.VerifyAll();
			_daifukuProviderGatewayMock.VerifyAll();
		}
		
		[Test]
		public void GetTransportOrderProgress_WhenCalled_ReturnsTransportOrderProgress()
		{
			// Arrange
			var transportOrderId = Guid.NewGuid();
			var box1Id = Guid.NewGuid();
			var box2Id = Guid.NewGuid();

			var transportOrder = new TransportOrder
			{
				Id = transportOrderId,
				Status = TransportOrderStatus.InProgress,
				ProviderType = AgvProviderType.Daifuku,
				Boxes = new List<TransportOrderBox>
				{
					new() { Id = box1Id },
					new() { Id = box2Id }
				}
			};

			_transportOrderRepositoryMock
				.Setup(x => x.GetById(transportOrderId))
				.Returns(transportOrder);

			_agvProviderFactoryMock
				.Setup(x => x.GetProvider(AgvProviderType.Daifuku))
				.Returns(_daifukuProviderGatewayMock.Object);

			var boxProgresses = new List<TransportOrderBoxProgress>
			{
				new()
				{
					TransportOrderBoxId = box1Id,
					Progress = 30
				},
				new()
				{
					TransportOrderBoxId = box2Id,
					Progress = 50
				}
			};

			_daifukuProviderGatewayMock
				.Setup(x => x.GetBoxProgresses(It.Is<List<Guid>>(l => l.All(i => i == box1Id || i == box2Id))))
				.Returns(boxProgresses);
			
			// Act
			var result = _instance.GetTransportOrderProgress(transportOrderId);

			// Assert
			Assert.That(result, Is.Not.Null);
			Assert.That(result.TransportOrderId, Is.EqualTo(transportOrderId));
			Assert.That(result.Status, Is.EqualTo(TransportOrderStatus.InProgress));
			Assert.That(result.BoxProgresses, Is.EquivalentTo(boxProgresses));
		}
	}
}
