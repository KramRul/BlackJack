using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories.Dapper
{
    public class PlayerRepositoryDapper : BaseRepositoryDapper<Player>, IPlayerRepository
    {
        public PlayerRepositoryDapper(IDbConnection connection) : base(connection)
        {
        }

        public new async Task<List<Player>> GetAll()
        {
            string sQuery = "SELECT * FROM AspNetUsers b";
            var result = await _connection.QueryAsync<Player>(sQuery);
            return result.ToList();
        }

        public new async Task<Player> Get(Guid id)
        {
            string sQuery = "SELECT TOP(1) * " +
                "FROM AspNetUsers e " +
                "WHERE (e.Id = @id)";
            var result = await _connection.QueryAsync<Player>(sQuery, new { id });
            return result.FirstOrDefault();
        }

        public async Task<Player> GetByName(string name)
        {
            string sQuery = "SELECT TOP(1) * " +
                "FROM AspNetUsers e " +
                "WHERE (e.UserName = @name)";
            var result = await _connection.QueryAsync<Player>(sQuery, new { name });
            return result.FirstOrDefault();
        }
    }
}
