using BlackJack.DataAccess;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.DataAccess.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private ApplicationContext db;

        public PlayerRepository(ApplicationContext context)
        {
            this.db = context;
        }

        public IEnumerable<Player> GetAll()
        {
            return db.Users;
        }

        public Player Get(Guid id)
        {
            return db.Users.Find(id.ToString());
        }

        public void Create(Player player)
        {
            db.Users.Add(player);
        }

        public void Update(Player player)
        {
            db.Entry(player).State = EntityState.Modified;
        }

        public IEnumerable<Player> Find(Func<Player, Boolean> predicate)
        {
            return db.Users.Where(predicate).ToList();
        }

        public void Delete(Guid id)
        {
            Player player = db.Users.Find(id);
            if (player != null)
                db.Users.Remove(player);
        }
    }
}
