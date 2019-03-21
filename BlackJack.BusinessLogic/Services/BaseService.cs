using BlackJack.DataAccess.UnitOfWorks.Interfaces;
using System;

namespace BlackJack.BusinessLogic.Services
{
    public class BaseService
    {
        protected readonly IBaseUnitOfWork _database;
        protected readonly Random _random = new Random();

        public BaseService(IBaseUnitOfWork unitOfWork)
        {
            _database = unitOfWork;
        }
    }
}
