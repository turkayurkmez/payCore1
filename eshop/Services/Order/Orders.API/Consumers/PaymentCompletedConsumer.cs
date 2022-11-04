using eshop.Messages;
using MassTransit;
using MediatR;
using Orders.API.Commands;
using Orders.API.Handlers;
using Orders.API.Models;

namespace Orders.API.Consumers
{
    public class PaymentCompletedConsumer : IConsumer<PaymentCompleted>
    {
        private readonly ILogger<PaymentCompletedConsumer> _logger;
        private readonly IMediator _mediator;

        public PaymentCompletedConsumer(ILogger<PaymentCompletedConsumer> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public Task Consume(ConsumeContext<PaymentCompleted> context)
        {
            //burası db'ye gidecek!
            _logger.LogInformation($"{context.Message.OrderId} numaralı sipariş, başarıyla tamamlandı");
            var existedOrder = new Order { Id = context.Message.OrderId };
            existedOrder.State = OrderStatus.Completed;

            UpdateStatusToCompletedCommandHandler completedCommandHandler = new UpdateStatusToCompletedCommandHandler();
            UpdateOrderStatusCommand command = new UpdateOrderStatusCommand { OrderId = 3, OrderState = OrderStatus.Completed };
            var order = _mediator.Send(command);

            return Task.CompletedTask;
        }
    }
}
