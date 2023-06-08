using CursovaBackend.Entities;

namespace CursovaBackend.Repositories
{
    public interface ICartRepository
    {
        Task<Guid> CreateCart(CancellationToken cancellationToken);
        Task<Guid> UpdateCart(Guid cartId, Guid productId, uint quantity, CancellationToken cancellationToken);
        Task<Guid> DeleteCart(Guid cartId, CancellationToken cancellationToken);
        Task<Cart?> GetCart(Guid cartId, CancellationToken cancellationToken);
        Task<Guid> DeleteProductFromCart(Guid cartId, Guid productId, CancellationToken cancellationToken);
    }
}
