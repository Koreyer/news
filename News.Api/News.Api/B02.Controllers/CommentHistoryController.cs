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
    public class CommentHistoryController:BaseController<CommentHistory, CommentHistoryDTO>
    {

        public CommentHistoryController(IApiService<CommentHistory, CommentHistoryDTO> apiService) : base(apiService) { }
        public override async Task<Result> AddAsync(CommentHistoryDTO apiEntity)
        {
            return await ApiService.AddAsync(apiEntity,x=>x.AppUser, x => x.Comment);
        }
    }
}
