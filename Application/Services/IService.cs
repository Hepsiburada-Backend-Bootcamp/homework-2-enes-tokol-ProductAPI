using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.Services
{
    public interface IService<TEntity> where TEntity:class
    {
        Task<Responses.Response<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
            Expression<Func<TEntity, TEntity>> select = null);
        Task<Responses.Response<IEnumerable<TEntity>>> GetAll(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
            Expression<Func<TEntity, TEntity>> select = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null);
        Task<Responses.Response<TEntity>> AddAsync(TEntity entity);
        Task<Responses.Response<IEnumerable<TEntity>>> AddRangeAsync(IEnumerable<TEntity> entities);
        void Remove(TEntity entity,bool isInclude=false);
        void RemoveRange(IEnumerable<TEntity> entities);
        Responses.Response<TEntity> Update(TEntity entity);
    }
}