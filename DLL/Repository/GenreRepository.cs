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
    public class GenreRepository : BaseRepository<Genre>
    {
        public GenreRepository(MainContext context) : base(context)
        {
        }
        public async override Task<IEnumerable<Genre>> GetWhere(Expression<Func<Genre, bool>> predicate)
        {
            return await this.Dbset.Include(x => x.Relationships).Where(predicate).ToListAsync().ConfigureAwait(false);
        }

        public async override Task<IEnumerable<Genre>> GetAllAsync()
        {
            return await this.Dbset.Include(x => x.Relationships).ToListAsync().ConfigureAwait(false);
        }
    }
}
