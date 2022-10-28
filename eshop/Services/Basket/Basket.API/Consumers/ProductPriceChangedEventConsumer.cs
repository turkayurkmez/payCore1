using eshop.Messages;
using MassTransit;

namespace Basket.API.Consumers
{
    public class ProductPriceChangedEventConsumer : IConsumer<ProductPriceChanged>
    {
        private readonly ILogger<ProductPriceChangedEventConsumer> _logger;

        public ProductPriceChangedEventConsumer(ILogger<ProductPriceChangedEventConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<ProductPriceChanged> context)
        {
            //ürün fiyatını; o ürünü sepete eklemiş olan müşterilerde güncelle....
            _logger.LogInformation($"Ürün fiyatı değişti! {context.Message.ProductId} id'li ürünün yeni fiyatı {context.Message.NewPrice} TL'dir ");
            return Task.CompletedTask;

        }
    }
}
