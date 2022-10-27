using Catalog.Entities;

namespace Catalog.Application
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();
    }
}
