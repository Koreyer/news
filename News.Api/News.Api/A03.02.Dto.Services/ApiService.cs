using AutoMapper;
using News.Api.A01.Foundation.Data;
using News.Api.A01.Foundation.DataHelpers;
using News.Api.A02._02.News.ORM;
using News.Api.A02._03.News.Repositories;
using News.Api.A03._02.Dto.Services.Helpers;
using System.Linq.Expressions;

namespace News.Api.A03._02.Dto.Services
{
    public class ApiService<TEntity, TApiEntity> : IApiService<TEntity, TApiEntity>
        where TEntity : class, IData, new()
        where TApiEntity : class, IData, new()
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IMapperHelp<TEntity,TApiEntity> _mapper;
        public ApiService(IRepository<TEntity> repository, IMapperHelp<TEntity, TApiEntity> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }   
        public NewsContext Context { get=>_repository.Context; }
        public IRepository<TEntity> Repository { get => _repository; }
        public IMapperHelp<TEntity, TApiEntity> Mapper { get => _mapper; }


        public virtual async Task<Result> AddAsync(TApiEntity request, params Expression<Func<TEntity, object>>[] expressions)
        {
            var bo = await _mapper.MapToEntityAsync(request, expressions);
            return await _repository.AddAsync(bo);
        }

        public async Task<Result> DeleteByIdAsync(Guid id)=> await _repository.DeleteAsync(id);

        public async Task<ResultData<TApiEntity>> GetAllAsync()
        {
            var ddos = await _repository.GetAllAsync();
            var dtos =  _mapper.Mapper.Map<List<TApiEntity>>(ddos.Datas);
            return new ResultData<TApiEntity>()
            {
                Datas = dtos,
                TotalCount = ddos.TotalCount
            };
        }

        public async Task<ResultData<TApiEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var ddos = await _repository.GetAllAsync(predicate);
            var dtos =  _mapper.Mapper.Map<List<TApiEntity>>(ddos.Datas);
            return new ResultData<TApiEntity>()
            {
                Datas = dtos,
                TotalCount = ddos.TotalCount
            };
        }

        public async Task<TApiEntity> GetAsync(Guid id)=>  _mapper.Mapper.Map<TApiEntity>(await _repository.GetAsync(id));

        public async Task<TApiEntity> GetAsync(Expression<Func<TEntity, bool>> predicate) =>  _mapper.Mapper.Map<TApiEntity>(await _repository.GetAsync(predicate));

        public async Task<ResultData<TApiEntity>> GetBySelectAsync(int start, int length, Expression<Func<TEntity, bool>> predicate)
        {
            var ddos = await _repository.GetBySelectAsync(start, length, predicate);
            var dtos =  _mapper.Mapper.Map<List<TApiEntity>>(ddos.Datas);
            return new ResultData<TApiEntity>()
            {
                Datas = dtos,
                TotalCount = ddos.TotalCount
            };
        }

        public async Task<Result> UpdateAsync(TApiEntity request, params Expression<Func<TEntity, object>>[] expressions)
        {
            var bo = await _mapper.MapToEntityAsync(request,expressions);
            bo.Id = request.Id;
            return await _repository.UpdateAsync(bo);
        }

        public async Task<bool> HasAsync(Guid id)
        {
            return await _repository.HasAsync(id);
        }
    }
}
