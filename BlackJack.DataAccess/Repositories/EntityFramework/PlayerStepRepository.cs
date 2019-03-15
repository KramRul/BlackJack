using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories.EntityFramework
{
    public class PlayerStepRepository: BaseRepository, IPlayerStepRepository
    {
        public PlayerStepRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<List<PlayerStep>> GetAll()
        {            
            var result = await dataBase.PlayerSteps
                .Include(p => p.Player)
                .Include(g=>g.Game)
                .ToListAsync();
            return result;
        }

        public async Task<List<PlayerStep>> GetAllStepsByPlayerIdAndGameId(string playerId, Guid gameId)
        {
            var result = await dataBase.PlayerSteps
                .Include(p => p.Player)
                .Where(p => p.PlayerId == playerId && p.GameId == gameId)
                .ToListAsync();
            return result;
        }

        public async Task<List<PlayerStep>> GetAllStepsByPlayerId(string playerId)
        {
            var result = await dataBase.PlayerSteps
                .Include(p => p.Player)
                .Where(p => p.PlayerId == playerId)
                .ToListAsync();
            return result;
        }

            public async Task<PlayerStep> Get(Guid id)
        {
            var result = await dataBase.PlayerSteps.FindAsync(id);
            return result;
        }

        public async Task Create(PlayerStep playerStep)
        {
            await dataBase.PlayerSteps.AddAsync(playerStep);
            await Save();
        }

        public async Task AddRange(List<PlayerStep> playerSteps)
        {
            await dataBase.PlayerSteps.AddRangeAsync(playerSteps);
            await Save();
        }

        public async Task Update(PlayerStep playerStep)
        {
            dataBase.Entry(playerStep).State = EntityState.Modified;
            await Save();
        }

        public async Task Delete(Guid id)
        {
            PlayerStep playerStep = await dataBase.PlayerSteps.FindAsync(id);
            if (playerStep != null)
                dataBase.PlayerSteps.Remove(playerStep);
            await Save();
        }
    }
}
