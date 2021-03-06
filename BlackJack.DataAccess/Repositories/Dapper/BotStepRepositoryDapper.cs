﻿using BlackJack.DataAccess.Entities;
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

        public async Task<List<BotStep>> GetAllByGameId(Guid gameId)
        {
            string sQuery = @"SELECT DISTINCT * 
                FROM BotSteps b 
                INNER JOIN Bots bots ON b.BotId = bots.Id 
                WHERE b.GameId = @gameId";
            var result = await _connection.QueryAsync<BotStep, Bot, BotStep>(sQuery, (step, bot) =>
            {
                step.Bot = bot; return step;
            }, new { gameId });
            var steps = result.ToList();
            return steps;
        }

        public async Task<List<BotStep>> GetAllByBotId(Guid botId)
        {
            string sQuery = @"SELECT DISTINCT * 
                FROM BotSteps b 
                INNER JOIN Bots bots ON b.BotId = bots.Id 
                WHERE b.BotId = @botId";
            var result = await _connection.QueryAsync<BotStep, Bot, BotStep>(sQuery, (step, bot) =>
            {
                step.Bot = bot; return step;
            }, new { botId });
            var steps = result.ToList();
            return steps;
        }
    }
}
