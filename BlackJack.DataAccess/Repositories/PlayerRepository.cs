using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly ApplicationContext _db;

        public PlayerRepository(ApplicationContext context)
        {
            _db = context;
        }

        public async Task<IEnumerable<Player>> GetAll()
        {
            var result = await _db.Users.ToListAsync();
            return result;
        }

        public async Task<Player> Get(Guid id)
        {
            var result = await _db.Users.FindAsync(id.ToString());
            return result;
        }

        public async Task<Player> GetByName(string name)
        {
            var result = await _db.Users.Where(x => x.UserName == name).FirstOrDefaultAsync();
            return result;
        }

        public async Task Create(Player player)
        {
            await _db.Users.AddAsync(player);
        }

        public void Update(Player player)
        {
            _db.Entry(player).State = EntityState.Modified;
        }

        public async Task Delete(Guid id)
        {
            Player player = await _db.Users.FindAsync(id.ToString());
            if (player != null)
                _db.Users.Remove(player);
        }
    }
}
