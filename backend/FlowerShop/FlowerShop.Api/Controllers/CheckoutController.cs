using FlowerShop.Application.DTOs;
using FlowerShop.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FlowerShop.Api.Controllers
{
    [Route("api/checkout")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly ICheckoutService _service;

        public CheckoutController(ICheckoutService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(CheckoutDto dto)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var orderId = await _service.Checkout(userId, dto.Address);

            return Ok(new { orderId });
        }
    }
}
