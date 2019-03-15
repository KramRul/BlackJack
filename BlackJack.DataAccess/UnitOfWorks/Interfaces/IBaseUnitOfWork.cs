using BlackJack.DataAccess.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.UnitOfWorks.Interfaces
{
    public interface IBaseUnitOfWork
    {
        IPlayerRepository Players { get; }
        IGameRepository Games { get; }
        IBotRepository Bots { get; }
        IBotStepRepository BotSteps { get; }
        IPlayerStepRepository PlayerSteps { get; }
    }
}
