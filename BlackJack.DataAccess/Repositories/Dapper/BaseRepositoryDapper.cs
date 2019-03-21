using BlackJack.DataAccess.Repositories.Interfaces;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories.Dapper
{
    public class BaseRepositoryDapper<T> : IBaseRepository<T> where T : class
    {
        protected IDbConnection _connection;

        public BaseRepositoryDapper(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<T> Get(Guid id)
        {
            var result = await _connection.GetAsync<T>(id);
            return result;
        }

        public async Task Create(T element)
        {
            await _connection.InsertAsync(element);
        }

        public async Task AddRange(List<T> elements)
        {
            await _connection.InsertAsync(elements);
        }

        public async Task Update(T element)
        {
            await _connection.UpdateAsync<T>(element);
        }

        public async Task Update(List<T> elements)
        {
            await _connection.UpdateAsync(elements);
        }

        public async Task Delete(T element)
        {
            await _connection.DeleteAsync<T>(element);
        }

        public async Task<List<T>> GetAll()
        {
            var result = await _connection.GetAllAsync<T>();
            return result.ToList();
        }
    }
}
