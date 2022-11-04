using eshop.Messages;
using MassTransit;
using Orders.API.Models;

namespace Orders.API.Consumers
{
    public class PaymentFailedEventConsumer : IConsumer<PaymentFailed>
    {
        private readonly ILogger<PaymentFailedEventConsumer> _logger;

        public PaymentFailedEventConsumer(ILogger<PaymentFailedEventConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<PaymentFailed> context)
        {
            //burası db'ye gidecek!
            _logger.LogInformation($"{context.Message.OrderId} numaralı sipariş, başarısız oldu (ödeme alınamadı)");
            var existedOrder = new Order { Id = context.Message.OrderId };
            existedOrder.State = OrderStatus.Failed;

            return Task.CompletedTask;
        }
    }
}
