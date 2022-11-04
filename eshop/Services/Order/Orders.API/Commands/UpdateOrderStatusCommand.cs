using MediatR;
using Orders.API.Models;

namespace Orders.API.Commands
{
    public class UpdateOrderStatusCommand : IRequest<Order>
    {
        public int OrderId { get; set; }
        public OrderStatus OrderState { get; set; }

    }
}
