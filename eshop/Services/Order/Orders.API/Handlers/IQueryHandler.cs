using Orders.API.Models;
using Orders.API.Queries;

namespace Orders.API.Handlers
{
    public interface IQueryHandler<T> where T : IQuery
    {
        IEnumerable<Order> Handle(T entity);
    }
}
