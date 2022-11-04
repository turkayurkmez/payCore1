using MassTransit;
using Orders.API.Consumers;

namespace Orders.API.Extensions
{
    public static class ConsumerExtension
    {
        public static void AddTotalConsumers(this IBusRegistrationConfigurator config)
        {
            config.AddConsumer<ProductPriceChangedEventConsumer>();
            config.AddConsumer<PaymentFailedEventConsumer>();
            config.AddConsumer<PaymentCompletedConsumer>();
            config.AddConsumer<StockNotReservedEventConsumer>();
        }
    }
}