using MediatR;
using Orders.API.Commands;
using Orders.API.Models;
using Orders.API.Repository;

namespace Orders.API.Handlers
{
    public class UpdateStatusToCompletedCommandHandler : IRequestHandler<UpdateOrderStatusCommand, Order>
    {
        FakeRepository fakeRepository = new FakeRepository();
        public UpdateStatusToCompletedCommandHandler()
        {

        }

        //public void Handle(UpdateOrderStatusCommand command)
        //{
        //    var order = fakeRepository.GetOrder(command.OrderId);

        //    order.State = Models.OrderStatus.Completed;

        //}

        public Task<Order> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
