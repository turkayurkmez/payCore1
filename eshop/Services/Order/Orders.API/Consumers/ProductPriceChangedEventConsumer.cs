using eshop.Messages;
using MassTransit;

namespace Orders.API.Consumers
{
    public class ProductPriceChangedEventConsumer : IConsumer<ProductPriceChanged>
    {
        private readonly ILogger<ProductPriceChangedEventConsumer> _logger;

        public ProductPriceChangedEventConsumer(ILogger<ProductPriceChangedEventConsumer> logger)
        {
            _logger = logger;
        }
        public ProductPriceChangedEventConsumer()
        {

        }
        public Task Consume(ConsumeContext<ProductPriceChanged> context)
        {
            //burası db'ye gidecek!
            _logger.LogInformation($"Dün aldığınız {context.Message.ProductId} id'li ürünün yeni fiyatı {context.Message.NewPrice} TL oldu.{context.Message.OldPrice - context.Message.NewPrice} TL Hesabınıza tanımlandı.... ");
            return Task.CompletedTask;
        }
    }
}
