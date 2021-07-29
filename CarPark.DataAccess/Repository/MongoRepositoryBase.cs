using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CarPark.Core.Models;
using CarPark.Core.Repository.Abstract;
using CarPark.Core.Settings;
using CarPark.DataAccess.Context;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CarPark.DataAccess.Repository
{
    public class MongoRepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private readonly MongoDbContext _context;
        private readonly IMongoCollection<TEntity> _collection;

        public MongoRepositoryBase(IOptions<MongoSettings> settings)
        {
            _context = new MongoDbContext(settings);
            _collection = _context.GetCollection<TEntity>();
        }
        /// <summary>
        /// Get All
        /// </summary>
        /// <returns></returns>
        public GetManyResult<TEntity> GetAll()
        {
            var result = new GetManyResult<TEntity>();
            try
            {
                var data = _collection.AsQueryable().ToList();
                if (data != null)
                {
                    result.Result = data;
                }

            }
            catch (Exception e)
            {
                result.Message = $"AsQuarable {e.Message}";
                result.Success = false;
                result.Result = null;
            }


            return result;
        }

        /// <summary>
        /// Get All Async
        /// </summary>
        /// <returns></returns>
        public async Task<GetManyResult<TEntity>> GetAllAsync()
        {
            var result = new GetManyResult<TEntity>();
            try
            {
                var data = await _collection.AsQueryable().ToListAsync();
                if (data != null)
                {
                    result.Result = data;
                }
            }
            catch (Exception e)
            {
                result.Message = $"AsQurableAsync {e.Message}";
                result.Success = false;
                result.Result = null;
            }
            return result;
        }

        /// <summary>
        /// Get All By Filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public GetManyResult<TEntity> FilterBy(Expression<Func<TEntity, bool>> filter)
        {
            var result = new GetManyResult<TEntity>();
            try
            {
                var data = _collection.Find(filter).ToList();
                if (data != null)
                {
                    result.Result = data;
                }

            }
            catch (Exception e)
            {
                result.Message = $"FilterBy {e.Message}";
                result.Success = false;
                result.Result = null;
            }


            return result;
        }
        /// <summary>
        /// Get All By Filter Async
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<GetManyResult<TEntity>> FilterByAsync(Expression<Func<TEntity, bool>> filter)
        {
            var result = new GetManyResult<TEntity>();
            try
            {
                var data = await _collection.Find(filter).ToListAsync();
                if (data != null)
                {
                    result.Result = data;
                }

            }
            catch (Exception e)
            {
                result.Message = $"FilterBy {e.Message}";
                result.Success = false;
                result.Result = null;
            }


            return result;
        }

        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GetOneResult<TEntity> GetById(string id)
        {
            var result = new GetOneResult<TEntity>();
            try
            {
                var objectId = ObjectId.Parse(id);
                var filter = Builders<TEntity>.Filter.Eq("_id", objectId);
                var data = _collection.Find(filter).FirstOrDefault();
                if (data != null)
                    result.Entity = data;
            }
            catch (Exception e)
            {
                result.Message = $"FilterBy {e.Message}";
                result.Success = false;
                result.Entity = null;
            }


            return result;
        }

        /// <summary>
        /// Get By Id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GetOneResult<TEntity>> GetByIdAsync(string id)
        {
            var result = new GetOneResult<TEntity>();
            try
            {
                var objectId = ObjectId.Parse(id);
                var filter = Builders<TEntity>.Filter.Eq("_id", objectId);
                var data = await _collection.Find(filter).FirstOrDefaultAsync();
                if (data != null)
                    result.Entity = data;
            }
            catch (Exception e)
            {
                result.Message = $"FilterBy {e.Message}";
                result.Success = false;
                result.Entity = null;
            }


            return result;
        }

        /// <summary>
        /// Insert One
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public GetOneResult<TEntity> InsertOne(TEntity entity)
        {
            var result = new GetOneResult<TEntity>();
            try
            {
                _collection.InsertOne(entity);
                result.Entity = entity;
            }
            catch (Exception e)
            {
                result.Message = $"InsertOne {e.Message}";
                result.Success = false;
                result.Entity = null;
            }


            return result;
        }

        /// <summary>
        /// Insert One Async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<GetOneResult<TEntity>> InsertOneAsync(TEntity entity)
        {
            var result = new GetOneResult<TEntity>();
            try
            {
                _collection.InsertOneAsync(entity);
                result.Entity = entity;
            }
            catch (Exception e)
            {
                result.Message = $"InsertOneAsync {e.Message}";
                result.Success = false;
                result.Entity = null;
            }


            return result;
        }

        /// <summary>
        /// Insert Many
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public GetManyResult<TEntity> InsertMany(ICollection<TEntity> entities)
        {
            var result = new GetManyResult<TEntity>();
            try
            {
                _collection.InsertMany(entities);
                result.Result = entities;
            }
            catch (Exception e)
            {
                result.Message = $"InsertMany {e.Message}";
                result.Success = false;
                result.Result = null;
            }


            return result;
        }
        /// <summary>
        /// Insert Many Async
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task<GetManyResult<TEntity>> InsertManyAsync(ICollection<TEntity> entities)
        {
            var result = new GetManyResult<TEntity>();
            try
            {
                _collection.InsertManyAsync(entities);
                result.Result = entities;
            }
            catch (Exception e)
            {
                result.Message = $"InsertManyAsync {e.Message}";
                result.Success = false;
                result.Result = null;
            }


            return result;
        }

        /// <summary>
        /// Replace One
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public GetOneResult<TEntity> ReplaceOne(TEntity entity, string id)
        {
            var result = new GetOneResult<TEntity>();
            try
            {
                var objectId = ObjectId.Parse(id);
                var filter = Builders<TEntity>.Filter.Eq("_id", objectId);
                var updatedDocument = _collection.ReplaceOne(filter, entity);
                result.Entity = entity;
            }
            catch (Exception e)
            {
                result.Message = $"ReplaceOne {e.Message}";
                result.Success = false;
                result.Entity = null;
            }


            return result;
        }
        /// <summary>
        /// Replace One Async
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GetOneResult<TEntity>> ReplaceOneAsync(TEntity entity, string id)
        {
            var result = new GetOneResult<TEntity>();
            try
            {
                var objectId = ObjectId.Parse(id);
                var filter = Builders<TEntity>.Filter.Eq("_id", objectId);
                var updatedDocument = _collection.ReplaceOneAsync(filter, entity);
                result.Entity = entity;
            }
            catch (Exception e)
            {
                result.Message = $"ReplaceOne {e.Message}";
                result.Success = false;
                result.Entity = null;
            }


            return result;
        }
        /// <summary>
        /// Delete One
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public GetOneResult<TEntity> DeleteOne(Expression<Func<TEntity, bool>> filter)
        {
            var result = new GetOneResult<TEntity>();
            try
            {
                var deletedDocument = _collection.FindOneAndDelete(filter);
                result.Entity = deletedDocument;
            }
            catch (Exception e)
            {
                result.Message = $"DeleteOne {e.Message}";
                result.Success = false;
                result.Entity = null;
            }


            return result;
        }
        /// <summary>
        /// Delete One Async
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<GetOneResult<TEntity>> DeleteOneAsync(Expression<Func<TEntity, bool>> filter)
        {
            var result = new GetOneResult<TEntity>();
            try
            {
                var deletedDocument = await _collection.FindOneAndDeleteAsync(filter);
                result.Entity = deletedDocument;

            }
            catch (Exception e)
            {
                result.Message = $"DeleteOneAsync {e.Message}";
                result.Success = false;
                result.Entity = null;
            }


            return result;
        }
        /// <summary>
        /// Delete By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GetOneResult<TEntity> DeleteById(string id)
        {
            var result = new GetOneResult<TEntity>();
            try
            {
                var objectId = ObjectId.Parse(id);
                var filter = Builders<TEntity>.Filter.Eq("_id", objectId);
                var data = _collection.FindOneAndDelete(filter);
                if (data != null)
                    result.Entity = data;
            }
            catch (Exception e)
            {
                result.Message = $"DeleteById {e.Message}";
                result.Success = false;
                result.Entity = null;
            }


            return result;
        }

        /// <summary>
        /// Delete By Id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GetOneResult<TEntity>> DeleteByIdAsync(string id)
        {
            var result = new GetOneResult<TEntity>();
            try
            {
                var objectId = ObjectId.Parse(id);
                var filter = Builders<TEntity>.Filter.Eq("_id", objectId);
                var data = await _collection.FindOneAndDeleteAsync(filter);
                if (data != null)
                    result.Entity = data;
            }
            catch (Exception e)
            {
                result.Message = $"DeleteById {e.Message}";
                result.Success = false;
                result.Entity = null;
            }


            return result;
        }

        /// <summary>
        /// Delete Many
        /// </summary>
        /// <param name="filter"></param>
        public void DeleteMany(Expression<Func<TEntity, bool>> filter)
        {
            _collection.DeleteMany(filter);

        }

        /// <summary>
        /// Delete Many Async
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task DeleteManyAsync(Expression<Func<TEntity, bool>> filter)
        {
            await _collection.DeleteManyAsync(filter);

        }
    }
}
