using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories.EntityFramework
{
    public class BaseRepository: IDisposable
    {
        public ApplicationContext dataBase;

        public BaseRepository(ApplicationContext context)
        {
            dataBase = context;
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
