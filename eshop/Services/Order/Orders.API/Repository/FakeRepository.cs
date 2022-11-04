using Orders.API.Models;

namespace Orders.API.Repository
{
    public class FakeRepository
    {
        public Order GetOrder(int orderId)
        {
            return new Order { Id = 1, State = OrderStatus.Pending };
        }

        internal IEnumerable<Order> GetOrders()
        {
            var list = new List<Order>();
            list.Add(new Order { Id = 2, State = OrderStatus.Pending });
            list.Add(new Order { Id = 3, State = OrderStatus.Completed });

            return list;


        }
    }
}
