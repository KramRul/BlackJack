using BlackJack.DataAccess.Repositories.Interfaces;
using System;

namespace BlackJack.DataAccess.UnitOfWorks.Interfaces
{
    public interface IBaseUnitOfWork : IDisposable
    {
        IPlayerRepository Players { get; }
        IGameRepository Games { get; }
        IBotRepository Bots { get; }
        IBotStepRepository BotSteps { get; }
        IPlayerStepRepository PlayerSteps { get; }
    }
}
