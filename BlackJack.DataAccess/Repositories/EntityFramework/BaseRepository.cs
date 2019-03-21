using BlackJack.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories.EntityFramework
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected ApplicationContext dataBase;
        private DbSet<T> _dbSet;

        public BaseRepository(ApplicationContext context)
        {
            dataBase = context;
            _dbSet = context.Set<T>();
        }

        public async Task<List<T>> GetAll()
        {
            var result = await _dbSet.ToListAsync();
            return result;
        }

        public async Task<T> Get(Guid id)
        {
            var result = await _dbSet.FindAsync(id);
            return result;
        }

        public async Task Create(T item)
        {
            await _dbSet.AddAsync(item);
            await Save();
        }

        public async Task Create(List<T> items)
        {
            await _dbSet.AddRangeAsync(items);
            await Save();
        }

        public async Task Update(T item)
        {
            dataBase.Entry(item).State = EntityState.Modified;
            await Save();
        }

        public async Task Update(List<T> items)
        {
            _dbSet.UpdateRange(items);
            await Save();
        }

        public async Task Delete(T item)
        {
            _dbSet.Remove(item);
            await Save();
        }

        public async Task Save()
        {
            await dataBase.SaveChangesAsync();
        }
    }
}
