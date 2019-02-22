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
        private ApplicationContext db;

        public PlayerStepRepository(ApplicationContext context)
        {
            this.db = context;
        }

        public async Task<IEnumerable<PlayerStep>> GetAll()
        {            
            var result = await db.PlayerSteps.Include(p => p.Player).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<PlayerStep>> GetAllStepsByPlayerIdAndGameId(string playerId, Guid gameId)
        {
            var result = await db.PlayerSteps.Include(p => p.Player).Where(p => p.PlayerId == playerId && p.GameId == gameId).ToListAsync();
            return result;
        }

        public async Task<PlayerStep> Get(Guid id)
        {
            var result = await db.PlayerSteps.FindAsync(id);
            return result;
        }

        public async Task Create(PlayerStep playerStep)
        {
            await db.PlayerSteps.AddAsync(playerStep);
        }

        public void Update(PlayerStep playerStep)
        {
            db.Entry(playerStep).State = EntityState.Modified;
        }

        public async Task Delete(Guid id)
        {
            PlayerStep playerStep = await db.PlayerSteps.FindAsync(id);
            if (playerStep != null)
                db.PlayerSteps.Remove(playerStep);
        }
    }
}
