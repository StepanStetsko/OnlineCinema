using DLL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected MainContext mainContext;
        protected DbSet<TEntity> Dbset { get; set; }

        public BaseRepository(MainContext context)
        {
            this.mainContext = context;
            Dbset = mainContext.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return await Dbset.Where(predicate).ToListAsync().ConfigureAwait(false);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Dbset.ToListAsync().ConfigureAwait(false);
        }

        public virtual async Task Create(TEntity entity)
        {
            await Dbset.AddAsync(entity).ConfigureAwait(false);
            await mainContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task Delete(TEntity entity)
        {
            Dbset.Remove(entity);
            await mainContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task Update(TEntity entity)
        {
            mainContext.Entry(entity).State = EntityState.Modified;
            await mainContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
