using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using News.Api.A01.Foundation.DataHelpers;
using News.Api.A02._01.News.Models;
using News.Api.A03._01.Dto.Models;
using News.Api.A03._02.Dto.Services;
using News.Api.B01.BaseController;

namespace News.Api.B02.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("Api/[controller]/[action]")]
    public class PraiseController : BaseController<Praise, PraiseDTO>
    {
        public PraiseController(IApiService<Praise, PraiseDTO> apiService) : base(apiService) { }


        /// <summary>
        /// 用户点赞新增
        /// </summary>
        /// <param name="praise"></param>
        /// <returns></returns>
        [HttpPost]
        public override async Task<Result> AddAsync(PraiseDTO praise)
        {
            var pra = await ApiService.GetAsync(x => x.Newsa.Id == Guid.Parse(praise.NewsaId) && x.AppUser.Id == Guid.Parse(praise.AppUserId));
            if (pra == null)
            {
                var news = await ApiService.GetOtherAsync<Newsa, NewsaDTO>(Guid.Parse(praise.NewsaId));
                news.CommentCount += 1;
                await ApiService.UpdateTOherAsync<Newsa, NewsaDTO>(news);
                return await ApiService.AddAsync(praise, x => x.AppUser, x => x.Newsa);
            }
            else
                return new Result();
        }
        /// <summary>
        /// 删除点赞
        /// </summary>
        /// <param name="praise"></param>
        /// <returns></returns>
        [HttpPost]
        public   async Task<Result> DeleteAsync(PraiseDTO praise)
        {
            var news = await ApiService.GetOtherAsync<Newsa, NewsaDTO>(Guid.Parse(praise.NewsaId));
            news.CommentCount -= 1;
            await ApiService.UpdateTOherAsync<Newsa, NewsaDTO>(news);
            return await ApiService.DeleteByIdAsync(praise.Id);
        }
        /// <summary>
        /// 获取用户点赞数
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<int> PraiseCountByAppUserId(Guid id) => await ApiService.CountAsync(x => x.AppUser.Id == id);

        /// <summary>
        /// 获取用户点赞
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ResultData<PraiseDTO>> GetByAppUserIdAsync(Guid appUserId) =>await ApiService.GetAllAsync(x => x.AppUser.Id == appUserId);
    }
}
