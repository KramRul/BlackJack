using BlackJack.DataAccess.Repositories.Dapper;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.DataAccess.UnitOfWorks.Interfaces;
using System;
using System.Data;

namespace BlackJack.DataAccess.UnitOfWorks
{
    public class DapperUnitOfWork : IDapperUnitOfWork
    {
        private GameRepositoryDapper _gameRepository;
        private PlayerRepositoryDapper _playerRepository;
        private BotRepositoryDapper _botRepository;
        private PlayerStepRepositoryDapper _playerStepRepository;
        private BotStepRepositoryDapper _botStepRepository;
        private IDbConnection _connection;

        public DapperUnitOfWork(IDbConnection connection)
        {
            _connection = connection;
        }
        public IGameRepository Games
        {
            get
            {
                if (_gameRepository == null)
                {
                    _gameRepository = new GameRepositoryDapper(_connection);
                }
                return _gameRepository;
            }
        }

        public IPlayerRepository Players
        {
            get
            {
                if (_playerRepository == null)
                {
                    _playerRepository = new PlayerRepositoryDapper(_connection);
                }
                return _playerRepository;
            }
        }

        public IBotRepository Bots
        {
            get
            {
                if (_botRepository == null)
                {
                    _botRepository = new BotRepositoryDapper(_connection);
                }
                return _botRepository;
            }
        }

        public IPlayerStepRepository PlayerSteps
        {
            get
            {
                if (_playerStepRepository == null)
                {
                    _playerStepRepository = new PlayerStepRepositoryDapper(_connection);
                }
                return _playerStepRepository;
            }
        }

        public IBotStepRepository BotSteps
        {
            get
            {
                if (_botStepRepository == null)
                {
                    _botStepRepository = new BotStepRepositoryDapper(_connection);
                }
                return _botStepRepository;
            }
        }

        private bool _disposed = false;

        public void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _connection.Close();
                    _connection.Dispose();
                    _connection = null;
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
