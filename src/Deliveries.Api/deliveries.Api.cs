using Deliveries.Domain;
using Deliveries.Application;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using System.Collections.Concurrent;

namespace Deliveries.Api
{
	[ApiController]
	[Route("api/deliveries")]
	public class DeliveriesController : ControllerBase
	{
		private static readonly ConcurrentDictionary<Guid, Delivery> _db = new();
		private readonly PricingService _pricingService = new();
		private readonly CreateDeliveryDtoValidator _validator = new();

		[HttpPost]
		public IActionResult Create([FromBody] CreateDeliveryDto dto)
		{
			var validation = _validator.Validate(dto);
			if (!validation.IsValid)
				return BadRequest(validation.Errors.Select(e => e.ErrorMessage));

			var delivery = new Delivery
			{
				Id = Guid.NewGuid(),
				ClientName = dto.ClientName,
				Distance = dto.Distance,
				Poids = dto.Poids,
				Prix = _pricingService.CalculerPrix(dto.Distance, dto.Poids),
				CreatedAt = DateTime.UtcNow
			};
			_db[delivery.Id] = delivery;
			return CreatedAtAction(nameof(GetById), new { id = delivery.Id }, delivery);
		}

		[HttpGet("{id}")]
		public IActionResult GetById(Guid id)
		{
			if (_db.TryGetValue(id, out var delivery))
				return Ok(delivery);
			return NotFound();
		}
	}
}
