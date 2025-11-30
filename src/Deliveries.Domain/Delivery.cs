namespace Deliveries.Domain
{
    public class Delivery
    {
        public Guid Id { get; set; }
        public string ClientName { get; set; }
        public double Distance { get; set; }
        public double Poids { get; set; }
        public double Prix { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CreateDeliveryDto
    {
        public string ClientName { get; set; }
        public double Distance { get; set; }
        public double Poids { get; set; }
    }
}