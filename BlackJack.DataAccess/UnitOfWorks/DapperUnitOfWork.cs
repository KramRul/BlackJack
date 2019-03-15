using BlackJack.DataAccess.Repositories.Dapper;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.DataAccess.UnitOfWorks.Interfaces;
using Microsoft.Extensions.Configuration;

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

        public DapperUnitOfWork(IConfiguration config)
        {
            _config = config;
        }
        public IGameRepository Games
        {
            get
            {
                if (gameRepository == null)
                    gameRepository = new GameRepositoryDapper(_config);
                return gameRepository;
            }
        }

        public IPlayerRepository Players
        {
            get
            {
                if (playerRepository == null)
                    playerRepository = new PlayerRepositoryDapper(_config);
                return playerRepository;
            }
        }

        public IBotRepository Bots
        {
            get
            {
                if (botRepository == null)
                    botRepository = new BotRepositoryDapper(_config);
                return botRepository;
            }
        }

        public IPlayerStepRepository PlayerSteps
        {
            get
            {
                if (playerStepRepository == null)
                    playerStepRepository = new PlayerStepRepositoryDapper(_config);
                return playerStepRepository;
            }
        }

        public IBotStepRepository BotSteps
        {
            get
            {
                if (botStepRepository == null)
                    botStepRepository = new BotStepRepositoryDapper(_config);
                return botStepRepository;
            }
        }
    }
}
