using System;

namespace BlackJack.DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPlayerRepository Players { get; }
        void Save();
    }
}
