using DLL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace DLL.Repository
{
    public class WatchListRepository : BaseRepository<WatchStatus>
    {
        public WatchListRepository(MainContext context) : base(context)
        {
        }

        public async override Task<IEnumerable<WatchStatus>> GetWhere(Expression<Func<WatchStatus, bool>> predicate)
        {
            return await this.Dbset.Include(x => x.User).Include(y => y.Season).Where(predicate).ToListAsync().ConfigureAwait(false);
        }

        public async override Task<IEnumerable<WatchStatus>> GetAllAsync()
        {
            return await this.Dbset.ToListAsync().ConfigureAwait(false);
        }
    }
}
