using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using News.Api.A01.Foundation.DataHelpers;
using News.Api.A01.Foundation.Tools;
using News.Api.A02._01.News.Models;
using News.Api.A02._03.News.Repositories.Helpers;
using News.Api.A03._01.Dto.Models;
using News.Api.A03._02.Dto.Services;
using News.Api.B01.BaseController;

namespace News.Api.B02.Controllers
{
    /// <summary>
    /// 评论
    /// </summary>
    [ApiController]
    [Route("Api/[controller]/[action]")]
    public class CommentController : BaseController<Comment, CommentDTO>
    {

        public CommentController(IApiService<Comment, CommentDTO> apiService) : base(apiService) {}

        public override async Task<Result> AddAsync(CommentDTO apiEntity)
        {
            return await ApiService.AddAsync(apiEntity,x=>x.AppUser, x => x.Newsa);
        }

        [HttpGet]
        public  async Task<List<CommentResult>> GetComment([FromBody] SelectParameter selectParameter)
        {
            var result = new List<CommentResult>();
            var com = await ApiService.GetBySelectAsync(selectParameter.Start, selectParameter.Length,x=>x.Newsa.Id ==  Guid.Parse(selectParameter.SelectValue));
            foreach (var item in com.Datas)
            {
                var historys = await ApiService.GetAllOtherAsync<CommentHistory, CommentHistoryDTO>(x=>x.Comment.Id == item.Id);
                result.Add(new CommentResult()
                {
                    Comment = item,
                    Historys = historys.Datas
                }) ;
            }
            return result;
        }
    }
}
