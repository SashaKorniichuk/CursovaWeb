using CursovaBackend.Entities;

namespace CursovaBackend.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts(CancellationToken cancellationToken);
        Task<Product?> GetProductById(Guid id, CancellationToken cancellationToken);
    }
}
