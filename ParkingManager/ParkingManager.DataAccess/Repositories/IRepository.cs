using ParkingManager.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManager.DataAccess.Repositories
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
