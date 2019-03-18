using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories.Dapper
{
    public class BotStepRepositoryDapper : BaseRepositoryDapper<BotStep>, IBotStepRepository
    {
        public BotStepRepositoryDapper(IDbConnection connection) : base(connection)
        {
        }

        public async Task<List<Bot>> GetAllBotsByGameId(Guid gameId)
        {
            string sQuery = "SELECT DISTINCT bots.* " +
                "FROM BotSteps b " +
                "INNER JOIN Bots bots ON b.BotId = bots.Id " +
                "WHERE b.GameId = @gameId ";
            _connection.Open();
            var result = await _connection.QueryMultipleAsync(sQuery, new { gameId });           
            var bots = result.Read<Bot>().ToList();
            _connection.Close();
            return bots;
        }

        public async Task<List<BotStep>> GetAllStepsByGameId(Guid gameId)
        {
            string sQuery = "SELECT DISTINCT * " +
                "FROM BotSteps b " +
                "INNER JOIN Bots bots ON b.BotId = bots.Id " +
                "WHERE b.GameId = @gameId";
            _connection.Open();
            var result = await _connection.QueryAsync<BotStep, Bot, BotStep>(sQuery, (step, bot) => { step.Bot = bot; return step; }, new { gameId });           
            var steps = result.ToList();
            _connection.Close();
            return steps;
        }

        public async Task<List<BotStep>> GetAllStepsByBotId(Guid botId)
        {
            string sQuery = "SELECT DISTINCT * " +
                "FROM BotSteps b " +
                "INNER JOIN Bots bots ON b.BotId = bots.Id " +
                "WHERE b.BotId = @botId";
            _connection.Open();
            var result = await _connection.QueryAsync<BotStep, Bot, BotStep>(sQuery, (step, bot) => { step.Bot = bot; return step; }, new { botId });
            var steps = result.ToList();
            _connection.Close();
            return steps;
        }
    }
}
