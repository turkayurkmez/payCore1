using Catalog.Application;
using Catalog.Entities;
using eshop.Messages;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IPublishEndpoint publishEndpoint;


        public ProductsController(IProductService productService, IPublishEndpoint publishEndpoint)
        {
            this.productService = productService;
            this.publishEndpoint = publishEndpoint;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await productService.GetProducts());
        }
        [HttpPut]
        public async Task<IActionResult> DiscountToProduct(Product product)
        {
            //db'de ürün güncellendikten sonra
            var oldPrice = 10; //fake (yani uydurduk :))
            var newPrice = product.Price;

            var productPriceChanged = new ProductPriceChanged { NewPrice = newPrice, OldPrice = oldPrice, ProductId = product.Id };
            await publishEndpoint.Publish(productPriceChanged);

            return Ok(product);

        }
    }
}
