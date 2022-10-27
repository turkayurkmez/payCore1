using Catalog.Entities;

namespace Catalog.DataAccess
{
    public class FakeProductRepository : IProductRepository
    {
        private List<Product> products;
        public FakeProductRepository()
        {

            products = new List<Product>{
                new Product { Id = 1, Description = "Test.Desc", Name = "Test.Name", Price = 500 },
                new Product { Id = 2, Description = "Test2.Desc", Name = "Test2.Name", Price = 700 }
            };
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await Task.FromResult(products);

        }

        public IEnumerable<Product> SearchProductByName(string productName)
        {
            throw new NotImplementedException();
        }
    }
}
