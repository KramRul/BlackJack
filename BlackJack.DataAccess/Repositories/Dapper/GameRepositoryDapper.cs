﻿using BlackJack.DataAccess.Entities;
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
            string sQuery = "SELECT * FROM dbo.Games g LEFT JOIN dbo.AspNetUsers aspUser ON g.PlayerId = aspUser.Id";
            var result = await _connection.QueryAsync<Game, Player, Game>(sQuery, (game, player) => { game.Player = player; return game; });
            _connection.Close();
            return result.ToList();
        }

        public async Task<List<Game>> GetGamesForPlayer(string playerId)
        {
            string sQuery = "SELECT DISTINCT g.Id, g.BotId, g.GameId, g.Rank, g.Suite, g.Bot.Id, g.Bot.Balance, g.Bot.Bet, g.Bot.Name " +
                "FROM Games g " +
                "INNER JOIN AspNetUsers aspPlayer ON g.PlayerId = aspPlayer.Id " +
                "WHERE g.PlayerId = @playerId";
            _connection.Open();
            var result = await _connection.QueryAsync<Game, Player, Game>(sQuery, (game, player) => { game.Player = player; return game; }, new { playerId });
            _connection.Close();
            return result.ToList();

        }

        public async Task<Game> GetActiveGameForPlayer(string playerId)
        {
            string sQuery = "SELECT TOP(1) * " +
                "FROM Games AS g " +
                "LEFT JOIN AspNetUsers aspPlayer ON g.PlayerId = aspPlayer.Id " +
                "WHERE (g.PlayerId = @playerId) AND (g.GameState = 0)";
            _connection.Open();
            var result = await _connection.QueryAsync<Game, Player, Game>(sQuery, (game, player) => { game.Player = player; return game; }, new { playerId });
            _connection.Close();
            return result.FirstOrDefault();
        }

        public async Task<Game> GetLastActiveGameForPlayer(string playerId)
        {
            string sQuery = "SELECT DISTINCT * " +
                "FROM Games AS g " +
                "LEFT JOIN AspNetUsers aspPlayer ON g.PlayerId = aspPlayer.Id " +
                "WHERE (g.PlayerId = @playerId)";
            _connection.Open();
            var result = await _connection.QueryAsync<Game, Player, Game>(sQuery, (game, player) => { game.Player = player; return game; }, new { playerId });
            _connection.Close();
            return result.LastOrDefault();
        }

        public new async Task<Game> Get(Guid gameid)
        {
            string sQuery = "SELECT * " +
                "FROM Games AS g " +
                "LEFT JOIN AspNetUsers aspPlayer ON g.PlayerId = aspPlayer.Id " +
                "WHERE (g.Id = @gameid)";
            _connection.Open();
            var result = await _connection.QueryAsync<Game, Player, Game>(sQuery, (game, player) => { game.Player = player; return game; }, new { gameid });
            _connection.Close();
            return result.FirstOrDefault();
        }
    }
}
