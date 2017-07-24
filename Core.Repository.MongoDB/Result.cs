using System.Collections.Generic;

namespace Core.Repository.MongoDB
{
    public class Result<TEntity>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int ErrorCode { get; set; }
        public TEntity Entity { get; set; }
        public Result()
        {
            Success = false;
            Message = "";
            ErrorCode = 500;
        }
    }

    public class GetOneResult<TEntity> : Result<TEntity> where TEntity : class, new()
    {
        public TEntity Entity { get; set; }
    }

    public class GetManyResult<TEntity> : Result<TEntity> where TEntity : class, new()
    {
        public IEnumerable<TEntity> Entities { get; set; }
    }

    public class GetListResult<TEntity> : Result<TEntity>
    {
        public List<TEntity> Entities { get; set; }
    }
}
