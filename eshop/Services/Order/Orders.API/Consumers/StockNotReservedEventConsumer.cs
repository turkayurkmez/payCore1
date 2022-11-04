using eshop.Messages;
using MassTransit;
using Orders.API.Models;

namespace Orders.API.Consumers
{
    public class StockNotReservedEventConsumer : IConsumer<StockNotReserved>
    {
        private readonly ILogger<StockNotReservedEventConsumer> _logger;

        public StockNotReservedEventConsumer(ILogger<StockNotReservedEventConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<StockNotReserved> context)
        {
            //burası db'ye gidecek!
            _logger.LogInformation($"{context.Message.OrderId} numaralı sipariş, başarısız oldu (stok rezerve edilemedi)");
            var existedOrder = new Order { Id = context.Message.OrderId };
            existedOrder.State = OrderStatus.Failed;

            return Task.CompletedTask;
        }
    }
}
