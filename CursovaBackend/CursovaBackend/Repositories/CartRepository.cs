using CursovaBackend.Entities;
using Microsoft.EntityFrameworkCore;

namespace CursovaBackend.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly IProductRepository _productRepository;
        private readonly ApplicationDbContext _applicationDbContext;

        public CartRepository(IProductRepository productRepository, ApplicationDbContext context)
        {
            _productRepository = productRepository;
            _applicationDbContext = context;
        }
        public async Task<Guid> CreateCart(CancellationToken cancellationToken)
        {
            var cart = new Cart
            {
                TotalPrice = 0
            };
            await _applicationDbContext.Carts.AddAsync(cart, cancellationToken);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return cart.Id;
        }

        public async Task<Guid> DeleteCart(Guid cartId, CancellationToken cancellationToken)
        {
            var cart = await _applicationDbContext.Carts.FindAsync(cartId, cancellationToken);

            var productsCarts = _applicationDbContext.ProductsCarts.Where(x => x.CartId == cart!.Id);
            _applicationDbContext.ProductsCarts.RemoveRange(productsCarts);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return cart!.Id;
        }

        public async Task<Guid> DeleteProductFromCart(Guid cartId, Guid productId, CancellationToken cancellationToken)
        {
            var cartProduct = await _applicationDbContext.ProductsCarts.Where(x => x.CartId==cartId &&x.ProductId == productId).FirstOrDefaultAsync(cancellationToken);

            _applicationDbContext.Remove(cartProduct!);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return cartProduct.CartId;
        }

        public async Task<Cart?> GetCart(Guid cartId, CancellationToken cancellationToken)
        {
             var cart = await _applicationDbContext.Carts.Include(c => c.ProductCarts)
                .ThenInclude(cp => cp.Product)
                .FirstOrDefaultAsync(c => c.Id == cartId, cancellationToken);

             cart.TotalPrice = cart.ProductCarts.Select(x => x.Product.Price * x.Quantity).Sum();
             cart.TotalPrice = (float)System.Math.Round(cart.TotalPrice, 2);
             return cart;
        }

        public async Task<Guid> UpdateCart(Guid cartId, Guid productId, uint quantity, CancellationToken cancellationToken)
        {
            var cartProduct = await _applicationDbContext.ProductsCarts.Where(x => x.CartId==cartId &&x.ProductId == productId).FirstOrDefaultAsync(cancellationToken);
            if (cartProduct is null)
            {
                await _applicationDbContext.ProductsCarts.AddAsync(new ProductCart()
                { Id = Guid.NewGuid(), CartId = cartId, ProductId = productId, Quantity = quantity },cancellationToken);
            }
            else
            {
                cartProduct.Quantity = quantity;

                _applicationDbContext.ProductsCarts.Update(cartProduct);
            }
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return cartId;
        }
    }
}
