using Catalog.Entities;

namespace Catalog.DataAccess
{
    public interface IProductRepository : IRepository<Product>
    {
        public IEnumerable<Product> SearchProductByName(string productName);
    }
}
