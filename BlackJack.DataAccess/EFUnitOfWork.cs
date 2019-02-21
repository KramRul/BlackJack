using BlackJack.DataAccess.Interfaces;
using BlackJack.DataAccess.Repositories;
using System;
using System.Threading.Tasks;

namespace BlackJack.DataAccess
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private ApplicationContext db;
        private GameRepository gameRepository;
        private PlayerRepository playerRepository;
        private BotRepository botRepository;
        private PlayerStepRepository playerStepRepository;
        private BotStepRepository botStepRepository;

        public EFUnitOfWork(ApplicationContext context)
        {
            db = context;
        }
        public IGameRepository Games
        {
            get
            {
                if (gameRepository == null)
                    gameRepository = new GameRepository(db);
                return gameRepository;
            }
        }

        public IPlayerRepository Players
        {
            get
            {
                if (playerRepository == null)
                    playerRepository = new PlayerRepository(db);
                return playerRepository;
            }
        }

        public IBotRepository Bots
        {
            get
            {
                if (botRepository == null)
                    botRepository = new BotRepository(db);
                return botRepository;
            }
        }

        public IPlayerStepRepository PlayerSteps
        {
            get
            {
                if (playerStepRepository == null)
                    playerStepRepository = new PlayerStepRepository(db);
                return playerStepRepository;
            }
        }

        public IBotStepRepository BotSteps
        {
            get
            {
                if (botStepRepository == null)
                    botStepRepository = new BotStepRepository(db);
                return botStepRepository;
            }
        }

        public async Task Save()
        {
            await db.SaveChangesAsync();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
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
