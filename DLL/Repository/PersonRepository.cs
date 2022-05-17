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
    public class PersonRepository : BaseRepository<Person>
    {
        public PersonRepository(MainContext context) : base(context)
        {
        }

        public async override Task<IEnumerable<Person>> GetWhere(Expression<Func<Person, bool>> predicate)
        {
            return await this.Dbset.Include(x => x.PersonInfo).Include(y => y.VideoCatalog).Where(predicate).ToListAsync().ConfigureAwait(false);
        }

        public async override Task<IEnumerable<Person>> GetAllAsync()
        {
            return await this.Dbset.Include(x => x.PersonInfo).Include(y => y.VideoCatalog).ToListAsync().ConfigureAwait(false);
        }
    }
}
