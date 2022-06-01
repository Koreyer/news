using Microsoft.AspNetCore.Mvc;
using News.Api.A01.Foundation.DataHelpers;
using News.Api.A02._01.News.Models;
using News.Api.A03._01.Dto.Models;
using News.Api.A03._02.Dto.Services;
using News.Api.B01.BaseController;

namespace News.Api.B02.Controllers
{
    [ApiController]
    [Route("Api/[controller]/[action]")]
    public class CollectionController:BaseController<Collection,CollectionDTO>
    {
        public CollectionController(IApiService<Collection, CollectionDTO> apiservice) : base(apiservice) { }

        /// <summary>
        /// 用户收藏新增
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        public override async Task<Result> AddAsync(CollectionDTO collection)
        {
            var col = await ApiService.GetAsync(x => x.Newsa.Id == Guid.Parse(collection.NewsaId) && x.AppUser.Id == Guid.Parse(collection.AppUserId));
            if (col == null)
            {
                var news = await ApiService.GetOtherAsync<Newsa, NewsaDTO>(Guid.Parse(collection.NewsaId));
                news.CollectionCount += 1;
                await ApiService.UpdateTOherAsync<Newsa, NewsaDTO>(news);
                return await ApiService.AddAsync(collection, x => x.AppUser, x => x.Newsa);
            }
            else
                return new Result();
        }
        /// <summary>
        /// 删除收藏
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Result> DeleteAsync(CollectionDTO collection)
        {
            var news = await ApiService.GetOtherAsync<Newsa, NewsaDTO>(Guid.Parse(collection.NewsaId));
            news.CollectionCount -= 1;
            await ApiService.UpdateTOherAsync<Newsa, NewsaDTO>(news);
            return await ApiService.DeleteByIdAsync(collection.Id);
        }
        /// <summary>
        /// 获取用户收藏数
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<int> CollectionCountByAppUserId(Guid appUserId) => await ApiService.CountAsync(x => x.AppUser.Id == appUserId);
        /// <summary>
        /// 获取用户收藏
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet]
        public  async Task<ResultData<CollectionDTO>> GetByAppUserIdAsync(Guid appUserId) =>await ApiService.GetAllAsync(x => x.AppUser.Id == appUserId);

    }
}
