using AutoMapper;
using News.Api.A01.Foundation.Data;
using News.Api.A01.Foundation.DataHelpers;
using News.Api.A02._02.News.ORM;
using News.Api.A02._03.News.Repositories;
using News.Api.A03._02.Dto.Services.Helpers;
using System.Linq.Expressions;

namespace News.Api.A03._02.Dto.Services
{
    public interface IApiService<TEntity, TApiEntity>
        where TEntity : class, IData , new()
        where TApiEntity : class,IData , new()
    {
        NewsContext Context { get; }
        IRepository<TEntity> Repository { get; }
        IMapperHelp<TEntity, TApiEntity> Mapper { get; }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="request"></param>
        /// <param name="expressions"></param>
        /// <returns></returns>
        Task<Result> AddAsync(TApiEntity request, params Expression<Func<TEntity, object>>[] expressions);
        Task<Result> AddTOherAsync<TOher, TApiOher>(TApiOher request, params Expression<Func<TOher, object>>[] expressions) where TOher : class, IData, new() where TApiOher : class, IData, new();
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="request"></param>
        /// <param name="expressions"></param>
        /// <returns></returns>
        Task<Result> UpdateAsync(TApiEntity request, params Expression<Func<TEntity, object>>[] expressions);
        Task<Result> UpdateTOherAsync<TOher,TApiOher>(TApiOher request, params Expression<Func<TOher, object>>[] expressions) where TOher:class,IData,new() where TApiOher : class, IData, new();
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> DeleteByIdAsync(Guid id);
        /// <summary>
        /// 根据id获取一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TApiEntity> GetAsync(Guid id);
        /// <summary>
        /// 根据条件获取一条数据
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<TApiEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TApiOther> GetOtherAsync<Other,TApiOther>(Guid id) where Other : class, IData, new() where TApiOther:class,IData,new() ;
        Task<ResultData<TApiOther>> GetAllOtherAsync<Other, TApiOther>(Expression<Func<Other, bool>> predicate) where Other : class, IData, new() where TApiOther : class, IData, new();
        /// <summary>
        /// 获取一组数据
        /// </summary>
        /// <returns></returns>
        Task<ResultData<TApiEntity>> GetAllAsync();
        /// <summary>
        /// 根据条件获取一组数据
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<ResultData<TApiEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// 根据查询条件获取一组数据
        /// </summary>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<ResultData<TApiEntity>> GetBySelectAsync(int start, int length, Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// 根据id查找是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> HasAsync(Guid id);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
        Task<int> CountAsync();
    }
}
