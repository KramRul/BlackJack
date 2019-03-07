using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories
{
    public class PlayerStepRepository: IPlayerStepRepository
    {
        private ApplicationContext dataBase;

        public PlayerStepRepository(ApplicationContext context)
        {
            dataBase = context;
        }

        public async Task<IEnumerable<PlayerStep>> GetAll()
        {            
            var result = await dataBase.PlayerSteps
                .Include(p => p.Player)
                .Include(g=>g.Game)
                .ToListAsync();
            return result;
        }

        public async Task<IEnumerable<PlayerStep>> GetAllStepsByPlayerIdAndGameId(string playerId, Guid gameId)
        {
            var result = await dataBase.PlayerSteps
                .Include(p => p.Player)
                .Where(p => p.PlayerId == playerId && p.GameId == gameId)
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
        }

        public async Task AddRange(List<PlayerStep> playerSteps)
        {
            await dataBase.PlayerSteps.AddRangeAsync(playerSteps);
        }

        public void Update(PlayerStep playerStep)
        {
            dataBase.Entry(playerStep).State = EntityState.Modified;
        }

        public async Task Delete(Guid id)
        {
            PlayerStep playerStep = await dataBase.PlayerSteps.FindAsync(id);
            if (playerStep != null)
                dataBase.PlayerSteps.Remove(playerStep);
        }
    }
}
