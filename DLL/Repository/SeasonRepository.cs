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
    public class SeasonRepository : BaseRepository<Season>
    {
        public SeasonRepository(MainContext context) : base(context)
        {
        }

        public async override Task<IEnumerable<Season>> GetWhere(Expression<Func<Season, bool>> predicate)
        {
            return await this.Dbset.Include(x => x.Movies)
                .Include(x => x.Reviews)
                .Include(x => x.Genres)
                .Include(x => x.Cast).Where(predicate).ToListAsync().ConfigureAwait(false);
        }

        public async override Task<IEnumerable<Season>> GetAllAsync()
        {
            return await this.Dbset.Include(x => x.Movies)
                .Include(x => x.Reviews)
                .Include(x => x.Genres)
                .Include(x => x.Cast).ToListAsync().ConfigureAwait(false);
        }
    }
}
