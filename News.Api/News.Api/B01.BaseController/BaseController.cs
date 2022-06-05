using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using News.Api.A01.Foundation.Data;
using News.Api.A01.Foundation.DataHelpers;
using News.Api.A01.Foundation.Tools;
using News.Api.A02._03.News.Repositories;
using News.Api.A03._02.Dto.Services;

namespace News.Api.B01.BaseController
{
    [AllowAnonymous]
    public class BaseController<TEntity,TApiEntity> : ControllerBase
        where TEntity : class,IData,new()
        where TApiEntity : class,IData, new()
    {
        private readonly IApiService<TEntity, TApiEntity> _apiService;
        private readonly IRepository<TEntity> _repository;
        protected IApiService<TEntity,TApiEntity> ApiService { get => _apiService; }
        protected IRepository<TEntity> Repository { get => _repository; }
        public BaseController(IApiService<TEntity,TApiEntity> apiService)
        {
            _apiService = apiService;
            _repository = apiService.Repository;
        }
        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public virtual async Task<ResultData<TApiEntity>> GetAsync()=>await _apiService.GetAllAsync();
        
        /// <summary>
        /// 根据Id进行查找数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual async Task<TApiEntity> GetByIdAsync(Guid id)=>await _apiService.GetAsync(id);
        
        /// <summary>
        /// 根据条件进行查询
        /// </summary>
        /// <param name="selectParameter"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public virtual async Task<ResultData<TApiEntity>> GetBySelectAsync([FromBody] SelectParameter selectParameter)
        {
            if(!string.IsNullOrEmpty(selectParameter.SelectValue))
            {
                return await _apiService.GetBySelectAsync(selectParameter.Start, selectParameter.Length, x => x.Name == selectParameter.SelectValue);
            }
            return await _apiService.GetBySelectAsync(selectParameter.Start, selectParameter.Length,null);
        }

        /// <summary>
        /// 通过id进行删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public virtual async Task<Result> DeleteByIdAsync(string id)
        {
            var deid = Guid.Empty;
            if(Guid.TryParse(id,out deid))
            {
                return await _apiService.DeleteByIdAsync(deid);
            }
            else
            {
                return new Result() { Message = "Id错误", ResultEnum = A01.Foundation.Enum.ResultEnum.操作失败, Status = 400 };
            }
        }

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="apiEntity"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<Result> AddAsync(TApiEntity apiEntity)=>await _apiService.AddAsync(apiEntity);
        
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="apiEntity"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<Result> UpdateAsync(TApiEntity apiEntity)=> await _apiService.UpdateAsync(apiEntity);



    }
}
