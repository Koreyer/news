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
            var news = await ApiService.GetOtherAsync<Newsa,NewsaDTO>(Guid.Parse(praise.NewsaId));
            news.CommentCount += 1;
            await ApiService.UpdateTOherAsync<Newsa, NewsaDTO>(news);
            return await ApiService.AddAsync(praise, x => x.User, x => x.Newsa);
        }

        [HttpPost]
        public   async Task<Result> DeleteAsync(PraiseDTO praise)
        {
            var news = await ApiService.GetOtherAsync<Newsa, NewsaDTO>(Guid.Parse(praise.NewsaId));
            news.CommentCount += 1;
            await ApiService.UpdateTOherAsync<Newsa, NewsaDTO>(news);
            return await ApiService.AddAsync(praise, x => x.User, x => x.Newsa);
        }
    }
}
