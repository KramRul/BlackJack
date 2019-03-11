using BlackJack.DataAccess.Interfaces;
using BlackJack.DataAccess.Repositories.Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace BlackJack.DataAccess
{
    public class DapperUnitOfWork : IUnitOfWork
    {
        private ApplicationContext dataBase;
        private GameRepositoryDapper gameRepository;
        private PlayerRepositoryDapper playerRepository;
        private BotRepositoryDapper botRepository;
        private PlayerStepRepositoryDapper playerStepRepository;
        private BotStepRepositoryDapper botStepRepository;
        private readonly IConfiguration _config;

        public DapperUnitOfWork(ApplicationContext context, IConfiguration config)
        {
            dataBase = context;
            _config = config;
        }
        public IGameRepository Games
        {
            get
            {
                if (gameRepository == null)
                    gameRepository = new GameRepositoryDapper(dataBase, _config);
                return gameRepository;
            }
        }

        public IPlayerRepository Players
        {
            get
            {
                if (playerRepository == null)
                    playerRepository = new PlayerRepositoryDapper(dataBase, _config);
                return playerRepository;
            }
        }

        public IBotRepository Bots
        {
            get
            {
                if (botRepository == null)
                    botRepository = new BotRepositoryDapper(dataBase, _config);
                return botRepository;
            }
        }

        public IPlayerStepRepository PlayerSteps
        {
            get
            {
                if (playerStepRepository == null)
                    playerStepRepository = new PlayerStepRepositoryDapper(dataBase, _config);
                return playerStepRepository;
            }
        }

        public IBotStepRepository BotSteps
        {
            get
            {
                if (botStepRepository == null)
                    botStepRepository = new BotStepRepositoryDapper(dataBase, _config);
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
