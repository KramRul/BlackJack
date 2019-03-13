using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories.Dapper
{
    public class PlayerStepRepositoryDapper : IPlayerStepRepository
    {
        private ApplicationContext dataBase;
        private readonly IConfiguration _config;
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        public PlayerStepRepositoryDapper(ApplicationContext context, IConfiguration config)
        {
            dataBase = context;
            _config = config;
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

        public async Task Create(PlayerStep playerStep)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "INSERT INTO PlayerSteps (Id, GameId, PlayerId, Rank, Suite) VALUES(@Id, @GameId, @PlayerId, @Rank, @Suite)";
                conn.Open();
                await conn.ExecuteAsync(sQuery, playerStep);
            }
        }

        public async Task AddRange(List<PlayerStep> playerSteps)
        {
            foreach (var step in playerSteps)
                using (IDbConnection conn = Connection)
                {
                    string sQuery = "INSERT INTO PlayerSteps (Id, GameId, PlayerId, Rank, Suite) VALUES(@Id, @GameId, @PlayerId, @Rank, @Suite)";
                    conn.Open();
                    await conn.ExecuteAsync(sQuery, step);
                }
        }
        public async void Update(PlayerStep playerStep)
        {
            using (IDbConnection conn = Connection)
            {
                var sQuery = "UPDATE PlayerSteps SET Rank = @Rank, Suite = @Suite WHERE Id = @Id";
                await conn.ExecuteAsync(sQuery, playerStep);
            }
        }

        public async Task Delete(Guid id)
        {
            using (IDbConnection conn = Connection)
            {
                var sQuery = "DELETE FROM PlayerSteps WHERE Id = @id";
                await conn.ExecuteAsync(sQuery, new { id });
            }
        }
    }
}
