using CursovaBackend.Entities;
using Microsoft.EntityFrameworkCore;

namespace CursovaBackend.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product?> GetProductById(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IEnumerable<Product>> GetProducts(CancellationToken cancellationToken)
        {
            return await _context.Products.AsNoTracking().ToListAsync(cancellationToken);
        }
    }
}
