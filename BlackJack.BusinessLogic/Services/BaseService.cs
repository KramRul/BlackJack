using BlackJack.DataAccess.UnitOfWorks.Interfaces;

namespace BlackJack.BusinessLogic.Services
{
    public class BaseService
    {
        protected readonly IBaseUnitOfWork Database;

        public BaseService(IBaseUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }
    }
}
