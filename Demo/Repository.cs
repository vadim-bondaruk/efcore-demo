using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class Repository<T> : IRepository<T> where T:class
    {
        private readonly AppContext context;

        public Repository(AppContext context)
        {
            this.context = context;
        }
        public async Task<R> GetAsync<R>(Expression<Func<T, bool>> match, IConfigurationProvider configuration)
        {
            return await context.Set<T>().Where(match).ProjectTo<R>(configuration).FirstOrDefaultAsync();
        }
    }
}
