using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using News.Api.A01.Foundation.DataHelpers;
using News.Api.A01.Foundation.Tools;
using News.Api.A02._01.News.Models;
using News.Api.A03._01.Dto.Models;
using News.Api.A03._02.Dto.Services;
using News.Api.A03._02.Dto.Services.Helpers;
using News.Api.B01.BaseController;

namespace News.Api.B02.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("Api/[controller]/[action]")]
    public class NewsController:BaseController<Newsa,NewsaDTO>
    {
        public NewsController(IApiService<Newsa, NewsaDTO> apiService) : base(apiService) { }

        //[Authorize(Roles = "发布社")]
        public override Task<Result> AddAsync(NewsaDTO apiEntity)
        {
            return ApiService.AddAsync(apiEntity,x=>x.AppUser, x => x.Chanel, x => x.Files);
        }
        /// <summary>
        /// 用户获取新闻
        /// </summary>
        /// <param name="selectParameter"></param>
        /// <returns></returns>
        public override async Task<ResultData<NewsaDTO>> GetBySelectAsync([FromBody] SelectParameter selectParameter)
        {
            if (!string.IsNullOrEmpty(selectParameter.SelectValue) && !string.IsNullOrEmpty(selectParameter.ChanelId))
            {
                return await ApiService.GetBySelectAsync(selectParameter.Start, selectParameter.Length, x => x.Name.Contains(selectParameter.SelectValue) && x.Chanel.Id == Guid.Parse(selectParameter.ChanelId));
            }else if (!string.IsNullOrEmpty(selectParameter.SelectValue))
            {
                return await ApiService.GetBySelectAsync(selectParameter.Start, selectParameter.Length, x => x.Name.Contains(selectParameter.SelectValue));
            }
            else if (!string.IsNullOrEmpty(selectParameter.ChanelId))
            {
                return await ApiService.GetBySelectAsync(selectParameter.Start, selectParameter.Length, x => x.Chanel.Id == Guid.Parse(selectParameter.ChanelId));
            }
            else
            {
                return await ApiService.GetBySelectAsync(selectParameter.Start, selectParameter.Length,null);
            }
        }
        /// <summary>
        /// 新闻访问
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<Result> AccessAsync(Guid id)
        {
            var news = await ApiService.GetAsync(id);
            news.AccessCount+=1;
            return await ApiService.UpdateAsync(news);
        }
        


    }
}
