using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories.EntityFramework
{
    public class PlayerRepository : BaseRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(ApplicationContext context) : base(context)
        {
        }

        public new async Task<Player> Get(Guid id)
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

        public new async Task Create(Player player)
        {
            await dataBase.Users.AddAsync(player);
            await dataBase.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            Player player = await dataBase.Users.FindAsync(id.ToString());
            if (player != null)
                dataBase.Users.Remove(player);
            await dataBase.SaveChangesAsync();
        }
    }
}
