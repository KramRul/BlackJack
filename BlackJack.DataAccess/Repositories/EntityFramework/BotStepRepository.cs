﻿using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories.EntityFramework
{
    public class BotStepRepository : BaseRepository<BotStep>, IBotStepRepository
    {
        public BotStepRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<List<BotStep>> GetAllByGameId(Guid gameId)
        {
            var result = await dataBase.BotSteps
                .Include(b => b.Bot)
                .Where(b => b.GameId == gameId)
                .ToListAsync();
            return result;
        }

        public async Task<List<BotStep>> GetAllByBotId(Guid botId)
        {
            var result = await dataBase.BotSteps
                .Include(b => b.Bot)
                .Where(b => b.BotId == botId)
                .ToListAsync();
            return result;
        }
    }
}
