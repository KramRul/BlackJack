using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories.EntityFramework
{
    public class GameRepository: BaseRepository<Game>, IGameRepository
    {
        public GameRepository(ApplicationContext context) : base(context)
        {
        }

        public new async Task<List<Game>> GetAll()
        {
            var result = await dataBase.Games.Include(d => d.Player).ToListAsync();
            return result;
        }

        public async Task<List<Game>> GetAllByPlayerId(string playerId)
        {
            var result = await dataBase.Games
                .Include(d => d.Player)
                .Where(p=>p.Player.Id == playerId)
                .ToListAsync();
            return result;
        }

        public async Task<Game> GetActiveByPlayerId(string playerId)
        {
            var result = await dataBase.Games
                .Include(d => d.Player)
                .Where(p => p.Player.Id == playerId)
                .Where(p => p.GameState==Enums.GameStateType.Unknown)
                .FirstOrDefaultAsync();
            return result;
        }

        public async Task<Game> GetLastActiveByPlayerId(string playerId)
        {
            var result = await dataBase.Games
                .Include(d => d.Player)
                .Where(p => p.Player.Id == playerId)
                .LastOrDefaultAsync();
            return result;
        }

        public new async Task<Game> Get(Guid gameid)
        {
            var result = await dataBase.Games
                .Include(p => p.Player)
                .Where(t => t.Id == gameid)
                .ToListAsync();
            return result.First();
        }
    }
}
