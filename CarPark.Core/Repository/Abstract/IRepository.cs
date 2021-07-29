using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CarPark.Core.Models;

namespace CarPark.Core.Repository.Abstract
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        /// <summary>
        /// Get All Start
        /// </summary>
        /// <returns></returns>
        GetManyResult<TEntity> GetAll();
        Task<GetManyResult<TEntity>> GetAllAsync();
        /// <summary>
        /// Filter List Start
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        GetManyResult<TEntity> FilterBy(Expression<Func<TEntity, bool>> filter);
        Task<GetManyResult<TEntity>> FilterByAsync(Expression<Func<TEntity, bool>> filter);
        GetOneResult<TEntity> GetById(string id);
        Task<GetOneResult<TEntity>> GetByIdAsync(string id);
        /// <summary>
        /// Insert Start
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        GetOneResult<TEntity> InsertOne(TEntity entity);
        Task<GetOneResult<TEntity>> InsertOneAsync(TEntity entity);
        GetManyResult<TEntity> InsertMany(ICollection<TEntity> entities);
        Task<GetManyResult<TEntity>> InsertManyAsync(ICollection<TEntity> entities);
        /// <summary>
        /// Update Start
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        GetOneResult<TEntity> ReplaceOne(TEntity entity, string id);
        Task<GetOneResult<TEntity>> ReplaceOneAsync(TEntity entity, string id);
        /// <summary>
        /// Delete Start
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        GetOneResult<TEntity> DeleteOne(Expression<Func<TEntity, bool>> filter);
        Task<GetOneResult<TEntity>> DeleteOneAsync(Expression<Func<TEntity, bool>> filter);
        GetOneResult<TEntity> DeleteById(string id);
        Task<GetOneResult<TEntity>> DeleteByIdAsync(string id);
        void DeleteMany(Expression<Func<TEntity, bool>> filter);
        Task DeleteManyAsync(Expression<Func<TEntity, bool>> filter);

    }
}
