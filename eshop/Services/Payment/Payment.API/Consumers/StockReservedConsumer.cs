using eshop.Messages;
using MassTransit;

namespace Payment.API.Consumers
{
    public class StockReservedConsumer : IConsumer<StockReserved>
    {
        private readonly IPublishEndpoint publishEndpoint;

        public StockReservedConsumer(IPublishEndpoint publishEndpoint)
        {
            this.publishEndpoint = publishEndpoint;
        }

        public async Task Consume(ConsumeContext<StockReserved> context)
        {
            if (checkPayment())
            {
                await publishEndpoint.Publish(new PaymentCompleted { OrderId = context.Message.OrderId });
            }
            else
            {
                await publishEndpoint.Publish(new PaymentFailed { OrderId = context.Message.OrderId, Message = "CCV Hatalı" });
            }
        }

        private bool checkPayment()
        {
            return new Random().Next(1, 10) % 2 == 0;
        }
    }
}
