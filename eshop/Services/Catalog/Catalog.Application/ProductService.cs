using Catalog.DataAccess;
using Catalog.Entities;

namespace Catalog.Application
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await productRepository.GetAllAsync();
        }
    }
}
