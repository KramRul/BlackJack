using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories
{
    public class GameRepository: IGameRepository
    {
        private ApplicationContext dataBase;

        public GameRepository(ApplicationContext context)
        {
            dataBase = context;
        }

        public async Task<List<Game>> GetAll()
        {
            var result = await dataBase.Games.Include(d => d.Player).ToListAsync();
            return result;
        }

        public async Task<List<Game>> GetGamesForPlayer(string playerId)
        {
            var result = await dataBase.Games
                .Include(d => d.Player)
                .Where(p=>p.Player.Id == playerId)
                .ToListAsync();
            return result;
        }

        public async Task<Game> GetActiveGameForPlayer(string playerId)
        {
            var result = await dataBase.Games
                .Include(d => d.Player)
                .Where(p => p.Player.Id == playerId)
                .Where(p => p.GameState==Enums.GameState.Unknown)
                .FirstOrDefaultAsync();
            return result;
        }

        public async Task<Game> GetLastActiveGameForPlayer(string playerId)
        {
            var result = await dataBase.Games
                .Include(d => d.Player)
                .Where(p => p.Player.Id == playerId)
                .LastOrDefaultAsync();
            return result;
        }

        public async Task<Game> Get(Guid gameid)
        {
            var result = await dataBase.Games
                .Include(p => p.Player)
                .Where(t => t.Id == gameid)
                .ToListAsync();
            return result.First();
        }

        public async Task Create(Game game)
        {
            await dataBase.Games.AddAsync(game);
        }

        public void Update(Game game)
        {
            dataBase.Entry(game).State = EntityState.Modified;
        }

        public async Task Delete(Guid id)
        {
            Game game = await dataBase.Games.FindAsync(id);
            if (game != null)
                dataBase.Games.Remove(game);
        }
    }
}
