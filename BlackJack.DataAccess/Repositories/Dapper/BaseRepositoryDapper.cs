﻿using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories.Dapper
{
    public class BaseRepositoryDapper
    {
        private readonly IConfiguration _config;

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        public BaseRepositoryDapper(IConfiguration config)
        {
            _config = config;
        }

        public async Task<T> Get<T>(string id) where T : class
        {
            using (IDbConnection conn = Connection)
            {
                conn.Open();
                return await conn.GetAsync<T>(id);
            }
        }

        public async Task Create<T>(T element) where T : class
        {
            using (IDbConnection conn = Connection)
            {
                conn.Open();
                await conn.InsertAsync<T>(element);
            }
        }

        public async Task AddRange<T>(List<T> elements) where T : class
        {
            using (IDbConnection conn = Connection)
            {
                conn.Open();
                await conn.InsertAsync(elements);
            }
        }

        public async Task Update<T>(T element) where T : class
        {
            using (IDbConnection conn = Connection)
            {
                conn.Open();
                await conn.UpdateAsync<T>(element);
            }
        }

        public async Task Delete<T>(T element) where T : class
        {
            using (IDbConnection conn = Connection)
            {
                conn.Open();
                await conn.DeleteAsync<T>(element);
            }
        }
    }
}
