using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;

        public Service(IRepository<TEntity> repository)
        {
            _repository = repository;
        }
        
         public async Task<Responses.Response<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
            Expression<Func<TEntity, TEntity>> select = null)
        {
            return new(await _repository.Get(filter, includes,select));
        }

        public async Task<Responses.Response<IEnumerable<TEntity>>> GetAll(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
            Expression<Func<TEntity, TEntity>> select = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null, int? take = null)
        {
            return new(await _repository.GetAll(filter,includes,select,orderBy,skip,take));
        }
        
        public async Task<Responses.Response<TEntity>> AddAsync(TEntity entity)
        {
            try
            {
                await _repository.AddAsync(entity);
                return new Responses.Response<TEntity>(entity);
            }
            catch (Exception e)
            {
                return new Responses.Response<TEntity>(e.Message);
            }
        }

        public async Task<Responses.Response<IEnumerable<TEntity>>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            try
            {
                var entityList = entities.ToList();
                await _repository.AddRangeAsync(entityList);
                return new Responses.Response<IEnumerable<TEntity>>(entityList);
            }
            catch (Exception e)
            {
                return new Responses.Response<IEnumerable<TEntity>>(e.Message);
            }
        }

        public void Remove(TEntity entity,bool isInclude=false)
        {
            _repository.Remove(entity);
        }
        
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _repository.RemoveRange(entities);
        }

        public Responses.Response<TEntity> Update(TEntity entity)
        {
            try
            {
                var updateEntity = _repository.Update(entity);
                return new Responses.Response<TEntity>(updateEntity);
            }
            catch (Exception e)
            {
                return new Responses.Response<TEntity>(e.Message);
            }
        }
        
    
    }
}