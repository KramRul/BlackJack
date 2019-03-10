using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Interfaces;
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
    public class BotRepositoryDapper: IBotRepository
    {
        private ApplicationContext dataBase;
        private readonly IConfiguration _config;
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        public BotRepositoryDapper(ApplicationContext context, IConfiguration config)
        {
            dataBase = context;
            _config = config;
        }

        public async Task<IEnumerable<Bot>> GetAll()
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM[Bots] AS[b]";//LEFT JOIN[AspNetUsers] AS[d.Player] ON[d].[PlayerId] = [d.Player].[Id]
                conn.Open();
                var result = await conn.QueryAsync<Bot>(sQuery);
                return result;
            }
        }

        public async Task<int> Count()
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT COUNT(*) FROM[Bots] AS[b]";
                conn.Open();
                var result = await conn.QueryAsync<int>(sQuery);
                return result.FirstOrDefault();
            }
        }

        public async Task<Bot> Get(Guid id)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM[Bots] AS[b] WHERE Id = @Id";
                conn.Open();
                var result = await conn.QueryAsync<Bot>(sQuery, new { Id = id });
                return result.FirstOrDefault();
            }
        }

        public async Task Create(Bot bot)
        {
            var guid = Guid.NewGuid();
            using (IDbConnection conn = Connection)
            {
                string sQuery = "INSERT INTO Bots (Id, Name, Balance, Bet) VALUES(@Id, @Name, @Balance, @Bet))";
                conn.Open();
                await conn.ExecuteAsync(sQuery, new { Id = guid, bot.Name, bot.Balance, bot.Bet });
            }
        }

        public async void Update(Bot bot)
        {
            using (IDbConnection conn = Connection)
            {
                var sQuery = "UPDATE Bots SET Name = @Name, Balance = @Balance, Bet = @Bet WHERE Id = @Id";
                await conn.ExecuteAsync(sQuery, bot);
            }
        }

        public async Task Delete(Guid id)
        {
            using (IDbConnection conn = Connection)
            {
                var sQuery = "DELETE FROM Bots WHERE Id = @id";
                await conn.ExecuteAsync(sQuery, new { id });
            }
        }
    }
}
