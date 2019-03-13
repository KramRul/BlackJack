using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories.Dapper
{
    public class PlayerRepositoryDapper : IPlayerRepository
    {
        private readonly ApplicationContext dataBase;
        private readonly IConfiguration _config;
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        public PlayerRepositoryDapper(ApplicationContext context, IConfiguration config)
        {
            dataBase = context;
            _config = config;
        }

        public async Task<List<Player>> GetAll()
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM AspNetUsers b";
                conn.Open();
                var result = await conn.QueryAsync<Player>(sQuery);
                return result.ToList();
            }
        }

        public async Task<Player> Get(Guid id)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT TOP(1) * " +
                    "FROM AspNetUsers e " +
                    "WHERE (e.Id = @id)";
                conn.Open();
                var result = await conn.QueryAsync<Player>(sQuery, new { id });
                return result.FirstOrDefault();
            }
        }

        public async Task<Player> GetByName(string name)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT TOP(1) * " +
                    "FROM AspNetUsers e " +
                    "WHERE (e.UserName = @name)";
                conn.Open();
                var result = await conn.QueryAsync<Player>(sQuery, new { name });
                return result.FirstOrDefault();
            }
        }

        public async Task Create(Player player)
        {
            var guid = Guid.NewGuid();
            using (IDbConnection conn = Connection)
            {
                string sQuery = "INSERT INTO AspNetUsers (Id, Balance, Bet) VALUES(@Id, @Balance, @Bet)";
                conn.Open();
                await conn.ExecuteAsync(sQuery, player);
            }
        }

        public async void Update(Player player)
        {
            using (IDbConnection conn = Connection)
            {
                var sQuery = "UPDATE AspNetUsers SET Balance = @Balance, Bet = @Bet WHERE Id = @Id";
                await conn.ExecuteAsync(sQuery, player);
            }
        }

        public async Task Delete(Guid id)
        {
            using (IDbConnection conn = Connection)
            {
                var sQuery = "DELETE FROM AspNetUsers WHERE Id = @id";
                await conn.ExecuteAsync(sQuery, new { id });
            }
        }
    }
}
