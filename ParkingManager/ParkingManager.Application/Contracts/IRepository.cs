using ParkingManager.Domain.Entities;
using System.Collections.ObjectModel;
namespace ParkingManager.Application.Contracts
{
    public interface IRepository { }

    public interface IRepository<T> : IRepository where T : BaseEntity
    {
        public Task<ReadOnlyCollection<T>> Get();
        public Task<T?> Get(int id);
        public Task<ReadOnlyCollection<T>> Get(Func<T, bool> predicate);
        public Task Create(T entity);
        public Task Update(T entity);
        public Task Delete(int id);
    }
}
