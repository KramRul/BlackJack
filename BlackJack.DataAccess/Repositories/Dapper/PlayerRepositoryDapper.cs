using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories.Dapper
{
    public class PlayerRepositoryDapper : IPlayerRepository
    {
        private readonly ApplicationContext dataBase;

        public PlayerRepositoryDapper(ApplicationContext context)
        {
            dataBase = context;
        }

        public async Task<IEnumerable<Player>> GetAll()
        {
            var result = await dataBase.Users.ToListAsync();
            return result;
        }

        public async Task<Player> Get(Guid id)
        {
            var result = await dataBase.Users.FindAsync(id.ToString());
            return result;
        }

        public async Task<Player> GetByName(string name)
        {
            var result = await dataBase.Users
                .Where(x => x.UserName == name)
                .FirstOrDefaultAsync();
            return result;
        }

        public async Task Create(Player player)
        {
            await dataBase.Users.AddAsync(player);
        }

        public void Update(Player player)
        {
            dataBase.Entry(player).State = EntityState.Modified;
        }

        public async Task Delete(Guid id)
        {
            Player player = await dataBase.Users.FindAsync(id.ToString());
            if (player != null)
                dataBase.Users.Remove(player);
        }
    }
}
