	using Deliveries.Domain;
	using FluentValidation;

	public class CreateDeliveryDtoValidator : AbstractValidator<CreateDeliveryDto>
	{
		public CreateDeliveryDtoValidator()
		{
			RuleFor(x => x.ClientName).NotEmpty().WithMessage("Le nom du client est requis.");
			RuleFor(x => x.Distance).GreaterThan(0).WithMessage("La distance doit être positive.");
			RuleFor(x => x.Poids).GreaterThan(0).WithMessage("Le poids doit être positif.");
		}
	}
namespace Deliveries.Application
{
	public class PricingService
	{
		private readonly double _prixDeBase;
		public PricingService(double prixDeBase = 10)
		{
			_prixDeBase = prixDeBase;
		}

		public double CalculerPrix(double distance, double poids)
		{
			return _prixDeBase + distance + poids;
		}
	}
}
