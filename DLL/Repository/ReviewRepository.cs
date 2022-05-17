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
    public class ReviewRepository : BaseRepository<Review>
    {
        public ReviewRepository(MainContext context) : base(context)
        {
        }

        public async override Task<IEnumerable<Review>> GetWhere(Expression<Func<Review, bool>> predicate)
        {
            return await this.Dbset.Include(x => x.Reviewer).Include(y => y.Reviewed).Where(predicate).ToListAsync().ConfigureAwait(false);
        }

        public async override Task<IEnumerable<Review>> GetAllAsync()
        {
            return await this.Dbset.Include(x => x.Reviewer).Include(y => y.Reviewed).ToListAsync().ConfigureAwait(false);
        }
    }
}
