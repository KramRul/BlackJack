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
    public class BotStepRepositoryDapper : IBotStepRepository
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
        public BotStepRepositoryDapper(ApplicationContext context, IConfiguration config)
        {
            dataBase = context;
            _config = config;
        }

        public async Task<IEnumerable<BotStep>> GetAll()
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM BotSteps b";
                conn.Open();
                var result = await conn.QueryAsync<BotStep>(sQuery);
                return result;
            }
        }

        public async Task<List<Bot>> GetAllBotsByGameId(Guid gameId)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT DISTINCT bots.* " +
                    "FROM BotSteps b " +
                    "INNER JOIN Bots bots ON b.BotId = bots.Id " +
                    "WHERE b.GameId = @gameId ";
                conn.Open();
                var result = await conn.QueryMultipleAsync(sQuery, new { gameId });
                return result.Read<Bot>().ToList();
            }
        }

        public async Task<IEnumerable<BotStep>> GetAllStepsByGameId(Guid gameId)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT DISTINCT * " +
                    "FROM BotSteps b " +
                    "INNER JOIN Bots bots ON b.BotId = bots.Id " +
                    "WHERE b.GameId = @gameId";
                conn.Open();
                var result = await conn.QueryAsync<BotStep, Bot, BotStep>(sQuery, (step, bot) => { step.Bot = bot; return step; }, new { gameId });
                return result;
            }
        }

        public async Task<IEnumerable<BotStep>> GetAllStepsByBotId(Guid botId)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT DISTINCT * " +
                    "FROM BotSteps b " +
                    "INNER JOIN Bots bots ON b.BotId = bots.Id " +
                    "WHERE b.BotId = @botId";
                conn.Open();
                var result = await conn.QueryAsync<BotStep, Bot, BotStep>(sQuery, (step, bot) => { step.Bot = bot; return step; }, new { botId });
                return result;
            }
        }

        public async Task<BotStep> Get(Guid id)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * " +
                    "FROM BotSteps b " +
                    "WHERE b.BotId = @id";
                conn.Open();
                var result = await conn.QueryAsync<BotStep>(sQuery, new { id });
                return result.FirstOrDefault();
            }
        }

        public async Task Create(BotStep botStep)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "INSERT INTO BotSteps (Id, BotId, GameId, Rank, Suite) VALUES(@Id, @BotId, @GameId, @Rank, @Suite)";
                conn.Open();
                await conn.ExecuteAsync(sQuery, botStep);
            }
        }

        public async Task AddRange(List<BotStep> botSteps)
        {
            foreach (var step in botSteps)
                using (IDbConnection conn = Connection)
                {
                    string sQuery = "INSERT INTO BotSteps (Id, BotId, GameId, Rank, Suite) VALUES(@Id, @BotId, @GameId, @Rank, @Suite)";
                    conn.Open();
                    await conn.ExecuteAsync(sQuery, step);
                }
        }

        public async void Update(BotStep botStep)
        {
            using (IDbConnection conn = Connection)
            {
                var sQuery = "UPDATE BotSteps SET Rank = @Rank, Suite = @Suite WHERE Id = @Id";
                await conn.ExecuteAsync(sQuery, botStep);
            }
        }

        public async Task Delete(Guid id)
        {
            using (IDbConnection conn = Connection)
            {
                var sQuery = "DELETE FROM BotSteps WHERE Id = @id";
                await conn.ExecuteAsync(sQuery, new { id });
            }
        }
    }
}
