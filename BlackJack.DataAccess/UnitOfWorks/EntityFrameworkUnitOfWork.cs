using BlackJack.DataAccess.Repositories.EntityFramework;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.DataAccess.UnitOfWorks.Interfaces;
using System;

namespace BlackJack.DataAccess.UnitOfWorks
{
    public class EntityFrameworkUnitOfWork : IEntityFrameworkUnitOfWork
    {
        private ApplicationContext _dataBase;
        private GameRepository gameRepository;
        private PlayerRepository playerRepository;
        private BotRepository botRepository;
        private PlayerStepRepository playerStepRepository;
        private BotStepRepository botStepRepository;

        public EntityFrameworkUnitOfWork(ApplicationContext context)
        {
            _dataBase = context;
        }
        public IGameRepository Games
        {
            get
            {
                if (gameRepository == null)
                    gameRepository = new GameRepository(_dataBase);
                return gameRepository;
            }
        }

        public IPlayerRepository Players
        {
            get
            {
                if (playerRepository == null)
                    playerRepository = new PlayerRepository(_dataBase);
                return playerRepository;
            }
        }

        public IBotRepository Bots
        {
            get
            {
                if (botRepository == null)
                    botRepository = new BotRepository(_dataBase);
                return botRepository;
            }
        }

        public IPlayerStepRepository PlayerSteps
        {
            get
            {
                if (playerStepRepository == null)
                    playerStepRepository = new PlayerStepRepository(_dataBase);
                return playerStepRepository;
            }
        }

        public IBotStepRepository BotSteps
        {
            get
            {
                if (botStepRepository == null)
                    botStepRepository = new BotStepRepository(_dataBase);
                return botStepRepository;
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dataBase.Dispose();
                    _dataBase = null;
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
