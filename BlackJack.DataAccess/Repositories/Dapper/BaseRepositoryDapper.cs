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
            _connection.Open();
            var result = await _connection.GetAsync<T>(id);
            _connection.Close();
            return result;
        }

        public async Task Create(T element)
        {
            _connection.Open();
            await _connection.InsertAsync(element);
            _connection.Close();
        }

        public async Task AddRange(List<T> elements)
        {
            _connection.Open();
            await _connection.InsertAsync(elements);
            _connection.Close();
        }

        public async Task Update(T element)
        {

            _connection.Open();
            await _connection.UpdateAsync<T>(element);
            _connection.Close();
        }

        public async Task Delete(T element)
        {
            _connection.Open();
            await _connection.DeleteAsync<T>(element);
            _connection.Close();
        }

        public async Task<List<T>> GetAll()
        {
            _connection.Open();
            var result = await _connection.GetAllAsync<T>();
            _connection.Close();
            return result.ToList();
        }
    }
}
