﻿using BlackJack.DataAccess.Entities;
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
        private ApplicationContext db;

        public GameRepository(ApplicationContext context)
        {
            this.db = context;
        }

        public async Task<IEnumerable<Game>> GetAll()
        {
            var result = await db.Games.Include(d => d.Player).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Game>> GetGamesForPlayer(string playerId)
        {
            var result = await db.Games.Include(d => d.Player).Where(p=>p.Player.Id == playerId).ToListAsync();
            return result;
        }

        public async Task<Game> Get(Guid gameid)
        {
            var result = await db.Games.Include(p => p.Player).Where(t => t.Id == gameid).ToListAsync();
            return result.First();
        }

        public async Task Create(Game game)
        {
            await db.Games.AddAsync(game);
        }

        public void Update(Game game)
        {
            db.Entry(game).State = EntityState.Modified;
        }

        public async Task Delete(Guid id)
        {
            Game game = await db.Games.FindAsync(id);
            if (game != null)
                db.Games.Remove(game);
        }
    }
}
