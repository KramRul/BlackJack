using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> Get(Guid id);
        Task Create(T item);
        Task Create(List<T> items);
        Task Update(T item);
        Task Update(List<T> items);
        Task Delete(T id);
    }
}
