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
    public class GameRepositoryDapper : BaseRepositoryDapper, IGameRepository
    {
        public GameRepositoryDapper(IConfiguration config) : base(config)
        {
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
            await Create<Game>(new Game()
            {
                Id = game.Id,
                GameState = game.GameState,
                WonName = game.WonName,
                PlayerId = game.PlayerId,
                Player = game.Player
            });
        }

        public async Task Update(Game game)
        {
            await Update<Game>(game);
        }

        public async Task Delete(Guid id)
        {
            await Delete<Game>(new Game() { Id = id });
        }
    }
}
