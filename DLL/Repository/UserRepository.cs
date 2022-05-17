using DLL.Context;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(MainContext context) : base(context)
        {
        }

        public async override Task<IEnumerable<User>> GetWhere(Expression<Func<User, bool>> predicate)
        {
            return await this.Dbset.Include(x => x.Reviews).Include(y => y.Favorite).Include(x => x.UserWatchList).ThenInclude(y => y.Season).Where(predicate).ToListAsync().ConfigureAwait(false);
        }

        public async override Task<IEnumerable<User>> GetAllAsync()
        {
            return await this.Dbset.ToListAsync().ConfigureAwait(false);
        }
    }
}
