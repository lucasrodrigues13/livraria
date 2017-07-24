using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repository.MongoDB
{
    public interface IMongoDbRepository
    {
        /// <summary>
        /// A generic GetOne method
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<GetOneResult<TEntity>> GetOne<TEntity>(string id) where TEntity : class, new();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="filter"></param>
        /// <returns></returns>
        GetOneResult<TEntity> GetOne<TEntity>(FilterDefinition<TEntity> filter) where TEntity : class, new();

        /// <summary>
        /// A generic GetOne method
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<GetOneResult<TEntity>> GetOneAsync<TEntity>(FilterDefinition<TEntity> filter) where TEntity : class, new();

        /// <summary>
        /// A generic get many method
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<GetManyResult<TEntity>> GetMany<TEntity>(IEnumerable<string> ids) where TEntity : class, new();

        GetManyResult<TEntity> GetMany<TEntity>(FilterDefinition<TEntity> filter) where TEntity : class, new();

        /// <summary>
        /// A generic get many method with filter
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<GetManyResult<TEntity>> GetManyAsync<TEntity>(FilterDefinition<TEntity> filter) where TEntity : class, new();

        /// <summary>
        /// GetMany with filter and projection
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="filter"></param>
        /// <returns>A cursor for the query</returns>
        IFindFluent<TEntity, TEntity> FindCursor<TEntity>(FilterDefinition<TEntity> filter) where TEntity : class, new();

        /// <summary>
        /// A generic get all method
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        GetManyResult<TEntity> GetAll<TEntity>() where TEntity : class, new();

        /// <summary>
        /// A generic Exists method
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<bool> Exists<TEntity>(string id) where TEntity : class, new();

        /// <summary>
        /// A generic count method
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<long> Count<TEntity>(string id) where TEntity : class, new();

        /// <summary>
        /// A generic count method
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<long> Count<TEntity>(FilterDefinition<TEntity> filter) where TEntity : class, new();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        Result<TEntity> AddOne<TEntity>(TEntity item) where TEntity : class, new();
        /// <summary>
        /// A generic Add One method
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<Result<TEntity>> AddOneAsync<TEntity>(TEntity item) where TEntity : class, new();

        /// <summary>
        /// A generic delete one method
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<TEntity>> DeleteOne<TEntity>(string id) where TEntity : class, new();

        /// <summary>
        /// A generic delete many method
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<Result<TEntity>> DeleteMany<TEntity>(IEnumerable<string> ids) where TEntity : class, new();
        
        #region Update
        /// <summary>
        /// UpdateOne by id
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="id"></param>
        /// <param name="update"></param>
        /// <returns></returns>
        Result<TEntity> UpdateOne<TEntity>(string id, UpdateDefinition<TEntity> update) where TEntity : class, new();
        /// <summary>
        /// UpdateOne with filter
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="filter"></param>
        /// <param name="update"></param>
        /// <returns></returns>
        Result<TEntity> UpdateOne<TEntity>(FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> update) where TEntity : class, new();

        /// <summary>
        /// UpdateOne by id
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="id"></param>
        /// <param name="update"></param>
        /// <returns></returns>
        Task<Result<TEntity>> UpdateOneAsync<TEntity>(string id, UpdateDefinition<TEntity> update) where TEntity : class, new();

        /// <summary>
        /// UpdateOne with filter
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="filter"></param>
        /// <param name="update"></param>
        /// <returns></returns>
        Task<Result<TEntity>> UpdateOneAsync<TEntity>(FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> update) where TEntity : class, new();

        /// <summary>
        /// UpdateMany with Ids
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="id"></param>
        /// <param name="update"></param>
        /// <returns></returns>
        Task<Result<TEntity>> UpdateMany<TEntity>(IEnumerable<string> ids, UpdateDefinition<TEntity> update) where TEntity : class, new();

        /// <summary>
        /// UpdateMany with filter
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="filter"></param>
        /// <param name="update"></param>
        /// <returns></returns>
        Task<Result<TEntity>> UpdateMany<TEntity>(FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> update) where TEntity : class, new();
        #endregion Update

        #region Find And Update

        /// <summary>
        /// GetAndUpdateOne with filter
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="filter"></param>
        /// <param name="update"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        Task<GetOneResult<TEntity>> GetAndUpdateOne<TEntity>(FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> update, FindOneAndUpdateOptions<TEntity, TEntity> options) where TEntity : class, new();

        #endregion Find And Update
    }
}
