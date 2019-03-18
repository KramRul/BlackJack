using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using Dapper;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories.Dapper
{
    public class BotRepositoryDapper : BaseRepositoryDapper<Bot>, IBotRepository
    {
        public BotRepositoryDapper(IDbConnection connection) : base(connection)
        {
        }

        public async Task<int> Count()
        {
            string sQuery = "SELECT COUNT(*) FROM Bots b";
            _connection.Open();
            var result = await _connection.QueryAsync<int>(sQuery);          
            var count = result.FirstOrDefault();
            _connection.Close();
            return count;
        }
    }
}
