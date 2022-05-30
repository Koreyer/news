using AutoMapper;
using News.Api.A01.Foundation.Data;
using News.Api.A02._03.News.Repositories;
using System.Linq.Expressions;

namespace News.Api.A03._02.Dto.Services.Helpers
{
    public interface IMapperHelp<TEntity, TApiEntity>
        where TEntity : class, IData, new()
        where TApiEntity : class, IData, new()
    {
        public IRepository<TEntity> EntityRepository { get; }
        public IMapper Mapper { get; }
        Task<TEntity> MapToEntityAsync(TApiEntity apiBo, params Expression<Func<TEntity, object>>[] expressions);
        Task<TOther> MapToOtherEntityAsync<TOther, TApiOther>(TApiOther bo, params Expression<Func<TOther, object>>[] expressions)
            where TOther : class, IData, new()
            where TApiOther : class, IData, new();

    }
}
