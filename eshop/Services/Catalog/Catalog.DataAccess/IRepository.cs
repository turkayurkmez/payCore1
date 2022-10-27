using Catalog.Entities;

namespace Catalog.DataAccess
{
    public interface IRepository<T> where T : IEntity, new()
    {
        Task<IEnumerable<T>> GetAllAsync();

    }
}
