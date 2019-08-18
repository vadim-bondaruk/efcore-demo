using AutoMapper;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Demo
{
    public interface IRepository<T> where T:class
    {
        Task<R> GetAsync<R>(Expression<Func<T, bool>> match, IConfigurationProvider configuration);
    }
}
