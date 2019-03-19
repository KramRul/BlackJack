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
    public class PlayerStepRepositoryDapper : BaseRepositoryDapper<PlayerStep>, IPlayerStepRepository
    {
        public PlayerStepRepositoryDapper(IDbConnection connection) : base(connection)
        {
        }

        public new async Task<List<PlayerStep>> GetAll()
        {
            string sQuery = "SELECT DISTINCT * " +
                "FROM PlayerSteps p " +
                "INNER JOIN Games games ON p.GameId = games.Id " +
                "LEFT JOIN AspNetUsers players ON p.PlayerId = players.Id";
            var result = await _connection.QueryAsync<PlayerStep, Game, Player, PlayerStep>(sQuery, (step, game, player) => { step.Player = player; step.Game = game; return step; });
            return result.ToList();
        }

        public async Task<List<PlayerStep>> GetAllStepsByPlayerIdAndGameId(string playerId, Guid gameId)
        {
            string sQuery = "SELECT DISTINCT * " +
                "FROM PlayerSteps p " +
                "INNER JOIN Games games ON p.GameId = games.Id " +
                "LEFT JOIN AspNetUsers players ON p.PlayerId = players.Id " +
                "WHERE (p.PlayerId = @playerId) AND (p.GameId = @gameId)";
            var result = await _connection.QueryAsync<PlayerStep, Game, Player, PlayerStep>(sQuery, (step, game, player) => { step.Player = player; step.Game = game; return step; }, new { playerId, gameId });
            return result.ToList();
        }

        public async Task<List<PlayerStep>> GetAllStepsByPlayerId(string playerId)
        {
            string sQuery = "SELECT DISTINCT * " +
                "FROM PlayerSteps p " +
                "LEFT JOIN AspNetUsers players ON p.PlayerId = players.Id " +
                "WHERE (p.PlayerId = @playerId)";
            var result = await _connection.QueryAsync<PlayerStep, Player, PlayerStep>(sQuery, (step, player) => { step.Player = player; return step; }, new { playerId });
            return result.ToList();
        }

        public new async Task<PlayerStep> Get(Guid id)
        {
            string sQuery = "SELECT * " +
                "FROM PlayerSteps p " +
                "LEFT JOIN AspNetUsers players ON p.PlayerId = players.Id " +
                "WHERE (p.Id = @id)";
            var result = await _connection.QueryAsync<PlayerStep, Player, PlayerStep>(sQuery, (step, player) => { step.Player = player; return step; }, new { id });
            return result.FirstOrDefault();
        }
    }
}
