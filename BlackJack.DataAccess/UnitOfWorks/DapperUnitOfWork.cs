using BlackJack.DataAccess.Config;
using BlackJack.DataAccess.Repositories.Dapper;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.DataAccess.UnitOfWorks.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BlackJack.DataAccess.UnitOfWorks
{
    public class DapperUnitOfWork : IDapperUnitOfWork
    {
        private GameRepositoryDapper gameRepository;
        private PlayerRepositoryDapper playerRepository;
        private BotRepositoryDapper botRepository;
        private PlayerStepRepositoryDapper playerStepRepository;
        private BotStepRepositoryDapper botStepRepository;
        private readonly IConfiguration _config;
        private IDbConnection _connection;

        public DapperUnitOfWork(IConfiguration config)
        {
            _config = config;
            _connection = new SqlConnection(_config.ConnectionString());
        }
        public IGameRepository Games
        {
            get
            {
                if (gameRepository == null)
                    gameRepository = new GameRepositoryDapper(_connection);
                return gameRepository;
            }
        }

        public IPlayerRepository Players
        {
            get
            {
                if (playerRepository == null)
                    playerRepository = new PlayerRepositoryDapper(_connection);
                return playerRepository;
            }
        }

        public IBotRepository Bots
        {
            get
            {
                if (botRepository == null)
                    botRepository = new BotRepositoryDapper(_connection);
                return botRepository;
            }
        }

        public IPlayerStepRepository PlayerSteps
        {
            get
            {
                if (playerStepRepository == null)
                    playerStepRepository = new PlayerStepRepositoryDapper(_connection);
                return playerStepRepository;
            }
        }

        public IBotStepRepository BotSteps
        {
            get
            {
                if (botStepRepository == null)
                    botStepRepository = new BotStepRepositoryDapper(_connection);
                return botStepRepository;
            }
        }

        private bool disposed = false;

        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _connection.Dispose();
                    _connection = null;
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
