using FlowerShop.Application.DTOs;
using FlowerShop.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FlowerShop.Api.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _service;

        public CartController(ICartService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            return Ok(await _service.Get(userId));
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(AddCartDto dto)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            await _service.Add(userId, dto.ProductId, dto.Quantity);
            return Ok();
        }
    }
}
