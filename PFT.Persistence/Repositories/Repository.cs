using Microsoft.EntityFrameworkCore;
using PFT.Application.Contracts.Persistence;
using PFT.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFT.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly PFTDatabaseContext _pFTDatabaseContext;
        protected readonly DbSet<T> _dbSet;
        public Repository(PFTDatabaseContext pFTDatabaseContext )
        {
            _pFTDatabaseContext = pFTDatabaseContext;
            _dbSet = pFTDatabaseContext.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _pFTDatabaseContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _pFTDatabaseContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _pFTDatabaseContext.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            return entity != null;
        }
    }
}
