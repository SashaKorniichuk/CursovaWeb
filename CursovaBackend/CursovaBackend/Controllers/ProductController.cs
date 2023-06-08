using CursovaBackend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CursovaBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;

        public ProductController(ICartRepository cartRepository, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            return Ok(await _productRepository.GetProducts(cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCart(CancellationToken cancellationToken)
        {
            return Ok(await _cartRepository.CreateCart(cancellationToken));
        }

        [HttpPut("{cartId}/{productId}/{quantity}")]
        public async Task<IActionResult> UpdateCart(Guid cartId, Guid productId, uint quantity,CancellationToken cancellationToken)
        {
            return Ok(await _cartRepository.UpdateCart(cartId, productId, quantity,cancellationToken));
        }

        [HttpDelete("{cartId}")]
        public async Task<IActionResult> DeleteCart(Guid cartId, CancellationToken cancellationToken)
        {
            return Ok(await _cartRepository.DeleteCart(cartId, cancellationToken));
        }

        [HttpGet("{cartId}")]
        public async Task<IActionResult> GetCart(Guid cartId, CancellationToken cancellationToken)
        {
            return Ok(await _cartRepository.GetCart(cartId, cancellationToken));
        }

        [HttpDelete("{cartId}/{productId}")]
        public async Task<IActionResult> DeleteProductFromCart(Guid cartId, Guid productId, CancellationToken cancellationToken)
        {
            return Ok(await _cartRepository.DeleteProductFromCart(cartId, productId, cancellationToken));
        }
    }
}
