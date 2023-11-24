using Microsoft.AspNetCore.Mvc;
using TransportOrderService.Domain.Abstractions;
using TransportOrderService.Domain.Models;

namespace TransportOrderService.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TransportOrdersController : Controller
	{
		private readonly ITransportOrderService _transportOrderService;

		public TransportOrdersController(ITransportOrderService transportOrderService)
		{
			_transportOrderService = transportOrderService;
		}

		/// <summary>
		/// Fetches the current state of the Transport Order
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("{id}")]
		public IActionResult GetCurrentState(Guid id)
		{
			var progress = _transportOrderService.GetTransportOrderProgress(id);
			return Ok(progress);
		}
	}
}
