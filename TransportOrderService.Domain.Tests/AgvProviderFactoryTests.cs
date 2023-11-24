using NUnit.Framework;
using TransportOrderService.Domain.Implementations;
using TransportOrderService.Domain.Models;

namespace TransportOrderService.Domain.Tests
{
	[TestFixture]
	public class AgvProviderFactoryTests
	{
		private static IEnumerable<(AgvProviderType providerType, Type expectedType)> GetTestCases()
		{
			yield return (AgvProviderType.KIONGroup, typeof(KIONGroupAgvProviderGateway));
			yield return (AgvProviderType.Daifuku, typeof(DaifukuAgvProviderGateway));
		}

		[TestCaseSource(nameof(GetTestCases))]
		public void GetProvider_WhenCalledWithAgvProviderType_ReturnsAgvProviderGateway((AgvProviderType providerType, Type expectedType) testCase)
		{
			// Arrange
			var factory = new AgvProviderFactory();

			// Act
			var result = factory.GetProvider(testCase.providerType);

			// Assert
			Assert.That(result.GetType(), Is.EqualTo(testCase.expectedType));
		}

		[TestCase(AgvProviderType.Unknown)]
		public void GetProvider_WhenCalledWithUnknownAgvProviderType_ThrowsArgumentOutOfRangeException(AgvProviderType providerType)
		{
			// Arrange
			var factory = new AgvProviderFactory();

			// Act
			// Assert
			Assert.Throws<ArgumentOutOfRangeException>(
				() => factory.GetProvider(AgvProviderType.Unknown), 
				$"Unsupported AGV provider: {providerType}");
		}
	}
}
