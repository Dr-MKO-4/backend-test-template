using Xunit;
using Deliveries.Application;

namespace Deliveries.Unit
{
    public class PricingServiceTests
    {
        [Theory]
        [InlineData(10, 5, 2, 17)]
        [InlineData(10, 0, 0, 10)]
        [InlineData(10, 100, 50, 160)]
        public void CalculerPrix_RetournePrixCorrect(double prixBase, double distance, double poids, double attendu)
        {
            var service = new PricingService(prixBase);
            var prix = service.CalculerPrix(distance, poids);
            Assert.Equal(attendu, prix);
        }
    }
}
