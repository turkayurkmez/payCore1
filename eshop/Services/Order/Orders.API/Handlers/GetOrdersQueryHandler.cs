using MediatR;
using Orders.API.Models;
using Orders.API.Queries;

namespace Orders.API.Handlers
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrders, IEnumerable<Order>>
    {


        //IEnumerable<Order> IQueryHandler<GetOrders>.Handle(GetOrders entity)
        //{

        //    return new FakeRepository().GetOrders();
        //}
        public async Task<IEnumerable<Order>> Handle(GetOrders request, CancellationToken cancellationToken)
        {
            // var orders = repo.Find(request.CustomerId);
            //return orders;

            return null;
        }
    }
}
