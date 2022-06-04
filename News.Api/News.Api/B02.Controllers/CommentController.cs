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
    public class CommentController : BaseController<Comment, CommentDTO>
    {

        public CommentController(IApiService<Comment, CommentDTO> apiService) : base(apiService) { }

        public override Task<Result> AddAsync(CommentDTO apiEntity)
        {
            apiEntity.Time = DateTime.Now;
            return base.AddAsync(apiEntity);
        }
    }
}
