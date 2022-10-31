using eshop.Messages;
using MassTransit;

namespace Stock.API.Consumers
{
    public class OrderCreatedConsumer : IConsumer<OrderCreated>
    {
        private readonly IPublishEndpoint _endpoint;

        public OrderCreatedConsumer(IPublishEndpoint endpoint)
        {
            _endpoint = endpoint;
        }

        public async Task Consume(ConsumeContext<OrderCreated> context)
        {
            if (stockIsAvailable(context.Message.OrderItems))
            {
                await _endpoint.Publish(new StockReserved
                {
                    CustomerId = context.Message.CustomerId,
                    OrderId = context.Message.OrderId,
                    TotalPrice = context.Message.TotalPrice,
                    OrderItemMessages = context.Message.OrderItems
                });
            }
            else
            {
                await _endpoint.Publish(new StockNotReserved
                {
                    CustomerId = context.Message.CustomerId,
                    OrderId = context.Message.OrderId,
                    Message = "Stokta ürün bulunamadı"
                });
            }
        }

        private bool stockIsAvailable(List<OrderItemMessage> orderItems)
        {
            return new Random().Next(0, 10) % 2 == 0;
        }
    }
}
