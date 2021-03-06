﻿using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories.EntityFramework
{
    public class PlayerStepRepository : BaseRepository<PlayerStep>, IPlayerStepRepository
    {
        public PlayerStepRepository(ApplicationContext context) : base(context)
        {
        }

        public new async Task<List<PlayerStep>> GetAll()
        {
            var result = await dataBase.PlayerSteps
                .Include(p => p.Player)
                .Include(g => g.Game)
                .ToListAsync();
            return result;
        }

        public async Task<List<PlayerStep>> GetAllByPlayerIdAndGameId(string playerId, Guid gameId)
        {
            var result = await dataBase.PlayerSteps
                .Include(p => p.Player)
                .Where(p => p.PlayerId == playerId && p.GameId == gameId)
                .ToListAsync();
            return result;
        }

        public async Task<List<PlayerStep>> GetAllByPlayerId(string playerId)
        {
            var result = await dataBase.PlayerSteps
                .Include(p => p.Player)
                .Where(p => p.PlayerId == playerId)
                .ToListAsync();
            return result;
        }
    }
}
