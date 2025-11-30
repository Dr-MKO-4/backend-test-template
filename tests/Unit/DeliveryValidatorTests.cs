using Xunit;
using Deliveries.Application;
using Deliveries.Domain;

namespace Deliveries.Unit
{
    public class DeliveryValidatorTests
    {
        private readonly CreateDeliveryDtoValidator _validator = new();

        [Fact]
        public void Valide_Payload_Valide()
        {
            var dto = new CreateDeliveryDto { ClientName = "Test", Distance = 10, Poids = 5 };
            var result = _validator.Validate(dto);
            Assert.True(result.IsValid);
        }

        [Theory]
        [InlineData(null, 10, 5)]
        [InlineData("", 10, 5)]
        [InlineData("Test", 0, 5)]
        [InlineData("Test", 10, 0)]
        public void Invalide_Payload(string client, double distance, double poids)
        {
            var dto = new CreateDeliveryDto { ClientName = client, Distance = distance, Poids = poids };
            var result = _validator.Validate(dto);
            Assert.False(result.IsValid);
        }
    }
}
