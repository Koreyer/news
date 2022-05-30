using News.Api.A01.Foundation.Data;
using News.Api.A01.Foundation.DataHelpers;
using News.Api.A02._02.News.ORM;
using System.Linq.Expressions;

namespace News.Api.A02._03.News.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : class,IData,new()
    {
        NewsContext Context { get; }

        #region 1. 查询库存数量相关的方法
        /// <summary>
        /// 获取当前仓储（数据库）里面的领域泛型对象的总数
        /// </summary>
        /// <returns></returns>
        Task<int> CountAsync();
        /// <summary>
        /// 根据据查询条件，获取当前仓储（数据库）里面满足查询条件的领域泛型对象总数
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// 根据 Id 查找对应的领域泛型对象领域对象是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> HasAsync(Guid id);
        #endregion
        #region 2. 查询特定库存对象的方法
        /// <summary>
        /// 根据 Id 获取单个领域泛型对象的仓储数据
        /// </summary>
        /// <param name="id">待查询领域泛型对象的 Id</param>
        /// <returns></returns>
        Task<TEntity> GetAsync(Guid id);

        Task<Other> GetOtherAsync<Other>(Guid id)where Other:class,IData,new();
        Other GetOther<Other>(Guid id) where Other : class, IData, new();
        /// <summary>
        /// 根据查询条件，获取单个领域泛型对象的领域对象仓储数据
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
        //Task<TDdo> GetAsync(Expression<Func<TDdo, bool>> predicate, params Expression<Func<TDdo, object>>[] includeProperties);
        #endregion
        #region 3. 查询特定库存对象集合的方法
        /// <summary>
        /// 获取仓储中所有的领域泛型对象领域对象集合
        /// </summary>
        /// <returns></returns>
        Task<ResultData<TEntity>> GetAllAsync();
        //Task<List<TDdo>> GetAllAsync();
        /// <summary>
        /// 根据查询条件，获取仓储中满足条件的领域泛型对象领域对象集合
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<ResultData<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// 根据查询条件，获取仓储中满足条件，并且按照起始索引、数量返回的领域对象集合
        /// </summary>
        /// /// <param name="start">起始索引</param>
        /// <param name="length">数量</param>
        /// <param name="predicate">查询条件表达式</param>
        /// <returns></returns>
        Task<ResultData<TEntity>> GetBySelectAsync(int start,int length,Expression<Func<TEntity, bool>> predicate);
        #endregion
        #region 4. 入库的方法
        /// <summary>
        /// 入库：将传入的领域泛型对象领域对象添加到仓储中
        /// </summary>
        /// <param name="TEntity"></param>
        /// <returns></returns>
        Task<Result> AddAsync(TEntity ddo);
        Task<Result> AddTOherAsync<TOher>(TOher oher) where TOher : class, IData, new();
        #endregion
        #region 5. 更新库存对象的方法
        /// <summary>
        /// 更新（注意不是更换）：使用传入的领域泛型对象领域对象，更新仓储中已经存在的领域泛型对象领域对象的值
        /// </summary>
        /// <param name="TDdo"></param>
        /// <returns></returns>
        Task<Result> UpdateAsync(TEntity ddo);
        Task<Result> UpdateTOherAsync<TOher>(TOher oher) where TOher : class, IData, new();
        #endregion

        #region 6. 清除库存对象的方法
        /// <summary>
        /// 报废清除出库：根据领域泛型对象领域对象的特征值（这里是 Id），删除仓储中的领域泛型对象对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> DeleteAsync(Guid id);
        #endregion  

    }
}
