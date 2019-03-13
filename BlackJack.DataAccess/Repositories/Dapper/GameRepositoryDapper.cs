using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Interfaces;
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
    public class GameRepositoryDapper : IGameRepository
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

        public GameRepositoryDapper(ApplicationContext context, IConfiguration config)
        {
            dataBase = context;
            _config = config;
        }

        public async Task<List<Game>> GetAll()
        {
            var guid = Guid.NewGuid();
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM dbo.Games g LEFT JOIN dbo.AspNetUsers aspUser ON g.PlayerId = aspUser.Id";
                var result = await conn.QueryAsync<Game, Player, Game>(sQuery, (game, player) => { game.Player = player; return game; });
                return result.ToList();
            }
        }

        public async Task<List<Game>> GetGamesForPlayer(string playerId)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT DISTINCT g.Id, g.BotId, g.GameId, g.Rank, g.Suite, g.Bot.Id, g.Bot.Balance, g.Bot.Bet, g.Bot.Name " +
                    "FROM Games g " +
                    "INNER JOIN AspNetUsers aspPlayer ON g.PlayerId = aspPlayer.Id " +
                    "WHERE g.PlayerId = @playerId";
                conn.Open();
                var result = await conn.QueryAsync<Game, Player, Game>(sQuery, (game, player) => { game.Player = player; return game; }, new { playerId });
                return result.ToList();
            }
        }

        public async Task<Game> GetActiveGameForPlayer(string playerId)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT TOP(1) * " +
                    "FROM Games AS g " +
                    "LEFT JOIN AspNetUsers aspPlayer ON g.PlayerId = aspPlayer.Id " +
                    "WHERE (g.PlayerId = @playerId) AND (g.GameState = 0)";
                conn.Open();
                var result = await conn.QueryAsync<Game, Player, Game>(sQuery, (game, player) => { game.Player = player; return game; }, new { playerId });
                return result.FirstOrDefault();
            }
        }

        public async Task<Game> GetLastActiveGameForPlayer(string playerId)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT DISTINCT * " +
                    "FROM Games AS g " +
                    "LEFT JOIN AspNetUsers aspPlayer ON g.PlayerId = aspPlayer.Id " +
                    "WHERE (g.PlayerId = @playerId)";
                conn.Open();
                var result = await conn.QueryAsync<Game, Player, Game>(sQuery, (game, player) => { game.Player = player; return game; }, new { playerId });
                return result.LastOrDefault();
            }
        }

        public async Task<Game> Get(Guid gameid)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * " +
                    "FROM Games AS g " +
                    "LEFT JOIN AspNetUsers aspPlayer ON g.PlayerId = aspPlayer.Id " +
                    "WHERE (g.Id = @gameid)";
                conn.Open();
                var result = await conn.QueryAsync<Game, Player, Game>(sQuery, (game, player) => { game.Player = player; return game; }, new { gameid });
                return result.FirstOrDefault();
            }
        }

        public async Task Create(Game game)
        {
            var guid = Guid.NewGuid();
            using (IDbConnection conn = Connection)
            {
                string sQuery = "INSERT INTO Games (Id, GameState, WonName, PlayerId) VALUES(@Id, @GameState, @WonName, @PlayerId)";
                conn.Open();
                await conn.ExecuteAsync(sQuery, game);
            }
        }

        public async void Update(Game game)
        {
            using (IDbConnection conn = Connection)
            {
                var sQuery = "UPDATE Games SET GameState = @GameState, WonName = @WonName, PlayerId = @PlayerId WHERE Id = @Id";
                await conn.ExecuteAsync(sQuery, game);
            }
        }

        public async Task Delete(Guid id)
        {
            using (IDbConnection conn = Connection)
            {
                var sQuery = "DELETE FROM Games WHERE Id = @id";
                await conn.ExecuteAsync(sQuery, new { id });
            }
        }
    }
}
