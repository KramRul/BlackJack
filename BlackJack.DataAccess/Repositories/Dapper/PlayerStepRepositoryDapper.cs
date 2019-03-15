using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories.Dapper
{
    public class PlayerStepRepositoryDapper : BaseRepositoryDapper<PlayerStep>, IPlayerStepRepository
    {
        public PlayerStepRepositoryDapper(IConfiguration config) : base(config)
        {
        }

        public async Task<List<PlayerStep>> GetAll()
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT DISTINCT * " +
                    "FROM PlayerSteps p " +
                    "INNER JOIN Games games ON p.GameId = games.Id " +
                    "LEFT JOIN AspNetUsers players ON p.PlayerId = players.Id";
                conn.Open();
                var result = await conn.QueryAsync<PlayerStep, Game, Player, PlayerStep>(sQuery, (step, game, player) => { step.Player = player; step.Game = game; return step; });
                return result.ToList();
            }
        }

        public async Task<List<PlayerStep>> GetAllStepsByPlayerIdAndGameId(string playerId, Guid gameId)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT DISTINCT * " +
                    "FROM PlayerSteps p " +
                    "INNER JOIN Games games ON p.GameId = games.Id " +
                    "LEFT JOIN AspNetUsers players ON p.PlayerId = players.Id " +
                    "WHERE (p.PlayerId = @playerId) AND (p.GameId = @gameId)";
                conn.Open();
                var result = await conn.QueryAsync<PlayerStep, Game, Player, PlayerStep>(sQuery, (step, game, player) => { step.Player = player; step.Game = game; return step; }, new { playerId, gameId });
                return result.ToList();
            }
        }

        public async Task<List<PlayerStep>> GetAllStepsByPlayerId(string playerId)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT DISTINCT * " +
                    "FROM PlayerSteps p " +
                    "LEFT JOIN AspNetUsers players ON p.PlayerId = players.Id " +
                    "WHERE (p.PlayerId = @playerId)";
                conn.Open();
                var result = await conn.QueryAsync<PlayerStep, Player, PlayerStep>(sQuery, (step, player) => { step.Player = player; return step; }, new { playerId });
                return result.ToList();
            }
        }

        public async Task<PlayerStep> Get(Guid id)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * " +
                    "FROM PlayerSteps p " +
                    "LEFT JOIN AspNetUsers players ON p.PlayerId = players.Id " +
                    "WHERE (p.Id = @id)";
                conn.Open();
                var result = await conn.QueryAsync<PlayerStep, Player, PlayerStep>(sQuery, (step, player) => { step.Player = player; return step; }, new { id });
                return result.FirstOrDefault();
            }
        }

        public async Task Delete(Guid id)
        {
            await Delete(new PlayerStep() { Id = id });
        }
    }
}
