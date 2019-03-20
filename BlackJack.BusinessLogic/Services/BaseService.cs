using BlackJack.DataAccess.UnitOfWorks.Interfaces;

namespace BlackJack.BusinessLogic.Services
{
    public class BaseService
    {
        protected readonly IBaseUnitOfWork _database;

        public BaseService(IBaseUnitOfWork unitOfWork)
        {
            _database = unitOfWork;
        }
    }
}
