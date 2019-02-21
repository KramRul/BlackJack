using BlackJack.DataAccess.Interfaces;

namespace BlackJack.BusinessLogic.Services
{
    public class BaseService
    {
        protected readonly IUnitOfWork Database;

        public BaseService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
