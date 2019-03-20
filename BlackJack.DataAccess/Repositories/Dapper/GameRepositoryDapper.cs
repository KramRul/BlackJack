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
    public class GameRepositoryDapper : BaseRepositoryDapper<Game>, IGameRepository
    {
        public GameRepositoryDapper(IDbConnection connection) : base(connection)
        {
        }

        public new async Task<List<Game>> GetAll()
        {
            string sQuery = "SELECT * " +
                "FROM dbo.Games g " +
                "LEFT JOIN dbo.AspNetUsers aspUser ON g.PlayerId = aspUser.Id";
            var result = await _connection.QueryAsync<Game, Player, Game>(sQuery, (game, player) =>
            {
                game.Player = player; return game;
            });
            return result.ToList();
        }

        public async Task<List<Game>> GetAllByPlayerId(string playerId)
        {
            string sQuery = "SELECT DISTINCT g.Id, g.BotId, g.GameId, g.Rank, g.Suite, g.Bot.Id, g.Bot.Balance, g.Bot.Bet, g.Bot.Name " +
                "FROM Games g " +
                "INNER JOIN AspNetUsers aspPlayer ON g.PlayerId = aspPlayer.Id " +
                "WHERE g.PlayerId = @playerId";
            var result = await _connection.QueryAsync<Game, Player, Game>(sQuery, (game, player) =>
            {
                game.Player = player; return game;
            }, new { playerId });
            return result.ToList();

        }

        public async Task<Game> GetActiveByPlayerId(string playerId)
        {
            string sQuery = "SELECT TOP(1) * " +
                "FROM Games AS g " +
                "LEFT JOIN AspNetUsers aspPlayer ON g.PlayerId = aspPlayer.Id " +
                "WHERE (g.PlayerId = @playerId) AND (g.GameState = 0)";
            var result = await _connection.QueryAsync<Game, Player, Game>(sQuery, (game, player) =>
            {
                game.Player = player; return game;
            }, new { playerId });
            return result.FirstOrDefault();
        }

        public async Task<Game> GetLastActiveByPlayerId(string playerId)
        {
            string sQuery = "SELECT DISTINCT * " +
                "FROM Games AS g " +
                "LEFT JOIN AspNetUsers aspPlayer ON g.PlayerId = aspPlayer.Id " +
                "WHERE (g.PlayerId = @playerId)";
            var result = await _connection.QueryAsync<Game, Player, Game>(sQuery, (game, player) =>
            {
                game.Player = player; return game;
            }, new { playerId });
            return result.LastOrDefault();
        }

        public new async Task<Game> Get(Guid gameid)
        {
            string sQuery = "SELECT * " +
                "FROM Games AS g " +
                "LEFT JOIN AspNetUsers aspPlayer ON g.PlayerId = aspPlayer.Id " +
                "WHERE (g.Id = @gameid)";
            var result = await _connection.QueryAsync<Game, Player, Game>(sQuery, (game, player) =>
            {
                game.Player = player; return game;
            }, new { gameid });
            return result.FirstOrDefault();
        }
    }
}
