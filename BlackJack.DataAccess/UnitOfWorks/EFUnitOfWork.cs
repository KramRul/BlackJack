using BlackJack.DataAccess.Repositories.EntityFramework;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.DataAccess.UnitOfWorks.Interfaces;
using System;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.UnitOfWorks
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private ApplicationContext dataBase;
        private GameRepository gameRepository;
        private PlayerRepository playerRepository;
        private BotRepository botRepository;
        private PlayerStepRepository playerStepRepository;
        private BotStepRepository botStepRepository;

        public EFUnitOfWork(ApplicationContext context)
        {
            dataBase = context;
        }
        public IGameRepository Games
        {
            get
            {
                if (gameRepository == null)
                    gameRepository = new GameRepository(dataBase);
                return gameRepository;
            }
        }

        public IPlayerRepository Players
        {
            get
            {
                if (playerRepository == null)
                    playerRepository = new PlayerRepository(dataBase);
                return playerRepository;
            }
        }

        public IBotRepository Bots
        {
            get
            {
                if (botRepository == null)
                    botRepository = new BotRepository(dataBase);
                return botRepository;
            }
        }

        public IPlayerStepRepository PlayerSteps
        {
            get
            {
                if (playerStepRepository == null)
                    playerStepRepository = new PlayerStepRepository(dataBase);
                return playerStepRepository;
            }
        }

        public IBotStepRepository BotSteps
        {
            get
            {
                if (botStepRepository == null)
                    botStepRepository = new BotStepRepository(dataBase);
                return botStepRepository;
            }
        }

        public async Task Save()
        {
            await dataBase.SaveChangesAsync();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dataBase.Dispose();
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
