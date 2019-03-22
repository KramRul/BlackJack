using BlackJack.DataAccess.Repositories.EntityFramework;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.DataAccess.UnitOfWorks.Interfaces;
using System;

namespace BlackJack.DataAccess.UnitOfWorks
{
    public class EntityFrameworkUnitOfWork : IEntityFrameworkUnitOfWork
    {
        private ApplicationContext _dataBase;
        private GameRepository _gameRepository;
        private PlayerRepository _playerRepository;
        private BotRepository _botRepository;
        private PlayerStepRepository _playerStepRepository;
        private BotStepRepository _botStepRepository;

        public EntityFrameworkUnitOfWork(ApplicationContext context)
        {
            _dataBase = context;
        }
        public IGameRepository Games
        {
            get
            {
                if (_gameRepository == null)
                {
                    _gameRepository = new GameRepository(_dataBase);
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
                    _playerRepository = new PlayerRepository(_dataBase);
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
                    _botRepository = new BotRepository(_dataBase);
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
                    _playerStepRepository = new PlayerStepRepository(_dataBase);
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
                    _botStepRepository = new BotStepRepository(_dataBase);
                }
                return _botStepRepository;
            }
        }

        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dataBase.Dispose();
                    _dataBase = null;
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
