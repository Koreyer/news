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
        Task<Result> AddAsync(TApiEntity request, params Expression<Func<TEntity, object>>[] expressions);
        Task<Result> UpdateAsync(TApiEntity request, params Expression<Func<TEntity, object>>[] expressions);
        Task<Result> DeleteByIdAsync(Guid id);
        Task<TApiEntity> GetAsync(Guid id);
        Task<TApiEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<ResultData<TApiEntity>> GetAllAsync();
        Task<ResultData<TApiEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);
        Task<ResultData<TApiEntity>> GetBySelectAsync(int start, int length, Expression<Func<TEntity, bool>> predicate);
    }
}
