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
    internal class MovieRepository : BaseRepository<Movie>
    {
        public MovieRepository(MainContext context) : base(context)
        {
        }
        public async override Task<IEnumerable<Movie>> GetWhere(Expression<Func<Movie, bool>> predicate)
        {
            return await this.Dbset.Include(x => x.Season).Where(predicate).ToListAsync().ConfigureAwait(false);
        }

        public async override Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await this.Dbset.Include(x => x.Season).ToListAsync().ConfigureAwait(false);
        }
    }
}
